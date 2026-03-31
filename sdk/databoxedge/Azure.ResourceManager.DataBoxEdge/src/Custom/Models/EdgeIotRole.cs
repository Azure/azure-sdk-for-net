// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generated flattened RoleStatus/HostPlatform properties are non-nullable (DataBoxEdgeRoleStatus, DataBoxEdgeOSPlatformType),
// but baseline API had nullable types (DataBoxEdgeRoleStatus?, DataBoxEdgeOSPlatformType?). These Custom/ properties shadow
// the generated ones to restore nullable type signatures for backward compatibility.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeIotRole
    {
        /// <summary> Role status. </summary>
        public DataBoxEdgeRoleStatus? RoleStatus
        {
            get => Properties?.RoleStatus;
            set
            {
                if (Properties is null)
                    Properties = new IoTRoleProperties();
                if (value.HasValue)
                    Properties.RoleStatus = value.Value;
            }
        }

        /// <summary> Host OS supported by the IoT role. </summary>
        public DataBoxEdgeOSPlatformType? HostPlatform
        {
            get => Properties?.HostPlatform;
            set
            {
                if (Properties is null)
                    Properties = new IoTRoleProperties();
                if (value.HasValue)
                    Properties.HostPlatform = value.Value;
            }
        }
    }
}
