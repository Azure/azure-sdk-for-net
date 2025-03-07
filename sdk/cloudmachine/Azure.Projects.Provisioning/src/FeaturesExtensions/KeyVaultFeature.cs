// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Primitives;
using System.ClientModel.Primitives;

namespace Azure.Projects.KeyVault;

public class KeyVaultFeature : AzureProjectFeature
{
    public KeyVaultSku Sku { get; set; }

    public KeyVaultFeature(KeyVaultSku? sku = default)
    {
        sku ??= new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };
        Sku = sku;
    }

    protected internal override void EmitConnections(ICollection<System.ClientModel.Primitives.ClientConnection> connections, string cmId)
    {
        connections.Add(new ClientConnection("Azure.Security.KeyVault.Secrets.SecretClient", $"https://{cmId}.vault.azure.net/"));
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        // Add a KeyVault to the infrastructure.
        KeyVaultService keyVaultResource = new("cm_kv")
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
        infrastructure.AddResource(keyVaultResource);

        FeatureRole kvAdmin = new(KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator), KeyVaultBuiltInRole.KeyVaultAdministrator.ToString());
        RequiredSystemRoles.Add(keyVaultResource, [kvAdmin]);

        return keyVaultResource;
    }
}
