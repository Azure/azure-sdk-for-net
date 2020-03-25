
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

            using (var context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
                var numOfOperations = 32;

                try
                {
                    //Create a test capacity
                    var resultOperationsList = testBase.client.Operations.List();

                    //  validate the operations result
                    Assert.Equal(numOfOperations, resultOperationsList.Count());

                    var operationsPageLink =
                        "https://management.azure.com/providers/Microsoft.Kusto/operations?api-version=2018-09-07-preview";
                    var resultOperationsNextPage = testBase.client.Operations.ListNext(operationsPageLink);

                    //   validate the operations result
                    Assert.Equal(numOfOperations, resultOperationsNextPage.Count());
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
            string runningState = "Running";
            string stoppedState = "Stopped";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdcluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(createdcluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: runningState);

                // get cluster
                var cluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(cluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: runningState);

                //update cluster
                testBase.cluster.Sku = testBase.sku2;
                var updatedcluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(updatedcluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: runningState);

                //suspend cluster
                testBase.client.Clusters.Stop(testBase.rgName, testBase.clusterName);
                var stoppedCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(stoppedCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: stoppedState);

                //suspend cluster
                testBase.client.Clusters.Start(testBase.rgName, testBase.clusterName);
                var runningCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(runningCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: runningState);


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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdcluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdcluster.Name, testBase.databaseName, testBase.database);
                VerifyDatabase(createdDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdcluster.Name);

                // get database 
                var database = testBase.client.Databases.Get(testBase.rgName, createdcluster.Name, testBase.databaseName);
                VerifyDatabase(database, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdcluster.Name);

                //update database
                testBase.database.HotCachePeriod = testBase.hotCachePeriod2;
                testBase.database.SoftDeletePeriod = testBase.softDeletePeriod2;
                var updatedDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdcluster.Name, testBase.databaseName, testBase.database);
                VerifyDatabase(updatedDb, testBase.databaseName, testBase.softDeletePeriod2, testBase.hotCachePeriod2, createdcluster.Name);

                //delete database
                testBase.client.Databases.Delete(testBase.rgName, createdcluster.Name, testBase.databaseName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Databases.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdcluster.Name,
                        databaseName: testBase.databaseName);
                });

                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoDataConnectionTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                //create event hub connection
                var createdEventHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(createdEventHubConnection as EventHubDataConnection,
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    string.Empty);

                // get event hub connection
                var eventHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
                VerifyEventHub(eventHubConnection as EventHubDataConnection, 
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    string.Empty);

                //update event hub connection
                testBase.eventhubConnection.DataFormat = testBase.dataFormat;
                var updatedEventHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(updatedEventHubConnection as EventHubDataConnection,
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    testBase.dataFormat);

                //delete event hub
                testBase.client.DataConnections.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DataConnections.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: createdDb.Name,
                        dataConnectionName: testBase.eventHubConnectionName);
                });

                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoDatabasePrincipalsTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                //create principals list
                var databasePrincipalListRequest = new DatabasePrincipalListRequest(testBase.databasePrincipals);
                var principalsResult = testBase.client.Databases.AddPrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName, databasePrincipalListRequest);
                VerifyPrincipalsExists(principalsResult.Value, testBase.databasePrincipal);

                // get principals list
                var principalsList = testBase.client.Databases.ListPrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName);
                VerifyPrincipalsExists(principalsList, testBase.databasePrincipal);

                //delete principals
                principalsResult = testBase.client.Databases.RemovePrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName, databasePrincipalListRequest);
                VerifyPrincipalsDontExist(principalsResult.Value, testBase.databasePrincipal);

                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        private void VerifyPrincipalsExists(IEnumerable<DatabasePrincipal> principals, DatabasePrincipal databasePrincipal)
        {
            Assert.NotNull(principals.First(principal => principal.Email == databasePrincipal.Email));
        }

        private void VerifyPrincipalsDontExist(IEnumerable<DatabasePrincipal> principals, DatabasePrincipal databasePrincipal)
        {
            Assert.Null(principals.FirstOrDefault(principal => principal.Email == databasePrincipal.Email));
        }

        private void VerifyEventHub(EventHubDataConnection createdDataConnection, string eventHubConnectionName, string eventHubResourceId, string consumerGroupName, string clusterName, string databaseName, string dataFormat)
        {
            var eventHubFullName = ResourcesNamesUtils.GetFullEventHubName(clusterName, databaseName, eventHubConnectionName);
            Assert.Equal(createdDataConnection.Name, eventHubFullName);
            Assert.Equal(createdDataConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.Name, eventHubFullName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);

        }

        private void VerifyDatabase(Database database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string clusterName)
        {
            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(clusterName, databaseName);
            Assert.Equal(database.Name, databaseFullName);
            Assert.Equal(database.SoftDeletePeriod, softDeletePeriod);
            Assert.Equal(database.HotCachePeriod, hotCachePeriod);
        }

        private void VerifyCluster(Cluster cluster, string name, AzureSku sku, IList<TrustedExternalTenant> trustedExternalTenants, string state)
        {
            Assert.Equal(cluster.Name, name);
            AssetEqualtsSku(cluster.Sku, sku);
            Assert.Equal(state, cluster.State);
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


