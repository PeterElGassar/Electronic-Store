import { IProduct } from './../../shared/models/Product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
@Input() product : IProduct;
  constructor() { }

  ngOnInit() {
  }

  

}
