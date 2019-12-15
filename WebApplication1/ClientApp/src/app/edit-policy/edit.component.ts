import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Policy } from '../models/policy';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../core/data.service';
import { LoggerService } from '../core/logger.service';
import { PolicyTrackerError } from '../models/policyTrackerError';
import { PolicyHolder } from '../models/policyHolder';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styles: []
})

export class EditComponent implements OnInit {
  apolicyForm: FormGroup;
  submitted = false;
  newPolicy: Policy;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private dataService: DataService,
    private loggerService: LoggerService) { }

  ngOnInit() {
    this.apolicyForm = this.formBuilder.group({
      policyNumber: ['', Validators.required],
      policyHolder_id: ['', Validators.required],
      policyHolder_name: ['', Validators.required],
      policyHolder_age: ['', Validators.required],
      policyHolder_gender:['', Validators.required]
    });

    this.newPolicy = new Policy();
  }
  // convenience getter for easy access to form fields
  get f() { return this.apolicyForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.apolicyForm.invalid) {
      return;
    }

    let policy: Policy = new Policy();
    policy.policyHolder = new PolicyHolder();
    policy.policyNumber = Number(this.apolicyForm.controls['policyNumber'].value);
    policy.policyHolder.name = this.apolicyForm.controls['policyHolder_name'].value;
    policy.policyHolderId = Number(this.apolicyForm.controls['policyHolder_id'].value);
    policy.policyHolder.id = Number(this.apolicyForm.controls['policyHolder_id'].value);
    policy.policyHolder.age = Number(this.apolicyForm.controls['policyHolder_age'].value);
    policy.policyHolder.gender = this.apolicyForm.controls['policyHolder_gender'].value;

    this.dataService.addPolicy(policy)
      .subscribe((data: Policy) => {
        // this.notificationService.showSuccess("Policy number:" + data.policyNumber.toString(), "New Policy added");
      },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("update done")
      );
    console.log(policy);


    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.apolicyForm.value))
  }
}
