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
    public class ContainerGroupCollectionTests: ContainerInstanceManagementTestBase
    {
        public ContainerGroupCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_RegularPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, "Regular");
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = CreateContainerGroupAsync(containerGroupName, containerGroupData, rg).Result;
            Assert.AreEqual(containerGroupName, containerGroup.Data.Name);
            VerifyContainerGroupProperties(containerGroupData, containerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_SpotPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, priority: "Spot");
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = CreateContainerGroupAsync(containerGroupName, containerGroupData, rg).Result;
            Assert.AreEqual(containerGroupName, containerGroup.Data.Name);
            VerifyContainerGroupProperties(containerGroupData, containerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_ConfidentialContainerGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, isConfidentialSku: true, ccepolicy: null);
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = CreateContainerGroupAsync(containerGroupName, containerGroupData, rg).Result;
            Assert.AreEqual(containerGroupName, containerGroup.Data.Name);
            VerifyContainerGroupProperties(containerGroupData, containerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_RegularPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, "Regular");
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;

            ContainerGroupResource retrievedContainerGroup = await containerGroups.GetAsync(containerGroupName);
            VerifyContainerGroupProperties(containerGroup.Data, retrievedContainerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_SpotPriority()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, "Spot");
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;

            ContainerGroupResource retrievedContainerGroup = await containerGroups.GetAsync(containerGroupName);
            VerifyContainerGroupProperties(containerGroup.Data, retrievedContainerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get_ConfidentialContainerGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName, isConfidentialSku: true, ccepolicy: null);
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;

            ContainerGroupResource retrievedContainerGroup = await containerGroups.GetAsync(containerGroupName);
            VerifyContainerGroupProperties(containerGroup.Data, retrievedContainerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            var containerGroups = rg.GetContainerGroups();

            string containerGroupName1 = Recording.GenerateAssetName("containergrp");
            var containerGroupData1 = CreateContainerGroupData(containerGroupName1, "Regular");
            ContainerGroupResource containerGroup1 = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName1, containerGroupData1)).Value;
            string containerGroupName2 = Recording.GenerateAssetName("containergrp");
            var containerGroupData2 = CreateContainerGroupData(containerGroupName2, "Spot");
            ContainerGroupResource containerGroup2 = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName2, containerGroupData2)).Value;

            AsyncPageable<ContainerGroupResource> result = containerGroups.GetAllAsync();
            ContainerGroupResource containerGroup1FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupName1));
            VerifyContainerGroupProperties(containerGroup1.Data, containerGroup1FromList.Data);
            ContainerGroupResource containerGroup2FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupName2));
            VerifyContainerGroupProperties(containerGroup2.Data, containerGroup2FromList.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg1 = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            var containerGroups1 = rg1.GetContainerGroups();
            string containerGroupName1 = Recording.GenerateAssetName("containergrp");
            var containerGroupData1 = CreateContainerGroupData(containerGroupName1, "Regular");
            ContainerGroupResource containerGroup1 = (await containerGroups1.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName1, containerGroupData1)).Value;

            ResourceGroupResource rg2 = await CreateResourceGroupAsync(subscription, "testRg2", AzureLocation.WestUS);
            var containerGroups2 = rg2.GetContainerGroups();
            string containerGroupName2 = Recording.GenerateAssetName("containergrp2");
            var containerGroupData2 = CreateContainerGroupData(containerGroupName2, "Spot");
            ContainerGroupResource containerGroup2 = (await containerGroups2.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName2, containerGroupData2)).Value;

            ResourceGroupResource rg3 = await CreateResourceGroupAsync(subscription, "testRg3", AzureLocation.WestUS);
            var containerGroups3 = rg3.GetContainerGroups();
            string containerGroupName3 = Recording.GenerateAssetName("containergrp3");
            var containerGroupData3 = CreateContainerGroupData(containerGroupName3, isConfidentialSku: true, ccepolicy: null);
            ContainerGroupResource containerGroup3 = (await containerGroups3.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName3, containerGroupData3)).Value;

            AsyncPageable<ContainerGroupResource> result = subscription.GetContainerGroupsAsync();
            ContainerGroupResource containerGroup1FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupName1));
            VerifyContainerGroupProperties(containerGroup1.Data, containerGroup1FromList.Data);
            ContainerGroupResource containerGroup2FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupName2));
            VerifyContainerGroupProperties(containerGroup2.Data, containerGroup2FromList.Data);
            ContainerGroupResource containerGroup3FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupName3));
            VerifyContainerGroupProperties(containerGroup3.Data, containerGroup3FromList.Data);
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

            string containerGroupProfileName1 = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData1 = CreateContainerGroupProfileData(containerGroupProfileName1, "Regular");
            ContainerGroupProfileResource containerGroupProfile1 = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName1, containerGroupProfileData1)).Value;
            string containerGroupProfileName2 = Recording.GenerateAssetName("containergrpcgp");
            var containerGroupProfileData2 = CreateContainerGroupProfileData(containerGroupProfileName2, "Spot");
            ContainerGroupProfileResource containerGroupProfile2 = (await containerGroupProfiles.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupProfileName2, containerGroupProfileData2)).Value;

            AsyncPageable<ContainerGroupProfileResource> result = containerGroupProfiles.GetAllAsync();
            ContainerGroupProfileResource containerGroupProfile1FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupProfileName1));
            VerifyContainerGroupProfileProperties(containerGroupProfile1.Data, containerGroupProfile1FromList.Data);
            ContainerGroupProfileResource containerGroupProfile2FromList = await result.FirstOrDefaultAsync(cg => cg.Data.Name.Equals(containerGroupProfileName2));
            VerifyContainerGroupProfileProperties(containerGroupProfile2.Data, containerGroupProfile2FromList.Data);
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
    }
}
