
namespace Microsoft.Azure.Management.Dns.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// An AAAA record.
    /// </summary>
    public partial class AaaaRecord
    {
        /// <summary>
        /// Initializes a new instance of the AaaaRecord class.
        /// </summary>
        public AaaaRecord() { }

        /// <summary>
        /// Initializes a new instance of the AaaaRecord class.
        /// </summary>
        public AaaaRecord(string ipv6Address = default(string))
        {
            Ipv6Address = ipv6Address;
        }

        /// <summary>
        /// Gets or sets the IPv6 address of this AAAA record in string
        /// notation.
        /// </summary>
        [JsonProperty(PropertyName = "ipv6Address")]
        public string Ipv6Address { get; set; }

    }
}
