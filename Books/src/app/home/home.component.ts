import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BookService } from '../book.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  constructor(private _bookservice: BookService, private _router: Router, private jwtHelper: JwtHelperService) { }


  books: any;
  query: string = "";

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


  statusForm = new FormGroup({
    status: new FormControl(''),
  });

  search(searchData: any){
    this.query = searchData;
  }



  public addToList(id: number) {
    const token = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      const data = {
        userId: Number(localStorage.getItem('loggedUserId')),
        bookID: id,
        rating: 0,
      };
      this._bookservice.postAddBook(data).subscribe(
        (res) => {
          localStorage.setItem("status", res);
          alert(res);
        },
        (err) => {
          alert(err);
        }
      );
    } else {
      alert('You need to be logged in');
      this._router.navigate(['/login']);
    }
  }

  ngOnInit(): void {
    this._bookservice.getBookDetails().subscribe(
      (res) => {
        this.books = res;
        console.log(res);
      },
      (err) => {
        console.log(err);
      }
    );
  }

}
