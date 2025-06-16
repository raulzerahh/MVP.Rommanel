import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { CustomerViewModel } from '../../viewmodels/customer.viewmodel';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html'
})
export class CustomerListComponent implements OnInit {
  customers: CustomerViewModel[] = [];
  loading = false;
  error: string | null = null;

  constructor(
    private router: Router,
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.loading = true;
    this.error = null;

    this.customerService.getAll().subscribe({
      next: (data) => {
        this.customers = data;
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Erro ao carregar lista de clientes.';
        this.loading = false;
        console.error('Error loading customers:', error);
      }
    });
  }

  create(): void {
    this.router.navigate(['/customers/new']);
  }

  edit(id: string): void {
    this.router.navigate(['/customers/edit', id]);
  }

  viewHistory(id: string): void {
    this.router.navigate(['/customers/history', id]);
  }

  delete(id: string): void {
    if (confirm('Tem certeza que deseja excluir este cliente?')) {
      this.customerService.delete(id).subscribe({
        next: () => {
          this.loadCustomers();
        },
        error: (error) => {
          this.error = 'Erro ao excluir cliente.';
          console.error('Error deleting customer:', error);
        }
      });
    }
  }

  isCNPJ(documentNumber: string): boolean {
    return documentNumber.replace(/\D/g, '').length === 14;
  }
} 