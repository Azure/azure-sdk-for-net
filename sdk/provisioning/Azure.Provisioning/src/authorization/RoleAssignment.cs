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
        private static readonly ResourceType ResourceType = "Microsoft.Resources/roleAssignments";
        private static readonly ResourceType RoleDefinitionResourceType = "Microsoft.Authorization/roleDefinitions";

        private const string SubscriptionResourceIdFunction = "subscriptionResourceId";

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
            }

            AssignProperty(
                data => data.Name,
                $"guid('{resource.Name}', {(principalId == null ? "principalId" : "'" + principalId + "'")}," +
                $" {SubscriptionResourceIdFunction}({(resource.Scope.Configuration?.UseInteractiveMode != true ? "'" + Id.SubscriptionId + "', ": string.Empty)}" +
                $"'{RoleDefinitionResourceType}', '{roleDefinition}'))");

            AssignProperty(
                data => data.RoleDefinitionId,
                $"{SubscriptionResourceIdFunction}({(resource.Scope.Configuration?.UseInteractiveMode != true ? "'"+ Id.SubscriptionId + "', ": string.Empty)}" +
                $"'{RoleDefinitionResourceType}', '{roleDefinition}')");
        }

        /// <inheritdoc />
        protected override bool NeedsScope() => true;

        /// <inheritdoc />
        protected override bool NeedsParent() => false;
    }
}
