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
    public partial class AvailabilitySet : Resource
    {
        /// <summary>
        /// Gets or sets Update Domain count.
        /// </summary>
        [JsonProperty(PropertyName = "platformUpdateDomainCount")]
        public int? PlatformUpdateDomainCount { get; set; }

        /// <summary>
        /// Gets or sets Fault Domain count.
        /// </summary>
        [JsonProperty(PropertyName = "platformFaultDomainCount")]
        public int? PlatformFaultDomainCount { get; set; }

        /// <summary>
        /// Gets or sets a list containing reference to all Virtual Machines
        /// created under this Availability Set.
        /// </summary>
        [JsonProperty(PropertyName = "virtualMachines")]
        public IList<SubResource> VirtualMachines { get; set; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        [JsonProperty(PropertyName = "statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.VirtualMachines != null)
            {
                foreach ( var element in this.VirtualMachines)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.Statuses != null)
            {
                foreach ( var element1 in this.Statuses)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
        }
    }
}
