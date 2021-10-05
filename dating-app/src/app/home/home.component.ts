import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../_model/User';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isRegisterMode = false;
  user: UserRegister = new UserRegister();
  constructor(private accountsService:AccountsService) { }

  ngOnInit(): void {
  }

  cancelRegisterMode(event: boolean) {
    this.isRegisterMode = event;
  }
}
