// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed ControlPlaneNodeCount as a flat
    // property. The new TypeSpec-generated code nests it under
    // ControlPlaneNodeConfiguration.Count. This property preserves the old flat access pattern
    // to avoid breaking existing consumers.
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
