angular.module("umbraco.resources")
        .factory("Our.Umbraco.LoadBalancindDashboard.LoadBalancingApiResource", function ($http) {
            return {
                getLoadBalancingType: function () {
                    return $http.get(Umbraco.Sys.ServerVariables.OurUmbracoLoadBalancingDashboard.LoadBalancingApi + "GetLoadBalancingType");
                },
                getFlexibleServers : function() {
                    return $http.get(Umbraco.Sys.ServerVariables.OurUmbracoLoadBalancingDashboard.LoadBalancingApi + "GetFlexibleServerInfo");
                }
            };
        });