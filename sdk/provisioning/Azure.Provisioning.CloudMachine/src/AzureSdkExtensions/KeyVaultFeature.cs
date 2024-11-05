// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;

namespace Azure.Provisioning.CloudMachine.KeyVault;

public class KeyVaultFeature : CloudMachineFeature
{
    public KeyVaultSku Sku { get; set; }

    public KeyVaultFeature(KeyVaultSku? sku = default)
    {
        if (sku == null)
        {
            sku = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };
        }
        Sku = sku;
    }
    public override void AddTo(CloudMachineInfrastructure infrastructure)
    {
        // Add a KeyVault to the CloudMachine infrastructure.
        KeyVaultService keyVaultResource = new("cm_kv")
        {
            Name = infrastructure.Id,
            Properties =
                new KeyVaultProperties
                {
                    Sku = this.Sku,
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

        RoleAssignment ra = keyVaultResource.CreateRoleAssignment(KeyVaultBuiltInRole.KeyVaultAdministrator, RoleManagementPrincipalType.User, infrastructure.PrincipalIdParameter);
        infrastructure.AddResource(ra);

        // necessary until ResourceName is settable via AssignRole.
        RoleAssignment kvMiRoleAssignment = new RoleAssignment(keyVaultResource.BicepIdentifier + "_" + infrastructure.Identity.BicepIdentifier + "_" + KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator));
        kvMiRoleAssignment.Name = BicepFunction.CreateGuid(keyVaultResource.Id, infrastructure.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()));
        kvMiRoleAssignment.Scope = new IdentifierExpression(keyVaultResource.BicepIdentifier);
        kvMiRoleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        kvMiRoleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString());
        kvMiRoleAssignment.PrincipalId = infrastructure.Identity.PrincipalId;
        infrastructure.AddResource(kvMiRoleAssignment);
    }
}
