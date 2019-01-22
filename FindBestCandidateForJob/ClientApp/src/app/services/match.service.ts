import { Injectable } from '@angular/core';
import { Job } from '../models/job';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MatchService {
  public jobs: Job[];
  constructor(private http: HttpClient) {
  }

  GetMatcher(): Observable<Job[]> {
    return this.http.get("/api/JobMatchApi/GetMatcher")
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof ErrorEvent) {
      let errMessage = '';
      try {
        errMessage = error.error.message;
      } catch (err) {
        errMessage = error.statusText;
      }
      return Observable.throw(errMessage);
    }
    return Observable.throw(error.error || 'ASP.NET Core server error');
  }

}
