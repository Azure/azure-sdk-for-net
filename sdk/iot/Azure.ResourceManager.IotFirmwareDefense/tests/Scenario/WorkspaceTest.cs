// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class WorkspaceTest : IotFirmwareDefenseManagementTestBase
    {
        private static readonly string rgName = "testRg";
        private static ResourceGroupResource rg;

        public WorkspaceTest(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            IotFirmwareWorkspaceCollection resource = rg.GetIotFirmwareWorkspaces();
            var newWorkspaceData = await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new IotFirmwareWorkspaceData(AzureLocation.EastUS));
            newWorkspaceData.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            IotFirmwareWorkspaceCollection resource = rg.GetIotFirmwareWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new IotFirmwareWorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetIotFirmwareWorkspaceAsync(resourceName);
            retrievedWorkspace.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDeleteWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            IotFirmwareWorkspaceCollection resource = rg.GetIotFirmwareWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new IotFirmwareWorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetIotFirmwareWorkspaceAsync(resourceName);
            await retrievedWorkspace.Value.DeleteAsync(WaitUntil.Completed);
            var action = async () => await rg.GetIotFirmwareWorkspaceAsync(resourceName);
            await action.Should ().ThrowAsync<Exception> ();
        }
    }
}
