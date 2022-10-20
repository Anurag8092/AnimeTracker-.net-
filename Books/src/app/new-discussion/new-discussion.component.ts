import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ForumService } from '../forum.service';

@Component({
  selector: 'app-new-discussion',
  templateUrl: './new-discussion.component.html',
  styleUrls: ['./new-discussion.component.css']
})
export class NewDiscussionComponent implements OnInit {

  invalidEntry: boolean | undefined;

  constructor(private _forumService: ForumService,private router:Router) { }
  queryForm = new FormGroup({
    query: new FormControl("", [Validators.required]),
  })

  postQuery(): void{
    const data = {
      userId: Number(localStorage.getItem("loggedUserId")),
      fullname: localStorage.getItem("loggedUserName"),
      profileImage: localStorage.getItem("loggedUserImage"),
      query: this.queryForm.controls["query"].value,
      date: new Date().toLocaleString()
    }
    if(!this.queryForm.valid){
      this.invalidEntry = true;
    }
    else{
// console.log(data);
this._forumService.postQuery(data).subscribe(res => {
  // console.log(res);
  this.invalidEntry = false;
  alert("New Query Posted");
  this.router.navigate(["forum"]);
}, err => {
  this.invalidEntry = true;
  console.log(err);
})
    }

  }

  ngOnInit(): void {
  }

}
