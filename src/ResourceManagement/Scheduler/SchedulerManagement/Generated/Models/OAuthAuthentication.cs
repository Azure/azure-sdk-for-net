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
    public partial class OAuthAuthentication : HttpAuthentication
    {
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
