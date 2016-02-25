namespace Our.Umbraco.LoadBalancingDashboard.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The flexible server info.
    /// </summary>
    [DataContract(Name = "server")]
    public class FlexibleServerInfo
    {
        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        [DataMember(Name = "identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets the registered.
        /// </summary>
        [DataMember(Name = "registered")]
        public DateTime Registered { get; set; }

        /// <summary>
        /// Gets or sets the last accessed.
        /// </summary>
        [DataMember(Name = "lastaccessed")]
        public DateTime LastAccessed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
         [DataMember(Name = "isactive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is master.
        /// </summary>
        [DataMember(Name = "ismaster")]
        public bool IsMaster { get; set; }
    }
}
