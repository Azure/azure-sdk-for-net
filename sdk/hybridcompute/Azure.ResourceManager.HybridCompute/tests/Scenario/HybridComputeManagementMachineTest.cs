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
            Assert.That(resourceData.Name, Is.EqualTo(machineName));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineCollection()
        {
            HybridComputeMachineCollection resourceCollection = await getMachineCollection();

            Debug.WriteLine($"Succeeded on id: {resourceCollection.Id}");
            string collectionId = "/subscriptions/" + subscriptionId + "/resourcegroups/" + resourceGroupName;
            Assert.That(resourceCollection.Id.ToString(), Is.EqualTo(collectionId));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanInstallPatch(){
            MachineInstallPatchesResult resourceData = await installPatch();

            Assert.That(resourceData.Status.ToString(), Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanAssessPatch(){
            MachineAssessPatchesResult resourceData = await assessPatch();

            Assert.That(resourceData.Status.ToString(), Is.EqualTo("Succeeded"));
        }

        // have to have a valid private link scope before running this function
        [TestCase]
        [RecordedTest]
        public async Task CanUpdateMachine()
        {
            HybridComputeMachineData resourceData = await updateMachine();

            Debug.WriteLine($"Succeeded on id: {resourceData.Id}");
            Assert.That(resourceData.Name.ToString(), Is.EqualTo(machineName));
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteMachine(){
            await deleteMachine();
        }
    }
}
