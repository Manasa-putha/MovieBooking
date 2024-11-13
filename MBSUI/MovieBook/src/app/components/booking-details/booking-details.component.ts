import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  tickets: any[] = [];

  constructor(private http: HttpClient,private authService:AuthService) { }


  ngOnInit(): void {
    this.getUserTickets();
  }

  getUserTickets(): void {
    this.authService.getUserTickets().subscribe(data => {
      this.tickets = data;
    });
  }
}
