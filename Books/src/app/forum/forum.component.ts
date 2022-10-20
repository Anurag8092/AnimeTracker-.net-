import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ForumService } from '../forum.service';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {
allQueries: any;
  constructor(private _forumService: ForumService,private router:Router) { }

  ngOnInit(): void {
    this._forumService.getQueries().subscribe(res => {
      console.log(res)
      this.allQueries = res;
    })
  }

}
