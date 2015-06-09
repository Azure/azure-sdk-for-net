using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class ManagementLockProperties
    {
        /// <summary>
        /// Gets or sets the lock level of the management lock.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the notes of the management lock.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
