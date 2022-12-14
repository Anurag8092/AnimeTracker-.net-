import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";

@Injectable()
export class AuthGuard implements CanActivate{

  constructor(private router: Router, private jwtHelper: JwtHelperService){

  }

  canActivate(){
    const token = localStorage.getItem("jwt");

    if(token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    else{
      alert("Please LogIn to Continue!");
      this.router.navigate(["login"]);
      return false;
    }

  }
}
