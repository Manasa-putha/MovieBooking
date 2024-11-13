import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Movie, Show } from 'src/app/Models/models';
import { AuthService } from 'src/app/services/auth.service';
import { ToasrrService } from 'src/app/services/toasrr.service';
import { UserstoreService } from 'src/app/services/userstore.service';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  startDate: Date = new Date(); 
  endDate: Date = new Date(); 
  movies: Movie[] = [];
  availableShows: Show[] = [];
  selectedMovie: Movie | null = null;
  selectedShowtime: Show | null = null;
  numberOfSeats: number = 1;
  ticketId: string='';
  selectedDate: Date = new Date(); 
  selectedScreen: number | null = null;
  movieName: string="";
  screenNumber: number=1;
  showTimings: string='';
  totalAmount: number = 0;
  screenNumbers: number[] = [1, 2, 3];
  constructor(
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private toaster:ToasrrService, 
    private router:Router,
    private userStore:UserstoreService,) { }

  ngOnInit(): void {
    this.getMoviesByDate();
  }

  onDateChange(): void {
    this.getMoviesByDate();
  }


  getMoviesByDate(): void {
    console.log('Start Date:', this.startDate);
    console.log('End Date:', this.endDate);
    const formattedDate = this.selectedDate.toISOString().split('T')[0];
    this.authService.getMoviesByDate(this.startDate, this.endDate).subscribe(data => {
      this.movies = data;
      if (this.movies.length === 0) {
        this.toaster.showInfo("No movies available for the selected date. Please choose another date.", "Close");
      }
    
    }, error => {
        console.error('Error fetching movies by date:', error);
    
    }); 
}



  selectMovie(movie: Movie): void {
    this.selectedMovie = movie;
    const formattedDate = this.selectedDate.toISOString().split('T')[0];
    this.authService.getShowsByDate(this.startDate, this.endDate).subscribe(data => {
      this.availableShows = data.filter(show => show.movieId === movie.id);
    }, error => {
      console.error('Error fetching shows by date:', error);
    });
  }
  
  calculateTotalAmount(): void {
    if (this.selectedShowtime) {
      this.totalAmount = this.numberOfSeats * this.selectedShowtime.price;
      console.log( this.totalAmount );
    }
  }


  bookTicket(): void {
    if (this.selectedShowtime && this.numberOfSeats > 0 && this.numberOfSeats <= 10) {
      const bookingDetails = {
        ShowId: this.selectedShowtime.id,
        Seats: this.numberOfSeats,
        StartDate: this.startDate,  
        EndDate: this.endDate    
      };
      this.authService.bookTicket(bookingDetails).subscribe((response: any) => {
        this.ticketId = response.ticketId;
        this.movieName = response.movieName;
        this.screenNumber = response.screenNumber;
        this.showTimings = response.showTime;
        this.startDate = response.startDate;
        this.endDate = response.endDate;
        this.toaster.showInfo(`Booking Confirmed! Ticket ID: ${this.ticketId}`, 'Close');
        this.resetSelection();
        const tokenPayload = this.authService.decodedToken();
        this.userStore.setFullNameForStore(tokenPayload.name);
        this.userStore.setRoleForStore(tokenPayload.role);
      console.log(tokenPayload.role);
      if(tokenPayload.role === 'Admin'){
        localStorage.setItem('role','Admin');
       // this.service.setAdminValue(true);
        this.router.navigateByUrl('booking-details');
      }
    else{
      this.router.navigateByUrl('/booking');
      
    }}, error => {
        this.toaster.showInfo(`Booking Failed! ${error.error}`, 'Close');
      });
    } else {
      this.toaster.showInfo('Please select a valid showtime and number of seats should be less than 10 ,.', 'Close'
      );
    }
  }
  onMovieAdded() {
    this.getMoviesByDate();
  }
  resetSelection(): void {
    this.selectedMovie = null;
    this.selectedShowtime = null;
    this.numberOfSeats = 1;
  }
}
