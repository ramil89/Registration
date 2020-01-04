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
var LocationsApiService = /** @class */ (function (_super) {
    __extends(LocationsApiService, _super);
    function LocationsApiService() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    LocationsApiService.prototype.loadLocations = function (locationId) {
        return this.get('api/countries/' + (locationId || ''));
    };
    return LocationsApiService;
}(base_api_service_1.BaseApiService));
exports.LocationsApiService = LocationsApiService;
var LocationItem = /** @class */ (function () {
    function LocationItem() {
    }
    return LocationItem;
}());
exports.LocationItem = LocationItem;
//# sourceMappingURL=locations.service.js.map