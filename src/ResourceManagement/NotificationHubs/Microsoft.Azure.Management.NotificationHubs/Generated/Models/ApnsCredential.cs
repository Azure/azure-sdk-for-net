
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
    /// Description of a NotificationHub ApnsCredential.
    /// </summary>
    public partial class ApnsCredential
    {
        /// <summary>
        /// Initializes a new instance of the ApnsCredential class.
        /// </summary>
        public ApnsCredential() { }

        /// <summary>
        /// Initializes a new instance of the ApnsCredential class.
        /// </summary>
        public ApnsCredential(ApnsCredentialProperties properties = default(ApnsCredentialProperties))
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets properties of NotificationHub ApnsCredential.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ApnsCredentialProperties Properties { get; set; }

    }
}
