import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Movie, Show } from 'src/app/Models/models';
import { AuthService } from 'src/app/services/auth.service';
import { Route ,Router} from '@angular/router';
import { ToasrrService } from 'src/app/services/toasrr.service';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  @Output() movieAdded = new EventEmitter<void>();
  movieForm: FormGroup;

  shows: FormArray;
  movies: Movie[] = [];
  currentShows: Show[] = [];
  selectedDate!: string;

  constructor(private fb: FormBuilder,
     private authService: AuthService,
      private router:Router,
      private toaster:ToasrrService) {
    this.movieForm = this.fb.group({
      // Movie_Id: ['', Validators.required],
      MovieName: ['', Validators.required],
      Genre: ['', Validators.required],
      Director: ['', Validators.required],
      Description: ['', Validators.required],
      ImageUrl: ['', Validators.required], 
      Shows: this.fb.array([this.createShowGroup()])
    });

    this.shows = this.movieForm.get('Shows') as FormArray;
  }

  ngOnInit() {
    this.loadMovies();
  }

  createShowGroup(): FormGroup {
    return this.fb.group({
      Show_Id: ['', Validators.required],
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required],
      Timings: ['', Validators.required],
      No_of_seats: [0, Validators.required],
      Price: [0, Validators.required],
      Screen_Number: [0, [Validators.required, Validators.min(1), Validators.max(3)]], 
      Movie_Id: ['', Validators.required]
    });
  }

  addShow() {
    this.shows.push(this.createShowGroup());
  }

  loadMovies() {
    this.authService.getMovies().subscribe(movies => {
      this.movies = movies;
    });
  }

  // loadShowsByDate() {
  //   if (this.selectedDate) {
  //     this.authService.getShowsByDate(this.selectedDate).subscribe(shows => {
  //       this.currentShows = shows;
  //     });
  //   }
  // }

  checkShowConflict(show: Show): Observable<boolean> {
    return this.authService.checkShowConflict(show);
  }
  onSubmit() {
    const newMovie: Movie = this.movieForm.value;
    console.log('Submitting movie:', newMovie);
    console.log('Form values before submission:', this.movieForm.value);

    this.authService.addMovie(newMovie).subscribe(
      movie => {
        this.movies.push(movie);
        this.movieForm.reset();
        this.shows.clear();
        this.shows.push(this.createShowGroup());
        this.movieAdded.emit();
        this.router.navigateByUrl("dashboard");
      },
      error => {
        console.error('Error adding movie:', error);
        this.toaster.showInfo(`Error adding movie: ${error.message || error}`, 'Close');
      }
    );
  }
  
  // checkShowConflict(show: Show): void {
  //   this.authService.checkShowConflict(show).subscribe((conflict: boolean) => {
  //     if (conflict) {
  //       this.toaster.showInfo('There is a conflict with the show timings on the selected screen.', 'Close');
  //     } else {
  //       this.toaster.showInfo('No conflict detected. You can proceed with the booking.', 'Close');
  //       this.router.navigateByUrl("dashboard")
  //     }
  //   }, error => {
  //     this.toaster.showInfo(`Error checking show conflict: ${error.error}`, 'Close');
  //   });
  // }
  
  
}
