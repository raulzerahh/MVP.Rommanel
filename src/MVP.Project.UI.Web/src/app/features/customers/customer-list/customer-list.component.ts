import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../core/services/customer.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  standalone: true,
  styleUrls: ['./customer-list.component.css'],
    imports: [CommonModule, RouterModule]

})
export class CustomerListComponent implements OnInit {
  customers: any[] = [];
  loading = true;
  error: string | null = null;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.customerService.getAll().subscribe({
      next: (data: any) => {
        this.customers = data;
        this.loading = false;
      },
      error: (err: any) => {
        this.error = 'Erro ao carregar clientes';
        this.loading = false;
      }
    });
  }
  deleteCustomer(id: number): void {
  if (confirm('Tem certeza que deseja excluir este cliente?')) {
    this.customerService.delete(id).subscribe({
      next: () => {
        this.customers = this.customers.filter(c => c.id !== id);
      },
      error: () => {
        this.error = 'Erro ao excluir o cliente';
      }
    });
  }
}

}
