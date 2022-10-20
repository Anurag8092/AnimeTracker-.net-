import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute,  Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BookService } from '../book.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
currentUser: any;
userBookList: any;
  constructor( private _bookservice: BookService, private route: ActivatedRoute, private _route: Router, private _userService: UserService, private jwtHelper: JwtHelperService,) { }

  updateStatusForm = new FormGroup({
    status: new FormControl(''),
  });

  updateRatingForm = new FormGroup({
    rating: new FormControl(''),
  });

    public updateReadingStatus(id: number) {
    const token = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      const data = {
        userId: Number(localStorage.getItem('loggedUserId')),
        bookID: id,
        status: this.updateStatusForm.controls['status'].value,
        rating: this.updateRatingForm.controls['rating'].value,
      };
      this._bookservice.putReadingStatus(data).subscribe(
        (res : any) => {
          console.log(res);
          location.reload();
        },
        (err: any) => {
          console.log(err);
        }
      );
    } else {
      alert('You need to be logged in');
      this._route.navigate(['/login']);
    }
  }

  getUserData(id: number): void{
    this._userService.getById(id).subscribe(
      (user: any) => {
        console.log(user);
        this.currentUser = user;
      }
    )
  }

  readingStatus(id: number): void{
    this._userService.getReadingStatus(id).subscribe(
      (stats: any) => {
        console.log(stats);
        this.userBookList = stats;
      }
    )
  }

  isAdmin(){
      if(this.currentUser.isAdmin == true) return true;
      else return false;

  }


  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      if(localStorage.getItem("loggedUserId") === params.get("id")){
        this.getUserData(Number(params.get("id")));
      this.readingStatus(Number(params.get("id")));
      }
      else{
        this._route.navigate(["/"]);
        alert("Unauthorized access");
      }
    })

  }

}
