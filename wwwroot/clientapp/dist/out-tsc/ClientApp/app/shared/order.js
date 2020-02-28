import * as _ from "lodash";
export class Order {
    constructor() {
        this.items = new Array();
    }
    get subtotal() {
        return _.sum(_.map(this.items, i => i.unitPrice * i.quantity));
    }
}
export class OrderItem {
}
//# sourceMappingURL=order.js.map