import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { Member } from '../_model/Member';
import { AccountsService } from '../_services/accounts.service';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profile: Member = new Member();
  constructor(
    private membersService: MembersService,
    private accountsService: AccountsService
  ) {}
  ngOnInit(): void {
    let username = '';
    this.accountsService.currentUser$.subscribe(
      (account) => (username = account.username),
      (error) => console.log(error)
    );
    this.membersService.getMemberByUsername(username).subscribe(
      (member) => (this.profile = member),
      (error) => console.log(error)
    );
  }

  submit(){
    this.membersService.UpdateProfile(this.profile).subscribe(
      // (Response) => (),
      (error) => console.log(error)
    )
  }

}
