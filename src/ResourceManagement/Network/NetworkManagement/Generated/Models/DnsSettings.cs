namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class DnsSettings
    {
        /// <summary>
        /// Gets or sets list of DNS servers IP addresses
        /// </summary>
        [JsonProperty(PropertyName = "dnsServers")]
        public IList<string> DnsServers { get; set; }

        /// <summary>
        /// Gets or sets list of Applied DNS servers IP addresses
        /// </summary>
        [JsonProperty(PropertyName = "appliedDnsServers")]
        public IList<string> AppliedDnsServers { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
