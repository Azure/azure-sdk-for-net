// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudKubernetesClusterPatch
    {
        /// <summary> The number of virtual machines that use this configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? ControlPlaneNodeCount
        {
            get => ControlPlaneNodeConfiguration is null ? default : ControlPlaneNodeConfiguration.Count;
            set
            {
                if (ControlPlaneNodeConfiguration is null)
                    ControlPlaneNodeConfiguration = new ControlPlaneNodePatchConfiguration();
                ControlPlaneNodeConfiguration.Count = value;
            }
        }
    }
}
