import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdminComponent } from './components/admin/admin.component';
import { UserComponent } from './components/user/user.component';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideToastr, ToastrModule } from 'ngx-toastr';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './helper/interceptors/token.interceptor';
import { PageFooterComponent } from './components/navbars/page-footer/page-footer.component';
import { PageHeaderComponent } from './components/navbars/page-header/page-header.component';
import { PageSideNavComponent } from './components/navbars/page-side-nav/page-side-nav.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from './material/material.module';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { BookingDetailsComponent } from './components/booking-details/booking-details.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    AdminComponent,
    UserComponent,
    PageFooterComponent,
    PageHeaderComponent,
    PageSideNavComponent,
    BookingDetailsComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule ,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
    // ToastrService,
    ToastrModule.forRoot({ positionClass: 'inline' }),
    MatNativeDateModule ,
    MatDatepickerModule,
  
  ],
  providers: [
    provideAnimations(), 
    AuthService,
    provideToastr({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true,}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
