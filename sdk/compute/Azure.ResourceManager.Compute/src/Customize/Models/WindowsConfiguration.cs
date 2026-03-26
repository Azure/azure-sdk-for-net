// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class WindowsConfiguration
    {
        /// <summary> Indicates whether Automatic Updates is enabled for the Windows virtual machine. Default value is true. &lt;br&gt;&lt;br&gt; For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutomaticUpdates { get; set; }

        /// <summary> Indicates whether VMAgent Platform Updates is enabled for the Windows virtual machine. Default value is false. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsVmAgentPlatformUpdatesEnabled { get => EnableVMAgentPlatformUpdates; }
    }
}
