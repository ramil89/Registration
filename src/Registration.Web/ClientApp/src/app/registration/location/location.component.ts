import { Component, OnInit, EventEmitter, Output, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from '../../helpers/must-match.validator';
import { HttpClient } from '@angular/common/http';
import { LocationsApiService, LocationItem } from '../../services/locations.service';

@Component({
  selector: 'location-step',
  templateUrl: './location.component.html',
})
export class LocationComponent implements OnInit {
  registerForm: FormGroup;
  submitted: boolean;
  countries: LocationItem[];
  provinces: LocationItem[];
  @Output() dataSubmitted = new EventEmitter<LocationsData>();

  constructor(
    private formBuilder: FormBuilder,
    private locationsService: LocationsApiService) {
  }

  ngOnInit(): void {
    console.log('location init')

    this.registerForm = this.formBuilder.group({
      countryId: ['', [Validators.required]],
      provinceId: ['', [Validators.required]],
    });
    this.submitted = false;

    this.locationsService.loadLocations().subscribe(result => {
      this.countries = result;
      console.log(result);
    }, (error) => {
      console.log(error);
    });
  }

  countryChanged($event) {
    this.f['provinceId'].setValue(null);

    this.locationsService.loadLocations($event.target.value).subscribe(result => {
      this.provinces = result;
      console.log(this.provinces);
    }, (error) => {
      console.log(error);
    });
  }

  processLocations() {
    this.submitted = true;
    console.log(this.registerForm.invalid)

    if (this.registerForm.invalid) {
      return;
    }

    this.dataSubmitted.emit(
      new LocationsData(
        this.f.countryId.value,
        this.f.provinceId.value));
  }

  get f() { return this.registerForm.controls; }
}

export class LocationsData {
  constructor(countryId: number, provinceId: number) {
    this.CountryId = countryId;
    this.ProvinceId = provinceId;
  }

  CountryId: number;
  ProvinceId: number;
}
