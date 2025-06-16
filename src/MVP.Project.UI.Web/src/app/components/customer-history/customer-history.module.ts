import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CustomerHistoryComponent } from './customer-history.component';

const routes: Routes = [
  {
    path: '',
    component: CustomerHistoryComponent
  }
];

@NgModule({
  declarations: [
    CustomerHistoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class CustomerHistoryModule { } 