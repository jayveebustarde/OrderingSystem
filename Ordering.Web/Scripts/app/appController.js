(function () {
    'use strict';

    angular
        .module('app')
        .controller('appController', appController);

    appController.$inject = ['$scope', '$http'];

    function appController($scope, $http) {
        $scope.isLoggedin = false;
        $scope.products = [];
        $scope.user = {};
        $scope.product = null;
        $scope.isOrdering = false;
        $scope.display = 'home';
        $scope.pred = 'home';
        

        $scope.getProduct = getProduct;
        $scope.getUser = getUser;
        $scope.addOrder = addOrder;
        $scope.login = login;
        $scope.logout = logout;
        $scope.goToProducts = goToProducts;

        getProducts();

        function goToProducts() {
            $scope.display = 'products';
        }
        
        function getProducts() {
            $http({
                method: 'get',
                url: 'api/product'
            }).then(function (response) {
                if (response) {
                    $scope.products = response.data;
                }
            });
        }

        function getProduct(id) {
            $http({
                method: 'get',
                url: 'api/product/' + id
            }).then(function (response) {
                if (response && response.data) {
                    $scope.product = response.data;
                    $scope.pred = $scope.display;
                    $scope.display = 'product';
                }
            });
        }

        function getUser() {
            $http({
                method: 'get',
                url: 'api/user/' + $scope.user.Email + '/'
            }).then(function (response) {
                if (response && response.data) {
                    $scope.user = response.data;
                    $scope.isLoggedin = true;
                    $scope.display = $scope.pred;
                }
            });
        }

        function addOrder() {
            $scope.isOrdering = true;
            let order = {
                'UserId': $scope.user.Id,
                'ProductId': $scope.product.Id
            };
            $http({
                method: 'post',
                url: 'api/order/create',
                data: order
            }).then(function (response) {
                if (response) {
                    $scope.isOrdering = false;
                    $scope.getProduct($scope.product.Id);
                }
            });
        }

        function login() {
            $scope.pred = $scope.display;
            $scope.display = 'login';
        }

        function logout() {
            $scope.display = $scope.pred;
            $scope.user = {};
        }
    }
}) ();