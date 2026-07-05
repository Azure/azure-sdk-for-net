// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DataFactory.Tests;

public class BasicDataFactoryTests
{
    internal static Trycep CreateDataFactoryWithLinkedServiceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DataFactoryBasic
                Infrastructure infra = new();

                ProvisioningParameter connectionString =
                    new(nameof(connectionString), typeof(string))
                    {
                        Description = "The connection string for the storage account.",
                        IsSecure = true
                    };
                infra.Add(connectionString);

                DataFactoryService dataFactory =
                    new(nameof(dataFactory), DataFactoryService.ResourceVersions.V2018_06_01)
                    {
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        }
                    };
                infra.Add(dataFactory);

                DataFactoryLinkedService linkedService =
                    new(nameof(linkedService), DataFactoryLinkedService.ResourceVersions.V2018_06_01)
                    {
                        Parent = dataFactory,
                        Name = "ArmtemplateStorageLinkedService",
                        Properties = new AzureBlobStorageLinkedService
                        {
                            ConnectionString = connectionString
                        }
                    };
                infra.Add(linkedService);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = dataFactory.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = dataFactory.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.datafactory/data-factory-v2-blob-to-blob-copy/main.bicep")]
    public async Task CreateDataFactoryWithLinkedService()
    {
        await using Trycep test = CreateDataFactoryWithLinkedServiceTest();
        test.Compare(
            """
            @secure()
            @description('The connection string for the storage account.')
            param connectionString string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource dataFactory 'Microsoft.DataFactory/factories@2018-06-01' = {
              name: take('dataFactory-${uniqueString(resourceGroup().id)}', 63)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
            }

            resource linkedService 'Microsoft.DataFactory/factories/linkedservices@2018-06-01' = {
              name: 'ArmtemplateStorageLinkedService'
              properties: {
                type: 'AzureBlobStorage'
                typeProperties: {
                  connectionString: connectionString
                }
              }
              parent: dataFactory
            }

            output name string = dataFactory.name

            output resourceId string = dataFactory.id
            """);
    }

    internal static Trycep CreateDataFactoryWithGitConfigAndManagedVnetTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DataFactoryGitConfigManagedVnet
                Infrastructure infra = new();

                ProvisioningParameter gitAccountName =
                    new(nameof(gitAccountName), typeof(string))
                    {
                        Description = "Git account name."
                    };
                infra.Add(gitAccountName);

                ProvisioningParameter gitRepositoryName =
                    new(nameof(gitRepositoryName), typeof(string))
                    {
                        Description = "Git repository name."
                    };
                infra.Add(gitRepositoryName);

                DataFactoryService dataFactory =
                    new(nameof(dataFactory), DataFactoryService.ResourceVersions.V2018_06_01)
                    {
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        },
                        PublicNetworkAccess = DataFactoryPublicNetworkAccess.Disabled,
                        RepoConfiguration = new FactoryGitHubConfiguration
                        {
                            AccountName = gitAccountName,
                            RepositoryName = gitRepositoryName,
                            CollaborationBranch = "main",
                            RootFolder = "/"
                        }
                    };
                infra.Add(dataFactory);

                DataFactoryManagedVirtualNetwork managedVnet =
                    new(nameof(managedVnet), DataFactoryManagedVirtualNetwork.ResourceVersions.V2018_06_01)
                    {
                        Parent = dataFactory,
                        Name = "default",
                        Properties = new DataFactoryManagedVirtualNetworkProperties()
                    };
                infra.Add(managedVnet);

                DataFactoryIntegrationRuntime integrationRuntime =
                    new(nameof(integrationRuntime), DataFactoryIntegrationRuntime.ResourceVersions.V2018_06_01)
                    {
                        Parent = dataFactory,
                        Name = "AutoResolveIntegrationRuntime",
                        Properties = new ManagedIntegrationRuntime
                        {
                            ManagedVirtualNetwork = new ManagedVirtualNetworkReference
                            {
                                ReferenceName = "default",
                                ReferenceType = ManagedVirtualNetworkReferenceType.ManagedVirtualNetworkReference
                            },
                            ComputeProperties = new IntegrationRuntimeComputeProperties
                            {
                                Location = new AzureLocation("AutoResolve")
                            }
                        }
                    };
                infra.Add(integrationRuntime);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = dataFactory.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = dataFactory.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.datafactory/data-factory-v2-git-config-managed-vnet/main.bicep")]
    public async Task CreateDataFactoryWithGitConfigAndManagedVnet()
    {
        await using Trycep test = CreateDataFactoryWithGitConfigAndManagedVnetTest();
        test.Compare(
            """
            @description('Git account name.')
            param gitAccountName string

            @description('Git repository name.')
            param gitRepositoryName string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource dataFactory 'Microsoft.DataFactory/factories@2018-06-01' = {
              name: take('dataFactory-${uniqueString(resourceGroup().id)}', 63)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                publicNetworkAccess: 'Disabled'
                repoConfiguration: {
                  accountName: gitAccountName
                  repositoryName: gitRepositoryName
                  collaborationBranch: 'main'
                  rootFolder: '/'
                }
              }
            }

            resource managedVnet 'Microsoft.DataFactory/factories/managedVirtualNetworks@2018-06-01' = {
              name: 'default'
              parent: dataFactory
            }

            resource integrationRuntime 'Microsoft.DataFactory/factories/integrationRuntimes@2018-06-01' = {
              name: 'AutoResolveIntegrationRuntime'
              properties: {
                type: 'Managed'
                managedVirtualNetwork: {
                  type: 'ManagedVirtualNetworkReference'
                  referenceName: 'default'
                }
                typeProperties: {
                  computeProperties: {
                    location: 'AutoResolve'
                  }
                }
              }
              parent: dataFactory
            }

            output name string = dataFactory.name

            output resourceId string = dataFactory.id
            """);
    }
}