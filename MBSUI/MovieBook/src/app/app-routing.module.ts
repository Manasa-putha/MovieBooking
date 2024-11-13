import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { BookingDetailsComponent } from './components/booking-details/booking-details.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { UserComponent } from './components/user/user.component';
import { adminGuard } from './guards/admin.guard';
import { authGuard, } from './guards/auth.guard';

const routes: Routes = [
  {path:'',component:DashboardComponent },
  {path:'login',component:LoginComponent},
  {path:'signup',component:RegisterComponent},
  {path:'admin',component:AdminComponent,canActivate: [authGuard,adminGuard]},
  {path:'dashboard',component:DashboardComponent},
 // { path: 'movie-details/:id/:date', component: DashboardComponent,canActivate: [authGuard,adminGuard] },
  {path:'booking-details',component:BookingDetailsComponent,canActivate: [authGuard,adminGuard]},
  {path:'booking',component:UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
