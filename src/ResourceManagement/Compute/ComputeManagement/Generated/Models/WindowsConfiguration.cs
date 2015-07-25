namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes Windows Configuration of the OS Profile.
    /// </summary>
    public partial class WindowsConfiguration
    {
        /// <summary>
        /// Gets or sets whether VM Agent should be provisioned on the Virtual
        /// Machine.
        /// </summary>
        [JsonProperty(PropertyName = "provisionVMAgent")]
        public bool? ProvisionVMAgent { get; set; }

        /// <summary>
        /// Gets or sets whether Windows updates are automatically installed
        /// on the VM
        /// </summary>
        [JsonProperty(PropertyName = "enableAutomaticUpdates")]
        public bool? EnableAutomaticUpdates { get; set; }

        /// <summary>
        /// Gets or sets the Time Zone of the VM
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the additional base-64 encoded XML formatted
        /// information that can be included in the Unattend.xml file.
        /// </summary>
        [JsonProperty(PropertyName = "additionalUnattendContent")]
        public IList<AdditionalUnattendContent> AdditionalUnattendContent { get; set; }

        /// <summary>
        /// Gets or sets the Windows Remote Management configuration of the VM
        /// </summary>
        [JsonProperty(PropertyName = "winRM")]
        public WinRMConfiguration WinRM { get; set; }

    }
}
