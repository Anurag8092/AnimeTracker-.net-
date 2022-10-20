import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ForumService } from '../forum.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-query-details',
  templateUrl: './query-details.component.html',
  styleUrls: ['./query-details.component.css']
})
export class QueryDetailsComponent implements OnInit {
queryDet: any;
ansDet: any;
commDet: any;
invalidAnswer: boolean | undefined;

  constructor(private _forumService: ForumService,private router:Router, private route: ActivatedRoute, private jwtHelper: JwtHelperService) { }

  answerForm = new FormGroup({
    answer: new FormControl("", [Validators.required]),
  })

  commentForm = new FormGroup({
    comment: new FormControl("", [Validators.required]),
  })

  isUserAuthenticated(){
    const token = localStorage.getItem("jwt");
    if(token && !this.jwtHelper.isTokenExpired(token) && localStorage.getItem("loggedUserId")) return true;
    else return false;
  }


  postAnswer(id: number): void{
    const data = {
      queryId: id,
      userId: (Number)(localStorage.getItem("loggedUserId")),
      answer: this.answerForm.controls["answer"].value,
      date: new Date().toLocaleString()

    }
    if(!this.answerForm.valid){
      this.invalidAnswer = true;
    }
      else{
 // console.log(data);
 this._forumService.postAnswer(data).subscribe(res => {
  // console.log(res)
  this.invalidAnswer = false;
  alert("Answer Posted");
  location.reload();
}, err => {
  this.invalidAnswer = true;
  console.log(err);
})
    }

  }

  postComment(id: number){
    const data = {
      answerId: id,
      userId: (Number)(localStorage.getItem("loggedUserId")),
      comment: this.commentForm.controls["comment"].value,
      date: new Date().toLocaleString()
    }
      this._forumService.postComment(data).subscribe(res => {alert("Comment Posted")
        location.reload();
        // console.log(res);
      },err => {
        console.log(err);
      })


  }

  ngOnInit(): void {

    this.route.paramMap.subscribe((params) => {
      var id = (Number)(params.get("id"));
      this._forumService.getQueryById(id).subscribe(res => {
        this.queryDet = res[0];
        console.log(this.queryDet);
      });
      this._forumService.getAnsByQueryId(id).subscribe(res => {
        this.ansDet = res;
        console.log(this.ansDet);
      });
      this._forumService.getCommByAnsId(id).subscribe(res => {
        this.commDet = res;
        console.log(this.commDet);
    });
    })


  }

}
