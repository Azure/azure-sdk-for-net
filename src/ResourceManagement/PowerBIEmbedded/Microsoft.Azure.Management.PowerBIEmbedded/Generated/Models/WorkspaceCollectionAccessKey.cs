
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class WorkspaceCollectionAccessKey
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceCollectionAccessKey
        /// class.
        /// </summary>
        public WorkspaceCollectionAccessKey() { }

        /// <summary>
        /// Initializes a new instance of the WorkspaceCollectionAccessKey
        /// class.
        /// </summary>
        public WorkspaceCollectionAccessKey(AccessKeyName? keyName = default(AccessKeyName?))
        {
            KeyName = keyName;
        }

        /// <summary>
        /// Gets or sets key name. Possible values include: 'key1', 'key2'
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public AccessKeyName? KeyName { get; set; }

    }
}
