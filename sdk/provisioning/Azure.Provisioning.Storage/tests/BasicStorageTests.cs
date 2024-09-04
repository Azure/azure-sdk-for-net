// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class BasicStorageTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [RecordedTest]
    public async Task CreateDefault()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(StorageResources.CreateAccount("storage"))
        .Compare(
            """
            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('storage${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: resourceGroup().location
                sku: {
                    name: 'Standard_LRS'
                }
                properties: {
                    allowBlobPublicAccess: false
                    isHnsEnabled: true
                }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    public async Task CreateSimpleBlobs()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                StorageAccount storage = StorageResources.CreateAccount(nameof(storage));
                BlobService blobs = new(nameof(blobs)) { Parent = storage };
            })
        .Compare(
            """
            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('storage${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: resourceGroup().location
                sku: {
                    name: 'Standard_LRS'
                }
                properties: {
                    allowBlobPublicAccess: false
                    isHnsEnabled: true
                }
            }

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
                name: 'default'
                parent: storage
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    public async Task AddStorageRole()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                StorageAccount storage = StorageResources.CreateAccount(nameof(storage));
                UserAssignedIdentity id = new(nameof(id));
                storage.AssignRole(StorageBuiltInRole.StorageBlobDataReader, id);
            })
        .Compare(
            """
            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('storage${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: resourceGroup().location
                sku: {
                    name: 'Standard_LRS'
                }
                properties: {
                    allowBlobPublicAccess: false
                    isHnsEnabled: true
                }
            }

            resource id 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
                name: take('id-${uniqueString(resourceGroup().id)}', 128)
                location: resourceGroup().location
            }

            resource id_StorageBlobDataReader_storage 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
                name: guid(resourceGroup().id, 'id_StorageBlobDataReader_storage')
                properties: {
                    principalId: id.properties.principalId
                    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '2a2b9908-6ea1-4ae2-8e65-a410df84e7d1')
                    principalType: 'ServicePrincipal'
                }
                scope: storage
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    public async Task GetEndpoint()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                StorageAccount storage = StorageResources.CreateAccount(nameof(storage));
                BlobService blobs = new(nameof(blobs)) { Parent = storage };
                BicepOutput endpoint = BicepOutput.Create<string>("blobs_endpoint", storage.PrimaryEndpoints.Value!.BlobUri);
            })
        .Compare(
            """
            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('storage${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: resourceGroup().location
                sku: {
                    name: 'Standard_LRS'
                }
                properties: {
                    allowBlobPublicAccess: false
                    isHnsEnabled: true
                }
            }

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
                name: 'default'
                parent: storage
            }

            output blobs_endpoint string = storage.properties.primaryEndpoints.blob
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    public async Task CreateStandardStorageAccount()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter storageAccountType = BicepParameter.Create<string>(nameof(storageAccountType), StorageSkuName.StandardLrs);
                storageAccountType.Description = "Storage Account type";

                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The storage account location.";

                StorageAccount sa =
                    new(nameof(sa))
                    {
                        Location = location,
                        Sku = new StorageSku { Name = storageAccountType },
                        Kind = StorageKind.StorageV2
                    };

                BicepOutput.Create<string>("storageAccountName", sa.Name);
                BicepOutput.Create<string>("storageAccountId", sa.Id);
            })
        .Compare(
            """
            @description('Storage Account type')
            param storageAccountType string = 'Standard_LRS'

            @description('The storage account location.')
            param location string = resourceGroup().location

            resource sa 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('sa${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: location
                sku: {
                    name: storageAccountType
                }
            }

            output storageAccountName string = sa.name

            output storageAccountId string = sa.id
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-blob-container/main.bicep")]
    public async Task CreateStorageAccountAndContainer()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter containerName = BicepParameter.Create<string>(nameof(containerName), "mycontainer");
                containerName.Description = "The container name.";

                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The storage account location.";

                StorageAccount sa =
                    new(nameof(sa))
                    {
                        Location = location,
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.StorageV2,
                        AccessTier = StorageAccountAccessTier.Hot
                    };
                BlobService blobs = new(nameof(blobs)) { Parent = sa };
                BlobContainer container =
                    new(nameof(container), StorageAccount.ResourceVersions.V2023_01_01)
                    {
                        Parent = blobs,
                        Name = containerName
                    };
            })
        .Compare(
            """
            @description('The container name.')
            param containerName string = 'mycontainer'

            @description('The storage account location.')
            param location string = resourceGroup().location

            resource sa 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('sa${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: location
                sku: {
                    name: 'Standard_LRS'
                }
                properties: {
                    accessTier: 'Hot'
                }
            }

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
                name: 'default'
                parent: sa
            }

            resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-01-01' = {
                name: containerName
                parent: blobs
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-service-encryption-create/main.bicep")]
    public async Task CreateStorageAccountWithServiceEncryption()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter storageAccountType = BicepParameter.Create<string>(nameof(storageAccountType), StorageSkuName.StandardLrs);
                storageAccountType.Description = "Storage Account type";

                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The storage account location.";

                StorageAccount sa =
                    new(nameof(sa))
                    {
                        Location = location,
                        Sku = new StorageSku { Name = storageAccountType },
                        Kind = StorageKind.Storage,
                        Encryption =
                            new StorageAccountEncryption
                            {
                                KeySource = StorageAccountKeySource.Storage,
                                Services =
                                    new StorageAccountEncryptionServices
                                    {
                                        Blob = new StorageEncryptionService { IsEnabled = true }
                                    }
                            }
                    };

                BicepOutput.Create<string>("storageAccountName", sa.Name);
                BicepOutput.Create<string>("storageAccountId", sa.Id);
            })
        .Compare(
            """
            @description('Storage Account type')
            param storageAccountType string = 'Standard_LRS'

            @description('The storage account location.')
            param location string = resourceGroup().location

            resource sa 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('sa${uniqueString(resourceGroup().id)}', 24)
                kind: 'Storage'
                location: location
                sku: {
                    name: storageAccountType
                }
                properties: {
                    encryption: {
                        services: {
                            blob: {
                                enabled: true
                            }
                        }
                        keySource: 'Microsoft.Storage'
                    }
                }
            }

            output storageAccountName string = sa.name

            output storageAccountId string = sa.id
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.storage/storage-account-create/main.bicep")]
    public async Task CreateFileShare ()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                StorageAccount sa =
                    new(nameof(sa), StorageAccount.ResourceVersions.V2023_01_01)
                    {
                        Location = AzureLocation.WestUS2,
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.StorageV2
                    };
                FileService files = new(nameof(files)) { Parent = sa };
                FileShare share =
                    new(nameof(share), StorageAccount.ResourceVersions.V2023_01_01)
                    {
                        Parent = files,
                        Name = "photos"
                    };
            })
        .Compare(
            """
            resource sa 'Microsoft.Storage/storageAccounts@2023-01-01' = {
                name: take('sa${uniqueString(resourceGroup().id)}', 24)
                kind: 'StorageV2'
                location: 'westus2'
                sku: {
                    name: 'Standard_LRS'
                }
            }

            resource files 'Microsoft.Storage/storageAccounts/fileServices@2023-01-01' = {
                name: 'default'
                parent: sa
            }

            resource share 'Microsoft.Storage/storageAccounts/fileServices/shares@2023-01-01' = {
                name: 'photos'
                parent: files
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
