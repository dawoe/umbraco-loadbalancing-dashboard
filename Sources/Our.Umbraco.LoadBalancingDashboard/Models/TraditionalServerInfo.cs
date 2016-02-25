namespace Our.Umbraco.LoadBalancingDashboard.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The traditional server info.
    /// </summary>
    [DataContract(Name = "server")]
    public class TraditionalServerInfo
    {
        /// <summary>
        /// Gets or sets the app id.
        /// </summary>
        [DataMember(Name = "appid")]
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the force portnumber.
        /// </summary>
        [DataMember(Name = "portnumber")]
        public string ForcePortnumber { get; set; }

        /// <summary>
        /// Gets or sets the force protocol.
        /// </summary>
        [DataMember(Name = "protocol")]
        public string ForceProtocol { get; set; }

        /// <summary>
        /// Gets or sets the server address.
        /// </summary>
        [DataMember(Name = "address")]
        public string ServerAddress { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [DataMember(Name = "name")]
        public string ServerName { get; set; }
    }
}
