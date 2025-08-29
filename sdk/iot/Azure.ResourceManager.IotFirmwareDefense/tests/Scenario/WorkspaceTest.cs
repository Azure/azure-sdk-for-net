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
            FirmwareAnalysisWorkspaceCollection resource = rg.GetFirmwareAnalysisWorkspaces();
            var newWorkspaceData = await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS));
            newWorkspaceData.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            FirmwareAnalysisWorkspaceCollection resource = rg.GetFirmwareAnalysisWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetFirmwareAnalysisWorkspaceAsync(resourceName);
            retrievedWorkspace.Value.Data.Name.Should().Be(resourceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDeleteWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("resource");
            FirmwareAnalysisWorkspaceCollection resource = rg.GetFirmwareAnalysisWorkspaces();
            await resource.CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS));

            var retrievedWorkspace = await rg.GetFirmwareAnalysisWorkspaceAsync(resourceName);
            await retrievedWorkspace.Value.DeleteAsync(WaitUntil.Completed);
            var action = async () => await rg.GetFirmwareAnalysisWorkspaceAsync(resourceName);
            await action.Should ().ThrowAsync<Exception> ();
        }
    }
}
