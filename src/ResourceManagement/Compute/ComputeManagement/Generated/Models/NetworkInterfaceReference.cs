namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes a network interface reference.
    /// </summary>
    public partial class NetworkInterfaceReference : SubResource
    {
        /// <summary>
        /// Gets or sets whether this is a primary NIC on a virtual machine
        /// </summary>
        [JsonProperty(PropertyName = "properties.primary")]
        public bool? Primary { get; set; }

    }
}
