
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
    /// The DNS(Domain Name Server) settings of a device.
    /// </summary>
    public partial class DNSSettings
    {
        /// <summary>
        /// Initializes a new instance of the DNSSettings class.
        /// </summary>
        public DNSSettings() { }

        /// <summary>
        /// Initializes a new instance of the DNSSettings class.
        /// </summary>
        /// <param name="primaryDnsServer">The primary IPv4 DNS server for the
        /// device</param>
        /// <param name="primaryIpv6DnsServer">The primary IPv6 DNS server for
        /// the device</param>
        /// <param name="secondaryDnsServers">The secondary IPv4 DNS server for
        /// the device</param>
        /// <param name="secondaryIpv6DnsServers">The secondary IPv6 DNS server
        /// for the device</param>
        public DNSSettings(string primaryDnsServer = default(string), string primaryIpv6DnsServer = default(string), IList<string> secondaryDnsServers = default(IList<string>), IList<string> secondaryIpv6DnsServers = default(IList<string>))
        {
            PrimaryDnsServer = primaryDnsServer;
            PrimaryIpv6DnsServer = primaryIpv6DnsServer;
            SecondaryDnsServers = secondaryDnsServers;
            SecondaryIpv6DnsServers = secondaryIpv6DnsServers;
        }

        /// <summary>
        /// Gets or sets the primary IPv4 DNS server for the device
        /// </summary>
        [JsonProperty(PropertyName = "primaryDnsServer")]
        public string PrimaryDnsServer { get; set; }

        /// <summary>
        /// Gets or sets the primary IPv6 DNS server for the device
        /// </summary>
        [JsonProperty(PropertyName = "primaryIpv6DnsServer")]
        public string PrimaryIpv6DnsServer { get; set; }

        /// <summary>
        /// Gets or sets the secondary IPv4 DNS server for the device
        /// </summary>
        [JsonProperty(PropertyName = "secondaryDnsServers")]
        public IList<string> SecondaryDnsServers { get; set; }

        /// <summary>
        /// Gets or sets the secondary IPv6 DNS server for the device
        /// </summary>
        [JsonProperty(PropertyName = "secondaryIpv6DnsServers")]
        public IList<string> SecondaryIpv6DnsServers { get; set; }

    }
}

