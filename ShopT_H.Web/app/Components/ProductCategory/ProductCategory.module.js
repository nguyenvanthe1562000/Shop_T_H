
(function () {
    angular.module("Shop_T_H.ProductCategory", ['Shop_T_H.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("productCategory", {
                url: "/productcategory",
                parent: 'base',
                templateUrl: "/app/Components/ProductCategory/ProductCategoryListView.html",
                controller: "ProductCategoryListController"
            })
            .state("addProductCategory", {
                url: "/addProductCategory",
                parent: 'base',
                templateUrl: "/app/Components/ProductCategory/ProductCategoryAddView.html",
                controller: "ProductCategoryAddController"
            });
    }
})();