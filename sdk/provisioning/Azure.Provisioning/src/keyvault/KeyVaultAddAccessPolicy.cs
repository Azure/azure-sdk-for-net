// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.Provisioning.KeyVaults
{
    internal class KeyVaultAddAccessPolicy : Resource<KeyVaultAccessPolicyParameters>
    {
        private const string ResourceTypeName = "Microsoft.KeyVault/vaults/accessPolicies";

        public KeyVaultAddAccessPolicy(IConstruct scope, Parameter principalIdParameter, KeyVault? parent = default, string version = "2023-02-01", AzureLocation? location = default)
            : base(scope, parent, "add", ResourceTypeName, version, ArmKeyVaultModelFactory.KeyVaultAccessPolicyParameters(
                name: "add",
                resourceType: ResourceTypeName,
                accessPolicies: new List<KeyVaultAccessPolicy>
                {
                    new KeyVaultAccessPolicy(
                        Guid.Parse(Environment.GetEnvironmentVariable("AZURE_TENANT_ID")!),
                        GetParamValue(principalIdParameter, scope),
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
            ParameterOverrides.Add(Properties, new Dictionary<string, string> { { "objectId", GetParamValue(principalIdParameter, scope) } });
        }

        private static string GetParamValue(Parameter principalIdParameter, IConstruct scope)
        {
            if (principalIdParameter.Source is null || ReferenceEquals(principalIdParameter.Source, scope))
            {
                return principalIdParameter.Name;
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
                result = scope.GetSingleResource<KeyVault>() ?? new KeyVault(scope, "kv");
            }
            return result;
        }
    }
}
