namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The Usage Names.
    /// </summary>
    public partial class UsageName
    {
        /// <summary>
        /// Gets or sets a string describing the resource name.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a localized string describing the resource name.
        /// </summary>
        [JsonProperty(PropertyName = "localizedValue")]
        public string LocalizedValue { get; set; }

    }
}
