namespace Our.Umbraco.LoadBalancingDashboard.WebApi
{
    using System.Collections.Generic;
    using System.Web.Http;

    using AutoMapper;

    using Our.Umbraco.LoadBalancingDashboard.Enums;

    using global::Umbraco.Core.Configuration;

    using global::Umbraco.Web.Mvc;

    using global::Umbraco.Web.WebApi;

    using Our.Umbraco.LoadBalancingDashboard.Models;

    /// <summary>
    /// Load balancing dashboard api controller.
    /// </summary>
    [PluginController("OurUmbracoLoadBalancingDashboard")]
    public class LoadBalancingApiController : UmbracoAuthorizedApiController
    {
        /// <summary>
        /// Gets the loadbalancing type
        /// </summary>
        /// <returns>
        /// The <see cref="LoadBalancingType"/>.
        /// </returns>
        [HttpGet]
        public LoadBalancingType GetLoadBalancingType()
        {
            return UmbracoConfig.For.UmbracoSettings().DistributedCall.Enabled
                       ? LoadBalancingType.Traditional
                       : LoadBalancingType.Flexible;
        }

        /// <summary>
        /// Get flexible servers info
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<FlexibleServerInfo> GetFlexibleServerInfo()
        {
            return AutoMapper.Mapper.Map<IEnumerable<FlexibleServerInfo>>(ApplicationContext.Services.ServerRegistrationService.GetActiveServers());           
        }

        /// <summary>
        /// Ges traditional server info.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<TraditionalServerInfo> GetTraditionalServerInfo()
        {
            var servers = UmbracoConfig.For.UmbracoSettings().DistributedCall.Servers;

            var result = new List<TraditionalServerInfo>();

            foreach (var server in servers)
            {
                result.Add(Mapper.Map<TraditionalServerInfo>(server));
            }

            return result;
        }
    }
}
