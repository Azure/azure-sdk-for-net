
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobCollectionDefinition
    {
        /// <summary>
        /// Initializes a new instance of the JobCollectionDefinition class.
        /// </summary>
        public JobCollectionDefinition() { }

        /// <summary>
        /// Initializes a new instance of the JobCollectionDefinition class.
        /// </summary>
        public JobCollectionDefinition(string id = default(string), string type = default(string), string name = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), JobCollectionProperties properties = default(JobCollectionProperties))
        {
            Id = id;
            Type = type;
            Name = name;
            Location = location;
            Tags = tags;
            Properties = properties;
        }

        /// <summary>
        /// Gets the job collection resource identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the job collection resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets the job collection resource name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage account location.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the job collection properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public JobCollectionProperties Properties { get; set; }

    }
}
