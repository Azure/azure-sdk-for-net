// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceFabricManagedClusters.Tests;

public class BasicServiceFabricManagedClustersTests
{
    internal static Trycep CreateApplicationTypeTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ServiceFabricManagedClustersBasic
                Infrastructure infra = new();

                ServiceFabricManagedCluster cluster = ServiceFabricManagedCluster.FromExisting(nameof(cluster), ServiceFabricManagedCluster.ResourceVersions.V2026_02_01);
                cluster.Name = "existingCluster";
                infra.Add(cluster);

                ServiceFabricManagedApplicationType applicationType =
                    new(nameof(applicationType), ServiceFabricManagedApplicationType.ResourceVersions.V2026_02_01)
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
    [Description("https://learn.microsoft.com/azure/templates/microsoft.servicefabric/2026-02-01/managedclusters/applicationtypes")]
    public async Task CreateApplicationType()
    {
        await using Trycep test = CreateApplicationTypeTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource cluster 'Microsoft.ServiceFabric/managedClusters@2026-02-01' existing = {
              name: 'existingCluster'
            }

            resource applicationType 'Microsoft.ServiceFabric/managedClusters/applicationTypes@2026-02-01' = {
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
