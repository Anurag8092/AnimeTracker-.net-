import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { User } from './User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
webapiurl: string = "http://localhost:7630/api/Users";
webapiurl1: string = "http://localhost:7630/api/ReadingStatus";
  constructor(private _client: HttpClient) {}

  public getById(id: number): Observable<User[]> {
    return this._client.get<User[]>(this.webapiurl + '/' + id)
    .pipe(catchError(this.handleError));
  }
    //LogIn User
    getLoggedUser(credentials: any): Observable<any> {
      return this._client
        .post(this.webapiurl + '/loginuser', credentials)
        .pipe(catchError(this.handleError));
    }

    createUser(credentials: any): Observable<any>{
      return this._client
      .post(this.webapiurl, credentials)
      .pipe(catchError(this.handleError));
    }

    getReadingStatus(id: number): Observable<any>{
      return this._client.get<any>(this.webapiurl1 + '/' + id)
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
