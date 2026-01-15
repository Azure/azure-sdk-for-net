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
            Assert.That(resourceData.Name, Is.EqualTo(clusterName));
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
            Assert.That(resourceData.Name, Is.EqualTo(clusterName));

            var clustersList = clusterCollection.GetAllAsync();
            var clusterCount = 0;
            await foreach (ServiceFabricManagedClusterResource cluster in clustersList)
            {
                clusterCount++;
            }

            Assert.That(clusterCount, Is.EqualTo(1));
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

                Assert.That(FaultSimulationStatus.Active, Is.EqualTo(startFaultSimulationResult.Status));

                // List Fault Simulation
                var faultSimulationCount = 0;
                var mostRecentSimulationId = "";

                var listFaultSimulationResult = serviceFabricManagedCluster.GetFaultSimulationAsync();
                await foreach (FaultSimulation simulation in listFaultSimulationResult)
                {
                    faultSimulationCount++;
                    mostRecentSimulationId = simulation.SimulationId;
                }

                Assert.That(faultSimulationCount, Is.EqualTo(1));
                Assert.That(mostRecentSimulationId, Is.EqualTo(startFaultSimulationResult.SimulationId));

                // Get Fault Simulation
                FaultSimulationIdContent faultSimulationIdContent = new FaultSimulationIdContent(startFaultSimulationResult.SimulationId);
                var getFaultSimulationResult = (await serviceFabricManagedCluster.GetFaultSimulationAsync(faultSimulationIdContent)).Value;

                Assert.That(getFaultSimulationResult.SimulationId, Is.EqualTo(startFaultSimulationResult.SimulationId));
                Assert.That(getFaultSimulationResult.Details.ClusterId, Is.EqualTo(startFaultSimulationResult.Details.ClusterId));
                Assert.That(getFaultSimulationResult.StartOn, Is.EqualTo(startFaultSimulationResult.StartOn));
                Assert.That(getFaultSimulationResult.EndOn, Is.EqualTo(startFaultSimulationResult.EndOn));

                // Stop Fault Simulation
                var stopFaultSimulationResult = (await serviceFabricManagedCluster.StopFaultSimulationAsync(WaitUntil.Completed, faultSimulationIdContent)).Value;

                Assert.That(stopFaultSimulationResult.SimulationId, Is.EqualTo(startFaultSimulationResult.SimulationId));
                Assert.That(FaultSimulationStatus.Done, Is.EqualTo(stopFaultSimulationResult.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine(content);
                Console.WriteLine(ex);
            }
        }
    }
}
