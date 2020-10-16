import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  title = 'E-Commerce application';

  constructor() {}
  
  ngOnInit(): void {

  }
  
}
