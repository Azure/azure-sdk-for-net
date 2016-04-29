
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
    /// Description of a NotificationHub MpnsCredential.
    /// </summary>
    public partial class MpnsCredential
    {
        /// <summary>
        /// Initializes a new instance of the MpnsCredential class.
        /// </summary>
        public MpnsCredential() { }

        /// <summary>
        /// Initializes a new instance of the MpnsCredential class.
        /// </summary>
        public MpnsCredential(MpnsCredentialProperties properties = default(MpnsCredentialProperties))
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets properties of NotificationHub MpnsCredential.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public MpnsCredentialProperties Properties { get; set; }

    }
}
