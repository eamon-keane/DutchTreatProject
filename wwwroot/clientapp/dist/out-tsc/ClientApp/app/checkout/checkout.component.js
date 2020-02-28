import { __decorate } from "tslib";
import { Component } from "@angular/core";
let Checkout = class Checkout {
    constructor(data) {
        this.data = data;
    }
    onCheckout() {
        // TODO
        alert("Doing checkout");
    }
};
Checkout = __decorate([
    Component({
        selector: "checkout",
        templateUrl: "checkout.component.html",
        styleUrls: ['checkout.component.css']
    })
], Checkout);
export { Checkout };
//# sourceMappingURL=checkout.component.js.map