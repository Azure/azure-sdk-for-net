// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

namespace Azure.CloudMachine;

internal class RoleResolver(Dictionary<Provisionable, (string RoleName, string RoleId)[]> annotations, IEnumerable<UserAssignedIdentity> managedIdentities, IEnumerable<BicepValue<Guid>> userPrincipals) : InfrastructureResolver
{
    public override IEnumerable<Provisionable> ResolveResources(IEnumerable<Provisionable> resources, ProvisioningBuildOptions options)
    {
        foreach (Provisionable provisionable in base.ResolveResources(resources, options))
        {
            yield return provisionable;
            if (annotations.TryGetValue(provisionable, out (string RoleName, string RoleId)[]? roles) && provisionable is ProvisionableResource resource && roles is not null)
            {
                foreach ((string RoleName, string RoleId) in roles)
                {
                    foreach (BicepValue<Guid> userPrincipal in userPrincipals)
                    {
                        yield return new RoleAssignment($"{resource.BicepIdentifier}_{userPrincipal.Value.ToString().Replace('-', '_')}_{RoleName}")
                        {
                            Name = BicepFunction.CreateGuid(resource.BicepIdentifier, userPrincipal, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId)),
                            Scope = new IdentifierExpression(resource.BicepIdentifier),
                            PrincipalType = RoleManagementPrincipalType.User,
                            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId),
                            PrincipalId = userPrincipal
                        };
                    }

                    foreach (UserAssignedIdentity identity in managedIdentities)
                    {
                        yield return new RoleAssignment($"{resource.BicepIdentifier}_{identity.BicepIdentifier}_{RoleName}")
                        {
                            Name = BicepFunction.CreateGuid(resource.BicepIdentifier, identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId)),
                            Scope = new IdentifierExpression(resource.BicepIdentifier),
                            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId),
                            PrincipalId = identity.PrincipalId
                        };
                    }
                }
            }
        }
    }
}
