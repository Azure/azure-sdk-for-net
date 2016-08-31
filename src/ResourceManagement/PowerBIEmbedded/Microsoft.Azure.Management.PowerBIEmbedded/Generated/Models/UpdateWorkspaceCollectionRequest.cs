
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class UpdateWorkspaceCollectionRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateWorkspaceCollectionRequest
        /// class.
        /// </summary>
        public UpdateWorkspaceCollectionRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UpdateWorkspaceCollectionRequest
        /// class.
        /// </summary>
        public UpdateWorkspaceCollectionRequest(IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            Tags = tags;
        }
        /// <summary>
        /// Static constructor for UpdateWorkspaceCollectionRequest class.
        /// </summary>
        static UpdateWorkspaceCollectionRequest()
        {
            Sku = new AzureSku();
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public static AzureSku Sku { get; private set; }

    }
}
