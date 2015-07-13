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
    public partial class VirtualMachineExtensionImage : SubResource
    {
        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags attached to the resource.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the operating system this extension supports.
        /// </summary>
        [JsonProperty(PropertyName = "properties.operatingSystem")]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the type of role (IaaS or PaaS) this extension
        /// supports.
        /// </summary>
        [JsonProperty(PropertyName = "properties.computeRole")]
        public string ComputeRole { get; set; }

        /// <summary>
        /// Gets or sets the schema defined by publisher, where extension
        /// consumers should provide settings in a matching schema.
        /// </summary>
        [JsonProperty(PropertyName = "properties.handlerSchema")]
        public string HandlerSchema { get; set; }

        /// <summary>
        /// Gets or sets whether the extension can be used on xRP
        /// VMScaleSets.By default existing extensions are usable on
        /// scalesets, but there might be cases where a publisher wants to
        /// explicitly indicate the extension is only enabled for CRP VMs but
        /// not VMSS.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vmScaleSetEnabled")]
        public bool? VmScaleSetEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether the handler can support multiple extensions.
        /// </summary>
        [JsonProperty(PropertyName = "properties.supportsMultipleExtensions")]
        public bool? SupportsMultipleExtensions { get; set; }

    }
}
