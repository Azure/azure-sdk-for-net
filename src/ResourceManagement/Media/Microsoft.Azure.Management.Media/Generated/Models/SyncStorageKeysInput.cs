
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
    /// The request  body for a SyncStorageKeys API.
    /// </summary>
    public partial class SyncStorageKeysInput
    {
        /// <summary>
        /// Initializes a new instance of the SyncStorageKeysInput class.
        /// </summary>
        public SyncStorageKeysInput() { }

        /// <summary>
        /// Initializes a new instance of the SyncStorageKeysInput class.
        /// </summary>
        public SyncStorageKeysInput(string id = default(string))
        {
            Id = id;
        }

        /// <summary>
        /// The id of the storage account resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
