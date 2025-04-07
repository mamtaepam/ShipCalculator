import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface ShippingRequest
{
  countryId:number;
  quantity:number;
  prodDetails: Products;
}



export interface Products
{
  quantities:number[];
  productIds: number[];
}

export interface ShippingResponse
{
  subtotal:number;
  taxes:number;
  totalAmountDue:number;
  shipping:number;

}

@Injectable({
  providedIn: 'root'
})

export class ShippingService {

  private apiUrl = 'https://localhost:44359/api/ShipCalculator/calculate'; 
  constructor(private http:HttpClient) { }
  CalculateShipping(request:ShippingRequest):Observable<ShippingResponse>
  {
    console.log("service", request);
    return this.http.post<ShippingResponse>(this.apiUrl,request);
  }
}
