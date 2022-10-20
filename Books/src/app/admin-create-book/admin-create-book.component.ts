import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from '../book.service';

@Component({
  selector: 'app-admin-create-book',
  templateUrl: './admin-create-book.component.html',
  styleUrls: ['./admin-create-book.component.css']
})
export class AdminCreateBookComponent implements OnInit {
  invalidEntry: boolean | undefined;
  constructor(private _bookService:BookService,private router:Router) { }
  bookForm = new FormGroup({
    bName: new FormControl("", [Validators.required, Validators.minLength(3)]),
    aCreator: new FormControl("", [Validators.required, Validators.minLength(3)]),
    genre: new FormControl("", [Validators.required, Validators.minLength(3)]),
    bDesc: new FormControl("", [Validators.required, Validators.minLength(10)]),
    bImg: new FormControl("", [Validators.required, Validators.minLength(10)])
  })


  saveBook(): void{
    const data = {
      bookName: this.bookForm.controls["bName"].value,
      authorName: this.bookForm.controls["aCreator"].value,
      genre: this.bookForm.controls["genre"].value,
      description: this.bookForm.controls["bDesc"].value,
      bookImage: this.bookForm.controls["bImg"].value
    }
    if(!this.bookForm.valid && !this.invalidEntry){
      this.invalidEntry = true;
  }
    else{
      this._bookService.postNewBook(data).subscribe(res => {
        this.invalidEntry = false;
        alert("Anime Record Created")
        console.log(res);
      },
      err => {
        this.invalidEntry = true;
        console.log(err);
      })
    }

  }

  ngOnInit(): void {
    const admin = JSON.parse(sessionStorage.getItem("isAdmin") || "");
    if(admin != true){
      alert("You are not an admin");
      this.router.navigate(["/"]);
    }

  }

}
