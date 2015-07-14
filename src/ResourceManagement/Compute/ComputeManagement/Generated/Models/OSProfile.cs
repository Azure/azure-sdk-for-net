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
    public partial class OSProfile
    {
        /// <summary>
        /// Gets or sets the computer name.
        /// </summary>
        [JsonProperty(PropertyName = "computerName")]
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the admin user name.
        /// </summary>
        [JsonProperty(PropertyName = "adminUsername")]
        public string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the admin user password.
        /// </summary>
        [JsonProperty(PropertyName = "adminPassword")]
        public string AdminPassword { get; set; }

        /// <summary>
        /// Gets or sets a base-64 encoded string of custom data.
        /// </summary>
        [JsonProperty(PropertyName = "customData")]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the Windows Configuration of the OS profile.
        /// </summary>
        [JsonProperty(PropertyName = "windowsConfiguration")]
        public WindowsConfiguration WindowsConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the Linux Configuration of the OS profile.
        /// </summary>
        [JsonProperty(PropertyName = "linuxConfiguration")]
        public LinuxConfiguration LinuxConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the List of certificates for addition to the VM.
        /// </summary>
        [JsonProperty(PropertyName = "secrets")]
        public IList<VaultSecretGroup> Secrets { get; set; }

    }
}
