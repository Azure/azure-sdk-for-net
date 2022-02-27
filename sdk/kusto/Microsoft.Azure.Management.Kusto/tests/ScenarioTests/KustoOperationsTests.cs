
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
                    //Create a test capacity
                    var resultOperationsList = testBase.client.Operations.List();

                    //  validate the operations result
                    Assert.Equal(numOfOperations, resultOperationsList.Count());

                    var operationsPageLink = "https://management.azure.com/providers/Microsoft.Kusto/operations?api-version=2018-09-07-preview";
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(createdCluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId);
        
                // get cluster
                var cluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(cluster, testBase.clusterName, testBase.sku1, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId);
        
                //update cluster
                testBase.cluster.Sku = testBase.sku2;
                testBase.cluster.PublicIPType = "DualStack";
                var updatedCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
                VerifyCluster(updatedCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);
        
                //suspend cluster
                testBase.client.Clusters.Stop(testBase.rgName, testBase.clusterName);
                var stoppedCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(stoppedCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.stoppedState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);
        
                //suspend cluster
                testBase.client.Clusters.Start(testBase.rgName, testBase.clusterName);
                var runningCluster = testBase.client.Clusters.Get(testBase.rgName, testBase.clusterName);
                VerifyCluster(runningCluster, testBase.clusterName, testBase.sku2, trustedExternalTenants: testBase.trustedExternalTenants, state: testBase.runningState, tenantId: testBase.tenantId, publicIPType: testBase.cluster.PublicIPType);
        
        
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(createdDb, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdCluster.Name);
        
                // get database 
                var database = testBase.client.Databases.Get(testBase.rgName, createdCluster.Name, testBase.databaseName) as ReadWriteDatabase;
                VerifyReadWriteDatabase(database, testBase.databaseName, testBase.softDeletePeriod1, testBase.hotCachePeriod1, createdCluster.Name);
        
                //update database
                testBase.database.HotCachePeriod = testBase.hotCachePeriod2;
                testBase.database.SoftDeletePeriod = testBase.softDeletePeriod2;
                var updatedDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database) as ReadWriteDatabase;
                VerifyReadWriteDatabase(updatedDb, testBase.databaseName, testBase.softDeletePeriod2, testBase.hotCachePeriod2, createdCluster.Name);
        
                //delete database
                testBase.client.Databases.Delete(testBase.rgName, createdCluster.Name, testBase.databaseName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Databases.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: testBase.databaseName);
                });
        
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoEventHubTests()
        {
            using (var context = MockContext.Start(GetType()))
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
                    dataFormat: string.Empty);
        
                // get event hub connection
                var eventHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName);
                VerifyEventHub(eventHubConnection as EventHubDataConnection, 
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    dataFormat: string.Empty);
        
                //update event hub connection
                var systemAssignedManagedIdentityResourceId = createdCluster.Id;
                testBase.eventhubConnection.DataFormat = testBase.dataFormat;
                testBase.eventhubConnection.DatabaseRouting = testBase.MultiDatabaseRouting;
                testBase.eventhubConnection.ManagedIdentityResourceId = systemAssignedManagedIdentityResourceId;
                var updatedEventHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.eventHubConnectionName, testBase.eventhubConnection);
                VerifyEventHub(updatedEventHubConnection as EventHubDataConnection,
                    testBase.eventHubConnectionName,
                    testBase.eventHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    dataFormat: testBase.dataFormat,
                    databaseRouting: testBase.MultiDatabaseRouting,
                    manageIdentityResourceId:systemAssignedManagedIdentityResourceId);
        
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                //create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create iot hub connection
                var createdIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
                VerifyIotHub(createdIotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    dataFormat: string.Empty);
        
                // get Iot hub connection
                var iotHubConnection = testBase.client.DataConnections.Get(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName);
                VerifyIotHub(iotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                     dataFormat: string.Empty);
        
                //update Iot hub connection
                testBase.iotHubDataConnection.DataFormat = testBase.dataFormat;
                testBase.iotHubDataConnection.DatabaseRouting = testBase.MultiDatabaseRouting;
                var updatedIotHubConnection = testBase.client.DataConnections.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.iotHubConnectionName, testBase.iotHubDataConnection);
                VerifyIotHub(updatedIotHubConnection as IotHubDataConnection,
                    testBase.iotHubConnectionName,
                    testBase.iotHubResourceId,
                    testBase.consumerGroupName,
                    testBase.clusterName,
                    testBase.databaseName,
                    dataFormat:testBase.dataFormat,
                    databaseRouting: testBase.MultiDatabaseRouting);
        
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
            using (var context = MockContext.Start(GetType()))
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
        
                //update event grid connection with managed identity
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
        public void KustoDatabaseScriptTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                //create database
                var createdDb = testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);

                //create script
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

                //update script
                testBase.script.ForceUpdateTag = testBase.forceUpdateTag2;
                var updatedScript = testBase.client.Scripts.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName, testBase.script);
                 VerifyScript(updatedScript,
                    testBase.scriptUrl,
                    testBase.forceUpdateTag2,
                    testBase.continueOnErrors,
                    testBase.clusterName,
                    testBase.databaseName,
                    testBase.scriptName);
                 
                  //update script with content
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
                  
                //delete script
                testBase.client.Scripts.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName, testBase.scriptName);
                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.Scripts.Get(
                        resourceGroupName: testBase.rgName,
                        clusterName: createdCluster.Name,
                        databaseName: createdDb.Name,
                        scriptName: testBase.scriptName);
                });

                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);

                //delete cluster
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
        
                //Delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoDatabasePrincipalsTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                //create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                //create cluster principal assignment
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
        
                //create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create database principal assignment
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
        
                //delete database
                testBase.client.Databases.Delete(testBase.rgName, testBase.clusterName, testBase.databaseName);
        
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }
        
        [Fact]
        public void KustoAttachedDatabaseConfigurationTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                // create a follower cluster
                var createdFollowerCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);
        
                //create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
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
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);
        
                //create cluster
                var createdCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);
        
                // create a follower cluster
                var createdFollowerCluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.followerClusterName, testBase.cluster);
        
                //create database
                testBase.client.Databases.CreateOrUpdate(testBase.rgName, createdCluster.Name, testBase.databaseName, testBase.database);
        
                //create attached database configuration
                testBase.client.AttachedDatabaseConfigurations.CreateOrUpdate(
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
                
                //private endpoint connection rejection - Patch
                privateEndpointConnectionFetched.PrivateLinkServiceConnectionState.Status = PrivateEndpointStatus.Rejected.ToString();
                var rejectedPrivateEndpointConnection = testBase.client.PrivateEndpointConnections.CreateOrUpdate(
                    testBase.rgName, 
                    testBase.clusterName, 
                    privateEndpointConnectionFetched.Name, 
                    privateEndpointConnectionFetched
                );
                VerifyPrivateEndpointConnection(rejectedPrivateEndpointConnection, testBase.privateEndpointConnectionName, PrivateEndpointStatus.Rejected);
                
                //Get cluster and validate PrivateEndpointConnections
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

                //delete managed private endpoint
                testBase.client.ManagedPrivateEndpoints.Delete(testBase.rgName, testBase.clusterName, testBase.managedPrivateEndpointName);
                var list2 = testBase.client.ManagedPrivateEndpoints.List(testBase.rgName, testBase.clusterName);
                Assert.Empty(list2);
                
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
            }
        }

        [Fact]
        public void KustoPrivateLinkResourcesTests()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var testBase = new KustoTestBase(context);

                //create cluster
                var cluster = testBase.client.Clusters.CreateOrUpdate(testBase.rgName, testBase.clusterName, testBase.cluster);

                //create privateEndpointConnection
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
                
                //delete cluster
                testBase.client.Clusters.Delete(testBase.rgName, testBase.clusterName);
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

        private void VerifyEventHub(
            EventHubDataConnection createdDataConnection, 
            string eventHubConnectionName, 
            string eventHubResourceId,
            string consumerGroupName,
            string clusterName, 
            string databaseName, 
            string dataFormat,
            string databaseRouting = "Single",
            string manageIdentityResourceId = null)
        {
            var eventHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(clusterName, databaseName, eventHubConnectionName);
            Assert.Equal(createdDataConnection.Name, eventHubFullName);
            Assert.Equal(createdDataConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
            Assert.Equal(createdDataConnection.DatabaseRouting, databaseRouting);
            Assert.Equal(createdDataConnection.ManagedIdentityResourceId, manageIdentityResourceId);
        }

        private void VerifyIotHub(
            IotHubDataConnection createdDataConnection, 
            string iotHubConnectionName, 
            string iotHubResourceId, 
            string consumerGroupName, 
            string clusterName, 
            string databaseName, 
            string dataFormat,
            string databaseRouting = "Single")
        {
            var iotHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(clusterName, databaseName, iotHubConnectionName);
            Assert.Equal(createdDataConnection.Name, iotHubFullName);
            Assert.Equal(createdDataConnection.IotHubResourceId, iotHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
            Assert.Equal(createdDataConnection.DatabaseRouting, databaseRouting);
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
            Assert.Equal(createdDataConnection.Name, eventGridFullName);
            Assert.Equal(createdDataConnection.EventHubResourceId, eventHubResourceId);
            Assert.Equal(createdDataConnection.ConsumerGroup, consumerGroupName);
            Assert.Equal(createdDataConnection.DataFormat, dataFormat);
            Assert.Equal(createdDataConnection.StorageAccountResourceId, storageAccountResourceId);
            Assert.Equal(createdDataConnection.TableName, tableName);
            Assert.Equal(createdDataConnection.DatabaseRouting, databaseRouting);
            Assert.Equal(createdDataConnection.ManagedIdentityResourceId, manageIdentityResourceId);
            Assert.Equal(createdDataConnection.ManagedIdentityObjectId, manageIdentityObjectId);
        }

        private void VerifyScript(Script createdScript, string scriptUrl, string forceUpdateTag, bool continueOnEerros, string clusterName, string databaseName, string scriptName)
        {
            var eventHubFullName = ResourcesNamesUtils.GetDatabaseChildFullName(clusterName, databaseName, scriptName);
            Assert.Equal(createdScript.Name, eventHubFullName);
            Assert.Equal(createdScript.ForceUpdateTag, forceUpdateTag);
            Assert.Equal(createdScript.ScriptUrl, scriptUrl);
            Assert.Null(createdScript.ScriptContent);
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

        private void VerifyCluster(Cluster cluster, string name, AzureSku sku, IList<TrustedExternalTenant> trustedExternalTenants, string state, string tenantId, string publicIPType = "IPv4", IList<PrivateEndpointConnection> privateEndpointConnections = null)
        {
            Assert.Equal(cluster.Name, name);
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
                Assert.Null(cluster.PrivateEndpointConnections);
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


