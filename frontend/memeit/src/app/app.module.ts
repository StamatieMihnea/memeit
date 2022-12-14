import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/main/app.component';

import { NavbarComponent } from './components/navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LoginDialogComponent } from './components/login-dialog/login-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RegisterDialogComponent } from './components/register-dialog/register-dialog.component';
import { DialogTemplateComponent } from './components/dialog-template/dialog-template.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { LoginButtonsComponent } from './components/login-buttons/login-buttons.component';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';
import { MemeUploadPageComponent } from './components/meme-upload-page/meme-upload-page.component';
import { MostViewedPageComponent } from './components/most-viewed-page/most-viewed-page.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginDialogComponent,
    RegisterDialogComponent,
    DialogTemplateComponent,
    LandingPageComponent,
    LoginButtonsComponent,
    WelcomePageComponent,
    MemeUploadPageComponent,
    MostViewedPageComponent,
    FooterComponent,
  ],
  imports: [
    AppRoutingModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSidenavModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
