// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class UpgradeOverrideSettings
    {
        /// <summary> Whether to force upgrade the cluster. </summary>
        [WirePath("forceUpgrade")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ForceUpgrade { get => IsForceUpgradeEnabled; set => IsForceUpgradeEnabled = value; }
    }
}
