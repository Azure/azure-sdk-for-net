namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The List Usages operation response.
    /// </summary>
    public partial class UsagesListResult
    {
        /// <summary>
        /// Gets or sets the list Network Resource Usages.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Usage> Value { get; set; }

    }
}
