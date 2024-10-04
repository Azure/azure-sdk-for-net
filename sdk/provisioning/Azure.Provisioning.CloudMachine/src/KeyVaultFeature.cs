// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Provisioning.CloudMachine.KeyVault;

public class KeyVaultFeature : CloudMachineFeature
{
    public KeyVaultSku Sku { get; set; } = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, };

    public override void AddTo(CloudMachineInfrastructure cm)
    {
        // Add a KeyVault to the CloudMachine infrastructure.
        KeyVaultService _keyVault = new("cm_kv")
        {
            Name = cm.Id,
            Properties =
                new KeyVaultProperties
                {
                    Sku = this.Sku,
                    TenantId = BicepFunction.GetSubscription().TenantId,
                    EnabledForDeployment = true,
                    AccessPolicies = [
                        new KeyVaultAccessPolicy() {
                            ObjectId = cm.PrincipalIdParameter,
                            Permissions = new IdentityAccessPermissions() {
                                Secrets =  [IdentityAccessSecretPermission.Get, IdentityAccessSecretPermission.Set]
                            },
                            TenantId = cm.Identity.TenantId
                        }
                    ]
                },
        };

        cm.AddResource(_keyVault);

        RoleAssignment ra = _keyVault.CreateRoleAssignment(KeyVaultBuiltInRole.KeyVaultAdministrator, RoleManagementPrincipalType.User, cm.PrincipalIdParameter);
        cm.AddResource(ra);

        // necessary until ResourceName is settable via AssignRole.
        RoleAssignment kvMiRoleAssignment = new RoleAssignment(_keyVault.ResourceName + "_" + cm.Identity.ResourceName + "_" + KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator));
        kvMiRoleAssignment.Name = BicepFunction.CreateGuid(_keyVault.Id, cm.Identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()));
        kvMiRoleAssignment.Scope = new IdentifierExpression(_keyVault.ResourceName);
        kvMiRoleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        kvMiRoleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString());
        kvMiRoleAssignment.PrincipalId = cm.Identity.PrincipalId;
        cm.AddResource(kvMiRoleAssignment);
    }
}

public static class KeyVaultExtensions
{
    public static SecretClient GetKeyVaultSecretClient(this CloudMachineClient client)
    {
        return new(new($"https://{client.Id}.vault.azure.net/"), client.Credential);
    }
}
