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
    public class ContainerGroupProfileCollectionTests : ContainerInstanceManagementTestBase
    {
        public ContainerGroupProfileCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_ContainerGroupProfile_RegularPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Regular");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = CreateContainerGroupProfileAsync(containerGroupProfileName, containerGroupProfileData, rg).Result;
            Assert.AreEqual(containerGroupProfileName, containerGroupProfile.Data.Name);
            VerifyContainerGroupProfileProperties(containerGroupProfileData, containerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_ContainerGroupProfile_SpotPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Spot");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = CreateContainerGroupProfileAsync(containerGroupProfileName, containerGroupProfileData, rg).Result;
            Assert.AreEqual(containerGroupProfileName, containerGroupProfile.Data.Name);
            VerifyContainerGroupProfileProperties(containerGroupProfileData, containerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_ContainerGroupProfile_ConfidentialContainerGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, isConfidentialSku: true, ccepolicy: null);
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = CreateContainerGroupProfileAsync(containerGroupProfileName, containerGroupProfileData, rg).Result;
            Assert.AreEqual(containerGroupProfileName, containerGroupProfile.Data.Name);
            VerifyContainerGroupProfileProperties(containerGroupProfileData, containerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_ContainerGroupProfile_RegularPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Regular");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            ContainerGroupProfileResource retrievedContainerGroupProfile = await containerGroupProfiles.GetAsync(containerGroupProfileName);
            VerifyContainerGroupProfileProperties(containerGroupProfile.Data, retrievedContainerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_ContainerGroupProfile_SpotPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, "Spot");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            ContainerGroupProfileResource retrievedContainerGroupProfile = await containerGroupProfiles.GetAsync(containerGroupProfileName);
            VerifyContainerGroupProfileProperties(containerGroupProfile.Data, retrievedContainerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_ContainerGroupProfile_ConfidentialContainerGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData = CreateContainerGroupProfileData(containerGroupProfileName, isConfidentialSku: true, ccepolicy: null);
            var containerGroupProfiles = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData)).Value;

            ContainerGroupProfileResource retrievedContainerGroupProfile = await containerGroupProfiles.GetAsync(containerGroupProfileName);
            VerifyContainerGroupProfileProperties(containerGroupProfile.Data, retrievedContainerGroupProfile.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task List_ContainerGroupProfile()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            var containerGroupProfiles = rg.GetContainerGroupProfiles();

            string containerGroupProfileName1 = Recording.GenerateAssetName("containergrpcgp1");
            var containerGroupProfileData1 = CreateContainerGroupProfileData(containerGroupProfileName1, "Regular");
            ContainerGroupProfileResource containerGroupProfile1 = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName1, containerGroupProfileData1)).Value;

            string containerGroupProfileName2 = Recording.GenerateAssetName("containergrpcgp2");
            var containerGroupProfileData2 = CreateContainerGroupProfileData(containerGroupProfileName2, "Spot");
            ContainerGroupProfileResource containerGroupProfile2 = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName2, containerGroupProfileData2)).Value;

            ContainerGroupProfileCollection result = rg.GetContainerGroupProfiles();
            ContainerGroupProfileResource retrievedContainerGroupProfile1 = await result.GetAsync(containerGroupProfileName1);
            VerifyContainerGroupProfileProperties(containerGroupProfile1.Data, retrievedContainerGroupProfile1.Data);

            ContainerGroupProfileResource retrievedContainerGroupProfile2 = await result.GetAsync(containerGroupProfileName2);
            VerifyContainerGroupProfileProperties(containerGroupProfile2.Data, retrievedContainerGroupProfile2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription_ContainerGroupProfile()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg1 = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            var containerGroupProfiles1 = rg1.GetContainerGroupProfiles();
            string containerGroupProfileName1 = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData1 = CreateContainerGroupProfileData(containerGroupProfileName1, "Regular");
            ContainerGroupProfileResource containerGroupProfile1 = (await containerGroupProfiles1.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName1, containerGroupProfileData1)).Value;

            ResourceGroupResource rg2 = await CreateResourceGroupAsync(subscription, "testRg2", AzureLocation.WestUS);
            var containerGroupProfiles2 = rg2.GetContainerGroupProfiles();
            string containerGroupProfileName2 = Recording.GenerateAssetName("containergrp2cgp");
            var containerGroupProfileData2 = CreateContainerGroupProfileData(containerGroupProfileName2, "Spot");
            ContainerGroupProfileResource containerGroupProfile2 = (await containerGroupProfiles2.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName2, containerGroupProfileData2)).Value;

            ResourceGroupResource rg3 = await CreateResourceGroupAsync(subscription, "testRg3", AzureLocation.WestUS);
            var containerGroupProfiles3 = rg3.GetContainerGroupProfiles();
            string containerGroupProfileName3 = Recording.GenerateAssetName("containergrp3cgp");
            var containerGroupProfileData3 = CreateContainerGroupProfileData(containerGroupProfileName3, isConfidentialSku: true, ccepolicy: null);
            ContainerGroupProfileResource containerGroupProfile3 = (await containerGroupProfiles3.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName3, containerGroupProfileData3)).Value;

            AsyncPageable<ContainerGroupProfileResource> result = subscription.GetContainerGroupProfilesAsync();
            ContainerGroupProfileResource containerGroupProfile1FromList = await result.FirstOrDefaultAsync(cgp => cgp.Data.Name.Equals(containerGroupProfileName1));
            VerifyContainerGroupProfileProperties(containerGroupProfile1.Data, containerGroupProfile1FromList.Data);
            ContainerGroupProfileResource containerGroupProfile2FromList = await result.FirstOrDefaultAsync(cgp => cgp.Data.Name.Equals(containerGroupProfileName2));
            VerifyContainerGroupProfileProperties(containerGroupProfile2.Data, containerGroupProfile2FromList.Data);
            ContainerGroupProfileResource containerGroupProfile3FromList = await result.FirstOrDefaultAsync(cgp => cgp.Data.Name.Equals(containerGroupProfileName3));
            VerifyContainerGroupProfileProperties(containerGroupProfile3.Data, containerGroupProfile3FromList.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Check_ContainerGroupProfile_RevisionUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupProfileName = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfiles = rg.GetContainerGroupProfiles();

            var containerGroupProfileData1 = CreateContainerGroupProfileData(containerGroupProfileName, "Regular", doNotProvideCommand: true);
            ContainerGroupProfileResource containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData1)).Value;
            var containerGroupProfileData2 = CreateContainerGroupProfileData(containerGroupProfileName, "Regular");
            containerGroupProfile = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName, containerGroupProfileData2)).Value;

            ContainerGroupProfileRevisionCollection result = containerGroupProfile.GetContainerGroupProfileRevisions();
            Assert.IsNotNull(result);
            bool revision1exists = await result.ExistsAsync("1");
            Assert.IsTrue(revision1exists);
            bool revision2exists = await result.ExistsAsync("2");
            Assert.IsTrue(revision2exists);
        }
    }
}
