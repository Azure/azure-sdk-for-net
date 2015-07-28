namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The custom domain assigned to this storage account. This can be set
    /// via Update.
    /// </summary>
    public partial class CustomDomain
    {
        /// <summary>
        /// Gets or sets the custom domain name. Name is the CNAME source.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default
        /// value is false. This should only be set on updates
        /// </summary>
        [JsonProperty(PropertyName = "useSubDomain")]
        public bool? UseSubDomain { get; set; }

    }
}
