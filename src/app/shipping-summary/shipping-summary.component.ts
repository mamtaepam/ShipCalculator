import { ChangeDetectionStrategy, Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { ShippingResponse } from '../shipping.service';

export interface ShippingData
{
  Subtotal:number;
  Taxes:number;
  TotalAmountDue:number;
  Shipping:number;

}

@Component({
  selector: 'app-shipping-summary',
  standalone: false,
  templateUrl: './shipping-summary.component.html',
  styleUrl: './shipping-summary.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})


 export class ShippingSummaryComponent
 {
  

  @Input() response: ShippingResponse | null = null;
  
  
}








