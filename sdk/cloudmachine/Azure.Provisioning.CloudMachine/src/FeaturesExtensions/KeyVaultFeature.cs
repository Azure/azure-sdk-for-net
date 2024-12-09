// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Primitives;

namespace Azure.CloudMachine.KeyVault;

public class KeyVaultFeature : CloudMachineFeature
{
    public KeyVaultSku Sku { get; set; }

    public KeyVaultFeature(KeyVaultSku? sku = default)
    {
        sku ??= new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };
        Sku = sku;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        connections.Add(new ClientConnection("Azure.Security.KeyVault.Secrets.SecretClient", $"https://{cmId}.vault.azure.net/"));
    }

    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure infrastructure)
    {
        // Add a KeyVault to the CloudMachine infrastructure.
        KeyVaultService keyVaultResource = new("cm_kv")
        {
            Name = infrastructure.Id,
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
        infrastructure.AddResource(keyVaultResource);
        RequiredSystemRoles.Add(keyVaultResource, [(KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator), KeyVaultBuiltInRole.KeyVaultAdministrator.ToString())]);

        return keyVaultResource;
    }
}
