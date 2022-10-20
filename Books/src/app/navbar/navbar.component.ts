import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _router: Router, private jwtHelper: JwtHelperService) { }

  isUserAuthenticated(){
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token) && localStorage.getItem("loggedUserId")) return true;
    else return false;
  }

  getLoggedUserData(){
    if(localStorage.getItem("loggedUserId"))
      this._router.navigate(["user-profile", localStorage.getItem("loggedUserId")]);
      else
      alert("You are not logged in");
  }

  logOut(){
    localStorage.removeItem("jwt");
    localStorage.removeItem("loggedUserId");
    sessionStorage.removeItem("isAdmin");
    location.reload();
  }



  ngOnInit(): void {
  }

}
