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
        private static readonly ResourceType ResourceType = "Microsoft.Authorization/roleAssignments";
        private static readonly ResourceType RoleDefinitionResourceType = "Microsoft.Authorization/roleDefinitions";

        private const string SubscriptionResourceIdFunction = "subscriptionResourceId";

        internal RoleAssignment(
            Resource resource,
            RoleDefinition roleDefinition,
            Guid? principalId = default,
            RoleManagementPrincipalType? principalType = default)
            : base(
                resource.Scope,
                resource,
                // will be overriden
                resource.Name,
                ResourceType,
                // https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/authorization/Azure.ResourceManager.Authorization/src/Generated/RestOperations/RoleAssignmentsRestOperations.cs#L36
                "2022-04-01",
                (name) => ArmAuthorizationModelFactory.RoleAssignmentData(
                    name: name,
                    principalId: principalId,
                    roleDefinitionId: ResourceIdentifier.Parse($"/providers/{RoleDefinitionResourceType}/{roleDefinition}"),
                    principalType: principalType ?? RoleManagementPrincipalType.ServicePrincipal))
        {
            if (resource.Scope.Configuration?.UseInteractiveMode != true && principalId == null)
            {
                throw new InvalidOperationException("PrincipalId must be specified when not in interactive mode.");
            }

            if (principalId == null)
            {
                AssignProperty(data => data.PrincipalId, new Parameter("principalId"));
            }

            AssignProperty(
                data => data.Name,
                GetBicepName(resource));

            AssignProperty(
                data => data.RoleDefinitionId,
                $"{SubscriptionResourceIdFunction}({(resource.Scope.Configuration?.UseInteractiveMode != true ? "'"+ Id.SubscriptionId + "', ": string.Empty)}" +
                $"'{RoleDefinitionResourceType}', '{roleDefinition}')");
        }

        /// <inheritdoc />
        protected override string GetBicepName(Resource resource)
        {
            var data = (RoleAssignmentData)ResourceData;
            return
                $"guid({resource.Name}.id, {(data.PrincipalId == null ? "principalId" : "'" + data.PrincipalId + "'")}," +
                $" {SubscriptionResourceIdFunction}({(resource.Scope.Configuration?.UseInteractiveMode != true ? "'" + Id.SubscriptionId + "', " : string.Empty)}" +
                $"'{RoleDefinitionResourceType}', '{data.RoleDefinitionId.Name}'))";
        }

        /// <inheritdoc />
        protected override bool NeedsScope() => true;

        /// <inheritdoc />
        protected override bool NeedsParent() => false;
    }
}
