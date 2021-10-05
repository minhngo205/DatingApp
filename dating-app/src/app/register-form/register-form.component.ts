import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { UserRegister } from '../_model/User';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  @Input() userRegis: UserRegister = new UserRegister();
  @Output() cancelRegis = new EventEmitter();
  constructor(private accountsService:AccountsService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountsService
      .registerService(this.userRegis)
      .subscribe((response) => this.cancel());
  }
  cancel(){
    this.cancelRegis.emit(false);
  }
}