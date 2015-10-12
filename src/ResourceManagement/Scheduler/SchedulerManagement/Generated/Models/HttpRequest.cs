namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class HttpRequest
    {
        /// <summary>
        /// Gets or sets the http authentication.
        /// </summary>
        [JsonProperty(PropertyName = "httpAuthentication")]
        public HttpAuthentication HttpAuthentication { get; set; }

        /// <summary>
        /// Gets or sets the Uri for the request.
        /// </summary>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the method of the request.
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the request body.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the headers for the request.
        /// </summary>
        [JsonProperty(PropertyName = "headers")]
        public IDictionary<string, string> Headers { get; set; }

    }
}
