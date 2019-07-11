
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Kusto.Tests.Utils;
using Xunit;

namespace Kusto.Tests.ScenarioTests
{
    public class KustoOperationsTests : TestBase
    {

        [Fact]
        public void OperationsTest()
        {
            string executingAssemblyPath = typeof(KustoOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KustoTestBase(context);

                try
                {
                    //Create a test capacity
                    var resultOperationsList = testBase.client.Operations.List();

                    //  validate the operations result
                    Assert.Equal(18, resultOperationsList.Count());

                    var operationsPageLink =
                        "https://management.azure.com/providers/Microsoft.Kusto/operations?api-version=2018-09-07-preview";
                    var resultOperationsNextPage = testBase.client.Operations.ListNext(operationsPageLink);

                    //   validate the operations result
                    var a = resultOperationsNextPage.Count();

                    Assert.Equal(18, resultOperationsNextPage.Count());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }

        [Fact]
        public void KustoClusterTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdcluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(createdcluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants);

                // get cluster
                var cluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(cluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants);

                //update cluster
                testBase.cluster.Sku = testBase.sku2;
                var updatedcluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(updatedcluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants);

                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Clusters.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: testBase.clusterName);
                });
            }
        }

        [Fact]
        public void KustoDatabaseTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KustoTestBase(context);

                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseName, testBase.database);
                VerifyDatabase(createdDb, testBase.databaseName, testBase.softDeletePeriodInDays1, testBase.hotCachePeriodInDays1, testBase.clusterForNestedResourceName);

                // get database 
                var database = testBase.client.Databases.Get(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseName);
                VerifyDatabase(database, testBase.databaseName, testBase.softDeletePeriodInDays1, testBase.hotCachePeriodInDays1, testBase.clusterForNestedResourceName);

                //update database
                testBase.database.HotCachePeriodInDays = testBase.hotCachePeriodInDays2;
                testBase.database.SoftDeletePeriodInDays = testBase.softDeletePeriodInDays2;
                var updatedDb = testBase.client.Databases.CreateOrUpdate(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseName, testBase.database);
                VerifyDatabase(updatedDb, testBase.databaseName, testBase.softDeletePeriodInDays2, testBase.hotCachePeriodInDays2, testBase.clusterForNestedResourceName);

                //delete database
                testBase.client.Databases.Delete(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Databases.Get(
                        resourceGroupName: testBase.resourceGroupForNestedResourcesName,
                        clusterName: testBase.clusterForNestedResourceName,
                        databaseName: testBase.databaseName);
                });
            }
        }

        [Fact]
        public void KustoEventHubConnectionTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new KustoTestBase(context);

                //create event hub connection
                var createdEventHubConnection = testBase.client.EventHubConnections.CreateOrUpdate(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseForNestedResourceName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(createdEventHubConnection,
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForNestedResourceName,
                    testBase.databaseForNestedResourceName,
                    testBase.MappingNameForNestedResources1,
                    testBase.tableNameForNestedResources1,
                    testBase.dataFormat);

                // get event hub connection
                var eventHubConnection = testBase.client.EventHubConnections.Get(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseForNestedResourceName, testBase.eventHubConnectionName);
                VerifyEventHub(eventHubConnection, testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForNestedResourceName,
                    testBase.databaseForNestedResourceName,
                    testBase.MappingNameForNestedResources1,
                    testBase.tableNameForNestedResources1,
                    testBase.dataFormat);


                //update event hub connection
                testBase.eventhubConnection.MappingRuleName = testBase.MappingNameForNestedResources2;
                testBase.eventhubConnection.TableName = testBase.tableNameForNestedResources2;
                var updatedEventHubConnection = testBase.client.EventHubConnections.CreateOrUpdate(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseForNestedResourceName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(updatedEventHubConnection,
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForNestedResourceName,
                    testBase.databaseForNestedResourceName,
                    testBase.MappingNameForNestedResources1,
                    testBase.tableNameForNestedResources1,
                    testBase.dataFormat);

                //delete event hub
                testBase.client.EventHubConnections.Delete(testBase.resourceGroupForNestedResourcesName, testBase.clusterForNestedResourceName, testBase.databaseForNestedResourceName, testBase.eventHubConnectionName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.EventHubConnections.Get(
                        resourceGroupName: testBase.resourceGroupForNestedResourcesName,
                        clusterName: testBase.clusterForNestedResourceName,
                        databaseName: testBase.databaseForNestedResourceName,
                        eventHubConnectionName: testBase.eventHubConnectionName);
                });
            }
        }

        private void VerifyEventHub(EventHubConnection createdEventHubConnection, string eventHubConnectionName, string eventHubResourceId, string consumerGroupName, string clusterName, string databaseName, string mappingRule, string tableName, string dataFormat)
        {
            var eventHubFullName = ResourcesNamesUtils.GetFullEventHubName(clusterName, databaseName, eventHubConnectionName);
            Assert.Equal(createdEventHubConnection.Name, eventHubFullName);
            Assert.Equal(createdEventHubConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdEventHubConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdEventHubConnection.Name, eventHubFullName);
            Assert.Equal(createdEventHubConnection.Name, eventHubFullName);
        }

        private void VerifyDatabase(Database database, string databaseName, int softDeletePeriodInDays, int hotCachePeriodInDays, string clusterName)
        {
            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(clusterName, databaseName);
            Assert.Equal(database.Name, databaseFullName);
            Assert.Equal(database.SoftDeletePeriodInDays, softDeletePeriodInDays);
            Assert.Equal(database.HotCachePeriodInDays, hotCachePeriodInDays);
        }

        private void VerifyCluster(Cluster cluster, string name, AzureSku sku, IList<TrustedExternalTenant> trustedExternalTenants)
        {
            Assert.Equal(cluster.Name, name);
            AssetEqualtsSku(cluster.Sku, sku);
            AssetEqualtsExtrnalTenants(cluster.TrustedExternalTenants, trustedExternalTenants);
        }

        private void AssetEqualtsSku(AzureSku sku1, AzureSku sku2)
        {
            Assert.Equal(sku1.Capacity, sku2.Capacity);
            Assert.Equal(sku1.Name, sku2.Name);
        }

        private void AssetEqualtsExtrnalTenants(IList<TrustedExternalTenant> trustedExternalTenants, IList<TrustedExternalTenant> other)
        {
            Assert.Equal(trustedExternalTenants.Count, other.Count);
            foreach (var otherExtrenalTenants in other)
            {
                var equalExternalTenants = trustedExternalTenants.Where((extrenalTenant) =>
                {
                    return otherExtrenalTenants.Value == extrenalTenant.Value ;
                });
                Assert.Single(equalExternalTenants);
            }
        }
    }
}

