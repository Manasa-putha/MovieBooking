import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helper/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { ToasrrService } from 'src/app/services/toasrr.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public signUpForm!: FormGroup;
  type: string = 'password';
  isText: boolean = false;
  eyeIcon:string = "fa-eye-slash"
  constructor(
    
    private fb : FormBuilder,
    private router: Router,
    private http:HttpClient,
    private auth:AuthService,
    private toastService:ToasrrService) { } 

  ngOnInit() {
    this.signUpForm = this.fb.group({
      // firstName:['', Validators.required],
      // lastName:['', Validators.required],
      userName:['', Validators.required],
      email:['', Validators.required],
      password:['', Validators.required],
      pincode:['',Validators.required],
      mobileNumber:['',Validators.required],
      // city:['',Validators.required],
      role: ['', Validators.required],

    })
  //   this.signUpForm.get('role')!.valueChanges.subscribe(role => {
  //     const kwAllowedControl = this.signUpForm.get('Kw_Allowed');
  //     if (role === 'Customer') {
  //       kwAllowedControl!.setValidators([Validators.required]);
  //     } else {
  //       kwAllowedControl!.clearValidators();
  //     }
  //     kwAllowedControl!.updateValueAndValidity();
  //   });
   }
  
  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = 'fa-eye' : this.eyeIcon = 'fa-eye-slash'
    this.isText ? this.type = 'text' : this.type = 'password'
  }

  onRegister() {
    if (this.signUpForm.valid) {
    
      const formValue = this.signUpForm.value as {
        userName: string;
        email: string;
        password: string;
        userType: string;
        alternativeNumber: string;
        pincode: string;
        city: string;
        mobileNumber: string;
      };
      console.log(this.signUpForm.value);
      let signUpObj = {
        
        ...formValue,
        role:'',
        token:''
        
      };
      this.auth.signUp(signUpObj)
      .subscribe({
        next:(res=>{
          console.log(res.message);
          this.toastService.showSuccess(res.message);
          this.signUpForm.reset();
          this.router.navigate(['dasboard']);
          // alert(res.message)
    
        }),
        error:(err=>{
          // alert(err?.error.message)
          this.toastService.showError(err?.error.message);
        })
      })
    } else {
      ValidateForm.validateAllFormFields(this.signUpForm); 
      // console.log("form is not valid");
      //logic for throwing error
      // alert("your form is invalid");
      this.toastService.showWarning("your form is invalid");
    }
  }

}
