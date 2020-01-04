import { Observable } from "rxjs";

import { BaseApiService } from "./base.api.service";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class CustomersApiService extends BaseApiService {
  save(customerInfo: Customer) {
    return this.post('api/customers/', customerInfo);
  }
}

export class Customer {
  Login: string;
  Password: string;
  ConfirmPassword: string;
  CountryId: number;
  ProvinceId: number;
}
