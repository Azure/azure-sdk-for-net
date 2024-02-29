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

        internal RoleAssignment(
            Resource resource,
            RoleDefinition roleDefinition,
            Guid? principalId = default)
            : base(
                resource.Scope,
                resource,
                resource.Name,
                ResourceType,
                "2022-04-01",
                (name) => ArmAuthorizationModelFactory.RoleAssignmentData(
                    name: name,
                    principalId: principalId))
        {
            if (resource.Scope.Configuration?.UseInteractiveMode != true && principalId == null)
            {
                throw new InvalidOperationException("PrincipalId must be specified when not in interactive mode.");
            }

            if (principalId == null)
            {
                AssignParameter(data => data.PrincipalId, new Parameter("principalId"));
                AssignProperty(data => data.Name, $"guid('{resource.Name}', principalId, '{roleDefinition}')");
            }
            else
            {
                AssignProperty(data => data.Name, $"guid('{resource.Name}', '{principalId}', '{roleDefinition}')");
            }
            AssignProperty(data => data.RoleDefinitionId, $"subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '{roleDefinition}')");
        }

        /// <inheritdoc />
        protected override bool NeedsScope() => true;

        /// <inheritdoc />
        protected override bool NeedsParent() => false;
    }
}
