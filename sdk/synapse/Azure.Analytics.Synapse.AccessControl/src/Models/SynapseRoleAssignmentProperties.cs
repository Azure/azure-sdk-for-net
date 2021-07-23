// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Analytics.Synapse.AccessControl
{
    public class SynapseRoleAssignmentProperties
    {
        public SynapseRoleAssignmentProperties(string principalId, string roleDefinitionId, SynapseRoleScope? scope = default)
        {
            PrincipalId = principalId;
            RoleDefinitionId = roleDefinitionId;
            Scope = scope;
        }

        public string PrincipalId { get; }
        public string RoleDefinitionId { get; }
        public SynapseRoleScope? Scope { get; }
    }
}
