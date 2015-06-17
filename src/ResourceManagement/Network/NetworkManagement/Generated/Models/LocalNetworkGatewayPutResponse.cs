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
    public partial class LocalNetworkGatewayPutResponse
    {
        /// <summary>
        /// Puts the local network gateway that exists in a resource group
        /// </summary>
        [JsonProperty(PropertyName = "LocalNetworkGateway")]
        public LocalNetworkGateway LocalNetworkGateway { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.LocalNetworkGateway != null)
            {
                this.LocalNetworkGateway.Validate();
            }
            if (this.Error != null)
            {
                this.Error.Validate();
            }
        }
    }
}
