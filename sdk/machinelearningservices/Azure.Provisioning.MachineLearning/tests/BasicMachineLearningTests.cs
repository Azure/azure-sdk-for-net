// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.ApplicationInsights;
using Azure.Provisioning.ContainerRegistry;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.KeyVault;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.MachineLearning.Tests;

public class BasicMachineLearningTests
{
    // Based on the Azure Quickstart template:
    // https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.machinelearningservices/machine-learning-workspace/main.bicep
    internal static Trycep CreateWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MachineLearningWorkspaceBasic
                Infrastructure infra = new();

                ProvisioningVariable tenantId =
                    new(nameof(tenantId), typeof(string))
                    {
                        Value = BicepFunction.GetSubscription().TenantId
                    };
                infra.Add(tenantId);

                StorageAccount storage =
                    new(nameof(storage), StorageAccount.ResourceVersions.V2022_05_01)
                    {
                        Kind = StorageKind.StorageV2,
                        Sku = new StorageSku { Name = StorageSkuName.StandardRagrs },
                        AllowBlobPublicAccess = false,
                        EnableHttpsTrafficOnly = true,
                        Encryption =
                            new StorageAccountEncryption
                            {
                                Services =
                                    new StorageAccountEncryptionServices
                                    {
                                        Blob = new StorageEncryptionService { IsEnabled = true },
                                        File = new StorageEncryptionService { IsEnabled = true },
                                    },
                                KeySource = StorageAccountKeySource.Storage,
                            },
                        MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_2,
                        NetworkRuleSet =
                            new StorageAccountNetworkRuleSet
                            {
                                DefaultAction = StorageNetworkDefaultAction.Deny,
                            },
                    };
                infra.Add(storage);

                KeyVaultService vault =
                    new(nameof(vault), KeyVaultService.ResourceVersions.V2022_07_01)
                    {
                        Properties =
                            new Azure.Provisioning.KeyVault.KeyVaultProperties
                            {
                                TenantId = tenantId,
                                Sku = new KeyVaultSku
                                {
                                    Family = KeyVaultSkuFamily.A,
                                    Name = KeyVaultSkuName.Standard,
                                },
                                AccessPolicies = new BicepList<KeyVaultAccessPolicy>([]),
                                EnableSoftDelete = true,
                            },
                    };
                infra.Add(vault);

                ApplicationInsightsComponent applicationInsight =
                    new(nameof(applicationInsight), ApplicationInsightsComponent.ResourceVersions.V2020_02_02)
                    {
                        Kind = "web",
                        ApplicationType = ApplicationInsightsApplicationType.Web,
                    };
                infra.Add(applicationInsight);

                ContainerRegistryService registry =
                    new(nameof(registry), ContainerRegistryService.ResourceVersions.V2022_12_01)
                    {
                        Sku = new ContainerRegistrySku { Name = ContainerRegistrySkuName.Standard },
                        IsAdminUserEnabled = false,
                    };
                infra.Add(registry);

                MachineLearningWorkspace workspace =
                    new(nameof(workspace), MachineLearningWorkspace.ResourceVersions.V2026_05_01)
                    {
                        ApplicationInsights = applicationInsight.Id,
                        ContainerRegistry = registry.Id,
                        FriendlyName = "Machine Learning workspace",
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        },
                        KeyVault = vault.Id,
                        StorageAccount = storage.Id,
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.machinelearningservices/machine-learning-workspace/main.bicep")]
    public async Task CreateWorkspace()
    {
        await using Trycep test = CreateWorkspaceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            var tenantId = subscription().tenantId

            resource storage 'Microsoft.Storage/storageAccounts@2022-05-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              kind: 'StorageV2'
              location: location
              sku: {
                name: 'Standard_RAGRS'
              }
              properties: {
                allowBlobPublicAccess: false
                supportsHttpsTrafficOnly: true
                encryption: {
                  services: {
                    blob: {
                      enabled: true
                    }
                    file: {
                      enabled: true
                    }
                  }
                  keySource: 'Microsoft.Storage'
                }
                minimumTlsVersion: 'TLS1_2'
                networkAcls: {
                  defaultAction: 'Deny'
                }
              }
            }

            resource vault 'Microsoft.KeyVault/vaults@2022-07-01' = {
              name: take('vault-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                tenantId: tenantId
                sku: {
                  family: 'A'
                  name: 'standard'
                }
                accessPolicies: []
                enableSoftDelete: true
              }
            }

            resource applicationInsight 'Microsoft.Insights/components@2020-02-02' = {
              name: take('applicationInsight-${uniqueString(resourceGroup().id)}', 260)
              kind: 'web'
              location: location
              properties: {
                Application_Type: 'web'
              }
            }

            resource registry 'Microsoft.ContainerRegistry/registries@2022-12-01' = {
              name: take('registry${uniqueString(resourceGroup().id)}', 50)
              location: location
              sku: {
                name: 'Standard'
              }
              properties: {
                adminUserEnabled: false
              }
            }

            resource workspace 'Microsoft.MachineLearningServices/workspaces@2026-05-01' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 24)
              properties: {
                applicationInsights: applicationInsight.id
                containerRegistry: registry.id
                friendlyName: 'Machine Learning workspace'
                keyVault: vault.id
                storageAccount: storage.id
              }
              identity: {
                type: 'SystemAssigned'
              }
              location: location
            }
            """);
    }
}
