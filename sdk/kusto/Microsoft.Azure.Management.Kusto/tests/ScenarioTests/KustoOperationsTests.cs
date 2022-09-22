
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Kusto.Tests.Utils;
using Microsoft.Azure.Management.Network.Models;
using Newtonsoft.Json;
using Xunit;
using PrivateEndpointConnection = Microsoft.Azure.Management.Kusto.Models.PrivateEndpointConnection;

namespace Kusto.Tests.ScenarioTests
{
    public class KustoOperationsTests : TestBase
    {
        [Fact]
        public void OperationsTest()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
                var numOfOperations = 72;

                try
                {
                    // Create a test capacity
                    var resultOperationsList = testBase.client.Operations.List();

                    // validate the operations result
                    Assert.Equal(numOfOperations, resultOperationsList.Count());

                    var operationsPageLink = "https://management.azure.com/providers/Microsoft.Kusto/operations?api-version=2018-09-07-preview";
                    var resultOperationsNextPage = testBase.client.Operations.ListNext(operationsPageLink);

                    // validate the operations result
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(createdCluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId);

                // get cluster
                var cluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(cluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId);

                // update cluster
                testBase.cluster.Sku = testBase.sku2;
                testBase.cluster.PublicIPType = "DualStack";
                var updatedCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(updatedCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);

                // suspend cluster
                testBase.client.Clusters.Stop(testBase.rgName, testBase.clusterName);
                var stoppedCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(stoppedCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.stoppedState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);

                // suspend cluster
                testBase.client.Clusters.Start(testBase.rgName, testBase.clusterName);
                var runningCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(runningCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);


                // delete cluster
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(createdDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdCluster.Name);

                // get database
                var database = testBase.client.Databases.Get(testBase.rgName, createdCluster.Name, testBase.databaseName) as ReadWriteDatabase;
                VerifyReadWriteDatabase(database, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdCluster.Name);

                // update database
                testBase.database.HotCachePeriod = testBase.hotCachePeriod2;
                testBase.database.SoftDeletePeriod = testBase.softDeletePeriod2;
                var updatedDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(updatedDb, testBase.databaseName, testBase.softDeletePeriod2, testBase.hotCachePeriod2, createdCluster.Name);

                // delete database
                testBase.client.Databases.Delete(testBase.rgName, createdCluster.Name, testBase.databaseName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Databases.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: testBase.databaseName);
                });

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoEventHubTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                // create event hub connection
                var createdEventHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(createdEventHubConnection as EventHubDataConnection, testBase);

                // get event hub connection
                var eventHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
                VerifyEventHub(eventHubConnection as EventHubDataConnection, testBase);

                // update event hub connection
                var systemAssignedManagedIdentityResourceId = createdCluster.Id;
                testBase.eventhubConnection.DataFormat = testBase.dataFormat;
                testBase.eventhubConnection.DatabaseRouting = testBase.MultiDatabaseRouting;
                testBase.eventhubConnection.ManagedIdentityResourceId = systemAssignedManagedIdentityResourceId;
                testBase.eventhubConnection.RetrievalStartDate = testBase.retrievalStartDate;
                var updatedEventHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(updatedEventHubConnection as EventHubDataConnection, testBase, dataFormat: testBase.dataFormat, managedIdentityResourceId: systemAssignedManagedIdentityResourceId, databaseRouting: testBase.MultiDatabaseRouting, retrievalStartDate: testBase.retrievalStartDate.ToString());

