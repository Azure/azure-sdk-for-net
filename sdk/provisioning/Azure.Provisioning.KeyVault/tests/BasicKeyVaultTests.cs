// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.KeyVault.Tests;

public class BasicKeyVaultTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.keyvault/key-vault-create/main.bicep")]
    public async Task CreateKeyVaultAndSecret()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter skuName = BicepParameter.Create<string>(nameof(skuName), KeyVaultSkuName.Standard);
                skuName.Description = "Vault type";

                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "Vault location.";

                BicepParameter secretValue = BicepParameter.Create<string>(nameof(secretValue));
                secretValue.Description = "Specifies the value of the secret that you want to create.";
                secretValue.IsSecure = true;

                BicepParameter objectId = BicepParameter.Create<string>(nameof(objectId));
                objectId.Description = "Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault.";

                BicepVariable tenantId = BicepVariable.Create<string>(nameof(tenantId), BicepFunction.GetSubscription().TenantId);

                KeyVaultService kv =
                    new(nameof(kv))
                    {
                        Location = location,
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

                KeyVaultSecret secret =
                    new(nameof(secret))
                    {
                        Parent = kv,
                        Name = "myDarkNecessities",
                        Properties = new SecretProperties { Value = secretValue }
                    };

                BicepOutput.Create<string>("name", kv.Name);
                BicepOutput.Create<string>("resourceId", kv.Id);
            })
        .Compare(
            """
            @description('Vault type')
            param skuName string = 'standard'

            @description('Vault location.')
            param location string = resourceGroup().location

            @secure()
            @description('Specifies the value of the secret that you want to create.')
            param secretValue string

            @description('Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault.')
            param objectId string

            var tenantId = subscription().tenantId

            resource kv 'Microsoft.KeyVault/vaults@2019-09-01' = {
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

            resource secret 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
                name: 'myDarkNecessities'
                properties: {
                    value: secretValue
                }
                parent: kv
            }

            output name string = kv.name

            output resourceId string = kv.id
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
