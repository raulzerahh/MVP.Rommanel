import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../../core/services/customer.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  standalone: true,
  styleUrls: ['./customer-form.component.css'],
  imports: [ReactiveFormsModule, CommonModule],

})
export class CustomerFormComponent implements OnInit {
  customerForm: FormGroup;
  isEditMode = false;
  customerId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.customerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.customerId = Number(this.route.snapshot.paramMap.get('id'));

    if (this.customerId) {
      this.isEditMode = true;
      this.customerService.getById(this.customerId.toString()).subscribe((customer) => {
        this.customerForm.patchValue(customer);
      });
    }
  }

  onSubmit(): void {
    if (this.customerForm.invalid) return;

    const customerData = this.customerForm.value;

    if (this.isEditMode) {
      this.customerService.update(this.customerId!, customerData).subscribe(() => {
        this.router.navigate(['/customers']);
      });
    } else {
      this.customerService.create(customerData).subscribe(() => {
        this.router.navigate(['/customers']);
      });
    }
  }
}
