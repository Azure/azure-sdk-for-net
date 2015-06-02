using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class GenericResourceExtendedFilter
    {
        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        [JsonProperty(PropertyName = "tagname")]
        public string Tagname { get; set; }

        /// <summary>
        /// Gets or sets the tag value.
        /// </summary>
        [JsonProperty(PropertyName = "tagvalue")]
        public string Tagvalue { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
