// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests.Tests
{
    /// <summary>
    /// Tests for container instance SDK.
    /// </summary>
    public partial class ContainerGroupsTests : ContainerInstanceManagementClientBase
    {
        public ContainerGroupsTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ContainerGroupsCreateTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create container group for test
            var containerGroupName = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupParam = Helper.CreateTestContainerGroup(containerGroupName, location);
            var containerGroup = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName, containerGroupParam))).Value;
            Helper.VerifyContainerGroupProperties(containerGroupParam, containerGroup);
        }

        [Test]
        public async Task ContainerGroupsGetTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create two container group for test
            var containerGroupName01 = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupName02 = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);

            var containerGroupParam01 = Helper.CreateTestContainerGroup(containerGroupName01, location);
            var containerGroup01 = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName01, containerGroupParam01))).Value;

            var containerGroupParam02 = Helper.CreateTestContainerGroup(containerGroupName02, location);
            var containerGroup02 = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName02, containerGroupParam02))).Value;

            // Get container group by name
            var containerGroup = (await ContainerGroupsOperations.GetAsync(resourceGroup, containerGroupName01)).Value;
            Helper.VerifyContainerGroupProperties(containerGroup01, containerGroup);

            // List container groups unde a resource group
            var containerGroups = await ContainerGroupsOperations.ListByResourceGroupAsync(resourceGroup).ToEnumerableAsync();
            Assert.AreEqual(2, containerGroups.Count);

            // List container group under a subscription
            containerGroups = await ContainerGroupsOperations.ListAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(containerGroups.Count, 2);
        }

        [Test]
        public async Task ContainerGroupsUpdateTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create container group for test
            var containerGroupName = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupParam = Helper.CreateTestContainerGroup(containerGroupName, location);
            var containerGroup = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName, containerGroupParam))).Value;

            // Update container group
            var resourceParam = new Resource() { Tags = { { "key1", "value1" },{ "key2", "value2"}, { "key3", "value3" } } };
            var containerGroupUpdated = (await ContainerGroupsOperations.UpdateAsync(resourceGroup, containerGroupName, resourceParam)).Value;
            Assert.AreEqual(resourceParam.Tags.Count, containerGroupUpdated.Tags.Count);
        }

        [Test]
        public async Task ContainerGroupsDeleteTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create container group for test
            var containerGroupName = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupParam = Helper.CreateTestContainerGroup(containerGroupName, location);
            var containerGroup = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName, containerGroupParam))).Value;

            // Delete container group
            var containerGroupDeleted = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartDeleteAsync(resourceGroup, containerGroupName))).Value;
            // List container groups unde a resource group
            var containerGroups = await ContainerGroupsOperations.ListByResourceGroupAsync(resourceGroup).ToEnumerableAsync();
            Assert.AreEqual(0, containerGroups.Count);
        }
    }
}
