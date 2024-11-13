import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, Subject } from 'rxjs';
import { Movie, Show } from '../Models/models';
import { TokenApiModel } from '../Models/token-api.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  
  private baseUrl: string = 'https://localhost:7002/api/Auth/';
  private baseUrl1: string = 'https://localhost:7002/api/Show/';
  private baseUrl2: string = 'https://localhost:7002/api/Movie/';
   userStatus: Subject<string> = new Subject();
 // userStatus: BehaviorSubject<string> = new BehaviorSubject<string>(this.getUserStatus());
  private userPayload:any;
  private jwtHelper = new JwtHelperService();
  constructor(
    // private jwt: JwtHelperService,
    private http:HttpClient,
     private router: Router) { 
      this.userPayload = this.decodedToken();
  }
  private getUserStatus(): string {
    return localStorage.getItem('userStatus') || 'loggedOff';
  }
  signUp(userobj:any): Observable<any>{
    return this.http.post<any>(`${this.baseUrl}register`,userobj)
  }
  login(userobj:any): Observable<any>{
    return this.http.post<any>(`${this.baseUrl}login`,userobj)
  }
  logOut() {
    // localStorage.removeItem('access_token');
    // // this.userInfo = null;
    // this.userStatus.next('loggedOff');
    // this.userStateService.updateTokens(0);
    this.userStatus.next('loggedOff');
    localStorage.clear();
    this.userStatus.next('loggedOff');
    this.router.navigate(['login'])
  }

  // signOut(){
  //   localStorage.clear();
  //   this.userStatus.next('loggedOff');
  //   this.router.navigate(['login'])
  // }
  

  storeToken(tokenValue: string){
    localStorage.setItem('token', tokenValue)
  }
  storeRefreshToken(tokenValue: string){
    localStorage.setItem('refreshToken', tokenValue)
  }

  getToken(){
    return localStorage.getItem('token')
  }
  getRefreshToken(){
    return localStorage.getItem('refreshToken')
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (token) {
      // Check if the token is expired
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }

  getfullNameFromToken(){
    if(this.userPayload)
    return this.userPayload.name;
  }

  getRoleFromToken(){
    if(this.userPayload)
    return this.userPayload.role;
  }

  renewToken(tokenApi : TokenApiModel){
    return this.http.post<any>(`${this.baseUrl}refresh`, tokenApi)
  }
  addMovie(movie: Movie): Observable<Movie> {
    return this.http.post<Movie>(`${this.baseUrl2}movies`, movie);
  }

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.baseUrl2}movies`);
  }

  // getShowsByDate(date: string): Observable<Show[]> {
  //   return this.http.get<Show[]>(`${this.baseUrl1}shows?date=${date}`);
  // }
  getShowsByMovieId(movieId: number): Observable<Show[]> {
    return this.http.get<Show[]>(`${this.baseUrl2}movies/${movieId}`);
  }


  checkShowConflict(show: Show): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl1}shows/conflict`, show);
  }
 
  bookTicket(bookingDetails: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl1}book`, bookingDetails);
  }
  getShowsByDate(startDate: Date, endDate: Date): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl1}shows/date`,{
      params: {
        startDate: startDate.toISOString(),
        endDate: endDate.toISOString()
      }
    });
  }
  // getMoviesByDate(date: string): Observable<Movie[]> {
  //   return this.http.get<Movie[]>(`${this.baseUrl2}movies/date/${date}`);
  // }
  getMoviesByDate(startDate: Date, endDate: Date): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl2}movies/date`, {
      params: {
        startDate: startDate.toISOString(),
        endDate: endDate.toISOString()
      }
    });
  }
  getShowsByMovieAndDate(movieId: number, date: string): Observable<Show[]> {
    return this.http.get<Show[]>(`${this.baseUrl1}shows/movie/${movieId}/date/${date}`);
  }
  getUserTickets(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl1}user-tickets`);
  }


}
