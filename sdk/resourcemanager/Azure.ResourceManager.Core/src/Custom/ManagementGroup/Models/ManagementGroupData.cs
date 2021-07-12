// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    public partial class ManagementGroupData
    {
        internal ManagementGroupData(ManagementGroupInfo managementGroupInfo)
            : this(managementGroupInfo.Id, managementGroupInfo.Type, managementGroupInfo.Name, managementGroupInfo.TenantId, managementGroupInfo.DisplayName, null, new List<ManagementGroupChildInfo>())
        {
        }
    }
}
