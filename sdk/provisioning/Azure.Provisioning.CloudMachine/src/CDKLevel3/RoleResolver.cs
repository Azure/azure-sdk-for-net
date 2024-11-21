// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Storage;

public class RoleResolver(Dictionary<Provisionable, string[]> annotations, UserAssignedIdentity identity) : InfrastructureResolver
{
    public override IEnumerable<Provisionable> ResolveResources(IEnumerable<Provisionable> resources, ProvisioningBuildOptions options)
    {
        foreach (Provisionable resource in base.ResolveResources(resources, options))
        {
            yield return resource;
            if (annotations.TryGetValue(resource, out string[]? roles) && resource is ProvisionableResource named && roles is not null)
            {
                int count = 1;
                foreach (string role in roles)
                {
                    yield return new RoleAssignment($"{named.BicepIdentifier}_standardroles_{count++}")
                    {
                        Name = BicepFunction.CreateGuid(named.BicepIdentifier, identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
                        Scope = new IdentifierExpression(named.BicepIdentifier),
                        PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                        RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role),
                        PrincipalId = identity.PrincipalId
                    };
                }
            }
        }
    }
}
