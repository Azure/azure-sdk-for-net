
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class CheckNameRequest
    {
        /// <summary>
        /// Initializes a new instance of the CheckNameRequest class.
        /// </summary>
        public CheckNameRequest() { }

        /// <summary>
        /// Initializes a new instance of the CheckNameRequest class.
        /// </summary>
        public CheckNameRequest(string name = default(string), string type = default(string))
        {
            Name = name;
            Type = type;
        }

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

    }
}
