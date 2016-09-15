
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
    /// The properties of a storage account associated with this resource.
    /// </summary>
    public partial class StorageAccount
    {
        /// <summary>
        /// Initializes a new instance of the StorageAccount class.
        /// </summary>
        public StorageAccount() { }

        /// <summary>
        /// Initializes a new instance of the StorageAccount class.
        /// </summary>
        public StorageAccount(string id = default(string), bool? isPrimary = default(bool?))
        {
            Id = id;
            IsPrimary = isPrimary;
        }

        /// <summary>
        /// The id of the storage account resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Is this storage account resource the primary storage account for
        /// the Media Service resource.
        /// </summary>
        [JsonProperty(PropertyName = "isPrimary")]
        public bool? IsPrimary { get; set; }

    }
}
