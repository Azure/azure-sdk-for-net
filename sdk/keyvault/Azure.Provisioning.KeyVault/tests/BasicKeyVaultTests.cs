// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KeyVault.Tests;

public class BasicKeyVaultTests
{
    internal static Trycep CreateKeyVaultAndSecretTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:KeyVaultBasic
                Infrastructure infra = new();

                ProvisioningParameter skuName =
                    new(nameof(skuName), typeof(string))
                    {
                        Value = KeyVaultSkuName.Standard,
                        Description = "Vault type"
                    };
                infra.Add(skuName);

                ProvisioningParameter secretValue =
                    new(nameof(secretValue), typeof(string))
                    {
                        Description = "Specifies the value of the secret that you want to create.",
                        IsSecure = true
                    };
                infra.Add(secretValue);

                ProvisioningParameter objectId =
                    new(nameof(objectId), typeof(string))
                    {
                        Description = "Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault."
                    };
                infra.Add(objectId);

                ProvisioningVariable tenantId =
                    new(nameof(tenantId), typeof(string))
                    {
                        Value = BicepFunction.GetSubscription().TenantId
                    };
                infra.Add(tenantId);

                KeyVaultService kv =
                    new(nameof(kv), KeyVaultService.ResourceVersions.V2023_07_01)
                    {
                        Properties =
                            new KeyVaultProperties
                            {
                                Sku = new KeyVaultSku { Name = skuName, Family = KeyVaultSkuFamily.A, },
                                TenantId = tenantId,
                                EnableSoftDelete = true,
                                SoftDeleteRetentionInDays = 90,
                                AccessPolicies =
                                {
                                    new KeyVaultAccessPolicy
                                    {
                                        ObjectId = objectId,
                                        TenantId = tenantId,
                                        Permissions =
                                            new IdentityAccessPermissions
                                            {
                                                Keys = { IdentityAccessKeyPermission.List },
                                                Secrets = { IdentityAccessSecretPermission.List }
                                            }
                                    }
                                },
                                NetworkRuleSet =
                                    new KeyVaultNetworkRuleSet
                                    {
                                        DefaultAction = KeyVaultNetworkRuleAction.Allow,
                                        Bypass = KeyVaultNetworkRuleBypassOption.AzureServices
                                    }
                            }
                    };
                infra.Add(kv);

                KeyVaultSecret secret =
                    new(nameof(secret), KeyVaultSecret.ResourceVersions.V2023_07_01)
                    {
                        Parent = kv,
                        Name = "myDarkNecessities",
                        Properties = new SecretProperties { Value = secretValue }
                    };
                infra.Add(secret);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = kv.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = kv.Id });
                infra.Add(new ProvisioningOutput("vaultUri", typeof(string)) { Value = kv.Properties.VaultUri });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.keyvault/key-vault-create/main.bicep")]
    public async Task CreateKeyVaultAndSecret()
    {
        await using Trycep test = CreateKeyVaultAndSecretTest();
        test.Compare(
            """
            @description('Vault type')
            param skuName string = 'standard'

            @secure()
            @description('Specifies the value of the secret that you want to create.')
            param secretValue string

            @description('Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault.')
            param objectId string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            var tenantId = subscription().tenantId

            resource kv 'Microsoft.KeyVault/vaults@2023-07-01' = {
              name: take('kv-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                tenantId: tenantId
                sku: {
                  family: 'A'
                  name: skuName
                }
                accessPolicies: [
                  {
                    tenantId: tenantId
                    objectId: objectId
                    permissions: {
                      keys: [
                        'list'
                      ]
                      secrets: [
                        'list'
                      ]
                    }
                  }
                ]
                enableSoftDelete: true
                softDeleteRetentionInDays: 90
                networkAcls: {
                  bypass: 'AzureServices'
                  defaultAction: 'Allow'
                }
              }
            }

            resource secret 'Microsoft.KeyVault/vaults/secrets@2023-07-01' = {
              name: 'myDarkNecessities'
              properties: {
                value: secretValue
              }
              parent: kv
            }

            output name string = kv.name

            output resourceId string = kv.id

            output vaultUri string = kv.properties.vaultUri
            """);
    }
}
