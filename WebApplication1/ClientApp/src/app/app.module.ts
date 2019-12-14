import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { FormsModule } from '@angular/forms';

import { CoreModule } from './core/core.module';

import { AppComponent } from "./app.component";
import { AddPolicyComponent } from '../app/add-policy/add-policy.component';
import { EditPolicyComponent } from '../app/edit-policy/edit-policy.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations:
    [ AppComponent,
      AddPolicyComponent,
      EditPolicyComponent,
      DashboardComponent
    ],
  imports:
    [ HttpClientModule,
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      CoreModule
      ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
