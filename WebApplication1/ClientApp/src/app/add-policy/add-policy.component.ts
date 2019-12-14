import { Component, OnInit } from '@angular/core';
import { Policy } from "../models/policy";

@Component({
  selector: 'app-add-policy',
  templateUrl: './add-policy.component.html',
  styles: []
})
export class AddPolicyComponent implements OnInit {

  genders: any;
  constructor() { }

  ngOnInit() {
    this.getGenders();
  }

  savePolicy(formValues: any): void {
    let newPolicy: Policy = <Policy>formValues;
    // newPolicy.policyNumber = 0;
    console.log(newPolicy);
    console.warn('Save new book not yet implemented.');
  }

  getGenders(): void {
    this.genders = [
        {
          "Id": "M",
          "Name": "Male"
      },
      {
        "Id": "F",
        "Name": "Female"
      },  

    ]

  }

}
