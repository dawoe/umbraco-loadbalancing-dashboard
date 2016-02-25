angular.module("umbraco").controller("Our.Umbraco.LoadBalancindDashboard.DashboardController", [
    '$scope',
    'Our.Umbraco.LoadBalancindDashboard.LoadBalancingApiResource',
    function ($scope, loadBalancingApiResource) {

        $scope.loadData = function() {
            loadBalancingApiResource.getLoadBalancingType().then(function (response) {
                $scope.loadbalanceType = response.data;
            });
        }

        $scope.loadData();
    }
]);

angular.module("umbraco").controller("Our.Umbraco.LoadBalancindDashboard.FlexibleController", [
    '$scope',
    'Our.Umbraco.LoadBalancindDashboard.LoadBalancingApiResource',
    function ($scope, loadBalancingApiResource) {

        $scope.servers = {};

        $scope.reverse = false;
        $scope.predicate = 'identity';

        $scope.loadData = function () {
            loadBalancingApiResource.getFlexibleServers().then(function (response) {
                $scope.servers = response.data;
            });
        }

        // order data
        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };

        $scope.loadData();
    }
]);

angular.module("umbraco").controller("Our.Umbraco.LoadBalancindDashboard.TraditionalController", [
    '$scope',
    'Our.Umbraco.LoadBalancindDashboard.LoadBalancingApiResource',
    function ($scope, loadBalancingApiResource) {

        $scope.servers = {};

        $scope.reverse = false;
        $scope.predicate = 'address';

        $scope.loadData = function () {
            loadBalancingApiResource.getTraditionalServers().then(function (response) {
                $scope.servers = response.data;
            });
        }

        // order data
        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };

        $scope.loadData();
    }
]);