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