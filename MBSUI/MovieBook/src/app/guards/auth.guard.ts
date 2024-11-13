import { Injectable } from '@angular/core';
import { CanActivate, CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { ToasrrService } from '../services/toasrr.service';

@Injectable({
  providedIn: 'root'
})
// export const authGuard: CanActivateFn = (route, state) => {
//   return true;
// };

export class authGuard implements CanActivate {
  constructor(
    private auth : AuthService,
    private router: Router,
    private toastservice: ToasrrService){

  }
  canActivate():boolean{
    if(this.auth.isLoggedIn()){
      return true
    }else{
      this.toastservice.showError("ERROR", "Please Login First!");
      this.router.navigate(['login'])
      return false;
    }
  }
};
