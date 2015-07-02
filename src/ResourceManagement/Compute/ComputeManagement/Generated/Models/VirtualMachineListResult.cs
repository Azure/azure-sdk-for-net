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
    public partial class VirtualMachineListResult
    {
        /// <summary>
        /// Gets or sets the list of virtual machines.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<VirtualMachine> Value { get; set; }

        /// <summary>
        /// Gets or sets the uri to fetch the next page of VMs. Call
        /// ListNext() with this to fetch the next page of Virtual Machines.
        /// </summary>
        [JsonProperty(PropertyName = "@odata.nextLink")]
        public string OdatanextLink { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Value != null)
            {
                foreach ( var element in this.Value)
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
