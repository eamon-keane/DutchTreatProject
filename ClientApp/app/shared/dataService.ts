import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs"
import { map } from "rxjs/operators";
import { Product } from './product';
import { Order, OrderItem } from './order';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) {

    }

    private token: string = "";

    private tokenExpiration: Date;



    public order: Order = new Order();

    public products: Product[] = [];

    public get loginRequired(): boolean {
        return this.token.length == 0 || this.tokenExpiration > new Date();
    }

    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .pipe(
                map((data: any[]) => {
                this.products = data;
                return true;

            }));
    }

    public AddToOrder(newProduct: Product) {

        let item: OrderItem = this.order.items.find(i => i.productId == newProduct.id)


        if (item) {

            item.quantity ++

        } else {
           
            item = new OrderItem();
            item.productId = newProduct.id;
            item.productArtist = newProduct.artist;
            item.productArtId = newProduct.artId;
            item.productCategory = newProduct.category;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.unitPrice = newProduct.price;
            item.quantity = 1;

            this.order.items.push(item);
        }


        

    }
}