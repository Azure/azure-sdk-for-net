// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class AgentTests : StorageMoverManagementTestBase
    {
        public AgentTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetExistTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverResource storageMover = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverAgentCollection agents = storageMover.GetStorageMoverAgents();

            StorageMoverAgentResource agent = (await agents.GetAsync(AgentName)).Value;
            StorageMoverAgentResource agent2 = (await agent.GetAsync()).Value;
            Assert.AreEqual(agent.Data.Name, agent2.Data.Name);
            Assert.AreEqual(agent.Data.Id, agent2.Data.Id);
            Assert.AreEqual(agent.Data.LocalIPAddress, agent2.Data.LocalIPAddress);
            Assert.AreEqual(agent.Id.Name, agent2.Id.Name);

            int counter = 0;
            await foreach (StorageMoverAgentResource _ in agents.GetAllAsync())
            {
                counter++;
            }
            Assert.GreaterOrEqual(counter, 1);

            StorageMoverAgentPatch patch = new StorageMoverAgentPatch
            {
                Description = "This is an updated agent"
            };
            agent = (await agent.UpdateAsync(patch)).Value;
            Assert.AreEqual(patch.Description, agent.Data.Description);

            Assert.IsTrue((await agents.ExistsAsync(AgentName)).Value);
            Assert.IsFalse((await agents.ExistsAsync(AgentName + "111")).Value);
        }
    }
}
