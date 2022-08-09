// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    public class ContainerGroupOperationTests: ContainerInstanceManagementTestBase
    {
        public ContainerGroupOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName);
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;

            ContainerGroupResource retrievedContainerGroup = await containerGroup.GetAsync();
            VerifyContainerGroupProperties(containerGroup.Data, retrievedContainerGroup.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroupAsync(subscription, "testRg", AzureLocation.WestUS);
            string containerGroupName = Recording.GenerateAssetName("containergrp");
            var containerGroupData = CreateContainerGroupData(containerGroupName);
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;

            ContainerGroupResource deletedContainerGroup = (await containerGroup.DeleteAsync(WaitUntil.Completed)).Value;
            VerifyContainerGroupProperties(containerGroup.Data, deletedContainerGroup.Data);
        }
    }
}
