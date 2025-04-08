import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ShippingRequest, ShippingResponse, ShippingService } from '../shipping.service';
import { response } from 'express';
import { request } from 'http';

@Component({
  selector: 'app-product-selector',
  standalone: false,
  templateUrl: './product-selector.component.html',
  styleUrl: './product-selector.component.css'
})
export class ProductSelectorComponent {

  @Input() selectedCountryId: number=1; 

  @Output() shippingResponse = new EventEmitter<ShippingResponse>(); 
  quantities: { [key: number]: number } = {};

  products=[

    {id:1,name: "Product A",quantities:0},
    {id:2,name: "Product B",quantities:0},
    {id:3,name: "Product C",quantities:0}

  ];

  

  constructor(private shippingService:ShippingService){}


  submitShippingRequest() {

    const productIds = this.products.filter(p => this.quantities[p.id] > 0).map(p => p.id);
    const quantities = this.products.filter(p => this.quantities[p.id] > 0).map(p => this.quantities[p.id]);
    console.log("initial", quantities);

    
    const request: ShippingRequest = {
      countryId: this.selectedCountryId, 
      quantity: quantities.reduce((sum, qty) => sum + qty, 0),  
      prodDetails: {
        productIds: productIds, 
        quantities: quantities 
        
      }
      
    };


    this.shippingService.CalculateShipping(request).subscribe(
      (response) => {
        console.log('Shipping Response:', response);
        this.shippingResponse.emit(response);  
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}
