import { Component, OnInit } from '@angular/core';
import { Member } from '../_model/Member';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  members:Member[] = []
  constructor(private memberService:MembersService) { }

  ngOnInit(): void {
    this.getFetchedMembers()
  }

  /**
   * getFetchedMembers
   */
  public getFetchedMembers() {
    this.memberService.getMembers().subscribe(
      (response) => {this.members = response},
      (error) => {console.error(error)}
    )
  }
}