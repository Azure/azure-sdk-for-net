
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
    public partial class WnsCredential
    {
        /// <summary>
        /// Initializes a new instance of the WnsCredential class.
        /// </summary>
        public WnsCredential() { }

        /// <summary>
        /// Initializes a new instance of the WnsCredential class.
        /// </summary>
        public WnsCredential(WnsCredentialProperties properties = default(WnsCredentialProperties))
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets properties of NotificationHub WnsCredential.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public WnsCredentialProperties Properties { get; set; }

    }
}
