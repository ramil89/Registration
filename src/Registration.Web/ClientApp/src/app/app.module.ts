import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CredentialsComponent } from './registration/credentials/credentials.component';
import { RegistrationComponent } from './registration/registration.component';
import { LocationComponent } from './registration/location/location.component';
import { LocationsApiService } from './services/locations.service';
import { CustomersApiService } from './services/customers.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CredentialsComponent,
    LocationComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'registration', component: RegistrationComponent },
    ])
  ],
  providers: [
    LocationsApiService,
    CustomersApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
