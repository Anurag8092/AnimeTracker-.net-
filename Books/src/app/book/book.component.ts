import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
book: any;
bookRating: any;
  constructor(
    private _bookservice: BookService,
    private jwtHelper: JwtHelperService,
    private _router: Router,
    private _route: ActivatedRoute
  ) {}

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
          console.log(err);
        }
      );
    } else {
      alert('You need to be logged in');
      this._router.navigate(['/login']);
    }
  }


  ngOnInit(): void {
    this._route.paramMap.subscribe((params) => {

     this._bookservice.putBookRating(Number(params.get("id"))).subscribe(res => {
      console.log(res);
      this.bookRating = res.rating;
     })
     this._bookservice.getBookById(Number(params.get("id"))).subscribe(res => {
      this.book = res;
     //  console.log(this.book.bookName);
    })
    })
  }

}
