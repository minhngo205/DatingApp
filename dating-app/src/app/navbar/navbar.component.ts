import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../_model/UserLogin';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: UserLogin = new UserLogin();

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  login(){
    console.log(this.user);
    // this.httpClient.post("https://localhost:5001/api/Accounts/login",)
  }
}
