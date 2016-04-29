
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
    public partial class AdmCredential
    {
        /// <summary>
        /// Initializes a new instance of the AdmCredential class.
        /// </summary>
        public AdmCredential() { }

        /// <summary>
        /// Initializes a new instance of the AdmCredential class.
        /// </summary>
        public AdmCredential(AdmCredentialProperties properties = default(AdmCredentialProperties))
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets properties of NotificationHub AdmCredential.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public AdmCredentialProperties Properties { get; set; }

    }
}