                // delete event hub
                testBase.client.DataConnections.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DataConnections.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: createdDb.Name,
                        dataConnectionName: testBase.eventHubConnectionName);
                });

                // delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoIotHubTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                // create iot hub connection
                var createdIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
                VerifyIotHub(createdIotHubConnection as IotHubDataConnection, testBase);

                // get Iot hub connection
                var iotHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
                VerifyIotHub(iotHubConnection as IotHubDataConnection, testBase);

                // update Iot hub connection
                testBase.iotHubDataConnection.DataFormat = testBase.dataFormat;
                testBase.iotHubDataConnection.DatabaseRouting = testBase.MultiDatabaseRouting;
                testBase.iotHubDataConnection.RetrievalStartDate = testBase.retrievalStartDate;
                var updatedIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
                VerifyIotHub(updatedIotHubConnection as IotHubDataConnection, testBase, dataFormat: testBase.dataFormat, databaseRouting: testBase.MultiDatabaseRouting, retrievalStartDate: testBase.retrievalStartDate.ToString());

                testBase.client.DataConnections.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DataConnections.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: testBase.clusterName,
                        databaseName: testBase.databaseName,
                        dataConnectionName: testBase.iotHubConnectionName);
                });

                // delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoEventGridTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create event grid connection
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

                // update event grid connection with managed identity
                var systemAssignedManagedIdentityResourceId = testBase.clusterForEventGridTestResourceId;
                testBase.eventGridDataConnection.DataFormat = testBase.dataFormat;
                testBase.eventGridDataConnection.DatabaseRouting = testBase.MultiDatabaseRouting;
                testBase.eventGridDataConnection.ManagedIdentityResourceId = systemAssignedManagedIdentityResourceId;
                var updatedEventGridConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.resourceGroupForTest, testBase.clusterForEventGridTest, testBase.databaseForEventGridTest, testBase.eventGridConnectinoName, testBase.eventGridDataConnection);
                VerifyEventGrid(updatedEventGridConnection as EventGridDataConnection,
                    testBase.eventGridConnectinoName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterForEventGridTest,
                    testBase.databaseForEventGridTest,
                    testBase.dataFormat,
                    testBase.storageAccountForEventGridResourceId,
                    testBase.tableName,
                    databaseRouting: testBase.MultiDatabaseRouting,
                    manageIdentityResourceId: systemAssignedManagedIdentityResourceId,
                    manageIdentityObjectId: testBase.clusterForEventGridTestObjectId);

                // delete event grid
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
        public void KustoDatabaseScriptTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                // create script
                var createdScript = testBase.client.Scripts.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName, testBase.script);
                VerifyScript(createdScript,
                    testBase.scriptUrl,
                    testBase.forceUpdateTag,
                    testBase.continueOnErrors,
                    testBase.clusterName,
                    testBase.databaseName,
                    testBase.scriptName);

                // get script
                var script = testBase.client.Scripts.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName);
                VerifyScript(script,
                     testBase.scriptUrl,
                     testBase.forceUpdateTag,
                     testBase.continueOnErrors,
                     testBase.clusterName,
                     testBase.databaseName,
                     testBase.scriptName);

                // update script
                testBase.script.ForceUpdateTag = testBase.forceUpdateTag2;
                var updatedScript = testBase.client.Scripts.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName, testBase.script);
                 VerifyScript(updatedScript,
                    testBase.scriptUrl,
                    testBase.forceUpdateTag2,
                    testBase.continueOnErrors,
                    testBase.clusterName,
                    testBase.databaseName,
                    testBase.scriptName);

                  // update script with content
                  testBase.script.ScriptUrl = null;
                  testBase.script.ScriptUrlSasToken = null;
                  testBase.script.ScriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)";
                  var updatedScript2 = testBase.client.Scripts.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName, testBase.script);
                  VerifyScript(updatedScript2,
                      scriptUrl: null,
                      testBase.forceUpdateTag2,
                      testBase.continueOnErrors,
                      testBase.clusterName,
                      testBase.databaseName,
                      testBase.scriptName);

                  // get script with script content
                  var script2 = testBase.client.Scripts.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName);
                  VerifyScript(script2,
                      scriptUrl: null,
                      testBase.forceUpdateTag2,
                      testBase.continueOnErrors,
                      testBase.clusterName,
                      testBase.databaseName,
                      testBase.scriptName);

                // delete script
                testBase.client.Scripts.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Scripts.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: createdDb.Name,
                        scriptName: testBase.scriptName);
                });

                // delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoOptimizedAutoscaleTests()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(GetType()))
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

                // Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoDatabasePrincipalsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                var databaseName2 = $"{testBase.databaseName}2";
                var databasePrincipalListRequest = new DatabasePrincipalListRequest(new List<DatabasePrincipal> {
                            new DatabasePrincipal("Admin", "", "User", email: "t-abebchuk@microsoft.com")
                });

                // create cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database - caller is principal
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.database);

                // create database - caller is not principal
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.clusterName, databaseName2, testBase.database, callerRole: "None");

                // list principals - caller is principal
                var principalsList = testBase.client.Databases.ListPrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName).ToList();
                VerifyDatabasePrincipals(principalsList);

                // list principals - caller is not principal
                principalsList = testBase.client.Databases.ListPrincipals(testBase.rgName, testBase.clusterName, databaseName2).ToList();
                Assert.Empty(principalsList);

                // add principals
                principalsList = testBase.client.Databases.AddPrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName, databasePrincipalListRequest).Value.ToList();
                VerifyDatabasePrincipals(principalsList, addedPrincipalName: "Alon Bebchuk (t-abebchuk@microsoft.com)");

                // remove principals
                principalsList = testBase.client.Databases.RemovePrincipals(testBase.rgName, testBase.clusterName, testBase.databaseName, databasePrincipalListRequest).Value.ToList();
                VerifyDatabasePrincipals(principalsList);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoPrincipalAssignmentsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create cluster principal assignment
                var clusterPrincipalAssignment = new ClusterPrincipalAssignment(testBase.clientIdForPrincipal, testBase.clusterPrincipalRole, testBase.principalType);
                var principalAssignment = testBase.client.ClusterPrincipalAssignments.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.principaName, clusterPrincipalAssignment);
                VerifyClusterPrincipalAssignment(principalAssignment, name: testBase.principaName, aadObjectId: testBase.principalAadObjectId, role: testBase.clusterPrincipalRole, principalType: testBase.principalType);
                principalAssignment = testBase.client.ClusterPrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.principaName);
                VerifyClusterPrincipalAssignment(principalAssignment, name: testBase.principaName, aadObjectId: testBase.principalAadObjectId, role: testBase.clusterPrincipalRole, principalType: testBase.principalType);
                testBase.client.ClusterPrincipalAssignments.Delete(testBase.rgName, testBase.clusterName, testBase.principaName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.ClusterPrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.principaName);
                });

                // create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                // create database principal assignment
                var databasePrincipalAssignment = new DatabasePrincipalAssignment(testBase.clientIdForPrincipal, testBase.databasePrincipalRole, testBase.principalType);
                var databasePrincipalAssignmentResult = testBase.client.DatabasePrincipalAssignments.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.principaName, databasePrincipalAssignment);
                VerifyDatabasePrincipalAssignment(databasePrincipalAssignmentResult, name: testBase.principaName, aadObjectId: testBase.principalAadObjectId, role: testBase.databasePrincipalRole, principalType: testBase.principalType);
                databasePrincipalAssignmentResult = testBase.client.DatabasePrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.principaName);
                VerifyDatabasePrincipalAssignment(databasePrincipalAssignmentResult, name: testBase.principaName, aadObjectId: testBase.principalAadObjectId, role: testBase.databasePrincipalRole, principalType: testBase.principalType);
                testBase.client.DatabasePrincipalAssignments.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.principaName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.DatabasePrincipalAssignments.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.principaName);
                });

                // delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoAttachedDatabaseConfigurationTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                var databaseNameOverride = $"{testBase.databaseName}Override";
                var databaseNamePrefix = "prefix_";
                var prefixedDatabaseName = databaseNamePrefix + testBase.databaseName;

                // create cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.database);

                // create a follower cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);

                // create attached database configuration
                var attachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName, testBase.attachedDatabaseConfiguration);
                VerifyAttachedDatabaseConfiguration(attachedDatabaseConfiguration, testBase);

                // get attached database configuration
                attachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.Get(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName);
                VerifyAttachedDatabaseConfiguration(attachedDatabaseConfiguration, testBase);
                // test read-only following database
                var readonlyFollowingDb = testBase.client.Databases.Get(testBase.rgName, testBase.followerClusterName, testBase.databaseName) as ReadOnlyFollowingDatabase;
                VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase);

                // update attached database configuration
                testBase.attachedDatabaseConfiguration.DatabaseNameOverride = databaseNameOverride;
                attachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName, testBase.attachedDatabaseConfiguration);
                VerifyAttachedDatabaseConfiguration(attachedDatabaseConfiguration, testBase, databaseNameOverride: databaseNameOverride);
                // test read-only following database
                readonlyFollowingDb = testBase.client.Databases.Get(testBase.rgName, testBase.followerClusterName, databaseNameOverride) as ReadOnlyFollowingDatabase;
                VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase, databaseName: databaseNameOverride);

                // update attached database configuration
                testBase.attachedDatabaseConfiguration.DatabaseNameOverride = null;
                testBase.attachedDatabaseConfiguration.DatabaseNamePrefix = databaseNamePrefix;
                testBase.attachedDatabaseConfiguration.TableLevelSharingProperties = testBase.tableLevelSharingProperties;
                attachedDatabaseConfiguration = testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName, testBase.attachedDatabaseConfiguration);
                VerifyAttachedDatabaseConfiguration(attachedDatabaseConfiguration, testBase, databaseNamePrefix: databaseNamePrefix, tableLevelSharingProperties: testBase.tableLevelSharingProperties);
                // test read-only following database
                readonlyFollowingDb = testBase.client.Databases.Get(testBase.rgName, testBase.followerClusterName, prefixedDatabaseName) as ReadOnlyFollowingDatabase;
                VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase, databaseName: prefixedDatabaseName, tableLevelSharingProperties: testBase.tableLevelSharingProperties);

                // update read-only following database
                readonlyFollowingDb.HotCachePeriod = testBase.hotCachePeriod2;
                readonlyFollowingDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, prefixedDatabaseName, readonlyFollowingDb) as ReadOnlyFollowingDatabase;
                VerifyReadOnlyFollowingDatabase(readonlyFollowingDb, testBase, databaseName: prefixedDatabaseName, hotCachePeriod: testBase.hotCachePeriod2, tableLevelSharingProperties: testBase.tableLevelSharingProperties);

                // delete attached database configuration
                testBase.client.AttachedDatabaseConfigurations.Delete(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName);
                Assert.Throws<CloudException>(() => testBase.client.AttachedDatabaseConfigurations.Get(resourceGroupName: testBase.rgName, clusterName: testBase.followerClusterName, attachedDatabaseConfigurationName: testBase.attachedDatabaseConfigurationName));

                // delete follower cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.followerClusterName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoFollowerDatabaseActionsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.database);

                // create a follower cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);

                // create attached database configuration
                testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName, testBase.attachedDatabaseConfiguration);
                // testing follower databases
                var followerDatabasesList = testBase.client.Clusters.ListFollowerDatabases(testBase.rgName, testBase.clusterName).ToList();
                VerifyFollowerDatabases(followerDatabasesList, testBase);

                // update attached database configuration
                testBase.attachedDatabaseConfiguration.TableLevelSharingProperties = testBase.tableLevelSharingProperties;
                testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.attachedDatabaseConfigurationName, testBase.attachedDatabaseConfiguration);
                // test follower databases
                followerDatabasesList = testBase.client.Clusters.ListFollowerDatabases(testBase.rgName, testBase.clusterName).ToList();
                VerifyFollowerDatabases(followerDatabasesList, testBase, tableLevelSharingProperties: testBase.tableLevelSharingProperties);

                // detach follower database
                var followerDatabase = followerDatabasesList[0];
                testBase.client.Clusters.DetachFollowerDatabases(testBase.rgName, testBase.clusterName, followerDatabase);
                followerDatabasesList = testBase.client.Clusters.ListFollowerDatabases(testBase.rgName, testBase.clusterName).ToList();
                Assert.Empty(followerDatabasesList);

                // delete follower cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.followerClusterName);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoIdentityTests()
        {
            using (var context = MockContext.Start(GetType()))
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
            using (var context = MockContext.Start(GetType()))
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

        [Fact]
        public void KustoPrivateEndpointConnectionsTests()
        {
            // create private end point (external network resource that can't be created in advance because it depends on the cluster)
            // Important - az network vnet subnet update --name default --resource-group test-clients-rg   --vnet-name test-clients-vnet  --disable-private-endpoint-network-policies true --disable-private-link-service-network-policies true

            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                CreatePrivateEndpoints(testBase, createdCluster.Id);

                // Get list
                var privateEndpointConnections = testBase.client.PrivateEndpointConnections.List(testBase.rgName, testBase.clusterName).ToList();
                Assert.Single(privateEndpointConnections);

                var privateEndpointConnection = privateEndpointConnections.First();
                VerifyPrivateEndpointConnection(privateEndpointConnection, testBase.privateEndpointConnectionName, PrivateEndpointStatus.Pending);

                // private endpoint connection approval - Patch
                privateEndpointConnection.PrivateLinkServiceConnectionState.Status = PrivateEndpointStatus.Approved.ToString();
                var createdPrivateEndpointConnection = testBase.client.PrivateEndpointConnections.CreateOrUpdate(
                    testBase.rgName,
                    testBase.clusterName,
                    privateEndpointConnection.Name,
                    privateEndpointConnection
                );
                VerifyPrivateEndpointConnection(createdPrivateEndpointConnection, testBase.privateEndpointConnectionName, PrivateEndpointStatus.Approved);

                // Get private endpoint connection
                var privateEndpointConnectionFetched = testBase.client.PrivateEndpointConnections.Get(testBase.rgName, testBase.clusterName, privateEndpointConnection.Name);
                VerifyPrivateEndpointConnection(privateEndpointConnectionFetched, testBase.privateEndpointConnectionName, PrivateEndpointStatus.Approved);

                // private endpoint connection rejection - Patch
                privateEndpointConnectionFetched.PrivateLinkServiceConnectionState.Status = PrivateEndpointStatus.Rejected.ToString();
                var rejectedPrivateEndpointConnection = testBase.client.PrivateEndpointConnections.CreateOrUpdate(
                    testBase.rgName,
                    testBase.clusterName,
                    privateEndpointConnectionFetched.Name,
                    privateEndpointConnectionFetched
                );
                VerifyPrivateEndpointConnection(rejectedPrivateEndpointConnection, testBase.privateEndpointConnectionName, PrivateEndpointStatus.Rejected);

                // Get cluster and validate PrivateEndpointConnections
                var cluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(cluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId, privateEndpointConnections: privateEndpointConnections.ToList());

                // Delete private endpoint connection
                testBase.client.PrivateEndpointConnections.Delete(testBase.rgName, testBase.clusterName, testBase.privateEndpointConnectionName);

                // Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoManagedPrivateEndpointsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create private endpoint connection
                var managedPrivateEndpoint = testBase.client.ManagedPrivateEndpoints.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.managedPrivateEndpointName, new ManagedPrivateEndpoint
                {
                    PrivateLinkResourceId = testBase.eventHubNamespaceResourceId,
                    GroupId = "namespace",
                    RequestMessage = "Please Approve Kusto"
                });
                VerifyManagedPrivateEndpoints(managedPrivateEndpoint, testBase.clusterName, testBase.managedPrivateEndpointName, testBase.eventHubNamespaceResourceId);

                var list1 = testBase.client.ManagedPrivateEndpoints.List(testBase.rgName, testBase.clusterName);
                Assert.Single(list1);

                var fetchedManagedPrivateEndpoint = testBase.client.ManagedPrivateEndpoints.Get(testBase.rgName, testBase.clusterName, testBase.managedPrivateEndpointName);
                VerifyManagedPrivateEndpoints(fetchedManagedPrivateEndpoint, testBase.clusterName, testBase.managedPrivateEndpointName, testBase.eventHubNamespaceResourceId);

                // delete managed private endpoint
                testBase.client.ManagedPrivateEndpoints.Delete(testBase.rgName, testBase.clusterName, testBase.managedPrivateEndpointName);
                var list2 = testBase.client.ManagedPrivateEndpoints.List(testBase.rgName, testBase.clusterName);
                Assert.Empty(list2);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoPrivateLinkResourcesTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                // create cluster
                var cluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                // create privateEndpointConnection
                var privateLinkResources = testBase.client.PrivateLinkResources.List(testBase.rgName, testBase.clusterName).ToList();
                Assert.Single(privateLinkResources);

                var privateLinkResource = privateLinkResources.First();
                Assert.Equal("cluster", privateLinkResource.GroupId);
                Assert.Equal(cluster.Id + "/PrivateLinkResources/cluster", privateLinkResource.Id);
                Assert.Equal(cluster.Name + "/cluster", privateLinkResource.Name);
                Assert.Equal(8, privateLinkResource.RequiredMembers.Count);
                Assert.Equal("Engine", privateLinkResource.RequiredMembers[0]);
                Assert.Equal("DataManagement", privateLinkResource.RequiredMembers[1]);
                Assert.Equal(4, privateLinkResource.RequiredZoneNames.Count);
                Assert.Equal($"privatelink.australiacentral.kusto.windows.net", privateLinkResource.RequiredZoneNames[0]);
                Assert.Equal("privatelink.blob.core.windows.net", privateLinkResource.RequiredZoneNames[1]);
                Assert.Equal("privatelink.queue.core.windows.net", privateLinkResource.RequiredZoneNames[2]);
                Assert.Equal("privatelink.table.core.windows.net", privateLinkResource.RequiredZoneNames[3]);

                // delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        private void VerifyFollowerDatabases(List<FollowerDatabaseDefinition> followerDatabasesList, KustoTestBase testBase, TableLevelSharingProperties tableLevelSharingProperties = null)
        {
            Assert.Single(followerDatabasesList);
            var followerDatabase = followerDatabasesList[0];

            Assert.NotNull(followerDatabase);

            Assert.Equal(testBase.followerClusterResourceId, followerDatabase.ClusterResourceId);
            Assert.Equal(testBase.attachedDatabaseConfigurationName, followerDatabase.AttachedDatabaseConfigurationName);
            Assert.Equal(testBase.databaseName, followerDatabase.DatabaseName);
            Assert.Equal(testBase.databaseShareOrigin, followerDatabase.DatabaseShareOrigin);
            AssertTableLevelSharingProperties(tableLevelSharingProperties, followerDatabase.TableLevelSharingProperties);
        }

        private void VerifyKeyVaultProperties(KeyVaultProperties keyVaultProperties, string keyName, string keyVersion, string keyVaultUri)
        {
            Assert.NotNull(keyVaultProperties);
            Assert.Equal(keyName, keyVaultProperties.KeyName);
            Assert.Equal(keyVersion, keyVaultProperties.KeyVersion);
            Assert.Equal(keyVaultUri, keyVaultProperties.KeyVaultUri);
        }

        private void VerifyAttachedDatabaseConfiguration(AttachedDatabaseConfiguration attachedDatabaseConfiguration, KustoTestBase testBase, string databaseNameOverride = null, string databaseNamePrefix = null, TableLevelSharingProperties tableLevelSharingProperties = null)
        {
            Assert.NotNull(attachedDatabaseConfiguration);

            var attachedDatabaseConfigurationFullName = ResourcesNamesUtils.GetAttachedDatabaseConfigurationName(testBase.followerClusterName, testBase.attachedDatabaseConfigurationName);
            Assert.Equal(attachedDatabaseConfigurationFullName, attachedDatabaseConfiguration.Name);

            Assert.Equal(testBase.databaseName, attachedDatabaseConfiguration.DatabaseName);
            Assert.Equal(testBase.leaderClusterResourceId, attachedDatabaseConfiguration.ClusterResourceId);
            Assert.Equal(testBase.defaultPrincipalsModificationKind, attachedDatabaseConfiguration.DefaultPrincipalsModificationKind);
            Assert.Equal(databaseNameOverride, attachedDatabaseConfiguration.DatabaseNameOverride);
            Assert.Equal(databaseNamePrefix, attachedDatabaseConfiguration.DatabaseNamePrefix);
            AssertTableLevelSharingProperties(tableLevelSharingProperties, attachedDatabaseConfiguration.TableLevelSharingProperties);
        }

        private void VerifyEventHub(
            EventHubDataConnection eventHubDataConnection,
            KustoTestBase testBase,
            string dataFormat = "",
            string managedIdentityResourceId = null,
            string databaseRouting = "Single",
            string retrievalStartDate = "9/19/2022 8:49:39 PM")
        {
            Assert.NotNull(eventHubDataConnection);

            var eventHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
            Assert.Equal(eventHubFullName, eventHubDataConnection.Name);

            Assert.Equal(testBase.eventHubResourceId, eventHubDataConnection.EventHubResourceId);
            Assert.Equal(testBase.consumerGroupName, eventHubDataConnection.ConsumerGroup);
            Assert.Equal(dataFormat, eventHubDataConnection.DataFormat);
            Assert.Equal(managedIdentityResourceId, eventHubDataConnection.ManagedIdentityResourceId);
            Assert.Equal(databaseRouting, eventHubDataConnection.DatabaseRouting);
            Assert.Equal(retrievalStartDate, eventHubDataConnection.RetrievalStartDate.ToString());
        }

        private void VerifyIotHub(
            IotHubDataConnection iotHubDataConnection,
            KustoTestBase testBase,
            string dataFormat = "",
            string databaseRouting = "Single",
            string retrievalStartDate = "9/19/2022 7:36:22 PM")
        {
            Assert.NotNull(iotHubDataConnection);

            var iotHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
            Assert.Equal(iotHubFullName, iotHubDataConnection.Name);

            Assert.Equal(testBase.iotHubResourceId, iotHubDataConnection.IotHubResourceId);
            Assert.Equal(testBase.consumerGroupName, iotHubDataConnection.ConsumerGroup);
            Assert.Equal(dataFormat, iotHubDataConnection.DataFormat);
            Assert.Equal(databaseRouting, iotHubDataConnection.DatabaseRouting);
            Assert.Equal(retrievalStartDate, iotHubDataConnection.RetrievalStartDate.ToString());
        }

        private void VerifyEventGrid(
            EventGridDataConnection createdDataConnection,
            string eventGridConnectionName,
            string eventHubResourceId,
            string consumerGroupName,
            string clusterName,
            string databaseName,
            string dataFormat,
            string storageAccountResourceId,
            string tableName,
            string databaseRouting = "Single",
            string manageIdentityResourceId = null,
            string manageIdentityObjectId = null)
        {
            var eventGridFullName = ResourcesNamesUtils.GetDatabaseChildFullName(clusterName, databaseName, eventGridConnectionName);
            Assert.Equal(eventGridFullName, createdDataConnection.Name);
            Assert.Equal(eventHubResourceId, createdDataConnection.EventHubResourceId);
            Assert.Equal(consumerGroupName, createdDataConnection.ConsumerGroup);
            Assert.Equal(dataFormat, createdDataConnection.DataFormat);
            Assert.Equal(storageAccountResourceId, createdDataConnection.StorageAccountResourceId);
            Assert.Equal(tableName, createdDataConnection.TableName);
            Assert.Equal(databaseRouting, createdDataConnection.DatabaseRouting);
            Assert.Equal(manageIdentityResourceId, createdDataConnection.ManagedIdentityResourceId);
            Assert.Equal(manageIdentityObjectId, createdDataConnection.ManagedIdentityObjectId);
        }

        private void VerifyScript(Script createdScript, string scriptUrl, string forceUpdateTag, bool continueOnEerros, string clusterName, string databaseName, string scriptName)
        {
            var eventHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(clusterName, databaseName, scriptName);
            Assert.Equal(eventHubFullName, createdScript.Name);
            Assert.Equal(forceUpdateTag, createdScript.ForceUpdateTag);
            Assert.Equal(scriptUrl, createdScript.ScriptUrl);
            Assert.Null(createdScript.ScriptContent);
        }

        private void VerifyReadOnlyFollowingDatabase(ReadOnlyFollowingDatabase database, KustoTestBase testBase, string databaseName = null, TimeSpan? hotCachePeriod = null, TableLevelSharingProperties tableLevelSharingProperties = null)
        {
            Assert.NotNull(database);

            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(testBase.followerClusterName, databaseName ?? testBase.databaseName);
            Assert.Equal(databaseFullName, database.Name);

            Assert.Equal(testBase.softDeletePeriod1, database.SoftDeletePeriod);
            Assert.Equal(testBase.defaultPrincipalsModificationKind, database.PrincipalsModificationKind);
            // TODO: uncomment when bug fixed
            // Assert.Equal(testBase.databaseName, database.OriginalDatabaseName);
            Assert.Equal(testBase.databaseShareOrigin, database.DatabaseShareOrigin);
            Assert.Equal(hotCachePeriod ?? testBase.hotCachePeriod1, database.HotCachePeriod);
            AssertTableLevelSharingProperties(tableLevelSharingProperties,database.TableLevelSharingProperties);
        }

        private void VerifyReadWriteDatabase(ReadWriteDatabase database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string clusterName)
        {
            var databaseFullName = ResourcesNamesUtils.GetFullDatabaseName(clusterName, databaseName);

            Assert.NotNull(database);
            Assert.Equal(databaseFullName, database.Name);
            Assert.Equal(softDeletePeriod, database.SoftDeletePeriod);
            Assert.Equal(hotCachePeriod, database.HotCachePeriod);
        }

        private void VerifyCluster(Cluster cluster, string name, AzureSku sku, IList<TrustedExternalTenant> trustedExternalTenants, string state, string tenantId, string publicIPType = "IPv4", IList<PrivateEndpointConnection> privateEndpointConnections = null)
        {
            Assert.Equal(name, cluster.Name);
            AssetEqualtsSku(cluster.Sku, sku);
            Assert.Equal(state, cluster.State);
            AssetEqualtsExtrnalTenants(cluster.TrustedExternalTenants, trustedExternalTenants);
            Assert.Equal("SystemAssigned", cluster.Identity.Type);
            Assert.True(Guid.TryParse(cluster.Identity.PrincipalId, out _));
            Assert.Equal(tenantId, cluster.Identity.TenantId);
            Assert.Equal(publicIPType, cluster.PublicIPType);
            Assert.Null(cluster.VirtualClusterGraduationProperties);
            if (privateEndpointConnections == null)
            {
                Assert.Empty(cluster.PrivateEndpointConnections);
            }
            else
            {
                Assert.Equal(privateEndpointConnections.Count, cluster.PrivateEndpointConnections.Count);
                Assert.Equal(privateEndpointConnections[0].GroupId, cluster.PrivateEndpointConnections[0].GroupId);
            }
        }

        private void VerifyPrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection, string privateEndpointConnectionNamePrefix, PrivateEndpointStatus privateEndpointStatus)
        {
            Assert.Contains(privateEndpointConnectionNamePrefix, privateEndpointConnection.Name);
            Assert.Equal(privateEndpointStatus.ToString(), privateEndpointConnection.PrivateLinkServiceConnectionState.Status);
        }

        private void VerifyManagedPrivateEndpoints(ManagedPrivateEndpoint managedPrivateEndpoint, string clusterName, string managedPrivateEndpointName, string eventHubNamespaceResourceId)
        {
            Assert.Equal(clusterName + "/" + managedPrivateEndpointName, managedPrivateEndpoint.Name);
            Assert.Equal("Please Approve Kusto", managedPrivateEndpoint.RequestMessage);
            Assert.Equal(eventHubNamespaceResourceId, managedPrivateEndpoint.PrivateLinkResourceId);

        }

        private void ValidateOptimizedAutoscale(Cluster createdCluster, OptimizedAutoscale expectedOptimizedAutoscale)
        {
            var clusterOptimizedAutoscale = createdCluster.OptimizedAutoscale;

            if (clusterOptimizedAutoscale == null)
            {
                Assert.Null(expectedOptimizedAutoscale);

                return;
            }

            Assert.Equal(expectedOptimizedAutoscale.Version, clusterOptimizedAutoscale.Version);
            Assert.Equal(expectedOptimizedAutoscale.Minimum, clusterOptimizedAutoscale.Minimum);
            Assert.Equal(expectedOptimizedAutoscale.Maximum, clusterOptimizedAutoscale.Maximum);
            Assert.Equal(expectedOptimizedAutoscale.IsEnabled, clusterOptimizedAutoscale.IsEnabled);
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

        private void VerifyClusterPrincipalAssignment(ClusterPrincipalAssignment clusterPrincipalAssignment, string name, string aadObjectId, string role, string principalType)
        {
            Assert.Equal(aadObjectId, clusterPrincipalAssignment.AadObjectId);
            Assert.EndsWith(name, clusterPrincipalAssignment.Name);
            Assert.EndsWith(name, clusterPrincipalAssignment.Id);
            Assert.Equal(role, clusterPrincipalAssignment.Role);
            Assert.Equal(principalType, clusterPrincipalAssignment.PrincipalType);
        }

        private void VerifyDatabasePrincipalAssignment(DatabasePrincipalAssignment clusterPrincipalAssignment, string name, string aadObjectId, string role, string principalType)
        {
            Assert.Equal(aadObjectId, clusterPrincipalAssignment.AadObjectId);
            Assert.EndsWith(name, clusterPrincipalAssignment.Name);
            Assert.EndsWith(name, clusterPrincipalAssignment.Id);
            Assert.Equal(role, clusterPrincipalAssignment.Role);
            Assert.Equal(principalType, clusterPrincipalAssignment.PrincipalType);
        }

        private void AssertTableLevelSharingProperties(TableLevelSharingProperties expectedTableLevelSharingProperties, TableLevelSharingProperties actualTableLevelSharingProperties)
        {
            if (expectedTableLevelSharingProperties == null)
            {
                Assert.Null(actualTableLevelSharingProperties);
            }
            else
            {
                Assert.Equal(JsonConvert.SerializeObject(expectedTableLevelSharingProperties), JsonConvert.SerializeObject(actualTableLevelSharingProperties));
            }
        }

        private void VerifyDatabasePrincipals(List<DatabasePrincipal> principals, string addedPrincipalName = null)
        {
            var expectedPrincipalNames = new List<string> { "KustoClientsScenarioTest" };
            if (addedPrincipalName != null)
            {
                expectedPrincipalNames.Add(addedPrincipalName);
            }

            Assert.Equal(JsonConvert.SerializeObject(expectedPrincipalNames), JsonConvert.SerializeObject(principals.Select(principal => principal.Name)));
        }

        private static void CreatePrivateEndpoints( KustoTestBase testBase, string clusterId)
        {
            testBase.networkManagementClient.PrivateEndpoints.CreateOrUpdate(
                testBase.resourceGroupForTest,
                testBase.privateEndpointConnectionName,
                new PrivateEndpoint
                {
                    Location = testBase.location,
                    Subnet = new Subnet { Id = testBase.privateNetworkSubnetId },
                    ManualPrivateLinkServiceConnections = new List<PrivateLinkServiceConnection>(1)
                    {
                        new PrivateLinkServiceConnection
                        {
                            Name = testBase.privateEndpointConnectionName,
                            GroupIds = new List<string>(1) { "cluster" },
                            PrivateLinkServiceId = clusterId,
                            RequestMessage = "Please Approve"
                        }
                    }
                });
        }

        private enum PrivateEndpointStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}


