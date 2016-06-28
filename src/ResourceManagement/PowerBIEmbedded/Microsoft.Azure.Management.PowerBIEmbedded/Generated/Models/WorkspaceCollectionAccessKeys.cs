
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class WorkspaceCollectionAccessKeys
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceCollectionAccessKeys
        /// class.
        /// </summary>
        public WorkspaceCollectionAccessKeys() { }

        /// <summary>
        /// Initializes a new instance of the WorkspaceCollectionAccessKeys
        /// class.
        /// </summary>
        public WorkspaceCollectionAccessKeys(string key1 = default(string), string key2 = default(string))
        {
            Key1 = key1;
            Key2 = key2;
        }

        /// <summary>
        /// Gets or sets access key 1
        /// </summary>
        [JsonProperty(PropertyName = "key1")]
        public string Key1 { get; set; }

        /// <summary>
        /// Gets or sets access key 2
        /// </summary>
        [JsonProperty(PropertyName = "key2")]
        public string Key2 { get; set; }

    }
}
