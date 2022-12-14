import { Component, OnInit } from '@angular/core';
// import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.scss'],
})
export class LoginDialogComponent implements OnInit {

  // username: string;
  // password: string;

  constructor(
    // private loginService: LoginService
    ) {
    // this.username = '';
    // this.password = '';
  }

  ngOnInit(): void {}

  // loginUser(): void {
  //   this.loginService.loginUser(this.username, this.password);
  // }
}
