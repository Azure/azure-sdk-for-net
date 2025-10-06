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
    public class HybridComputeManagementMachineTest : HybridComputeManagementTestBase
    {
        public HybridComputeManagementMachineTest(bool isAsync) : base(isAsync)
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
        public async Task CanGetMachine()
        {
            HybridComputeMachineData resourceData = await getMachine();

            Debug.WriteLine($"Succeeded on id: {resourceData.Id}");
            Debug.WriteLine($"Succeeded on name: {resourceData.Name}");
            Assert.AreEqual(machineName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineCollection()
        {
            HybridComputeMachineCollection resourceCollection = await getMachineCollection();

            Debug.WriteLine($"Succeeded on id: {resourceCollection.Id}");
            string collectionId = "/subscriptions/" + subscriptionId + "/resourcegroups/" + resourceGroupName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanInstallPatch(){
            MachineInstallPatchesResult resourceData = await installPatch();

            Assert.NotNull(resourceData.Status.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanAssessPatch(){
            MachineAssessPatchesResult resourceData = await assessPatch();

            Assert.AreEqual("Succeeded", resourceData.Status.ToString());
        }

        // have to have a valid private link scope before running this function
        [TestCase]
        [RecordedTest]
        public async Task CanUpdateMachine()
        {
            HybridComputeMachineData resourceData = await updateMachine();

            Debug.WriteLine($"Succeeded on id: {resourceData.Id}");
            Assert.AreEqual(machineName, resourceData.Name.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteMachine(){
            await deleteMachine();
        }
    }
}
