(function () {
    'use strict';

    angular
        .module('app')
        .controller('appController', appController);

    appController.$inject = ['$scope', '$http', '$location'];

    function appController($scope, $http, $location) {
        $scope.isLoggedin = false;
        $scope.products = [];
        $scope.user = {};
        $scope.product = null;
        $scope.isOrdering = false;
        $scope.display = 'home';
        $scope.pred = 'home';
        $scope.baseurl = getBaseUrl();
        

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
                url: $scope.baseurl + 'api/product'
            }).then(function (response) {
                if (response) {
                    $scope.products = response.data;
                }
            });
        }

        function getProduct(id) {
            $http({
                method: 'get',
                url: $scope.baseurl + 'api/product/' + id
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
                url: $scope.baseurl + 'api/user/' + $scope.user.Email + '/'
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
                url: $scope.baseurl + 'api/order/create',
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
            $scope.user = {};
            $scope.isLoggedin = false;
        }

        function getBaseUrl() {
            return $location.protocol() + '://' + $location.host() + ($location.port() !== 80 ? ':' + $location.port() : '') + '/';
        }
    }
}) ();