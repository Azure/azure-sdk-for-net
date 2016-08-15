
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class OAuthAuthentication : HttpAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the OAuthAuthentication class.
        /// </summary>
        public OAuthAuthentication() { }

        /// <summary>
        /// Initializes a new instance of the OAuthAuthentication class.
        /// </summary>
        public OAuthAuthentication(HttpAuthenticationType? type = default(HttpAuthenticationType?), string secret = default(string), string tenant = default(string), string audience = default(string), string clientId = default(string))
            : base(type)
        {
            Secret = secret;
            Tenant = tenant;
            Audience = audience;
            ClientId = clientId;
        }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the tenant.
        /// </summary>
        [JsonProperty(PropertyName = "tenant")]
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        [JsonProperty(PropertyName = "audience")]
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

    }
}
