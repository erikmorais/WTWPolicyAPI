import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddPolicyComponent } from "./add-policy/add-policy.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { EditPolicyComponent } from "./edit-policy/edit-policy.component";
import { EditComponent } from './edit-policy/edit.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'addpolicy', component: AddPolicyComponent },
  { path: 'edit', component: EditComponent },
 // { path: 'edit/:policyNumber', component: EditComponent },
  { path: 'editpolicy/:policyNumber', component: EditPolicyComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
