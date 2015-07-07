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
    public partial class AddressSpace
    {
        /// <summary>
        /// Gets or sets List of address blocks reserved for this virtual
        /// network in CIDR notation
        /// </summary>
        [JsonProperty(PropertyName = "addressPrefixes")]
        public IList<string> AddressPrefixes { get; set; }

    }
}
