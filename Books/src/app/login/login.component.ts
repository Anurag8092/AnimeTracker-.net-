import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean | undefined;
  constructor(private _userService:UserService,private router:Router) { }
  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.pattern("^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$")]),
    pass: new FormControl("", [Validators.required, Validators.minLength(3), Validators.maxLength(15)])
  })

  authUser(): void{
    const credentials = {
      Email: this.loginForm.controls["email"].value,
      Password: this.loginForm.controls["pass"].value
    }
    this._userService.getLoggedUser(credentials).subscribe(res => {
      localStorage.setItem("jwt", res.token);
      localStorage.setItem("loggedUserId", res.user.userId);
      localStorage.setItem("loggedUserName", res.user.fullname);
      localStorage.setItem("loggedUserImage", res.user.profileImage);
      sessionStorage.setItem("isAdmin", res.user.isAdmin);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
      console.log(res);
    },
    err => {
      this.invalidLogin = true;
      console.log(err);
    })
  }

  ngOnInit(): void {
    if(localStorage.getItem("jwt")){
      alert("You are already logged in!");
      this.router.navigate(["/"])
    }

  }

}
