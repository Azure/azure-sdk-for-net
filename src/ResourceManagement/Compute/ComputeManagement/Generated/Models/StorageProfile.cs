namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes a storage profile.
    /// </summary>
    public partial class StorageProfile
    {
        /// <summary>
        /// Gets or sets the image reference.
        /// </summary>
        [JsonProperty(PropertyName = "imageReference")]
        public ImageReference ImageReference { get; set; }

        /// <summary>
        /// Gets or sets the OS disk.
        /// </summary>
        [JsonProperty(PropertyName = "osDisk")]
        public OSDisk OsDisk { get; set; }

        /// <summary>
        /// Gets or sets the data disks.
        /// </summary>
        [JsonProperty(PropertyName = "dataDisks")]
        public IList<DataDisk> DataDisks { get; set; }

    }
}
