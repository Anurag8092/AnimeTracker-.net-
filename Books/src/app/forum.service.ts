import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForumService {
webapiurl: string = "http://localhost:7630/api/Forum";

  constructor(private _client: HttpClient) { }

  getQueries(): Observable<any>{
    return this._client.get<any>(this.webapiurl + '/')
    .pipe(catchError(this.handleError));
  }

  postQuery(data: any): Observable<any> {
    return this._client
      .post(this.webapiurl, data)
      .pipe(catchError(this.handleError));
  }

  postAnswer(data: any): Observable<any> {
    return this._client
      .post(this.webapiurl + '/answer', data)
      .pipe(catchError(this.handleError));
  }

  postComment(data: any): Observable<any>{
    return this._client
    .post(this.webapiurl + "/comment", data)
    .pipe(catchError(this.handleError));
  }


  getQueryById(id: number): Observable<any>{
    return this._client
    .get<any>(this.webapiurl + '/' + id)
    .pipe(catchError(this.handleError));
  }

  getAnsByQueryId(id: number): Observable<any>{
    return this._client.get<any>(this.webapiurl + '/answer/' + id)
    .pipe(catchError(this.handleError));
  }

  getCommByAnsId(id: number): Observable<any>{
    return this._client.get<any>(this.webapiurl + '/comment/' + id)
    .pipe(catchError(this.handleError));
  }


  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.log(error);
    } else {
      console.log(error.error);
    }
    return throwError('Something bad happened; please try again later.');
  }
}
