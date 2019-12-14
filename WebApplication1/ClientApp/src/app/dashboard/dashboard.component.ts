import { Component, OnInit, Version, VERSION } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable, from } from 'rxjs';
import { DataService } from '../core/data.service';
import { LoggerService } from '../core/logger.service';
import { Policy } from "../models/policy"
import { PolicyTrackerError } from '../models/policyTrackerError';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: []
})
export class DashboardComponent implements OnInit {

  allPolicy: Policy[];

  constructor(private loggerService: LoggerService,
    private dataService: DataService,
    private title: Title) {
    this.loggerService.log('Creating the dashboard!');
  }

  ngOnInit() {
  //  this.allPolicy = this.dataService.getAllPolicy();
    this.dataService.getAllPolicy()
      .subscribe(
        (data: Policy[]) => this.allPolicy = data,
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log('All done getting readers!')
      );


    this.loggerService.log('Done with dashboard initialization');

   // throw new Error('Ugly technical error!');
  }

  private async getAuthorRecommendationAsync(readerID: number): Promise<void> {
    //let author: string = await this.dataService.getAuthorRecommendation(readerID);
    //this.loggerService.log(author);
  }

  deleteBook(bookID: number): void {
    console.warn(`Delete book not yet implemented (bookID: ${bookID}).`);
  }

  deletePolicy(policyNumber: number): void {

    this.dataService.deletePolicy(policyNumber)
      .subscribe((data: Policy) => {
        var idx = this.allPolicy.findIndex(a => a.policyNumber == policyNumber);
        this.allPolicy.splice(idx, 1);
        },
          (err: PolicyTrackerError) => console.log(err.friendlyMessage),
          () => this.loggerService.log("delete done")
        );
  }

}
