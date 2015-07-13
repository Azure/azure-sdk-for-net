namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class ListUsagesResult
    {
        /// <summary>
        /// Gets or sets the list Compute Resource Usages.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Usage> Value { get; set; }

    }
}
