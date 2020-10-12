import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  
  title = 'E-Commerce application';
  // products: Array<any>;
  products: IProduct[];

  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/products").subscribe( (response: any) => {
      console.log(response);
      this.products = response;
    }, (error) => {
      console.log(error);
    });
  }
  
}
