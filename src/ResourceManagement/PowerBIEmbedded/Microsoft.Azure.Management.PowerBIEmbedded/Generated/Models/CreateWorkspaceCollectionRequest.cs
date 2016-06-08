
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class CreateWorkspaceCollectionRequest
    {
        /// <summary>
        /// Initializes a new instance of the CreateWorkspaceCollectionRequest
        /// class.
        /// </summary>
        public CreateWorkspaceCollectionRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CreateWorkspaceCollectionRequest
        /// class.
        /// </summary>
        public CreateWorkspaceCollectionRequest(string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            Location = location;
            Tags = tags;
        }
        /// <summary>
        /// Static constructor for CreateWorkspaceCollectionRequest class.
        /// </summary>
        static CreateWorkspaceCollectionRequest()
        {
            Sku = new AzureSku();
        }

        /// <summary>
        /// Gets or sets azure location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

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
