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
    public partial class VirtualMachineImageResourceList
    {
        /// <summary>
        /// Gets a list of virtual machine image resources.
        /// </summary>
        [JsonProperty(PropertyName = "Resources")]
        public IList<Resource> Resources { get; set; }

    }
}
