// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
        /// <param name="principalId">The principal ID.</param>
        public static RoleAssignment AssignRole(this Resource resource, RoleDefinition roleDefinition, Guid? principalId = default)
        {
            return new RoleAssignment(resource, roleDefinition, principalId);
        }
    }
}
