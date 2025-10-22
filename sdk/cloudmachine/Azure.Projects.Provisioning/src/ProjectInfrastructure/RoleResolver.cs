// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;

namespace Azure.Projects;

internal readonly struct FeatureRole
{
    public FeatureRole(string name, string id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; }
    public string Id { get; }
}

internal class RoleResolver(string id, Dictionary<Provisionable, List<FeatureRole>> annotations, IEnumerable<UserAssignedIdentity> managedIdentities, IEnumerable<BicepValue<Guid>> userPrincipals) : InfrastructureResolver
{
    private static string RoleAssignmentVersion =>
        RoleAssignment.ResourceVersions.V2022_04_01;

    public override IEnumerable<Provisionable> ResolveResources(IEnumerable<Provisionable> resources, ProvisioningBuildOptions options)
    {
        Dictionary<string, int> roleCount = new();
        foreach (Provisionable provisionable in base.ResolveResources(resources, options))
        {
            yield return provisionable;
            if (annotations.TryGetValue(provisionable, out List<FeatureRole>? roles) && provisionable is ProvisionableResource resource && roles is not null)
            {
                foreach (FeatureRole role in roles)
                {
                    foreach (BicepValue<Guid> userPrincipal in userPrincipals)
                    {
                        string roleKey = $"{resource.BicepIdentifier}_{userPrincipal.Value.ToString()}_{role.Name}";
                        if (roleCount.TryGetValue(roleKey, out int count))
                        {
                            count++;
                        }
                        else
                        {
                            count = 1;
                        }
                        roleCount[roleKey] = count;

                        string bicepId = $"{resource.BicepIdentifier}_admin_{role.Name}";
                        if (count > 1) bicepId = $"{resource.BicepIdentifier}_admin_{role.Name}_{count}";
                        yield return new RoleAssignment(bicepId, RoleAssignmentVersion)
                        {
                            Name = BicepFunction.CreateGuid(resource.BicepIdentifier, id, userPrincipal, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.Id)),
                            Scope = new IdentifierExpression(resource.BicepIdentifier),
                            PrincipalType = RoleManagementPrincipalType.User,
                            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.Id),
                            PrincipalId = userPrincipal
                        };
                    }

                    foreach (UserAssignedIdentity identity in managedIdentities)
                    {
                        yield return new RoleAssignment($"{resource.BicepIdentifier}_{identity.BicepIdentifier}_{role.Name}", RoleAssignmentVersion)
                        {
                            Name = BicepFunction.CreateGuid(resource.BicepIdentifier, identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.Id)),
                            Scope = new IdentifierExpression(resource.BicepIdentifier),
                            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.Id),
                            PrincipalId = identity.PrincipalId
                        };
                    }
                }
            }
        }
    }
}
