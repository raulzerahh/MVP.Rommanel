import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { CustomerViewModel } from '../../models/customer.view-model';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent implements OnInit {
  form: FormGroup;
  isEditMode = false;
  loading = false;
  error = '';

  constructor(
    private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email]],
      documentNumber: ['', [Validators.required, Validators.maxLength(20)]],
      birthDate: ['', [Validators.required]],
      phone: ['', [Validators.maxLength(20)]],
      stateInscription: ['', [Validators.maxLength(50), Validators.pattern('^\\d+$')]],
      streetAddress: ['', [Validators.maxLength(200)]],
      buildingNumber: ['', [Validators.maxLength(20)]],
      secondaryAddress: ['', [Validators.maxLength(200)]],
      neighborhood: ['', [Validators.maxLength(100)]],
      zipCode: ['', [Validators.maxLength(20)]],
      city: ['', [Validators.maxLength(100)]],
      state: ['', [Validators.maxLength(2)]],
      active: [true]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.loadCustomer(id);
    }
  }

  loadCustomer(id: string): void {
    this.loading = true;
    this.customerService.getById(id).subscribe({
      next: (customer) => {
        this.form.patchValue(customer);
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Erro ao carregar cliente. Por favor, tente novamente.';
        this.loading = false;
        console.error('Erro ao carregar cliente:', err);
      }
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      this.loading = true;
      const customer: CustomerViewModel = this.form.value;

      const request = this.isEditMode
        ? this.customerService.update(customer)
        : this.customerService.create(customer);

      request.subscribe({
        next: () => {
          this.router.navigate(['/customers']);
        },
        error: (err) => {
          this.error = 'Erro ao salvar cliente. Por favor, tente novamente.';
          this.loading = false;
          console.error('Erro ao salvar cliente:', err);
        }
      });
    }
  }

  isCNPJ(): boolean {
    const document = this.form.get('documentNumber')?.value;
    if (!document) return false;
    return document.replace(/\D/g, '').length === 14;
  }

  cancel(): void {
    this.router.navigate(['/customers']);
  }
} 