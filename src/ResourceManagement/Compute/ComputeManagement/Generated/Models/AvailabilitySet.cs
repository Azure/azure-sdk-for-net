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
        [JsonProperty(PropertyName = "properties.platformUpdateDomainCount")]
        public int? PlatformUpdateDomainCount { get; set; }

        /// <summary>
        /// Gets or sets Fault Domain count.
        /// </summary>
        [JsonProperty(PropertyName = "properties.platformFaultDomainCount")]
        public int? PlatformFaultDomainCount { get; set; }

        /// <summary>
        /// Gets or sets a list containing reference to all Virtual Machines
        /// created under this Availability Set.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualMachines")]
        public IList<SubResource> VirtualMachines { get; set; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        [JsonProperty(PropertyName = "properties.statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
