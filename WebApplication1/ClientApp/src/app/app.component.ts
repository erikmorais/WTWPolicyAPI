import { Component } from '@angular/core';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  navbarCollapsed = true;

  title = 'WTW Policy';
  subtitle = " Test CRUD Web API - by Erik Morais";

  toggleNavbarCollapse() {
    this.navbarCollapsed = !this.navbarCollapsed;
  }
}

