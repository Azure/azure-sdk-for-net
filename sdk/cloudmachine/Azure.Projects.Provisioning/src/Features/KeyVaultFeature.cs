// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;

namespace Azure.Projects;

public class KeyVaultFeature : AzureProjectFeature
{
    public KeyVaultSku Sku { get; set; }

    public KeyVaultFeature()
    {
        Sku = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A };
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        // Add a KeyVault to the infrastructure.
        KeyVaultService kv = new("keyVault", KeyVaultService.ResourceVersions.V2023_07_01)
        {
            Name = infrastructure.ProjectId,
            Properties =
                new KeyVaultProperties
                {
                    Sku = Sku,
                    TenantId = BicepFunction.GetSubscription().TenantId,
                    EnabledForDeployment = true,
                    AccessPolicies = [
                        new KeyVaultAccessPolicy() {
                            ObjectId = infrastructure.PrincipalIdParameter,
                            Permissions = new IdentityAccessPermissions() {
                                Secrets =  [IdentityAccessSecretPermission.Get, IdentityAccessSecretPermission.Set]
                            },
                            TenantId = infrastructure.Identity.TenantId
                        }
                    ]
                },
        };
        infrastructure.AddConstruct(Id, kv);

        infrastructure.AddSystemRole(
            kv,
            KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator),
            KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()
        );

        EmitConnection(infrastructure,
            "Azure.Security.KeyVault.Secrets.SecretClient",
            $"https://{infrastructure.ProjectId}.vault.azure.net/"
        );
    }
}
