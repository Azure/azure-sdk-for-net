
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
    /// An A record.
    /// </summary>
    public partial class ARecord
    {
        /// <summary>
        /// Initializes a new instance of the ARecord class.
        /// </summary>
        public ARecord() { }

        /// <summary>
        /// Initializes a new instance of the ARecord class.
        /// </summary>
        public ARecord(string ipv4Address = default(string))
        {
            Ipv4Address = ipv4Address;
        }

        /// <summary>
        /// Gets or sets the IPv4 address of this A record in string notation.
        /// </summary>
        [JsonProperty(PropertyName = "ipv4Address")]
        public string Ipv4Address { get; set; }

    }
}
