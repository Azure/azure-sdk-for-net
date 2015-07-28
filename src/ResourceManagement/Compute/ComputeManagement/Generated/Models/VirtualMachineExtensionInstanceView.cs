namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The instance view of a virtual machine extension.
    /// </summary>
    public partial class VirtualMachineExtensionInstanceView
    {
        /// <summary>
        /// Gets or sets the virtual machine extension name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full type of the extension handler which includes
        /// both publisher and type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the type version of the extension handler.
        /// </summary>
        [JsonProperty(PropertyName = "typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        [JsonProperty(PropertyName = "substatuses")]
        public IList<InstanceViewStatus> Substatuses { get; set; }

        /// <summary>
        /// Gets or sets the resource status information.
        /// </summary>
        [JsonProperty(PropertyName = "statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }

    }
}
