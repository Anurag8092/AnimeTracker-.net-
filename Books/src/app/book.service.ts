import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  webapiurl: string = "http://localhost:7630/api/Books"
  webapiurl1: string = "http://localhost:7630/api/ReadingStatus"
  webapiurl2: string = "http://localhost:7630/api/ReadingStatus/bookrating"
  constructor(private _client: HttpClient) {}

  getBookDetails(): Observable<any> {
    return this._client
      .get(this.webapiurl)
      .pipe(catchError(this.handleError));
  }

  putReadingStatus(data: any): Observable<any>{
    return this._client
    .put(this.webapiurl1, data, {responseType: "text"})
    .pipe(catchError(this.handleError));
  }

  postAddBook(data: any): Observable<any>{
    return this._client
    .post(this.webapiurl1, data, {responseType: "text"})
    .pipe(catchError(this.handleError));
  }

  postNewBook(data: any): Observable<any>{
    return this._client
    .post(this.webapiurl, data, {responseType: "text"})
    .pipe(catchError(this.handleError));
  }

  getBookById(id: number): Observable<any>{
    return this._client
    .get(this.webapiurl + "/" + id)
    .pipe(catchError(this.handleError));
  }

  putBookRating(data: any): Observable<any>{
    return this._client
    .put(this.webapiurl2 + "/" + data, {responseType: "text"})
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
