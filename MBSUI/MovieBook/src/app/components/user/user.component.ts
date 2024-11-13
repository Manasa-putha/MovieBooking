import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  tickets: any[] = [];

  constructor(private http: HttpClient,private authService:AuthService) { }

  ngOnInit(): void {
    this.getUserTickets();
  }

  getUserTickets(): void {
    this.authService.getUserTickets().subscribe(data => {
      this.tickets = data;
    }, error => {
      console.error('Error fetching tickets:', error);
    });
  }

}
