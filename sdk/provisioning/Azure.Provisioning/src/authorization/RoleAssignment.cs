// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.Provisioning.Authorization
{
    /// <summary>
    /// Role assignment resource.
    /// </summary>
    public class RoleAssignment : Resource<RoleAssignmentData>
    {
        internal static readonly ResourceType ResourceType = "Microsoft.Resources/roleAssignments";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAssignment"/>.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="resource"></param>
        /// <param name="roleDefinition"></param>
        /// <param name="principalId"></param>
        /// <param name="principalType"></param>
        internal RoleAssignment(
            IConstruct scope,
            Resource resource,
            RoleDefinition roleDefinition,
            Guid? principalId,
            RoleManagementPrincipalType principalType)
            : base(
                scope,
                resource,
                // TODO use guid bicep function?
                $"{resource.Name}{principalId}{roleDefinition}",
                ResourceType,
                "2022-04-01",
                (name) => ArmAuthorizationModelFactory.RoleAssignmentData(
                    name: name,
                    roleDefinitionId: ResourceIdentifier.Parse($"/providers/Microsoft.Authorization/roleDefinitions/{roleDefinition}"),
                    principalId: principalId,
                    principalType: principalType))
        {
        }
    }
}
