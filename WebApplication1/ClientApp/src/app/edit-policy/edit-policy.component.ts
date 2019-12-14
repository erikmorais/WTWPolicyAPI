import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Policy } from "../models/policy";
import { DataService } from '../core/data.service';
import { LoggerService } from '../core/logger.service';
import { Observable } from 'rxjs';
import { PolicyTrackerError } from '../models/policyTrackerError';

@Component({
  selector: 'app-edit-policy',
  templateUrl: './edit-policy.component.html',
  styles: []
})
export class EditPolicyComponent implements OnInit {

  selectedPolicy: Policy ;

  constructor(private route: ActivatedRoute,
              private dataService: DataService,
              private loggerService: LoggerService) { }

  ngOnInit() {
    let policyNumber: number = parseInt(this.route.snapshot.params['policyNumber']);

    this.dataService.getPolicyByPolicyNumber(policyNumber)
      .subscribe(
        (data: Policy) => {
          this.selectedPolicy = data;
          this.selectedPolicy.policyHolder = data.policyHolder;
        },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("done")
      );
  }


  //saveChanges(): void {
  //  let policy: Policy = this.selectedPolicy;

  //  console.log(policy);
  //  console.warn('Save policy not yet implemented.');
  //}


  saveChanges():void {
    if (this.selectedPolicy) {
      this.selectedPolicy.policyHolderId = this.selectedPolicy.policyHolder.id;
      this.dataService.updatePolicy(this.selectedPolicy)
        .subscribe((data: Policy) => {
          // replace the hero in the heroes list with update from server
          this.selectedPolicy = data;
        },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("update done")

      );

      //this.selectedPolicy = undefined;
    }
  }

}
