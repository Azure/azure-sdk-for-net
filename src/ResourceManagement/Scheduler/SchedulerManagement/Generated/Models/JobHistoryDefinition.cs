namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class JobHistoryDefinition
    {
        /// <summary>
        /// Gets the job history identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the job history resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the job history name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the job history properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public JobHistoryDefinitionProperties Properties { get; private set; }

    }
}
