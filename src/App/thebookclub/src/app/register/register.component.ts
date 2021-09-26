import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  constructor(private formBuilder: FormBuilder, private userService: UserService,private router: Router) {
    this.registerForm = this.formBuilder.group({
      emailAddress: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', Validators.required]
  });
   }

  ngOnInit(): void {
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
        return;
    }

    this.loading = true;
    this.userService.register(this.f.emailAddress.value, this.f.firstName.value, this.f.lastName.value,this.f.password.value)
        .subscribe(
            data => {
                this.router.navigate(['/login']);
            },
            error => {
                this.error = error;
                this.loading = false;
            });
}
}
