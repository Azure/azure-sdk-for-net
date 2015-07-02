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
        [JsonProperty(PropertyName = "plan")]
        public PurchasePlan Plan { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "osDiskImage")]
        public OSDiskImage OsDiskImage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dataDiskImages")]
        public IList<DataDiskImage> DataDiskImages { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Plan != null)
            {
                this.Plan.Validate();
            }
            if (this.OsDiskImage != null)
            {
                this.OsDiskImage.Validate();
            }
            if (this.DataDiskImages != null)
            {
                foreach ( var element in this.DataDiskImages)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
        }
    }
}
