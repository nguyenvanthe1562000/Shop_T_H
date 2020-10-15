(function (app) {

    app.controller('LoginController', LoginController)
    LoginController.$inject=['$scope','$state']
    function LoginController($scope, $state) {
        $scope.LoginSubmit = function () { $state.go('home');}
    }
}
)(angular.module('Shop_T_H'));