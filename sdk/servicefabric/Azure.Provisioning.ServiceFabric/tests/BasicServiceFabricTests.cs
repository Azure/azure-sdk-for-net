// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceFabric.Tests;

public class BasicServiceFabricTests
{
    internal static Trycep CreateApplicationTypeTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ServiceFabricBasic
                Infrastructure infra = new();

                ServiceFabricCluster cluster = ServiceFabricCluster.FromExisting(nameof(cluster), ServiceFabricCluster.ResourceVersions.V2026_03_01_PREVIEW);
                cluster.Name = "existingCluster";
                infra.Add(cluster);

                ServiceFabricApplicationType applicationType =
                    new(nameof(applicationType), ServiceFabricApplicationType.ResourceVersions.V2026_03_01_PREVIEW)
                    {
                        Parent = cluster,
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(applicationType);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.servicefabric/service-fabric-secure-cluster-5-node-1-nodetype/main.bicep")]
    public async Task CreateApplicationType()
    {
        await using Trycep test = CreateApplicationTypeTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cluster 'Microsoft.ServiceFabric/clusters@2026-03-01-preview' existing = {
              name: 'existingCluster'
            }

            resource applicationType 'Microsoft.ServiceFabric/clusters/applicationTypes@2026-03-01-preview' = {
              name: take('applicationtype${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              parent: cluster
            }
            """);
    }
}
