// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Analytics.Synapse.AccessControl
{
    public class SynapseRoleDefinition
    {
        public SynapseRoleDefinition(string id, string name,string description, IList<SynapsePermission> permissions, IList<SynapseRoleScope> assignableScopes)
        {
            Id = id;
            Name = name;
            Description = description;
            Permissions = permissions;
            AssignableScopes = assignableScopes;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; set; }

        public IList<SynapsePermission> Permissions { get; }

        public IList<SynapseRoleScope> AssignableScopes { get; }

        // TODO: solve the missing properties
        //public SynapseRoleDefinitionType? Type { get; }

        //public string RoleName { get; set; }

        //public SynapseRoleType? RoleType { get; set; }
    }
}
