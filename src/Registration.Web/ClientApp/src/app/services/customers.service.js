"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var base_api_service_1 = require("./base.api.service");
var CustomersApiService = /** @class */ (function (_super) {
    __extends(CustomersApiService, _super);
    function CustomersApiService() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    CustomersApiService.prototype.save = function (customerInfo) {
        return this.post('api/customers/', customerInfo);
    };
    return CustomersApiService;
}(base_api_service_1.BaseApiService));
exports.CustomersApiService = CustomersApiService;
var Customer = /** @class */ (function () {
    function Customer() {
    }
    return Customer;
}());
exports.Customer = Customer;
//# sourceMappingURL=customers.service.js.map