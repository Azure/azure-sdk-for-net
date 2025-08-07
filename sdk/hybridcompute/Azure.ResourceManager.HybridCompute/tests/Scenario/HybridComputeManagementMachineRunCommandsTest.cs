// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridCompute;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;
using System.Diagnostics;

namespace Azure.ResourceManager.HybridCompute.Tests.Scenario
{
    public class HybridComputeManagementMachineRunCommandsTest : HybridComputeManagementTestBase
    {
        public HybridComputeManagementMachineRunCommandsTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateMachineRunCommand()
        {
            MachineRunCommandData resourceData = await createRunCommand();
            Assert.AreEqual(runCommandName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdateMachineRunCommand()
        {
            MachineRunCommandData resourceData = await updateRunCommand();
            Assert.AreEqual(runCommandName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineRunCommand()
        {
            MachineRunCommandData resourceData = await getRunCommand();
            Assert.AreEqual(runCommandName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineRunCommandCollection()
        {
            MachineRunCommandCollection resourceCollection = await getRunCommandCollection();
            string collectionId = "/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + machineName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteMachineRunCommand(){
            await deleteRunCommand();
        }
    }
}
