// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ManagedClusterTests : ServiceFabricManagedClustersManagementTestBase
    {
        public ServiceFabricManagedClusterCollection clusterCollection { get; set; }
        public string clusterName;
        private ResourceGroupResource resourceGroupResource;
        public ServiceFabricManagedClusterResource serviceFabricManagedCluster;
        public ManagedClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task BasicClusterTestAsync()
        {
            resourceGroupResource = await CreateResourceGroupWithTag();

            clusterName = Recording.GenerateAssetName("sfmctestclusternet");
            clusterCollection = resourceGroupResource.GetServiceFabricManagedClusters();

            ServiceFabricManagedClusterData data = new ServiceFabricManagedClusterData(new AzureLocation("westus"))
            {
                DnsName = clusterName,
                AdminUserName = "Myusername4",
                AdminPassword = "Sfmcpass5!",
                Sku = new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Standard),
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080
            };
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));

            serviceFabricManagedCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;

            ServiceFabricManagedClusterData resourceData = serviceFabricManagedCluster.Data;
            Assert.AreEqual(clusterName, resourceData.Name);
        }

        [Test]
        [RecordedTest]
        public async Task ListClusterTestAsync()
        {
            resourceGroupResource = await CreateResourceGroupWithTag();

            clusterName = Recording.GenerateAssetName("sfmctestclusternet");
            clusterCollection = resourceGroupResource.GetServiceFabricManagedClusters();

            ServiceFabricManagedClusterData data = new ServiceFabricManagedClusterData(new AzureLocation("westus"))
            {
                DnsName = clusterName,
                AdminUserName = "Myusername4",
                AdminPassword = "Sfmcpass5!",
                Sku = new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Standard),
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080
            };
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));

            serviceFabricManagedCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;

            ServiceFabricManagedClusterData resourceData = serviceFabricManagedCluster.Data;
            Assert.AreEqual(clusterName, resourceData.Name);

            var clustersList = clusterCollection.GetAllAsync();
            var clusterCount = 0;
            await foreach (ServiceFabricManagedClusterResource cluster in clustersList)
            {
                clusterCount++;
            }

            Assert.AreEqual(clusterCount, 1);
        }

        [Test]
        [RecordedTest]
        public async Task ClusterFaultSimulation()
        {
            // CreateOrUpdate
            resourceGroupResource = await CreateResourceGroupWithTag();

            serviceFabricManagedCluster = await CreateServiceFabricManagedClusterZoneResilient(resourceGroupResource, Recording.GenerateAssetName("sfmctest"));

            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(serviceFabricManagedCluster, primaryNodeTypeName, true);

            // Start Fault Simulation
            FaultSimulationContent content = new ZoneFaultSimulationContent
            {
                Zones = { "2" },
                FaultKind = "Zone",
            };

            FaultSimulationContentWrapper faultSimulationContentWrapper = new FaultSimulationContentWrapper(content);

            try
            {
                var startFaultSimulationResult = (await serviceFabricManagedCluster.StartFaultSimulationAsync(WaitUntil.Completed, faultSimulationContentWrapper)).Value;

                Assert.AreEqual(startFaultSimulationResult.Status, FaultSimulationStatus.Active);

                // List Fault Simulation
                var faultSimulationCount = 0;
                var mostRecentSimulationId = "";

                var listFaultSimulationResult = serviceFabricManagedCluster.GetFaultSimulationAsync();
                await foreach (FaultSimulation simulation in listFaultSimulationResult)
                {
                    faultSimulationCount++;
                    mostRecentSimulationId = simulation.SimulationId;
                }

                Assert.AreEqual(faultSimulationCount, 1);
                Assert.AreEqual(startFaultSimulationResult.SimulationId, mostRecentSimulationId);

                // Get Fault Simulation
                FaultSimulationIdContent faultSimulationIdContent = new FaultSimulationIdContent(startFaultSimulationResult.SimulationId);
                var getFaultSimulationResult = (await serviceFabricManagedCluster.GetFaultSimulationAsync(faultSimulationIdContent)).Value;

                Assert.AreEqual(startFaultSimulationResult.SimulationId, getFaultSimulationResult.SimulationId);
                Assert.AreEqual(startFaultSimulationResult.Details.ClusterId, getFaultSimulationResult.Details.ClusterId);
                Assert.AreEqual(startFaultSimulationResult.StartOn, getFaultSimulationResult.StartOn);
                Assert.AreEqual(startFaultSimulationResult.EndOn, getFaultSimulationResult.EndOn);

                // Stop Fault Simulation
                var stopFaultSimulationResult = (await serviceFabricManagedCluster.StopFaultSimulationAsync(WaitUntil.Completed, faultSimulationIdContent)).Value;

                Assert.AreEqual(startFaultSimulationResult.SimulationId, stopFaultSimulationResult.SimulationId);
                Assert.AreEqual(stopFaultSimulationResult.Status, FaultSimulationStatus.Done);
            }
            catch (Exception ex)
            {
                Console.WriteLine(content);
                Console.WriteLine(ex);
            }
        }
    }
}
