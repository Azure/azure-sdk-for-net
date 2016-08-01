
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
    /// The properties for a Media Services REST API endpoint.
    /// </summary>
    public partial class ApiEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the ApiEndpoint class.
        /// </summary>
        public ApiEndpoint() { }

        /// <summary>
        /// Initializes a new instance of the ApiEndpoint class.
        /// </summary>
        public ApiEndpoint(string endpoint = default(string), string majorVersion = default(string))
        {
            Endpoint = endpoint;
            MajorVersion = majorVersion;
        }

        /// <summary>
        /// The Media Services REST endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }

        /// <summary>
        /// The version of Media Services REST API.
        /// </summary>
        [JsonProperty(PropertyName = "majorVersion")]
        public string MajorVersion { get; set; }

    }
}
