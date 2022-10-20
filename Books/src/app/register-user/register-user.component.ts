import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css'],
})
export class RegisterUserComponent {
  emailExist: boolean = false;
  emailid: string = '';
  isValid: boolean | undefined;
  constructor(
    private _registrationservice: UserService,
    private router: Router
  ) {}

  signUpForm = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.pattern('^[a-zA-Z_]+( [a-zA-Z_]+)*$'),
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.pattern(
        '^[a-z0-9]+(.[_a-z0-9]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,15})$'
      ),
    ]),
    pass: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
    cpass: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
     profImageUrl: new FormControl(''),
  });

  public onSubmit(): void {
    const data = {
      fullName: this.signUpForm.controls['name'].value,
      email: this.signUpForm.controls['email'].value,
      password: this.signUpForm.controls['cpass'].value,
      profileImage: this.signUpForm.controls['profImageUrl'].value
    };
    if (this.signUpForm.controls['pass'].value == this.signUpForm.controls['cpass'].value) {
      this.isValid = true;
    }

    this.emailid = this.signUpForm.controls['email'].value;

    if (this.signUpForm.valid && this.isValid) {
      this._registrationservice.createUser(data).subscribe((res) => {
        console.log(res);
        if (res == null) this.emailExist = true;
        else {
          this.emailExist = false;
          this.router.navigate(['/login']);
        }
      });
    }

    if (!this.signUpForm.valid && !this.isValid)
      alert('This is not a valid form');
  }

  ngOnInit(): void {
    if(localStorage.getItem("jwt")){
      alert("You need to log out first!");
      this.router.navigate(["/"])
    }

  }
}
