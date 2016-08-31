
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobHistoryDefinition
    {
        /// <summary>
        /// Initializes a new instance of the JobHistoryDefinition class.
        /// </summary>
        public JobHistoryDefinition() { }

        /// <summary>
        /// Initializes a new instance of the JobHistoryDefinition class.
        /// </summary>
        public JobHistoryDefinition(string id = default(string), string type = default(string), string name = default(string), JobHistoryDefinitionProperties properties = default(JobHistoryDefinitionProperties))
        {
            Id = id;
            Type = type;
            Name = name;
            Properties = properties;
        }

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
