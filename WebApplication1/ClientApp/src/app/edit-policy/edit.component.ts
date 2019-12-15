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


  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.apolicyForm = this.formBuilder.group({
      policyNumber: ['', Validators.required],
      policyHolder_id: ['', Validators.required],
      policyHolder_name: ['', Validators.required],
      policyHolder_age: ['', Validators.required],
      policyHolder_gender:['', Validators.required]
    });

  }
  // convenience getter for easy access to form fields
  get f() { return this.apolicyForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.apolicyForm.invalid) {
      return;
    }

    alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.apolicyForm.value))
  }
}
