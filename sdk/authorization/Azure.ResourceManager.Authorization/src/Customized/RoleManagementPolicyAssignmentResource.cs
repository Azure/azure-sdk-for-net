// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.ResourceManager.Authorization
{
    // This class is to fix response ResourceType not match generated ResourceType
    // Generated: Microsoft.Authorization/roleManagementPolicyAssignments
    // Actual: Microsoft.Authorization/roleManagementPolicyAssignment
    //[CodeGenSuppress("ResourceType", typeof(ResourceType))]
    public partial class RoleManagementPolicyAssignmentResource
    {
        // <summary> Gets the resource type for the operations. </summary>
        //public static readonly ResourceType ResourceType = "Microsoft.Authorization/roleManagementPolicyAssignment";
    }
}
