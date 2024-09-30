// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Provisioning.CloudMachine;

public static class KeyVaultExtensions
{
    public static void AddKeyVault(this CloudMachineInfrastructure cm)
    {
        // Add a KeyVault to the CloudMachine infrastructure.
        KeyVaultService _keyVault = new($"cm_kv")
        {
            Properties =
                new KeyVaultProperties
                {
                    Sku = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A, },
                    TenantId = BicepFunction.GetSubscription().TenantId,
                    EnabledForDeployment = true,
                }
        };

        cm.AddResource(_keyVault);
        cm.AddResource(_keyVault.AssignRole(KeyVaultBuiltInRole.KeyVaultAdministrator, RoleManagementPrincipalType.User, cm.PrincipalIdParameter));
        // necessary until ResourceName is settable via AssignRole.
        RoleAssignment kvMiRoleAssignment = new RoleAssignment(_keyVault.ResourceName + "_" + cm._identity.ResourceName + "_" + KeyVaultBuiltInRole.GetBuiltInRoleName(KeyVaultBuiltInRole.KeyVaultAdministrator));
        kvMiRoleAssignment.Name = BicepFunction.CreateGuid(_keyVault.Id, cm._identity.Id, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString()));
        kvMiRoleAssignment.Scope = new IdentifierExpression(_keyVault.ResourceName);
        kvMiRoleAssignment.PrincipalType = RoleManagementPrincipalType.ServicePrincipal;
        kvMiRoleAssignment.RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", KeyVaultBuiltInRole.KeyVaultAdministrator.ToString());
        kvMiRoleAssignment.PrincipalId = cm._identity.PrincipalId;
        cm.AddResource(kvMiRoleAssignment);
    }

    public static SecretClient GetKeyVaultSecretClient(this CloudMachineClient client){
        return new(new($"https://{client.Id}.vault.azure.net/"), client.Credential);
    }
}
