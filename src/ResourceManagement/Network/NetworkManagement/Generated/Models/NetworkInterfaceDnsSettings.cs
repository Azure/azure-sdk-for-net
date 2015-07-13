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
    public partial class NetworkInterfaceDnsSettings
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
        /// Gets or sets the Internal DNS name
        /// </summary>
        [JsonProperty(PropertyName = "internalDnsNameLabel")]
        public string InternalDnsNameLabel { get; set; }

        /// <summary>
        /// Gets or sets full IDNS name in the form,
        /// DnsName.VnetId.ZoneId.TopleveSuffix. This is set when the NIC is
        /// associated to a VM
        /// </summary>
        [JsonProperty(PropertyName = "internalFqdn")]
        public string InternalFqdn { get; set; }

    }
}
