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
    public partial class VirtualMachineExtension : Resource
    {
        /// <summary>
        /// Gets or sets the name of the extension handler publisher.
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the type version of the extension handler.
        /// </summary>
        [JsonProperty(PropertyName = "typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }

        /// <summary>
        /// Gets or sets whether the extension handler should be automatically
        /// upgraded across minor versions.
        /// </summary>
        [JsonProperty(PropertyName = "autoUpgradeMinorVersion")]
        public bool? AutoUpgradeMinorVersion { get; set; }

        /// <summary>
        /// Gets or sets Json formatted public settings for the extension.
        /// </summary>
        [JsonProperty(PropertyName = "settings")]
        public object Settings { get; set; }

        /// <summary>
        /// Gets or sets Json formatted protected settings for the extension.
        /// </summary>
        [JsonProperty(PropertyName = "protectedSettings")]
        public object ProtectedSettings { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine extension instance view.
        /// </summary>
        [JsonProperty(PropertyName = "instanceView")]
        public VirtualMachineExtensionInstanceView InstanceView { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.InstanceView != null)
            {
                this.InstanceView.Validate();
            }
        }
    }
}
