import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-country-selector',
  standalone: false,
  templateUrl: './country-selector.component.html',
  styleUrl: './country-selector.component.css'
})
export class CountrySelectorComponent {

  countries=[
    { id: 1, name: 'Canada', taxRate: 5, baseShippingCost: 25 },
    { id: 2, name: 'USA', taxRate: 0, baseShippingCost: 20 }
  ];

  @Output() countrySelected = new EventEmitter<number>();

  onCountryChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;  
    const countryId = parseInt(selectElement.value, 10);  

    if (!isNaN(countryId)) {  
      this.countrySelected.emit(countryId);  
    }
  }
  
}
