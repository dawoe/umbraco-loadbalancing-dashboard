namespace Our.Umbraco.LoadBalancingDashboard
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Our.Umbraco.LoadBalancingDashboard.WebApi;

    using global::Umbraco.Core;

    using global::Umbraco.Web;

    using global::Umbraco.Web.UI.JavaScript;

    /// <summary>
    /// Bootstrapper to handle application events
    /// </summary>
    internal class BootStrapper : ApplicationEventHandler
    {
        /// <summary>
        /// Overridable method to execute when Bootup is completed, this allows you to perform any other bootup logic required for the application.
        ///             Resolution is frozen so now they can be used to resolve instances.
        /// </summary>
        /// <param name="umbracoApplication">the Umbraco HttpApplication</param>
        /// <param name="applicationContext"> the Umbraco Application context</param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ServerVariablesParser.Parsing += this.ServerVariablesParserParsing;            
        }

        /// <summary>
        /// Server variables parsing event handler
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ServerVariablesParserParsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));

            var mainDictionary = new Dictionary<string, object>
                                     {
                                         {
                                             "LoadBalancingApi",
                                             urlHelper.GetUmbracoApiServiceBaseUrl<LoadBalancingApiController>(
                                                 controller => controller.GetLoadBalancingType())
                                         }
                                     };

            if (!e.ContainsKey("Our.Umbraco.LoadBalancingDashboard"))
            {
                e.Add("Our.Umbraco.LoadBalancingDashboard", mainDictionary);
            }
        }
    }
}
