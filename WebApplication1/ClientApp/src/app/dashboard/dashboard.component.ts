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
  selectedPolicy: Policy;

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


 selectPolicy(policy:Policy) {
   this.selectedPolicy = policy;
  }


  deletePolicy(policyNumber: number): void {

    this.dataService.deletePolicy(policyNumber)
      .subscribe((data: Policy) => {
        var idx = this.allPolicy.findIndex(a => a.policyNumber == policyNumber);
        this.allPolicy.splice(idx, 1);
        this.selectedPolicy = null;
        },
          (err: PolicyTrackerError) => console.log(err.friendlyMessage),
          () => this.loggerService.log("delete done")
        );
  }

}
