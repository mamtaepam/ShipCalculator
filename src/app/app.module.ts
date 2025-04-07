import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductSelectorComponent } from './product-selector/product-selector.component';
import { CountrySelectorComponent } from './country-selector/country-selector.component';
import { ShippingSummaryComponent } from './shipping-summary/shipping-summary.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ShippingService } from './shipping.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductSelectorComponent,
    CountrySelectorComponent,
    ShippingSummaryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ShippingService],
  // providers: [
  //   provideClientHydration(withEventReplay())
  // ],
  bootstrap: [AppComponent]
})
export class AppModule { }
