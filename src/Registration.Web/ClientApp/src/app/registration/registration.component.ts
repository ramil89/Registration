import { Component, OnInit, EventEmitter, Output, ViewChild, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CredentialsComponent, CredentialsData } from './credentials/credentials.component';
import { LocationsData } from './location/location.component';
import { Customer } from '../services/models/customer.model';
import { CustomersApiService } from '../services/customers.service';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
})
export class RegistrationComponent implements OnInit {
  private step: 'credentials' | 'location';
  private customerInfo: Customer;

  ngOnInit(): void {
    this.step = 'credentials';
    this.customerInfo = new Customer();
  }

  constructor(private customersService: CustomersApiService) {

  }

  onCredentialsProcessed($event: CredentialsData) {
    this.step = 'location';

    this.customerInfo.Login = $event.Login;
    this.customerInfo.Password = $event.Password;
    this.customerInfo.ConfirmPassword = $event.ConfirmPassword;
  }

  onLocationProcessed($event: LocationsData) {
    this.customerInfo.CountryId = $event.CountryId;
    this.customerInfo.ProvinceId = $event.ProvinceId;

    this.customersService.save(this.customerInfo).subscribe((result) => {
      alert('Customer created');
      console.log(result);
    },
      (error) => {
        alert('Error occurred');
        console.log(error);
      }
    );
  }
}
