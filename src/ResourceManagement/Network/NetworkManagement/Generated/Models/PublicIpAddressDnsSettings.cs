namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Contains FQDN of the DNS record associated with the public IP address
    /// </summary>
    public partial class PublicIpAddressDnsSettings
    {
        /// <summary>
        /// Gets or sets the Domain name label.The concatenation of the domain
        /// name label and the regionalized DNS zone make up the fully
        /// qualified domain name associated with the public IP address. If a
        /// domain name label is specified, an A DNS record is created for
        /// the public IP in the Microsoft Azure DNS system.
        /// </summary>
        [JsonProperty(PropertyName = "domainNameLabel")]
        public string DomainNameLabel { get; set; }

        /// <summary>
        /// Gets the FQDN, Fully qualified domain name of the A DNS record
        /// associated with the public IP. This is the concatenation of the
        /// domainNameLabel and the regionalized DNS zone.
        /// </summary>
        [JsonProperty(PropertyName = "fqdn")]
        public string Fqdn { get; set; }

        /// <summary>
        /// Gets or Sests the Reverse FQDN. A user-visible, fully qualified
        /// domain name that resolves to this public IP address. If the
        /// reverseFqdn is specified, then a PTR DNS record is created
        /// pointing from the IP address in the in-addr.arpa domain to the
        /// reverse FQDN.
        /// </summary>
        [JsonProperty(PropertyName = "reverseFqdn")]
        public string ReverseFqdn { get; set; }

    }
}
