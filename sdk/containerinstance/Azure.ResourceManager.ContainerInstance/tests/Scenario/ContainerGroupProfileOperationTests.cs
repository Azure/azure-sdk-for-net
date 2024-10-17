// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    public class ContainerGroupProfileOperationTests : ContainerInstanceManagementTestBase
    {
        public ContainerGroupProfileOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Regular");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            ContainerGroupProfileResource retrievedContainerGroupProfile = await containerGroupProfile.GetAsync();
            VerifyContainerGroupProfileProperties(containerGroupProfile.Data, retrievedContainerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete_RegularPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Regular");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            bool deletedContainerGroupProfile = (await containerGroupProfile.DeleteAsync(WaitUntil.Completed)).HasCompleted;
            VerifyOperationCompletionStatus(deletedContainerGroupProfile);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete_SpotPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Spot");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            bool deletedContainerGroupProfile = (await containerGroupProfile.DeleteAsync(WaitUntil.Completed)).HasCompleted;
            VerifyOperationCompletionStatus(deletedContainerGroupProfile);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete_ConfidentialContainer()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, isConfidentialSku: true, ccepolicy: null);
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            bool deletedContainerGroupProfile = (await containerGroupProfile.DeleteAsync(WaitUntil.Completed)).HasCompleted;
            VerifyOperationCompletionStatus(deletedContainerGroupProfile);
        }
    }
}
