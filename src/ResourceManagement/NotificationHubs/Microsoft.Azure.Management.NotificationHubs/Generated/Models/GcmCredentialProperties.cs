
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
    /// Description of a NotificationHub GcmCredential.
    /// </summary>
    public partial class GcmCredentialProperties
    {
        /// <summary>
        /// Initializes a new instance of the GcmCredentialProperties class.
        /// </summary>
        public GcmCredentialProperties() { }

        /// <summary>
        /// Initializes a new instance of the GcmCredentialProperties class.
        /// </summary>
        public GcmCredentialProperties(string gcmEndpoint = default(string), string googleApiKey = default(string))
        {
            GcmEndpoint = gcmEndpoint;
            GoogleApiKey = googleApiKey;
        }

        /// <summary>
        /// Gets or sets the GCM endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "gcmEndpoint")]
        public string GcmEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the Google API key.
        /// </summary>
        [JsonProperty(PropertyName = "googleApiKey")]
        public string GoogleApiKey { get; set; }

    }
}
