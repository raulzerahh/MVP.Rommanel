import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { CustomerViewModel } from '../viewmodels/customer.viewmodel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = `${environment.apiUrl}/customers`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<CustomerViewModel[]> {
    return this.http.get<CustomerViewModel[]>(this.apiUrl);
  }

  getById(id: string): Observable<CustomerViewModel> {
    return this.http.get<CustomerViewModel>(`${this.apiUrl}/${id}`);
  }

  create(customer: CustomerViewModel): Observable<CustomerViewModel> {
    return this.http.post<CustomerViewModel>(this.apiUrl, customer);
  }

  update(id: string, customer: CustomerViewModel): Observable<CustomerViewModel> {
    return this.http.put<CustomerViewModel>(`${this.apiUrl}/${id}`, customer);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getHistory(id: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${id}/history`);
  }
} 