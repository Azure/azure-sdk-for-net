using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Storage.Models
{
    /// <summary>
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

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
