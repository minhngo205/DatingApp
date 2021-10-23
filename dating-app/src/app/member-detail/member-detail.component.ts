import { Component, Input, OnInit } from '@angular/core';
import { Member } from '../_model/Member';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  @Input() memberDetail: Member = new Member()
  constructor() { }

  ngOnInit(): void {
  }

}
