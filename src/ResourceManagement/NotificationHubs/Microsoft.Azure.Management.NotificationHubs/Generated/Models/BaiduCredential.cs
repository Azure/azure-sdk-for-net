
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
    /// Description of a NotificationHub BaiduCredential.
    /// </summary>
    public partial class BaiduCredential
    {
        /// <summary>
        /// Initializes a new instance of the BaiduCredential class.
        /// </summary>
        public BaiduCredential() { }

        /// <summary>
        /// Initializes a new instance of the BaiduCredential class.
        /// </summary>
        public BaiduCredential(BaiduCredentialProperties properties = default(BaiduCredentialProperties))
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets or sets properties of NotificationHub BaiduCredential.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public BaiduCredentialProperties Properties { get; set; }

    }
}
