import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { LoggerService } from './logger.service';
import { Policy } from '../models/policy';
import { PolicyTrackerError } from '../models/policyTrackerError';
import { allPolicy } from '../data';

@Injectable()
export class DataService {

  //const httpOptions = {
  //  headers: new HttpHeaders({
  //    'Content-Type': 'application/json',
  //    'Authorization': 'my-auth-token'
  //  })
  //}
  constructor(private loggerService: LoggerService,
              private http: HttpClient) { }


  private handleError(error: HttpErrorResponse): Observable<PolicyTrackerError> {
    let dataError = new PolicyTrackerError();
    dataError.errorNumber = 100;
    dataError.message = error.statusText;
    dataError.friendlyMessage = 'An error occurred retrieving data.';
    return throwError(dataError);
  }  

  getPolicyByPolicyNumber(policyNumber:number): Observable<Policy | PolicyTrackerError> {
    return this.http.get<Policy>('/api/policy/' + policyNumber)
      .pipe( 
        catchError(this.handleError)
      );
  }

  getAllPolicy(): Observable<Policy[] | PolicyTrackerError> {
    return this.http.get<Policy[]>('/api/policy')
      .pipe(
        catchError(this.handleError)
      );
  }

  //////// Save methods //////////

  /** POST: add a new policy to the database */
  addPolicy(policy: Policy): Observable<Policy> {

    let body: string = JSON.stringify(policy);
    let params = new HttpParams().set('params', body);
    console.log(params);
    let headers = new HttpHeaders().set('Content-type', 'application/json');
   // let header =new  RequestOptions({});
    policy.policyHolderId = policy.policyHolder.id;
    return this.http.post<Policy>('/api/policy/add', policy, {
      headers: headers,
      params
    });

    //  , {
    //  headers: headers,
    //  params
    //})
    //  .pipe(
    //    catchError(error => {
    //      return throwError("something went wrong!");
    //    }
    //    ));

    return this.http.post<Policy>('/api/policy/add', JSON.stringify(policy), {
      headers: { 'Content-Type': 'application/json; charset=utf-8' },
    });
      //.pipe(
      //  catchError(this.handleError)
      //);
  }

  /** DELETE: delete the hero from the server */
  deletePolicy(policyNumber: number): Observable<{}> {
    // DELETE api/policy/42
    return this.http.delete('/api/policy/' + policyNumber )
      .pipe(
        catchError(this.handleError)
      );
  }

  /** PUT: update the hero on the server. Returns the updated hero upon success. */
  updatePolicy(policy: Policy): Observable<Policy | PolicyTrackerError> {

    //httpOptions.headers =
    //  httpOptions.headers.set('Authorization', 'my-new-auth-token');
    return this.http.put<Policy>('/api/policy/', policy)
      .pipe(
        catchError(this.handleError)
      );
  }
}

