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
    public partial class VirtualMachineSize
    {
        /// <summary>
        /// Gets or sets the VM size name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Number of cores supported by a VM size.
        /// </summary>
        [JsonProperty(PropertyName = "numberOfCores")]
        public int? NumberOfCores { get; set; }

        /// <summary>
        /// Gets or sets the OS disk size allowed by a VM size.
        /// </summary>
        [JsonProperty(PropertyName = "osDiskSizeInMB")]
        public int? OsDiskSizeInMB { get; set; }

        /// <summary>
        /// Gets or sets the Resource disk size allowed by a VM size.
        /// </summary>
        [JsonProperty(PropertyName = "resourceDiskSizeInMB")]
        public int? ResourceDiskSizeInMB { get; set; }

        /// <summary>
        /// Gets or sets the Memory size supported by a VM size.
        /// </summary>
        [JsonProperty(PropertyName = "memoryInMB")]
        public int? MemoryInMB { get; set; }

        /// <summary>
        /// Gets or sets the Maximum number of data disks allowed by a VM size.
        /// </summary>
        [JsonProperty(PropertyName = "maxDataDiskCount")]
        public int? MaxDataDiskCount { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
