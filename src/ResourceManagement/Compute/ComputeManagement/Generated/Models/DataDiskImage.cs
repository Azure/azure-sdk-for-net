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
    public partial class DataDiskImage
    {
        /// <summary>
        /// Gets the LUN number for a data disk.This value is used to identify
        /// data disk image inside the VMImage therefore it must be unique
        /// for each data disk.The allowed character for the value is digit.
        /// </summary>
        [JsonProperty(PropertyName = "lun")]
        public int? Lun { get; set; }

    }
}
