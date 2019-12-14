import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddPolicyComponent } from "./add-policy/add-policy.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { EditPolicyComponent } from "./edit-policy/edit-policy.component";

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'addpolicy', component: AddPolicyComponent },
  { path: 'editpolicy/:policyNumber', component: EditPolicyComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
