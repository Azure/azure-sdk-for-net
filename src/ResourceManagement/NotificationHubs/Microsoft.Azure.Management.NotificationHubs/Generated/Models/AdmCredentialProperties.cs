
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Description of a NotificationHub AdmCredential.
    /// </summary>
    public partial class AdmCredentialProperties
    {
        /// <summary>
        /// Initializes a new instance of the AdmCredentialProperties class.
        /// </summary>
        public AdmCredentialProperties() { }

        /// <summary>
        /// Initializes a new instance of the AdmCredentialProperties class.
        /// </summary>
        public AdmCredentialProperties(string clientId = default(string), string clientSecret = default(string), string authTokenUrl = default(string))
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AuthTokenUrl = authTokenUrl;
        }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the credential secret access key.
        /// </summary>
        [JsonProperty(PropertyName = "clientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the URL of the authorization token.
        /// </summary>
        [JsonProperty(PropertyName = "authTokenUrl")]
        public string AuthTokenUrl { get; set; }

    }
}
