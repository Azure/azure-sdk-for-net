namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The List Availability Set operation response.
    /// </summary>
    public partial class AvailabilitySetListResult
    {
        /// <summary>
        /// Gets or sets the list of availability sets
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<AvailabilitySet> Value { get; set; }

    }
}
