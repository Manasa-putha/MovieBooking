import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

export interface NavigationItem  {
  value: string;
  link: string;
}
@Component({
  selector: 'app-page-side-nav',
  templateUrl: './page-side-nav.component.html',
  styleUrls: ['./page-side-nav.component.css']
})
export class PageSideNavComponent {
  panelName: string = '';
  navItems: NavigationItem[] = [];

  constructor(private authService: AuthService, private router: Router) {
  }
  ngOnInit() {
    this.checkAuthenticationStatus();

    this.authService.userStatus.subscribe(status => {
      this.updateNavigation(status);
    });
  }

  private checkAuthenticationStatus() {
    if (this.authService.isLoggedIn()) {
      const role = localStorage.getItem('role');
      this.updateNavigation('loggedIn');
    } else {
      this.updateNavigation('loggedOff');
    }
  }

  private updateNavigation(status: string) {
    if (status === 'loggedIn') {
      const role = localStorage.getItem('role');
      if (role === 'Admin') {
        this.panelName = 'Admin Panel';
        this.navItems = [
      
          { value: 'Movies', link: '/dashboard' },  
          { value: 'Add Movies', link: '/admin' },  
          {value: 'Booking Details',link:'/booking-details'}
        ];
      } else if (role === 'User') {
        this.panelName = 'Customer Panel';
        this.navItems = [
          { value: 'Movies', link: '/dashboard' }, 
          {value: 'Booking Details',link:'/booking'}
        ];
      }
    } else if (status === 'loggedOff') {
      this.panelName = 'Auth Panel';
      this.router.navigateByUrl('/login');
      this.navItems = [];
    }
}
}
