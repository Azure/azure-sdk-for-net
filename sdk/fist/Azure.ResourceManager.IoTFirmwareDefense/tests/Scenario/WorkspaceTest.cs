// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.IoTFirmwareDefense.Tests
{
    public class WorkspaceTest : IoTFirmwareDefenseTestBase
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
            WorkspaceCollection resource = rg.GetWorkspaces();
            var newWorkspaceData = await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new WorkspaceData(AzureLocation.EastUS));
            newWorkspaceData.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            WorkspaceCollection resource = rg.GetWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new WorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetWorkspaceAsync(resourceName);
            retrievedWorkspace.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDeleteWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            WorkspaceCollection resource = rg.GetWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new WorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetWorkspaceAsync(resourceName);
            await retrievedWorkspace.Value.DeleteAsync(WaitUntil.Completed);
            var action = async () => await rg.GetWorkspaceAsync(resourceName);
            await action.Should ().ThrowAsync<Exception> ();
        }
    }
}
