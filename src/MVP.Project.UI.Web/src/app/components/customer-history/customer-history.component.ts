import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-history',
  templateUrl: './customer-history.component.html'
})
export class CustomerHistoryComponent implements OnInit {
  customerId: string;
  history: any[] = [];
  loading = false;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService
  ) {
    this.customerId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.loadHistory();
  }

  loadHistory(): void {
    this.loading = true;
    this.error = null;

    this.customerService.getHistory(this.customerId).subscribe({
      next: (data) => {
        this.history = data;
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Erro ao carregar histórico do cliente.';
        this.loading = false;
        console.error('Error loading customer history:', error);
      }
    });
  }

  back(): void {
    this.router.navigate(['/customers']);
  }
} 