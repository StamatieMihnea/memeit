import { Component, OnInit } from '@angular/core';
import { DrawerService } from 'src/app/services/drawer.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {

  constructor(private drawerService: DrawerService) {}

  ngOnInit(): void {}

  toggleDrawer(): void{
    this.drawerService.toggle();
  }
}
