namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class OSDiskImage
    {
        /// <summary>
        /// Gets or sets the operating system of the osDiskImage. Possible
        /// values for this property include: 'Windows', 'Linux'
        /// </summary>
        [JsonProperty(PropertyName = "operatingSystem")]
        public OperatingSystemTypes? OperatingSystem { get; set; }

    }
}
