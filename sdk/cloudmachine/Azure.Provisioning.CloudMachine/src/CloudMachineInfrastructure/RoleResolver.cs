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

internal class RoleResolver(string id, Dictionary<Provisionable, (string RoleName, string RoleId)[]> annotations, IEnumerable<UserAssignedIdentity> managedIdentities, IEnumerable<BicepValue<Guid>> userPrincipals) : InfrastructureResolver
{
    public override IEnumerable<Provisionable> ResolveResources(IEnumerable<Provisionable> resources, ProvisioningBuildOptions options)
    {
        Dictionary<string, int> roleCount = new();
        foreach (Provisionable provisionable in base.ResolveResources(resources, options))
        {
            yield return provisionable;
            if (annotations.TryGetValue(provisionable, out (string RoleName, string RoleId)[]? roles) && provisionable is ProvisionableResource resource && roles is not null)
            {
                foreach ((string RoleName, string RoleId) in roles)
                {
                    foreach (BicepValue<Guid> userPrincipal in userPrincipals)
                    {
                        string roleKey = $"{resource.BicepIdentifier}_{userPrincipal.Value.ToString()}_{RoleName}";
                        if (roleCount.TryGetValue(roleKey, out int count))
                        {
                            count = count + 1;
                        }
                        else
                        {
                            count = 1;
                        }
                        roleCount[roleKey] = count;

                        yield return new RoleAssignment($"{resource.BicepIdentifier}_{count}_{RoleName}")
                        {
                            Name = BicepFunction.CreateGuid(resource.BicepIdentifier, id, userPrincipal, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", RoleId)),
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
