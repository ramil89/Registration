import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from '../../helpers/must-match.validator';

@Component({
  selector: 'credentials-step',
  templateUrl: './credentials.component.html',
})
export class CredentialsComponent implements OnInit {
  registerForm: FormGroup;
  submitted: boolean;
  @Output() dataSubmitted = new EventEmitter<CredentialsData>();

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern(/([a-zA-Z]+\d+|\d+[a-zA-Z]+)[0-9a-zA-Z]*/), Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      acceptTerms: [false, Validators.requiredTrue]
    }, {
      validator: MustMatch('password', 'confirmPassword')
    });
    this.submitted = false;
  }

  get f() { return this.registerForm.controls; }

  processCredentials() {

    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.dataSubmitted.emit(
      new CredentialsData(
        this.f.email.value,
        this.f.password.value,
        this.f.confirmPassword.value));
  }
}

export class CredentialsData {
  constructor(login: string, password: string, confirmPassword: string) {
    this.Login = login;
    this.Password = password;
    this.ConfirmPassword = confirmPassword;
  }

  Login: string;
  Password: string;
  ConfirmPassword: string;
}
