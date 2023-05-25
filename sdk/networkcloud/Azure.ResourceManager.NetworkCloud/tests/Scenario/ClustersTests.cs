// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class ClustersTests : NetworkCloudManagementTestBase
    {
        public ClustersTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public ClustersTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task Clusters()
        {
            var clusterName = Recording.GenerateAssetName("cluster");
            ClusterCollection clusterCollection = ResourceGroupResource.GetClusters();

            // Create
            var createCreds = new AdministrativeCredentials("password","username");
            ClusterData data = new ClusterData
            (
                new AzureLocation(TestEnvironment.Location),
                new ExtendedLocation(TestEnvironment.ManagerExtendedLocation, "CustomLocation"),
                new RackDefinition("/subscriptions/fca2e8ee-1179-48b8-9532-428ed0873a2e/resourceGroups/m15-lab/providers/Microsoft.Network/virtualNetworks/m15-vnet/subnets/ClusterManagerSubnet", "b37m15r1", "/subscriptions/fca2e8ee-1179-48b8-9532-428ed0873a2e/providers/Microsoft.NetworkCloud/rackSkus/VLab_Single_DellR750_8C2M_x70r3_9")
                {
                    BareMetalMachineConfigurationData =
                    {
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:FF","00:BB:CC:DD:EE:FF",2,"BM1219XXX")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName1",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:00","00:BB:CC:DD:EE:00",3,"BM1219YYY")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName2",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:F0","00:BB:CC:DD:EE:F0",4,"BM1219XX0")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName3",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:01","00:BB:CC:DD:EE:01",5,"BM1219YY1")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName4",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:F1","00:BB:CC:DD:EE:F1",6,"BM1219XX1")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName5",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:02","00:BB:CC:DD:EE:02",7,"BM1219YY2")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName6",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:F2","00:BB:CC:DD:EE:F2",8,"BM1219XX2")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName7",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:03","00:BB:CC:DD:EE:03",9,"BM1219YY3")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName8",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:F3","00:BB:CC:DD:EE:F3",10,"BM1219XX3")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName9",
                        },
                        new BareMetalMachineConfigurationData(createCreds,"AA:BB:CC:DD:EE:04","00:BB:CC:DD:EE:04",11,"BM1219YY4")
                        {
                            MachineDetails = "extraDetails",
                            MachineName = "bmmName10",
                        },
                    },
                    StorageApplianceConfigurationData =
                    {
                        new StorageApplianceConfigurationData(createCreds, 1, "serialno"){},
                    },
                },
                "testAnalyticsWorkspaceID",
                ClusterType.SingleRack,
                "0.1.6",
                "/subscriptions/fca2e8ee-1179-48b8-9532-428ed0873a2e/resourceGroups/m15-lab/providers/Microsoft.Network/virtualNetworks/m15-vnet/subnets/M15ClusterManagerSubnet"
            )
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            var createResult = await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data);
            Assert.AreEqual(clusterName, createResult.Value.Data.Name);

            // Get
            var getResult = await clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(clusterName, getResult.Value.Data.Name);
            ClusterResource clusterResource = Client.GetClusterResource(getResult.Value.Data.Id);

            // Update
            ClusterPatch patch = new ClusterPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            var patchResult = await clusterResource.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, patchResult.Value.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<ClusterResource>();
            await foreach (ClusterResource item in clusterCollection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<ClusterResource>();
            await foreach (ClusterResource item in SubscriptionResource.GetClustersAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await clusterResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}