
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
                var numOfOperations = 54;

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
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdcluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(createdDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdcluster.Name);
        
                // get database 
                var database = testBase.client.Databases.Get(testBase.rgName, createdcluster.Name, testBase.databaseName) as ReadWriteDatabase;
                VerifyReadWriteDatabase(database, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdcluster.Name);
        
                //update database
                testBase.database.HotCachePeriod = testBase.hotCachePeriod2;
                testBase.database.SoftDeletePeriod = testBase.softDeletePeriod2;
                var updatedDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdcluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(updatedDb, testBase.databaseName, testBase.softDeletePeriod2, testBase.hotCachePeriod2, createdcluster.Name);
        
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
        public void KustoEventHubTests()
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
        public void KustoIotHubTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create iot hub connection
                var createdIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
                VerifyIotHub(createdIotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    string.Empty);
        
                // get Iot hub connection
                var iotHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
                VerifyIotHub(iotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    string.Empty);
        
                //update Iot hub connection
                testBase.iotHubDataConnection.DataFormat = testBase.dataFormat;
                var updatedIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
        
                VerifyIotHub(updatedIotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    testBase.dataFormat);
        
                //delete Iot hub
                testBase.client.DataConnections.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DataConnections.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: testBase.clusterName,
                        databaseName: testBase.databaseName,
                        dataConnectionName: testBase.iotHubConnectionName);
                });
        
                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);
        
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoEventGridTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create event grid connection
                var createdEventGridConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.resourceGroupForTest, testBase.clusterForEventGridTest, testBase.databaseForEventGridTest, testBase.eventGridConnectinoName, testBase.eventGridDataConnection);
                VerifyEventGrid(createdEventGridConnection as EventGridDataConnection,
                    testBase.eventGridConnectinoName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForEventGridTest,
                    testBase.databaseForEventGridTest,
                    testBase.dataFormat,
                    testBase.storageAccountForEventGridResourceId,
                    testBase.tableName);
        
                // get event grid connection
                var eventGridConnection = testBase.client.DataConnections.Get(testBase.resourceGroupForTest, testBase.clusterForEventGridTest, testBase.databaseForEventGridTest, testBase.eventGridConnectinoName);
                VerifyEventGrid(eventGridConnection as EventGridDataConnection,
                    testBase.eventGridConnectinoName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForEventGridTest,
                    testBase.databaseForEventGridTest,
                    testBase.dataFormat,
                    testBase.storageAccountForEventGridResourceId,
                    testBase.tableName);
        
                //update event grid connection
                testBase.eventhubConnection.DataFormat = testBase.dataFormat;
        
                var updatedEventGridConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.resourceGroupForTest, testBase.clusterForEventGridTest, testBase.databaseForEventGridTest, testBase.eventGridConnectinoName, testBase.eventGridDataConnection);
                VerifyEventGrid(updatedEventGridConnection as EventGridDataConnection,
                    testBase.eventGridConnectinoName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForEventGridTest,
                    testBase.databaseForEventGridTest,
                    testBase.dataFormat,
                    testBase.storageAccountForEventGridResourceId,
                    testBase.tableName);
        
                //delete event grid
                testBase.client.DataConnections.Delete(testBase.resourceGroupForTest, testBase.clusterForEventGridTest, testBase.databaseForEventGridTest, testBase.eventGridConnectinoName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DataConnections.Get(
                        resourceGroupName: testBase.resourceGroupForTest,
                        clusterName: testBase.clusterForEventGridTest,
                        databaseName: testBase.databaseForEventGridTest,
                        dataConnectionName: testBase.eventGridConnectinoName);
                });
            }
        }
        
        [Fact]
        public void KustoOptimizedAutoscaleTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                // Create cluster with optimized autoscale
                var enabledOptimizedAutoscale = new OptimizedAutoscale(1, true, 2, 100);
                testBase.cluster.OptimizedAutoscale = enabledOptimizedAutoscale;
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                ValidateOptimizedAutoscale(createdCluster, enabledOptimizedAutoscale);
        
                // Update cluster with optimized autoscale
                enabledOptimizedAutoscale = new OptimizedAutoscale(1, true, 2, 101);
                testBase.cluster.OptimizedAutoscale = enabledOptimizedAutoscale;
                var updatedCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                ValidateOptimizedAutoscale(updatedCluster, enabledOptimizedAutoscale);
        
                var optimizedAutoscaleThatShouldNotBeAllowed = new OptimizedAutoscale(1, true, 0, 100);
                testBase.cluster.OptimizedAutoscale = optimizedAutoscaleThatShouldNotBeAllowed;
        
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                });
        
                // Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoStreamingIngestTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                // Create cluster with streaming ingest true
                testBase.cluster.EnableStreamingIngest = true;
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                Assert.True(createdCluster.EnableStreamingIngest);
        
                // Update cluster with streaming ingest false
                testBase.cluster.EnableStreamingIngest = false;
                var updatedCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                Assert.False(updatedCluster.EnableStreamingIngest);
        
                // Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoEnableDiskEncryptionTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                // Create cluster with Enable Disk Encryption true
                testBase.cluster.EnableDiskEncryption = true;
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                Assert.True(createdCluster.EnableDiskEncryption);
        
                // Update cluster with Enable Disk Encryption false
                testBase.cluster.EnableDiskEncryption = false;
                var updatedCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                Assert.False(updatedCluster.EnableDiskEncryption);
        
                //Delete cluster
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
        
        [Fact]
        public void KustoPrincipalAssignmentsTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                var principalName = "principal1";
                //create cluster principal assignment
                var clusterPrincipalAssignment = new ClusterPrincipalAssignment(testBase.clientIdForPrincipal, "AllDatabasesAdmin", "App");
                testBase.client.ClusterPrincipalAssignments.CreateOrUpdate(testBase.rgName, testBase.clusterName, principalName, clusterPrincipalAssignment);
                testBase.client.ClusterPrincipalAssignments.Get(testBase.rgName, testBase.clusterName, principalName);
                testBase.client.ClusterPrincipalAssignments.Delete(testBase.rgName, testBase.clusterName, principalName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.ClusterPrincipalAssignments.Get(testBase.rgName, testBase.clusterName, principalName);
                });
        
                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create database principal assignment
                var databasePrincipalAssignment = new DatabasePrincipalAssignment(testBase.clientIdForPrincipal, "Viewer", "App");
                testBase.client.DatabasePrincipalAssignments.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, principalName, databasePrincipalAssignment);
                testBase.client.DatabasePrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, principalName);
                testBase.client.DatabasePrincipalAssignments.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, principalName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DatabasePrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, principalName);
                });
        
                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);
        
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoAttachedDatabaseConfigurationTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                // create a follower cluster
                var createdFollowerCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);
        
                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create attached database configuration
                var createdAttachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(
                    testBase.rgName,
                    testBase.followerClusterName,
                    testBase.attachedDatabaseConfigurationName,
                    testBase.attachedDatabaseConfiguration);
        
                VerifyAttachedDatabaseConfiguration(createdAttachedDatabaseConfiguration,
                    testBase.attachedDatabaseConfigurationName,
                    testBase.followerClusterName, testBase.databaseName,
                    createdCluster.Id,
                    testBase.defaultPrincipalsModificationKind);
        
                // get attached database configuration
                var attachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.Get(testBase.rgName, createdFollowerCluster.Name, testBase.attachedDatabaseConfigurationName);
        
                VerifyAttachedDatabaseConfiguration(attachedDatabaseConfiguration,
                    testBase.attachedDatabaseConfigurationName,
                    testBase.followerClusterName, testBase.databaseName,
                    createdCluster.Id,
                    testBase.defaultPrincipalsModificationKind);
        
                // testing the created read-only following database
                TestReadonlyFollowingDatabase(testBase);
        
                // delete the attached database configuration
                testBase.client.AttachedDatabaseConfigurations.Delete(testBase.rgName, createdFollowerCluster.Name, testBase.attachedDatabaseConfigurationName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.AttachedDatabaseConfigurations.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdFollowerCluster.Name,
                        attachedDatabaseConfigurationName: testBase.attachedDatabaseConfigurationName);
                });
        
                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
        
                // delete follower cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.followerClusterName);
            }
        }
        
        [Fact]
        public void KustoFollowerDatabaseActionsTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                // create a follower cluster
                var createdFollowerCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);
        
                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create attached database configuration
                var createdAttachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(
                    testBase.rgName,
                    testBase.followerClusterName,
                    testBase.attachedDatabaseConfigurationName,
                    testBase.attachedDatabaseConfiguration);
        
                var followerDatabasesList = testBase.client.Clusters.ListFollowerDatabases(testBase.rgName, testBase.clusterName);
                var followerDatabase = followerDatabasesList.FirstOrDefault(f => f.AttachedDatabaseConfigurationName.Equals(testBase.attachedDatabaseConfigurationName, StringComparison.OrdinalIgnoreCase));
                VerifyFollowerDatabase(followerDatabase, testBase.attachedDatabaseConfigurationName, testBase.databaseName, createdFollowerCluster.Id);
        
                // detach the follower database
                testBase.client.Clusters.DetachFollowerDatabases(testBase.rgName, testBase.clusterName, followerDatabase);
                followerDatabasesList = testBase.client.Clusters.ListFollowerDatabases(testBase.rgName, testBase.clusterName);
                VerifyFollowerDatabaseDontExist(followerDatabasesList, testBase.attachedDatabaseConfigurationName);
        
                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
        
                // delete follower cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.followerClusterName);
            }
        }
        
        [Fact]
        public void KustoIdentityTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                // Create cluster with an identity
                testBase.cluster.Identity = new Identity(IdentityType.SystemAssigned);
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                Assert.Equal(IdentityType.SystemAssigned, createdCluster.Identity.Type);
        
                // Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoKeyVaultPropertiesTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                // Update the cluster with key vault properties
                var cluster = testBase.client.Clusters.Update(testBase.resourceGroupForTest, testBase.clusterForKeyVaultPropertiesTest, new ClusterUpdate(keyVaultProperties: testBase.keyVaultProperties));
        
                VerifyKeyVaultProperties(cluster.KeyVaultProperties, 
                    testBase.KeyNameForKeyVaultPropertiesTest, 
                    testBase.KeyVersionForKeyVaultPropertiesTest, 
                    testBase.KeyVaultUriForKeyVaultPropertiesTest);
            }
        }

        private void TestReadonlyFollowingDatabase(KustoTestBase testBase)
        {
            var readonlyFollowingDb = testBase.client.Databases.Get(testBase.rgName, testBase.followerClusterName, testBase.databaseName) as ReadOnlyFollowingDatabase;
            VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, testBase.defaultPrincipalsModificationKind, testBase.followerClusterName);

            readonlyFollowingDb.HotCachePeriod = testBase.hotCachePeriod2;
            readonlyFollowingDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.databaseName, readonlyFollowingDb) as ReadOnlyFollowingDatabase;
            VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod2, testBase.defaultPrincipalsModificationKind, testBase.followerClusterName);
        }

        private void VerifyFollowerDatabase(FollowerDatabaseDefinition followerDatabaseDefinition, string attachedDatabaseConfigurationName, string databaseName, string clusterResourceId)
        {
            Assert.NotNull(followerDatabaseDefinition);
            Assert.Equal(followerDatabaseDefinition.AttachedDatabaseConfigurationName, attachedDatabaseConfigurationName);
            Assert.Equal(followerDatabaseDefinition.DatabaseName, databaseName);
            Assert.Equal(followerDatabaseDefinition.ClusterResourceId, clusterResourceId);
        }

        private void VerifyKeyVaultProperties(KeyVaultProperties keyVaultProperties, string keyName, string keyVersion, string keyVaultUri)
        {
            Assert.NotNull(keyVaultProperties);
            Assert.Equal(keyVaultProperties.KeyName, keyName);
            Assert.Equal(keyVaultProperties.KeyVersion, keyVersion);
            Assert.Equal(keyVaultProperties.KeyVaultUri, keyVaultUri);
        }

        private void VerifyFollowerDatabaseDontExist(IEnumerable<FollowerDatabaseDefinition> followerDatabasesList, string attachedDatabaseConfigurationName)
        {
            Assert.Null(followerDatabasesList.FirstOrDefault(f => f.AttachedDatabaseConfigurationName.Equals(attachedDatabaseConfigurationName, StringComparison.OrdinalIgnoreCase)));
        }

        private void VerifyPrincipalsExists(IEnumerable<DatabasePrincipal> principals, DatabasePrincipal databasePrincipal)
        {
            Assert.NotNull(principals.First(principal => principal.Email == databasePrincipal.Email));
        }

        private void VerifyPrincipalsDontExist(IEnumerable<DatabasePrincipal> principals, DatabasePrincipal databasePrincipal)
        {
            Assert.Null(principals.FirstOrDefault(principal => principal.Email == databasePrincipal.Email));
        }

        private void VerifyAttachedDatabaseConfiguration(AttachedDatabaseConfiguration createdAttachedDatabaseConfiguration, string attachedDatabaseConfigurationName, string clusterName, string databaseName, string clusterResourceId, string defaultPrincipalsModificationKind)
        {
            var attahcedDatabaseConfigurationFullName = ResourcesNamesUtils.GetAttachedDatabaseConfigurationName(clusterName, attachedDatabaseConfigurationName);
            Assert.Equal(createdAttachedDatabaseConfiguration.Name, attahcedDatabaseConfigurationFullName);
            Assert.Equal(createdAttachedDatabaseConfiguration.DatabaseName, databaseName);
            Assert.Equal(createdAttachedDatabaseConfiguration.ClusterResourceId, clusterResourceId);
            Assert.Equal(createdAttachedDatabaseConfiguration.DefaultPrincipalsModificationKind, defaultPrincipalsModificationKind);
        }

        private void VerifyEventHub(EventHubDataConnection createdDataConnection, string eventHubConnectionName, string eventHubResourceId, string consumerGroupName, string clusterName, string databaseName, string dataFormat)
        {
            var eventHubFullName = ResourcesNamesUtils.GetDataConnectionFullName(clusterName, databaseName, eventHubConnectionName);
            Assert.Equal(createdDataConnection.Name, eventHubFullName);
            Assert.Equal(createdDataConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
        }

        private void VerifyIotHub(IotHubDataConnection createdDataConnection, string iotHubConnectionName, string iotHubResourceId, string consumerGroupName, string clusterName, string databaseName, string dataFormat)
        {
            var iotHubFullName = ResourcesNamesUtils.GetDataConnectionFullName(clusterName, databaseName, iotHubConnectionName);
            Assert.Equal(createdDataConnection.Name, iotHubFullName);
            Assert.Equal(createdDataConnection.IotHubResourceId, iotHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
        }

        private void VerifyEventGrid(EventGridDataConnection createdDataConnection, string eventGridConnectinoName, string eventHubResourceId, string consumerGroupName, string clusterName, string databaseName, string dataFormat, string storageAccountResourceId, string tableName)
        {
            var eventGridFullName = ResourcesNamesUtils.GetDataConnectionFullName(clusterName, databaseName, eventGridConnectinoName);
            Assert.Equal(createdDataConnection.Name, eventGridFullName);
            Assert.Equal(createdDataConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
            Assert.Equal(createdDataConnection.StorageAccountResourceId, storageAccountResourceId);
            Assert.Equal(createdDataConnection.TableName, tableName);
        }

        private void VerifyReadOnlyFollowingDatabase(ReadOnlyFollowingDatabase database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string principalsModificationKind, string clusterName)
        {
            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(clusterName, databaseName);

            Assert.NotNull(database);
            Assert.Equal(database.Name, databaseFullName);
            Assert.Equal(softDeletePeriod, database.SoftDeletePeriod);
            Assert.Equal(hotCachePeriod, database.HotCachePeriod);
            Assert.Equal(principalsModificationKind, database.PrincipalsModificationKind);
        }

        private void VerifyReadWriteDatabase(ReadWriteDatabase database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string clusterName)
        {
            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(clusterName, databaseName);

            Assert.NotNull(database);
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

        private void ValidateOptimizedAutoscale(Cluster createdCluster, OptimizedAutoscale expectedOptimizedAutoscale)
        {
            var clusterOptimizedAutoscale = createdCluster.OptimizedAutoscale;

            if (clusterOptimizedAutoscale == null)
            {
                Assert.Null(expectedOptimizedAutoscale);

                return;
            }

            Assert.Equal(clusterOptimizedAutoscale.Version, expectedOptimizedAutoscale.Version);
            Assert.Equal(clusterOptimizedAutoscale.Minimum, expectedOptimizedAutoscale.Minimum);
            Assert.Equal(clusterOptimizedAutoscale.Maximum, expectedOptimizedAutoscale.Maximum);
            Assert.Equal(clusterOptimizedAutoscale.IsEnabled, expectedOptimizedAutoscale.IsEnabled);
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
                    return otherExtrenalTenants.Value == extrenalTenant.Value;
                });
                Assert.Single(equalExternalTenants);
            }
        }
    }
}


