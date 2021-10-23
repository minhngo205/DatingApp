import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../_model/Member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = 'https://localhost:5001/api/Users';

  constructor(private httpClient: HttpClient) { }

  /**
   * getMembers
   */
  public getMembers() :Observable<Member[]> {
    return this.httpClient.get<Member[]>(this.baseUrl)
  }

  /**
   * getMemberByUsername
  */
  public getMemberByUsername(username:string): Observable<Member> {
    return this.httpClient.get<Member>(`${this.baseUrl}/${username}`)
  }
}
