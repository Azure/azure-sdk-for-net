// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Primitives;

namespace Azure.Projects.KeyVault;

public class KeyVaultFeature : AzureProjectFeature
{
    public KeyVaultSku Sku { get; set; }

    public KeyVaultFeature(KeyVaultSku? sku = default)
    {
        sku ??= new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };
        Sku = sku;
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        // Add a KeyVault to the infrastructure.
        KeyVaultService kv = new("cm_kv")
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
        infrastructure.AddConstruct(kv);

        infrastructure.AddSystemRole(
            kv,
            KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator),
            KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()
        );

        EmitConnection(infrastructure,
            "Azure.Security.KeyVault.Secrets.SecretClient",
            $"https://{infrastructure.ProjectId}.vault.azure.net/"
        );

        return kv;
    }
}
