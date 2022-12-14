import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { DrawerService } from 'src/app/services/drawer.service';

@Component({
  selector: 'landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements AfterViewInit {
  @ViewChild('drawer') private drawer!: MatDrawer;

  constructor( private drawerService: DrawerService) { }

  ngAfterViewInit(): void {
    this.drawerService.setDrawer(this.drawer);
  }

}
