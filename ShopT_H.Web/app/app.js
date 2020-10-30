/// <reference path="../assets/angularjs/angular.min.js" />

(function () {
    angular.module("Shop_T_H",
        ["Shop_T_H.common",
            "Shop_T_H.ProductCategory",
            "Shop_T_H.Product",
            "Shop_T_H.Post"
        ])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider','$urlMatcherFactoryProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider, $urlMatcherFactoryProvider) {
        $stateProvider
            .state("base", {
                url: '',
                templateUrl: '/app/Shared/View/BaseView.html',
                abstract:true
            })
            .state("home", {
                url: "/admin",
                parent:"base",
                templateUrl: "/app/Components/Home/HomeView.html",
                controller: "HomeController"
            })
            .state("login", {
                url: "/login",
                templateUrl: "/app/Components/Login/LoginView.html",
                controller: "LoginController"
            })
        $urlRouterProvider.otherwise("/login");
        //$urlMatcherFactoryProvider.caseInsensitive(true);
        //$locationProvider.html5Mode(true);
    }
})();