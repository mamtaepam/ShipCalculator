import { Component } from '@angular/core';
import { ShippingRequest, ShippingResponse, ShippingService } from './shipping.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})

export class AppComponent {
  countryId: number=0; 
  shippingResponse: ShippingResponse   | null = null;  


  onCountrySelected(countryId: number): void {
    this.countryId = countryId;
  }


  onShippingResponse(response: ShippingResponse): void {
    this.shippingResponse = response;
    console.log('Received app componenet Response:', this.shippingResponse); 
  }
}






 
