
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class HttpRequest
    {
        /// <summary>
        /// Initializes a new instance of the HttpRequest class.
        /// </summary>
        public HttpRequest() { }

        /// <summary>
        /// Initializes a new instance of the HttpRequest class.
        /// </summary>
        public HttpRequest(HttpAuthentication authentication = default(HttpAuthentication), string uri = default(string), string method = default(string), string body = default(string), IDictionary<string, string> headers = default(IDictionary<string, string>))
        {
            Authentication = authentication;
            Uri = uri;
            Method = method;
            Body = body;
            Headers = headers;
        }

        /// <summary>
        /// Gets or sets the http authentication.
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public HttpAuthentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets the Uri.
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
        /// Gets or sets the headers.
        /// </summary>
        [JsonProperty(PropertyName = "headers")]
        public IDictionary<string, string> Headers { get; set; }

    }
}
