// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Authorization.Models
{
    public readonly partial struct RoleManagementPrincipalType
    {
        // The stable 2022-04-01 API added agent principal values through a new TypeSpec union.
        // Keep the shipped extensible enum type and expose the new service values on it.

        /// <summary> Agent identity derived from a user. </summary>
        public static RoleManagementPrincipalType AgentUser { get; } = new RoleManagementPrincipalType("AgentUser");

        /// <summary> Agent identity derived from a service principal. </summary>
        public static RoleManagementPrincipalType AgentServicePrincipal { get; } = new RoleManagementPrincipalType("AgentServicePrincipal");
    }
}
