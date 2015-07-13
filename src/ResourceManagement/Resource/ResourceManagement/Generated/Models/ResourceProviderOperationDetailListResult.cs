namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class ResourceProviderOperationDetailListResult
    {
        /// <summary>
        /// Gets or sets the list of resource provider operations.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<ResourceProviderOperationDefinition> Value { get; set; }

    }
}
