
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
    /// Description of a NotificationHub WnsCredential.
    /// </summary>
    public partial class WnsCredentialProperties
    {
        /// <summary>
        /// Initializes a new instance of the WnsCredentialProperties class.
        /// </summary>
        public WnsCredentialProperties() { }

        /// <summary>
        /// Initializes a new instance of the WnsCredentialProperties class.
        /// </summary>
        public WnsCredentialProperties(string packageSid = default(string), string secretKey = default(string), string windowsLiveEndpoint = default(string))
        {
            PackageSid = packageSid;
            SecretKey = secretKey;
            WindowsLiveEndpoint = windowsLiveEndpoint;
        }

        /// <summary>
        /// Gets or sets the package ID for this credential.
        /// </summary>
        [JsonProperty(PropertyName = "packageSid")]
        public string PackageSid { get; set; }

        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        [JsonProperty(PropertyName = "secretKey")]
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the Windows Live endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "windowsLiveEndpoint")]
        public string WindowsLiveEndpoint { get; set; }

    }
}
