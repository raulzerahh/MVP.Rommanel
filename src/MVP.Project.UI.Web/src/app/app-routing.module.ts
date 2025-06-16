import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'customers',
    pathMatch: 'full'
  },
  {
    path: 'customers',
    loadChildren: () => import('./components/customer-list/customer-list.module').then(m => m.CustomerListModule)
  },
  {
    path: 'customers/new',
    loadChildren: () => import('./components/customer-form/customer-form.module').then(m => m.CustomerFormModule)
  },
  {
    path: 'customers/edit/:id',
    loadChildren: () => import('./components/customer-form/customer-form.module').then(m => m.CustomerFormModule)
  },
  {
    path: 'customers/history/:id',
    loadChildren: () => import('./components/customer-history/customer-history.module').then(m => m.CustomerHistoryModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { } 