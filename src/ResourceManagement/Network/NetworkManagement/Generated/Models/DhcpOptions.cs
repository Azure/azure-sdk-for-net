namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// DHCPOptions contains an array of DNS servers available to VMs deployed
    /// in the virtual networkStandard DHCP option for a subnet overrides
    /// VNET DHCP options.
    /// </summary>
    public partial class DhcpOptions
    {
        /// <summary>
        /// Gets or sets list of DNS servers IP addresses
        /// </summary>
        [JsonProperty(PropertyName = "dnsServers")]
        public IList<string> DnsServers { get; set; }

    }
}
