import { Observable } from "rxjs";

import { BaseApiService } from "./base.api.service";
import { Injectable } from "@angular/core";
import { LocationItem } from "./models/location-item.model";

@Injectable({
  providedIn: 'root'
})
export class LocationsApiService extends BaseApiService {
  loadLocations(locationId?: number) {
    return this.get<LocationItem[]>('api/countries/' + (locationId || ''));
  }
}
