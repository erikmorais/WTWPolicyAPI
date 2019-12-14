import { Policy } from "./models/policy";
import { PolicyHolder, Gender } from "./models/policyHolder";
export const allPolicy: Policy[] = [
  { policyNumber: 1, policyHolderId: 0, policyHolder: { name: "erik", age: 40, gender: Gender.M, id: 0 } },
  { policyNumber: 2, policyHolderId: 1, policyHolder: { name: "luv", age: 26, gender: Gender.F, id: 1 } },
  { policyNumber: 3, policyHolderId: 2, policyHolder: { name: "jhon", age: 50, gender: Gender.M, id: 2 }}
  ];

