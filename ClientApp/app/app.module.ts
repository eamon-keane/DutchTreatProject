import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http"

import { AppComponent } from './app.component';
import { ProductList } from "./shop/productList.component";
import { DataService } from './shared/dataService';
import { Cart } from './shop/cart.component';

@NgModule({
    declarations: [
        AppComponent,
        ProductList,
        Cart

    ],
    imports: [
        BrowserModule,
        HttpClientModule
    ],
    providers: [
        DataService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
