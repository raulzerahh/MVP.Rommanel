import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-history',
  templateUrl: './customer-history.component.html',
  standalone: true,
  styleUrls: ['./customer-history.component.css'],
    imports: [CommonModule]

})
export class CustomerHistoryComponent implements OnInit {
  customerId: number | null = null;
  logs: string[] = [];

  ngOnInit(): void {
    this.customerId = Number(this.route.snapshot.paramMap.get('id'));

    // Simulação de histórico
    this.logs = [
      `Cliente ${this.customerId} criado em 01/01/2024`,
      `Telefone atualizado em 10/02/2024`,
      `Email alterado em 15/03/2024`
    ];
  }

  constructor(private route: ActivatedRoute) {}
}
