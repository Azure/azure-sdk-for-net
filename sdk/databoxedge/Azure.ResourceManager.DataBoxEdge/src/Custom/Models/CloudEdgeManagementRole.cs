// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generated flattened RoleStatus property is non-nullable (DataBoxEdgeRoleStatus), but baseline API had nullable type.
// This Custom/ property shadows the generated one to restore nullable type signature for backward compatibility.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class CloudEdgeManagementRole
    {
        /// <summary> Role status. </summary>
        public DataBoxEdgeRoleStatus? RoleStatus
        {
            get => Properties?.RoleStatus;
            set
            {
                if (Properties is null)
                    Properties = new CloudEdgeManagementRoleProperties();
                if (value.HasValue)
                    Properties.RoleStatus = value.Value;
            }
        }
    }
}
