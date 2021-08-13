// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    public class SynapseRoleAssignmentProperties
    {
        public SynapseRoleAssignmentProperties(Guid principalId, SynapseRoleScope? scope = default, SynapsePrincipalType? principalType = default)
        {
            PrincipalId = principalId;
            Scope = scope;
            PrincipalType = principalType;
        }

        internal SynapseRoleAssignmentProperties(Guid principalId, Guid roleDefinitionId, SynapseRoleScope? scope = default, SynapsePrincipalType? principalType = default)
        {
            PrincipalId = principalId;
            RoleDefinitionId = roleDefinitionId;
            Scope = scope;
            PrincipalType = principalType;
        }

        public Guid PrincipalId { get; }
        public Guid RoleDefinitionId { get; }
        public SynapseRoleScope? Scope { get; }
        public SynapsePrincipalType? PrincipalType { get; }
    }
}
