namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue
    /// or table object.
    /// </summary>
    public partial class Endpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "blob")]
        public string Blob { get; set; }

        /// <summary>
        /// Gets the queue endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Gets the table endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "table")]
        public string Table { get; set; }

    }
}
