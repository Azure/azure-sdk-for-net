// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <summary>
    /// A factory class which constructs model classes for mocking purposes.
    /// </summary>
    public static class KeyVaultModelFactory
    {
        /// <summary>
        /// Initializes a new instance of RoleDefinition.
        /// </summary>
        /// <param name="id"> The role definition ID. </param>
        /// <param name="name"> The role definition name. </param>
        /// <param name="type"> The role definition type. </param>
        /// <param name="roleName"> The role name. </param>
        /// <param name="description"> The role definition description. </param>
        /// <param name="roleType"> The role type. </param>
        /// <param name="permissions"> Role definition permissions. </param>
        /// <param name="assignableScopes"> Role definition assignable scopes. </param>
        public static RoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, IReadOnlyList<KeyVaultPermission> permissions, IReadOnlyList<string> assignableScopes) =>
            new RoleDefinition(id, name, type, roleName, description, roleType, permissions, assignableScopes);

        /// <summary>
        /// Initializes a new instance of RoleAssignment.
        /// </summary>
        /// <param name="id"> The role assignment ID. </param>
        /// <param name="name"> The role assignment name. </param>
        /// <param name="type"> The role assignment type. </param>
        /// <param name="properties"> Role assignment properties. </param>
        public static RoleAssignment RoleAssignment(string id, string name, string type, RoleAssignmentPropertiesWithScope properties) =>
            new RoleAssignment(id, name, type, properties);
    }
}
