namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Used for establishing the purchase context of any 3rd Party artifact
    /// through MarketPlace.
    /// </summary>
    public partial class PurchasePlan
    {
        /// <summary>
        /// Gets or sets the publisher ID.
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the plan ID.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public string Product { get; set; }

    }
}
