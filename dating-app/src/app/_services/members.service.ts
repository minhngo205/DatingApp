import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../_model/Member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
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

  public UpdateProfile(profile: Member){
    return this.httpClient.put(this.baseUrl,profile,this.httpOptions)
  }
}
