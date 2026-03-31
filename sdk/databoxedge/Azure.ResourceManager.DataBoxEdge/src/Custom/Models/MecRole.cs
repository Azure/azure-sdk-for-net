// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated flattened RoleStatus property is non-nullable (DataBoxEdgeRoleStatus), but baseline API had nullable type.
// This Custom/ property shadows the generated one to restore nullable type signature for backward compatibility.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class MecRole
    {
        /// <summary> Role status. </summary>
        public DataBoxEdgeRoleStatus? RoleStatus
        {
            get => Properties?.RoleStatus;
            set
            {
                if (Properties is null)
                    Properties = new MECRoleProperties();
                if (value.HasValue)
                    Properties.RoleStatus = value.Value;
            }
        }
    }
}
