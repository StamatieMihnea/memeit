import jwt_decode from 'jwt-decode';
import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { apiURL } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  public currentUser: string | null;
  constructor(private http: HttpClient) {
    this.currentUser = this.getCurrentUser();
  }

  public loginUser(_username:string, _password:string): void {
    // this.http.post<any>(`${apiURL}/login`, {"username": _username, "password":_password} ).subscribe((response) => {
    //   localStorage.setItem('jwt', response.token);
    //   console.log(response);
    //   this.currentUser = this.getCurrentUser();
    // }, (error) => {console.log(error);
    // });
    localStorage.setItem('user', 'mihnea');
  }

  private getCurrentUser(): string | null {
    // var token = localStorage.getItem('jwt');
    // if (token == null) return null;
    // return JSON.parse(jwt_decode(token));
    // return null;
    var username = localStorage.getItem('user');
    return username;
  }

  public logout(): void {
    localStorage.clear();
    this.currentUser = null;
  }
}
