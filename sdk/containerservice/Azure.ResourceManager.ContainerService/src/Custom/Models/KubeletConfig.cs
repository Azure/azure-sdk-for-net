// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class KubeletConfig
    {
        /// <summary> If set to true it will make the Kubelet fail to start if swap is enabled on the node. </summary>
        [WirePath("failSwapOn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FailStartWithSwapOn { get => ShouldFailStartWithSwapOn; set => ShouldFailStartWithSwapOn = value; }
    }
}
