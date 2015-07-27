namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Response for CheckDnsNameAvailability Api servive call
    /// </summary>
    public partial class DnsNameAvailabilityResult
    {
        /// <summary>
        /// Domain availability (True/False)
        /// </summary>
        [JsonProperty(PropertyName = "available")]
        public bool? Available { get; set; }

    }
}
