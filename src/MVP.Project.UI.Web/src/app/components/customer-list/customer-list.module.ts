import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CustomerListComponent } from './customer-list.component';

const routes: Routes = [
  {
    path: '',
    component: CustomerListComponent
  }
];

@NgModule({
  declarations: [
    CustomerListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class CustomerListModule { } 