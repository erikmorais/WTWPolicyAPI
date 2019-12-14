import { Injectable, ErrorHandler } from '@angular/core';
import { PolicyTrackerError } from '../models/policyTrackerError'

@Injectable()
export class BookTrackerErrorHandlerService implements ErrorHandler {

  handleError(error: any): void {
    let customError: PolicyTrackerError = new PolicyTrackerError();
    customError.errorNumber = 200;
    customError.message = (<Error>error).message;
    customError.friendlyMessage = 'An error occurred. Please try again.';

    console.log(customError);    
  }

  constructor() { }
}
