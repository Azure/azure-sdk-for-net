
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class WorkspaceCollection
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceCollection class.
        /// </summary>
        public WorkspaceCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the WorkspaceCollection class.
        /// </summary>
        public WorkspaceCollection(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), object properties = default(object))
        {
            Id = id;
            Name = name;
            Type = type;
            Location = location;
            Tags = tags;
            Properties = properties;
        }
        /// <summary>
        /// Static constructor for WorkspaceCollection class.
        /// </summary>
        static WorkspaceCollection()
        {
            Sku = new AzureSku();
        }

        /// <summary>
        /// Resource id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Workspace collection name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Resource type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Azure location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public object Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public static AzureSku Sku { get; private set; }

    }
}
