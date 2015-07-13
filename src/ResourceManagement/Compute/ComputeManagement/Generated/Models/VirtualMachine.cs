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
    public partial class VirtualMachine : Resource
    {
        /// <summary>
        /// Gets or sets the purchase plan when deploying virtual machine from
        /// VM Marketplace images.
        /// </summary>
        [JsonProperty(PropertyName = "plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// Gets the virtual machine child extension resources.
        /// </summary>
        [JsonProperty(PropertyName = "resources")]
        public IList<VirtualMachineExtension> Resources { get; set; }

        /// <summary>
        /// Gets or sets the hardware profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.hardwareProfile")]
        public HardwareProfile HardwareProfile { get; set; }

        /// <summary>
        /// Gets or sets the storage profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageProfile")]
        public StorageProfile StorageProfile { get; set; }

        /// <summary>
        /// Gets or sets the OS profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.osProfile")]
        public OSProfile OsProfile { get; set; }

        /// <summary>
        /// Gets or sets the network profile.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkProfile")]
        public NetworkProfile NetworkProfile { get; set; }

        /// <summary>
        /// Gets or sets the reference Id of the availailbity set to which
        /// this virtual machine belongs.
        /// </summary>
        [JsonProperty(PropertyName = "properties.availabilitySet")]
        public SubResource AvailabilitySet { get; set; }

        /// <summary>
        /// Gets the virtual machine instance view.
        /// </summary>
        [JsonProperty(PropertyName = "properties.instanceView")]
        public VirtualMachineInstanceView InstanceView { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Resources != null)
            {
                foreach ( var element in this.Resources)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.StorageProfile != null)
            {
                this.StorageProfile.Validate();
            }
            if (this.OsProfile != null)
            {
                this.OsProfile.Validate();
            }
            if (this.AvailabilitySet != null)
            {
                this.AvailabilitySet.Validate();
            }
            if (this.InstanceView != null)
            {
                this.InstanceView.Validate();
            }
        }
    }
}
