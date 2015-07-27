namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Management lock information.
    /// </summary>
    public partial class ManagementLock
    {
        /// <summary>
        /// Gets or sets the properties of the lock.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ManagementLockProperties Properties { get; set; }

        /// <summary>
        /// Gets the Id of the lock.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the type of the lock.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the lock.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

    }
}
