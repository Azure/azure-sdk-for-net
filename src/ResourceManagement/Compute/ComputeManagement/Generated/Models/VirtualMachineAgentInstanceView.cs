namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The instance view of the VM Agent running on the virtual machine.
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

    }
}
