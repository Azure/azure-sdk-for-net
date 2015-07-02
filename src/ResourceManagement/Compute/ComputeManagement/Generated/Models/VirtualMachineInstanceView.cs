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
    public partial class VirtualMachineInstanceView
    {
        /// <summary>
        /// Gets or sets the Update Domain count.
        /// </summary>
        [JsonProperty(PropertyName = "platformUpdateDomain")]
        public int? PlatformUpdateDomain { get; set; }

        /// <summary>
        /// Gets or sets the Fault Domain count.
        /// </summary>
        [JsonProperty(PropertyName = "platformFaultDomain")]
        public int? PlatformFaultDomain { get; set; }

        /// <summary>
        /// Gets or sets the Remote desktop certificate thumbprint.
        /// </summary>
        [JsonProperty(PropertyName = "rdpThumbPrint")]
        public string RdpThumbPrint { get; set; }

        /// <summary>
        /// Gets or sets the VM Agent running on the virtual machine.
        /// </summary>
        [JsonProperty(PropertyName = "vmAgent")]
        public VirtualMachineAgentInstanceView VmAgent { get; set; }

        /// <summary>
        /// Gets or sets the the disks information.
        /// </summary>
        [JsonProperty(PropertyName = "disks")]
        public IList<DiskInstanceView> Disks { get; set; }

        /// <summary>
        /// Gets or sets the extensions information.
        /// </summary>
        [JsonProperty(PropertyName = "extensions")]
        public IList<VirtualMachineExtensionInstanceView> Extensions { get; set; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        [JsonProperty(PropertyName = "statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.VmAgent != null)
            {
                this.VmAgent.Validate();
            }
            if (this.Disks != null)
            {
                foreach ( var element in this.Disks)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.Extensions != null)
            {
                foreach ( var element1 in this.Extensions)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
            if (this.Statuses != null)
            {
                foreach ( var element2 in this.Statuses)
            {
                if (element2 != null)
            {
                element2.Validate();
            }
            }
            }
        }
    }
}
