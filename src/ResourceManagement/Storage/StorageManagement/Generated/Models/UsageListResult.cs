namespace Microsoft.Azure.Management.Storage.Models
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
    public partial class UsageListResult
    {
        /// <summary>
        /// Gets or sets the list Storage Resource Usages.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Usage> Value { get; set; }

    }
}
