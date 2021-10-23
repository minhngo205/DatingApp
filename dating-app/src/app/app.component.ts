import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_model/User';
import { AccountsService } from './_services/accounts.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  constructor(public accountService: AccountsService) {}
  ngOnInit(): void {
    this.accountService.refreshToken()
  }
  // fetchUsers() {
  //   this.httpClient
  //     .get('https://localhost:5001/api/users')
  //     .subscribe((response) => {
  //       this.ListUser = response as User[];
  //       console.log(this.ListUser);
  //     });
  // }
}