import { Observable } from "rxjs";

import { BaseApiService } from "./base.api.service";
import { Injectable } from "@angular/core";
import { Customer } from "./models/customer.model";

@Injectable({
  providedIn: 'root'
})
export class CustomersApiService extends BaseApiService {
  save(customerInfo: Customer) {
    return this.post('api/customers/', customerInfo);
  }
}
