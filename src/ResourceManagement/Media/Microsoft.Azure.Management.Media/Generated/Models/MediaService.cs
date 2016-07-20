
namespace Microsoft.Azure.Management.Media.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties of a Media Service resource.
    /// </summary>
    [JsonTransformation]
    public partial class MediaService : TrackedResource
    {
        /// <summary>
        /// Initializes a new instance of the MediaService class.
        /// </summary>
        public MediaService() { }

        /// <summary>
        /// Initializes a new instance of the MediaService class.
        /// </summary>
        public MediaService(string location, IDictionary<string, string> tags, string id = default(string), string name = default(string), string type = default(string), IList<ApiEndpoint> apiEndpoints = default(IList<ApiEndpoint>), IList<StorageAccount> storageAccounts = default(IList<StorageAccount>))
            : base(location, tags, id, name, type)
        {
            ApiEndpoints = apiEndpoints;
            StorageAccounts = storageAccounts;
        }

        /// <summary>
        /// The Media Services REST API endpoints for this resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.apiEndpoints")]
        public IList<ApiEndpoint> ApiEndpoints { get; set; }

        /// <summary>
        /// The storage accounts for this resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccounts")]
        public IList<StorageAccount> StorageAccounts { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
