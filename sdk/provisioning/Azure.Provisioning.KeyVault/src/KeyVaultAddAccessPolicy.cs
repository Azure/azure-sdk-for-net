// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.Provisioning.KeyVaults
{
    internal class KeyVaultAddAccessPolicy : Resource<KeyVaultAccessPolicyParameters>
    {
        private const string ResourceTypeName = "Microsoft.KeyVault/vaults/accessPolicies";

        public KeyVaultAddAccessPolicy(IConstruct scope, Parameter principalIdParameter, KeyVault? parent = default, string version = "2023-02-01", AzureLocation? location = default)
            : base(scope, parent, "add", ResourceTypeName, version, (name) => ArmKeyVaultModelFactory.KeyVaultAccessPolicyParameters(
                name: "add",
                resourceType: ResourceTypeName,
                accessPolicies: new List<KeyVaultAccessPolicy>
                {
                    new KeyVaultAccessPolicy(
                        // this value will be replaced by the tenant().tenantId expression
                        Guid.Empty,
                        // this value will be replaced by the parameter reference
                        "dummy",
                        new IdentityAccessPermissions()
                        {
                            Secrets =
                            {
                                IdentityAccessSecretPermission.Get,
                                IdentityAccessSecretPermission.List
                            }
                        })
                }))
        {
            AssignProperty(p => p.AccessPolicies[0].ObjectId, principalIdParameter);
            AssignProperty(p => p.AccessPolicies[0].TenantId, Tenant.TenantIdExpression);
        }

        private static string GetParamValue(Parameter principalIdParameter, IConstruct scope)
        {
            if (principalIdParameter.Source is null || ReferenceEquals(principalIdParameter.Source, scope))
            {
                return principalIdParameter.Value!;
            }
            else
            {
                return $"{principalIdParameter.Source.Name}.outputs.{principalIdParameter.Name}";
            }
        }

        protected override Resource? FindParentInScope(IConstruct scope)
        {
            var result = base.FindParentInScope(scope);
            if (result is null)
            {
                result = scope.GetSingleResource<KeyVault>() ?? new KeyVault(scope, name: "kv");
            }
            return result;
        }
    }
}
