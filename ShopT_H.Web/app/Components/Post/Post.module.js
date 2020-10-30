
(function () {
    angular.module("Shop_T_H.Post", ['Shop_T_H.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("post", {
                url: "/post",
                parent: 'base',
                templateUrl: "/app/Components/Post/PostView.html",
                controller: "PostController"
            })
    }
})();