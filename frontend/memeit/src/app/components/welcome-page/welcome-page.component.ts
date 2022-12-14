import { ViewportScroller } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.scss'],
})
export class WelcomePageComponent implements OnInit {
  constructor(private scroller: ViewportScroller) {
    this.scroller.setOffset([0,100]);
  }

  ngOnInit(): void {}

  scrollToMemeUpload(): void {
    this.scroller.scrollToAnchor('meme-upload-page');
  }
}
