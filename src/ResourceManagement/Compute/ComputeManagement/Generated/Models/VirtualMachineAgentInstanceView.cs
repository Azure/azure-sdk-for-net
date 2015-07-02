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
    public partial class VirtualMachineAgentInstanceView
    {
        /// <summary>
        /// Gets or sets the VM Agent full version.
        /// </summary>
        [JsonProperty(PropertyName = "vmAgentVersion")]
        public string VmAgentVersion { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine extension handler instance view.
        /// </summary>
        [JsonProperty(PropertyName = "extensionHandlers")]
        public IList<VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get; set; }

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
            if (this.ExtensionHandlers != null)
            {
                foreach ( var element in this.ExtensionHandlers)
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
