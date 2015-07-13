namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class ManagementLockProperties
    {
        /// <summary>
        /// Gets or sets the lock level of the management lock. Possible
        /// values for this property include: 'NotSpecified', 'CanNotDelete',
        /// 'ReadOnly'
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public LockLevel? Level { get; set; }

        /// <summary>
        /// Gets or sets the notes of the management lock.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

    }
}
