namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes Network Resource Usage.
    /// </summary>
    public partial class Usage
    {
        /// <summary>
        /// Gets or sets an enum describing the unit of measurement. Possible
        /// values for this property include: 'Count'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public UsageUnit? Unit { get; set; }

        /// <summary>
        /// Gets or sets the current value of the usage.
        /// </summary>
        [JsonProperty(PropertyName = "currentValue")]
        public int? CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the limit of usage.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public long? Limit { get; set; }

        /// <summary>
        /// Gets or sets the name of the type of usage.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public UsageName Name { get; set; }

    }
}
