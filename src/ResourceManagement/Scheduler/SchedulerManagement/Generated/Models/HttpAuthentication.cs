
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class HttpAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the HttpAuthentication class.
        /// </summary>
        public HttpAuthentication() { }

        /// <summary>
        /// Initializes a new instance of the HttpAuthentication class.
        /// </summary>
        public HttpAuthentication(HttpAuthenticationType? type = default(HttpAuthenticationType?))
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the http authentication type. Possible values
        /// include: 'NotSpecified', 'ClientCertificate',
        /// 'ActiveDirectoryOAuth', 'Basic'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public HttpAuthenticationType? Type { get; set; }

    }
}
