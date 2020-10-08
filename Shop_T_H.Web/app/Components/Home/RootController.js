(function (app) {
    app.controller('RootController', RootController);

    RootController.$inject = ['$state', '$scope'];

    function RootController($state, $scope) {
        $scope.LogOut = function () {
            $state.go('login');
        }
       
    }
})(angular.module('Shop_T_H'));