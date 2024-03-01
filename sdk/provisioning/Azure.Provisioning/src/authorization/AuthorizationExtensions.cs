// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.Provisioning.Authorization
{
    /// <summary>
    /// Extension methods for authorization.
    /// </summary>
    public static class AuthorizationExtensions
    {
        /// <summary>
        /// Assigns a role to the resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="roleDefinition">The role definition.</param>
        /// <param name="principalId">The principal ID. If not specified, a principalId parameter will be added to the resulting bicep module.</param>
        /// <param name="principalType">The principal type. If not specified, ServicePrincipal is used.</param>
        public static RoleAssignment AssignRole(
            this Resource resource,
            RoleDefinition roleDefinition,
            Guid? principalId = default,
            RoleManagementPrincipalType? principalType = default)
        {
            return new RoleAssignment(resource, roleDefinition, principalId, principalType);
        }
    }
}
