
(function () {
    angular.module("Shop_T_H.Product", ['Shop_T_H.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("product", {
                url: "/product",
                parent:'base',
                templateUrl: "/app/Components/Product/ProductListView.html",
                controller: "ProductListController"
            })
            .state("productAdd", {
                url: "/productAdd",
                parent: 'base',
                templateUrl: "/app/Components/Product/ProductAddView.html",
                controller: "ProductAddController"
            })
    }
})();