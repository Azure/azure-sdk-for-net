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
    public partial class VirtualNetworkGatewayConnectionListResult
    {
        /// <summary>
        /// Gets List of VirtualNetworkGatewayConnections that exists in a
        /// resource group
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<VirtualNetworkGatewayConnection> Value { get; set; }

        /// <summary>
        /// Gets the URL to get the next set of results.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; set; }

    }
}
