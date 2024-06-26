// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceAgentPoolTests : ContainerServiceManagementTestBase
    {
        public ContainerServiceAgentPoolTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateListGetDelete()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create cluster
            ContainerServiceManagedClusterResource cluster = await CreateContainerServiceAsync(rg, clusterName, rg.Data.Location);
            Assert.AreEqual(clusterName, cluster.Data.Name);
            Assert.AreEqual(DnsPrefix, cluster.Data.DnsPrefix);
            // Create agent pool
            ContainerServiceAgentPoolCollection collection = cluster.GetContainerServiceAgentPools();
            string agentPoolName = Recording.GenerateAssetName("ap");
            ContainerServiceAgentPoolData data = new ContainerServiceAgentPoolData()
            {
                Count = 3,
                VmSize = "Standard_DS2_v2",
                OSType = ContainerServiceOSType.Linux,
                OrchestratorVersion = "",
                EnableEncryptionAtHost = true
            };
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, agentPoolName, data).ConfigureAwait(false);
            ContainerServiceAgentPoolResource agentPool = lro.Value;
            Assert.AreEqual(agentPoolName, agentPool.Data.Name);
            // List Agent Pool
            int count = 0;
            await foreach (var pool in collection.GetAllAsync())
            {
                if (pool.Data.Name == agentPoolName)
                {
                    Assert.AreEqual(pool.Data.Name, agentPoolName);
                    count++;
                    break;
                }
            }
            Assert.AreEqual(count, 1);
            // Get Agent Pool
            ContainerServiceAgentPoolResource agentPoolGet = await agentPool.GetAsync();
            Assert.AreEqual(agentPoolGet.Data.Name, agentPoolName);
            // Delete Agent Pool
            await agentPoolGet.DeleteAsync(WaitUntil.Completed);
            // Delete Cluster
            await cluster.DeleteAsync(WaitUntil.Completed);
        }
    }
}
