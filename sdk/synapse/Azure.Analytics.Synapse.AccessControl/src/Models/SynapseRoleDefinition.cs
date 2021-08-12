// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

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

        public static implicit operator RequestContent(SynapseRoleDefinition value) => RequestContent.Create(
            new {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Permissions = value.Permissions,
                AssignableScopes = value.AssignableScopes
            });

        // TODO: solve the missing properties, in order to bring this type into alignment with ARM and KeyVault RBAC APIs
        //public SynapseRoleDefinitionType? Type { get; }

        //public string RoleName { get; set; }

        //public SynapseRoleType? RoleType { get; set; }
    }
}
