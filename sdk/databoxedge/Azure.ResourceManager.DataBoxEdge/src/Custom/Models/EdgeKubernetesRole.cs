// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generated flattened RoleStatus/HostPlatform properties are non-nullable, but baseline API had nullable types.
// These Custom/ properties shadow the generated ones to restore nullable type signatures for backward compatibility.
// Note: Setting null is a no-op because the underlying generated property is non-nullable.
// This is an intentional trade-off — we cannot store null, but the setter must exist for API compat.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeKubernetesRole
    {
        /// <summary> Role status. </summary>
        public DataBoxEdgeRoleStatus? RoleStatus
        {
            get => Properties?.RoleStatus;
            set
            {
                if (Properties is null)
                    Properties = new KubernetesRoleProperties();
                if (value.HasValue)
                    Properties.RoleStatus = value.Value;
            }
        }

        /// <summary> Host OS supported by the Kubernetes role. </summary>
        public DataBoxEdgeOSPlatformType? HostPlatform
        {
            get => Properties?.HostPlatform;
            set
            {
                if (Properties is null)
                    Properties = new KubernetesRoleProperties();
                if (value.HasValue)
                    Properties.HostPlatform = value.Value;
            }
        }
    }
}
