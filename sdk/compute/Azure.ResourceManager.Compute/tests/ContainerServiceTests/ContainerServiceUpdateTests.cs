// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ContainerServiceUpdateTests : ContainerServiceTestsBase
    {
        public ContainerServiceUpdateTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("need to be tested by compute team because of the ex' cannot unmarshal string into Go struct field Properties.properties.masterProfile of type int.'")]
        public async Task TestContainerServiceUpdateOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            var csName = Recording.GenerateAssetName(ContainerServiceNamePrefix);
            var masterDnsPrefixName = Recording.GenerateAssetName(MasterProfileDnsPrefix);
            var agentPoolDnsPrefixName = Recording.GenerateAssetName(AgentPoolProfileDnsPrefix);
            //Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "australiasoutheast");
            EnsureClientsInitialized();

            ContainerService inputContainerService;
            var getTwocontainerService = await CreateContainerService_NoAsyncTracking(
                rgName,
                csName,
                masterDnsPrefixName,
                agentPoolDnsPrefixName, cs =>
                {
                    cs.AgentPoolProfiles[0].Count = 1;
                    cs.MasterProfile.Count = 1;
                });
            var containerService = getTwocontainerService.Item1;
            inputContainerService = getTwocontainerService.Item2;
            // Update Container Service with increased AgentPoolProfiles Count
            containerService.AgentPoolProfiles[0].Count = 2;
            UpdateContainerService(rgName, csName, containerService);

            containerService = await ContainerServicesOperations.GetAsync(rgName, containerService.Name);
            ValidateContainerService(containerService, containerService);

            var listRes = ContainerServicesOperations.ListByResourceGroupAsync(rgName);
            var listResult = await listRes.ToEnumerableAsync();
            //Assert.Contains(listResult, a => a.Name == containerService.Name);
            await WaitForCompletionAsync(await ContainerServicesOperations.StartDeleteAsync(rgName, containerService.Name));
            var listResultAfterDeletionResult = ContainerServicesOperations.ListByResourceGroupAsync(rgName);
            var listResultAfterDeletion = await listResultAfterDeletionResult.ToEnumerableAsync();
            Assert.True(!listResultAfterDeletion.Any());
        }
    }
}
