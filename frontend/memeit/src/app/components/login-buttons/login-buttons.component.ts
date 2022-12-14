import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from '../login-dialog/login-dialog.component';
import { RegisterDialogComponent } from '../register-dialog/register-dialog.component';

@Component({
  selector: 'login-buttons',
  templateUrl: './login-buttons.component.html',
  styleUrls: ['./login-buttons.component.scss'],
})
export class LoginButtonsComponent implements OnInit {

  constructor(private dialog: MatDialog) {

  }

  ngOnInit(): void {}

  openLoginDialog(): void {
    const loginDialogRef = this.dialog.open(LoginDialogComponent, {
      panelClass: 'no-padding-dialog',
      maxWidth: '100vw',
      maxHeight: '100vh',
    });
  }

  openRegisterDialog(): void {
    const registerDialogRef = this.dialog.open(RegisterDialogComponent, {
      panelClass: 'no-padding-dialog',
      maxWidth: '100vw',
    });
  }

}
