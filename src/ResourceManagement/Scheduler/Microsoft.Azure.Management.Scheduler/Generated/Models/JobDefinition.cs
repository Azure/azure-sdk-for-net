
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobDefinition
    {
        /// <summary>
        /// Initializes a new instance of the JobDefinition class.
        /// </summary>
        public JobDefinition() { }

        /// <summary>
        /// Initializes a new instance of the JobDefinition class.
        /// </summary>
        public JobDefinition(string id = default(string), string type = default(string), string name = default(string), JobProperties properties = default(JobProperties))
        {
            Id = id;
            Type = type;
            Name = name;
            Properties = properties;
        }

        /// <summary>
        /// Gets the job resource identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the job resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the job resource name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the job properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public JobProperties Properties { get; set; }

    }
}
