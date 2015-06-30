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
    public partial class ApplicationGatewaySku
    {
        /// <summary>
        /// Gets or sets name of application gateway SKU. Possible values for
        /// this property include: 'Standard_Small', 'Standard_Medium',
        /// 'Standard_Large'
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public ApplicationGatewaySkuName? Name { get; set; }

        /// <summary>
        /// Gets or sets tier of application gateway. Possible values for this
        /// property include: 'Standard'
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public ApplicationGatewayTier? Tier { get; set; }

        /// <summary>
        /// Gets or sets capacity (instance count) of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public int? Capacity { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
