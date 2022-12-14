import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent implements OnInit {
 currentYear : number;
  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    this.currentYear = new Date().getFullYear();
    iconRegistry.addSvgIcon(
      'instagram',
      sanitizer.bypassSecurityTrustResourceUrl('/assets/icons/instagram.svg')
    );
    iconRegistry.addSvgIcon(
      'twitch',
      sanitizer.bypassSecurityTrustResourceUrl('/assets/icons/twitch.svg')
    );
    iconRegistry.addSvgIcon(
      'facebook',
      sanitizer.bypassSecurityTrustResourceUrl('/assets/icons/facebook.svg')
    );

  }

  ngOnInit(): void {}
}
