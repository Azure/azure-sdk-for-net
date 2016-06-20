
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class Workspace
    {
        /// <summary>
        /// Initializes a new instance of the Workspace class.
        /// </summary>
        public Workspace() { }

        /// <summary>
        /// Initializes a new instance of the Workspace class.
        /// </summary>
        public Workspace(string id = default(string), string name = default(string), string type = default(string), object properties = default(object))
        {
            Id = id;
            Name = name;
            Type = type;
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets workspace id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets workspace name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets resource type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets property bag
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public object Properties { get; set; }

    }
}
