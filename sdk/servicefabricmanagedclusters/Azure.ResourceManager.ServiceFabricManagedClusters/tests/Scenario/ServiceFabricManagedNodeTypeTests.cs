﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagedNodeTypeTests : ServiceFabricManagedClustersManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ServiceFabricManagedClusterResource _cluster;
        private ServiceFabricManagedNodeTypeCollection _nodeTypeCollection;
        public ServiceFabricManagedNodeTypeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        public async Task CreateOrUpdateDelete()
        {
            // CreateOrUpdate
            _cluster = await CreateServiceFabricManagedCluster(_resourceGroup, Recording.GenerateAssetName("sfmctest"));
            _nodeTypeCollection = _cluster.GetServiceFabricManagedNodeTypes();

            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            string secondaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, primaryNodeTypeName, true);
            var secondaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, secondaryNodeTypeName, false);
            ValidatePurviewAccount(primaryNodeType.Data, primaryNodeTypeName);
            ValidatePurviewAccount(secondaryNodeType.Data, secondaryNodeTypeName);
            // Delete
            await secondaryNodeType.DeleteAsync(WaitUntil.Completed);
            var flag = await _nodeTypeCollection.ExistsAsync(secondaryNodeTypeName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task ExistGetGetAll()
        {
            _cluster = await CreateServiceFabricManagedCluster(_resourceGroup, Recording.GenerateAssetName("sfmctest"));
            _nodeTypeCollection = _cluster.GetServiceFabricManagedNodeTypes();

            string nodeTypeName = Recording.GenerateAssetName("node");
            var nodeType = await CreateServiceFabricManagedNodeType(_cluster, nodeTypeName, true);

            // Exist
            var flag = await _nodeTypeCollection.ExistsAsync(nodeTypeName);
            Assert.IsTrue(flag);

            // Get
            var getNodeType = await _nodeTypeCollection.GetAsync(nodeTypeName);
            ValidatePurviewAccount(getNodeType.Value.Data, nodeTypeName);

            // GetAll
            var list = await _nodeTypeCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePurviewAccount(list.FirstOrDefault().Data, nodeTypeName);
        }

        [RecordedTest]
        [Ignore("TODO: re-record this test")]
        public async Task NodeTypesActions()
        {
            // CreateOrUpdate
            _cluster = await CreateServiceFabricManagedCluster(_resourceGroup, Recording.GenerateAssetName("sfmctest"));

            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            string secondaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, primaryNodeTypeName, true);
            var secondaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, secondaryNodeTypeName, false);
            ValidatePurviewAccount(primaryNodeType.Data, primaryNodeTypeName);
            ValidatePurviewAccount(secondaryNodeType.Data, secondaryNodeTypeName);

            // Actions
            NodeTypeActionContent content = new NodeTypeActionContent
            {
                Nodes = { String.Format("{0}_1", secondaryNodeTypeName), String.Format("{0}_3", secondaryNodeTypeName) },
            };

            // Deallocate
            await secondaryNodeType.DeallocateAsync(WaitUntil.Completed, content);

            // Start/Allocate
            await secondaryNodeType.StartAsync(WaitUntil.Completed, content);

            content.UpdateType = ServiceFabricManagedClusterUpdateType.ByUpgradeDomain;
            // Redeploy
            await secondaryNodeType.RedeployAsync(WaitUntil.Completed, content);
        }

        [RecordedTest]
        public async Task NodeTypeFaultSimulationTest()
        {
            // CreateOrUpdate
            _cluster = await CreateServiceFabricManagedClusterZoneResilient(_resourceGroup, Recording.GenerateAssetName("sfmctest"));

            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            string secondaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, primaryNodeTypeName, true);
            var secondaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, secondaryNodeTypeName, false);
            ValidatePurviewAccount(primaryNodeType.Data, primaryNodeTypeName);
            ValidatePurviewAccount(secondaryNodeType.Data, secondaryNodeTypeName);

            // Start Fault Simulation
            FaultSimulationContent content = new ZoneFaultSimulationContent
            {
                Zones = { "2" },
                FaultKind = "Zone",
            };

            FaultSimulationContentWrapper faultSimulationContentWrapper = new FaultSimulationContentWrapper(content);

            try
            {
                var startFaultSimulationResult = (await secondaryNodeType.StartFaultSimulationAsync(WaitUntil.Completed, faultSimulationContentWrapper)).Value;

                Assert.AreEqual(startFaultSimulationResult.Status, FaultSimulationStatus.Active);

                // List Fault Simulation
                var faultSimulationCount = 0;
                var mostRecentSimulationId = "";

                var listFaultSimulationResult = secondaryNodeType.GetFaultSimulationAsync();
                await foreach (FaultSimulation simulation in listFaultSimulationResult)
                {
                    faultSimulationCount++;
                    mostRecentSimulationId = simulation.SimulationId;
                }

                Assert.AreEqual(faultSimulationCount, 1);
                Assert.AreEqual(startFaultSimulationResult.SimulationId, mostRecentSimulationId);

                // Get Fault Simulation
                FaultSimulationIdContent faultSimulationIdContent = new FaultSimulationIdContent(startFaultSimulationResult.SimulationId);
                var getFaultSimulationResult = (await secondaryNodeType.GetFaultSimulationAsync(faultSimulationIdContent)).Value;

                Assert.AreEqual(startFaultSimulationResult.SimulationId, getFaultSimulationResult.SimulationId);
                Assert.AreEqual(startFaultSimulationResult.Details.ClusterId, getFaultSimulationResult.Details.ClusterId);
                Assert.AreEqual(startFaultSimulationResult.StartOn, getFaultSimulationResult.StartOn);
                Assert.AreEqual(startFaultSimulationResult.EndOn, getFaultSimulationResult.EndOn);

                // Stop Fault Simulation
                var stopFaultSimulationResult = (await secondaryNodeType.StopFaultSimulationAsync(WaitUntil.Completed, faultSimulationIdContent)).Value;

                Assert.AreEqual(startFaultSimulationResult.SimulationId, stopFaultSimulationResult.SimulationId);
                Assert.AreEqual(stopFaultSimulationResult.Status, FaultSimulationStatus.Done);
            }
            catch (Exception ex)
            {
                Console.WriteLine(content);
                Console.WriteLine(ex);
            }
        }

        private void ValidatePurviewAccount(ServiceFabricManagedNodeTypeData nodeType, string nodeTypeName)
        {
            Assert.IsNotNull(nodeType);
            Assert.IsNotEmpty(nodeType.Id);
            Assert.AreEqual(nodeTypeName, nodeType.Name);
            Assert.AreEqual("S", nodeType.DataDiskLetter);
            Assert.AreEqual(256, nodeType.DataDiskSizeInGB);
            Assert.AreEqual(ServiceFabricManagedDataDiskType.StandardSsdLrs, nodeType.DataDiskType);
            Assert.AreEqual("WindowsServer", nodeType.VmImageOffer);
            Assert.AreEqual("MicrosoftWindowsServer", nodeType.VmImagePublisher);
            Assert.AreEqual("2022-Datacenter", nodeType.VmImageSku);
            Assert.AreEqual("latest", nodeType.VmImageVersion);
            Assert.AreEqual(6, nodeType.VmInstanceCount);
            Assert.AreEqual("Standard_D2_v2", nodeType.VmSize);
        }
    }
}
