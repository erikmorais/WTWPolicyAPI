import { Component, OnInit } from '@angular/core';
import { Policy } from "../models/policy";
import { DataService } from '../core/data.service';
import { ActivatedRoute } from '@angular/router';
import { LoggerService } from '../core/logger.service';
import { PolicyTrackerError } from '../models/policyTrackerError';
import { PolicyHolder } from '../models/policyHolder';
import { NgForm } from '@angular/forms';
import { ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-add-policy',
  templateUrl: './add-policy.component.html',
  styles: []
})
export class AddPolicyComponent implements OnInit {

  genders: any;
  newPolicy: Policy;
  constructor(private route: ActivatedRoute,
    private dataService: DataService,
    private loggerService: LoggerService) { }

  ngOnInit() {
    this.newPolicy = new Policy();
  }

  formDto(formValues: NgForm): Policy {
    let policy: Policy = new Policy();
    policy.policyHolder = new PolicyHolder();
    policy.policyNumber = Number(formValues['policyNumber']);
    policy.policyHolder.name = formValues['policyHolder_name'];
    policy.policyHolderId = Number(formValues['policyHolder_id']);
    policy.policyHolder.id = Number(formValues['policyHolder_id']);
    policy.policyHolder.age = Number(formValues['policyHolder_age']);
    policy.policyHolder.gender = formValues['policyHolder_gender'];
    return policy;
  }
  addPolicy(formValues: NgForm): void {

    let addPolicy: Policy = this.formDto(formValues);

    this.dataService.addPolicy(addPolicy)
      .subscribe((data: Policy) => {
       // this.notificationService.showSuccess("Policy number:" + data.policyNumber.toString(), "New Policy added");
      },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("update done")
      );
    console.log(addPolicy);
  }


}
