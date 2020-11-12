
(function (app) {
    app.controller('RootController', RootController);

    RootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService'];

    function RootController($state, authData, loginService, $scope, authenticationService) {
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;

        authenticationService.validateRequest();
    }
})(angular.module('Shop_T_H'));