// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using Azure.Provisioning.Expressions;
using NUnit.Framework;
using System;

namespace Azure.Provisioning.Kusto.Tests;

public class BasicKustoTests
{
    internal static Trycep CreateKustoClusterDatabaseTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                #region Snippet:KustoClusterDatabase

                // Create parameters for cluster name, database name, and location
                ProvisioningParameter clustersKustoclusterName = new("clusters_kustocluster_name", typeof(string))
                {
                    Description = "Name of the cluster to create",
                    Value = BicepFunction.Interpolate($"kusto{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(clustersKustoclusterName);

                ProvisioningParameter databasesKustodbName = new("databases_kustodb_name", typeof(string))
                {
                    Description = "Name of the database to create",
                    Value = "kustodb"
                };
                infra.Add(databasesKustodbName);

                // Create Kusto cluster
                KustoCluster kustoCluster = new("kustoCluster")
                {
                    Name = clustersKustoclusterName,
                    Sku = new KustoSku
                    {
                        // Note: Standard_D8_v3 is not available in the enum, using StandardE8dV4 as a similar alternative
                        Name = KustoSkuName.StandardE8dV4,
                        Tier = KustoSkuTier.Standard,
                        Capacity = 2
                    },
                    Tags =
                    {
                        ["Created By"] = "GitHub quickstart template"
                    }
                };
                infra.Add(kustoCluster);

                // Create Kusto database
                KustoReadWriteDatabase kustoDatabase = new("kustoDatabase")
                {
                    Name = databasesKustodbName,
                    Parent = kustoCluster,
                    SoftDeletePeriod = TimeSpan.FromDays(365),
                    HotCachePeriod = TimeSpan.FromDays(31)
                };
                infra.Add(kustoDatabase);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/d56737b22db0280fc1967a59d7c01a6762ccbedd/quickstarts/microsoft.kusto/kusto-cluster-database/azuredeploy.json")]
    public async Task KustoClusterDatabase()
    {
        await using Trycep test = CreateKustoClusterDatabaseTest();
        test.Compare(
            """
            @description('Name of the cluster to create')
            param clusters_kustocluster_name string = 'kusto${uniqueString(resourceGroup().id)}'
            @description('Name of the database to create')
            param databases_kustodb_name string = 'kustodb'
            @description('Location for all resources.')
            param location string = resourceGroup().location
            resource kustoCluster 'Microsoft.Kusto/clusters@2024-04-13' = {
              name: clusters_kustocluster_name
              location: location
              sku: {
                name: 'Standard_E8d_v4'
                tier: 'Standard'
                capacity: 2
              }
            }
            resource kustoDatabase 'Microsoft.Kusto/clusters/databases@2024-04-13' = {
              name: databases_kustodb_name
              parent: kustoCluster
              location: location
              properties: {
                softDeletePeriodInDays: 365
                hotCachePeriodInDays: 31
              }
            }
            """);
    }
}
