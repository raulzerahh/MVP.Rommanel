import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { CustomerFormComponent } from './customer-form.component';

const routes: Routes = [
  { path: '', component: CustomerFormComponent }
];

@NgModule({
  declarations: [
    CustomerFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ]
})
export class CustomerFormModule { } 