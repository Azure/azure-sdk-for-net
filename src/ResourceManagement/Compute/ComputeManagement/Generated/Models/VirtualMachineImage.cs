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
    public partial class VirtualMachineImage : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.plan")]
        public PurchasePlan Plan { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.osDiskImage")]
        public OSDiskImage OsDiskImage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.dataDiskImages")]
        public IList<DataDiskImage> DataDiskImages { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
