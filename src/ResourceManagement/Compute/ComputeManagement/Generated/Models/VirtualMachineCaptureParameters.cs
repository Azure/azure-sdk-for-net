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
    public partial class VirtualMachineCaptureParameters
    {
        /// <summary>
        /// Gets or sets the captured VirtualHardDisk's name prefix.
        /// </summary>
        [JsonProperty(PropertyName = "vhdPrefix")]
        public string VhdPrefix { get; set; }

        /// <summary>
        /// Gets or sets the destination container name.
        /// </summary>
        [JsonProperty(PropertyName = "destinationContainerName")]
        public string DestinationContainerName { get; set; }

        /// <summary>
        /// Gets or sets whether it overwrites destination VirtualHardDisk if
        /// true, in case of conflict.
        /// </summary>
        [JsonProperty(PropertyName = "overwriteVhds")]
        public bool? OverwriteVhds { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
