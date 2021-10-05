import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../_model/UserLogin';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: UserLogin = new UserLogin();

  constructor(public accountsService:AccountsService) { }

  ngOnInit() { }

  login(){
    this.accountsService.loginService(this.user).subscribe(
      (response) => {
        console.log(response)
      },
      (error) => {
        console.log(error)
      }
    )
  }
}