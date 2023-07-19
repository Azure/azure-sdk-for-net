
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The secondary DNS settings.
    /// </summary>
    public partial class SecondaryDNSSettings
    {
        /// <summary>
        /// Initializes a new instance of the SecondaryDNSSettings class.
        /// </summary>
        public SecondaryDNSSettings() { }

        /// <summary>
        /// Initializes a new instance of the SecondaryDNSSettings class.
        /// </summary>
        /// <param name="secondaryDnsServers">The list of secondary DNS Server
        /// IP addresses.</param>
        public SecondaryDNSSettings(IList<string> secondaryDnsServers = default(IList<string>))
        {
            SecondaryDnsServers = secondaryDnsServers;
        }

        /// <summary>
        /// Gets or sets the list of secondary DNS Server IP addresses.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryDnsServers")]
        public IList<string> SecondaryDnsServers { get; set; }

    }
}

