import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerListModule } from './components/customer-list/customer-list.module';
import { CustomerFormModule } from './components/customer-form/customer-form.module';
import { CustomerHistoryModule } from './components/customer-history/customer-history.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    CustomerListModule,
    CustomerFormModule,
    CustomerHistoryModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { } 