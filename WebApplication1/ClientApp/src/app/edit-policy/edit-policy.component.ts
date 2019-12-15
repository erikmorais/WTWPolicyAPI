import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Policy } from '../models/policy';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../core/data.service';
import { LoggerService } from '../core/logger.service';
import { PolicyTrackerError } from '../models/policyTrackerError';
import { PolicyHolder } from '../models/policyHolder';

@Component({
  selector: 'app-edit-policy',
  templateUrl: './edit-policy.component.html',
  styles: []
})
export class EditPolicyComponent implements OnInit {
  apolicyForm: FormGroup;
  submitted = false;
  selectedPolicy: Policy;
  revertPolicy: string;

  constructor(private cdRef: ChangeDetectorRef, 
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private loggerService: LoggerService,
    private dataService: DataService) { }

  ngOnInit() {
    this.apolicyForm = this.formBuilder.group({
      policyNumber: ['', Validators.required],
      policyHolder_id: ['', Validators.required],
      policyHolder_name: ['', Validators.required],
      policyHolder_age: ['', Validators.required],
      policyHolder_gender: ['', Validators.required]
    });

   // this.revertPolicy = Policy[];
    let policyNumber: number = parseInt(this.route.snapshot.params['policyNumber']);

    this.dataService.getPolicyByPolicyNumber(policyNumber)
      .subscribe(
        (data: Policy) => {
          this.selectedPolicy = data;
          this.selectedPolicy.policyHolder = data.policyHolder;

          this.revertPolicy = JSON.stringify(this.selectedPolicy);
        },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("done")
      );
  }
  // convenience getter for easy access to form fields
  get f() { return this.apolicyForm.controls; }

  revert(): void {
    this.selectedPolicy = JSON.parse(this.revertPolicy); 
    //this.cdRef.detectChanges();
  }

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

    //this.selectedPolicy.policyHolderId = this.selectedPolicy.policyHolder.id;
    this.dataService.updatePolicy(policy)
      .subscribe((data: Policy) => {
        // replace the hero in the heroes list with update from server
        this.selectedPolicy = data;
      },
        (err: PolicyTrackerError) => console.log(err.friendlyMessage),
        () => this.loggerService.log("update done")
      );

    console.log(policy);


    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.apolicyForm.value))
  }
}
