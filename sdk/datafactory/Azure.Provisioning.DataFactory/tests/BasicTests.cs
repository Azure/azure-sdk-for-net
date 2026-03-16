// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DataFactory.Tests;

public class BasicDataFactoryTests
{
    [Test]
    public async Task CreateDataFactoryWithLinkedService()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter connectionString =
                    new(nameof(connectionString), typeof(string))
                    {
                        Description = "The connection string for the Azure Blob Storage account.",
                        IsSecure = true
                    };
                infra.Add(connectionString);

                DataFactoryService adf =
                    new(nameof(adf), DataFactoryService.ResourceVersions.V2018_06_01)
                    {
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        },
                        PublicNetworkAccess = DataFactoryPublicNetworkAccess.Disabled,
                        Tags = { { "environment", "test" } }
                    };
                infra.Add(adf);

                DataFactoryLinkedService linkedService =
                    new(nameof(linkedService), DataFactoryLinkedService.ResourceVersions.V2018_06_01)
                    {
                        Parent = adf,
                        Name = "blobStorage",
                        Properties = new AzureBlobStorageLinkedService
                        {
                            ConnectionString = connectionString
                        }
                    };
                infra.Add(linkedService);

                infra.Add(new ProvisioningOutput("factoryName", typeof(string)) { Value = adf.Name });
                infra.Add(new ProvisioningOutput("factoryId", typeof(string)) { Value = adf.Id });

                return infra;
            });
        test.Compare(
            """
            @secure()
            @description('The connection string for the Azure Blob Storage account.')
            param connectionString string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource adf 'Microsoft.DataFactory/factories@2018-06-01' = {
              name: take('adf-${uniqueString(resourceGroup().id)}', 63)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                publicNetworkAccess: 'Disabled'
              }
              tags: {
                environment: 'test'
              }
            }

            resource linkedService 'Microsoft.DataFactory/factories/linkedservices@2018-06-01' = {
              name: 'blobStorage'
              properties: {
                type: 'AzureBlobStorage'
                typeProperties: {
                  connectionString: connectionString
                }
              }
              parent: adf
            }

            output factoryName string = adf.name

            output factoryId string = adf.id
            """);
    }

    [Test]
    public async Task CreateDataFactoryWithPipeline()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                DataFactoryService adf =
                    new(nameof(adf), DataFactoryService.ResourceVersions.V2018_06_01);
                infra.Add(adf);

                DataFactoryPipeline pipeline =
                    new(nameof(pipeline), DataFactoryPipeline.ResourceVersions.V2018_06_01)
                    {
                        Parent = adf,
                        Name = "copyPipeline",
                        Description = "A sample pipeline",
                        Concurrency = 1
                    };
                infra.Add(pipeline);

                return infra;
            });
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource adf 'Microsoft.DataFactory/factories@2018-06-01' = {
              name: take('adf-${uniqueString(resourceGroup().id)}', 63)
              location: location
            }

            resource pipeline 'Microsoft.DataFactory/factories/pipelines@2018-06-01' = {
              name: 'copyPipeline'
              properties: {
                concurrency: 1
                description: 'A sample pipeline'
              }
              parent: adf
            }
            """);
    }
}