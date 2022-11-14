// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class LinuxConfiguration
    {
        /// <summary>
        /// Specifies whether password authentication should be disabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisablePasswordAuthentication { get => IsPasswordAuthenticationDisabled; set => IsPasswordAuthenticationDisabled = value; }
        /// <summary>
        /// Indicates whether VMAgent Platform Updates is enabled for the Linux virtual machine. Default value is false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableVmAgentPlatformUpdates { get => IsVmAgentPlatformUpdatesEnabled; set => IsVmAgentPlatformUpdatesEnabled = value; }
    }
}
