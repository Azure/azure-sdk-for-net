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

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Ssh != null)
            {
                this.Ssh.Validate();
            }
        }
    }
}
