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
    public partial class LinuxConfiguration
    {
        /// <summary>
        /// Gets or sets whether Authentication using user name and password
        /// is allowed or not
        /// </summary>
        [JsonProperty(PropertyName = "disablePasswordAuthentication")]
        public bool? DisablePasswordAuthentication { get; set; }

        /// <summary>
        /// Gets or sets the SSH configuration for linux VMs
        /// </summary>
        [JsonProperty(PropertyName = "ssh")]
        public SshConfiguration Ssh { get; set; }

    }
}
