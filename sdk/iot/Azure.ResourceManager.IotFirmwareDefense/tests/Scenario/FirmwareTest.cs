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
    public class FirmwareTest : IotFirmwareDefenseManagementTestBase
    {
        private static readonly string rgName = "testRg";
        private static ResourceGroupResource rg;
        private static IotFirmwareData testFirmware;

        public FirmwareTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void setup()
        {
            testFirmware = new IotFirmwareData
            {
                FileName = "testFileName",
                FileSize = 1,
                Vendor = "testVendor",
                Model = "testModel",
                Version = "testVersion",
                Description = "testDescription"
            };
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateFirmware()
        {
            var workspace = await getWorkspace();
            var response = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                testFirmware);
            response.Value.Data.Name.Should().Equals(testFirmware.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetFirmware()
        {
            var workspace = await getWorkspace();
            var _ = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                testFirmware);
            var response = await workspace.GetIotFirmwareAsync(_.Value.Data.Name);
            response.Value.Data.Name.Should().Equals(testFirmware.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdateFirmware()
        {
            var name = Recording.GenerateAssetName("resource");
            var updatedFirmware = new IotFirmwareData()
            {
                Description = "updatedDescription"
            };
            var workspace = await getWorkspace();
            var response = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                name,
                testFirmware);
            response.Value.Data.Description.Should().Equals(testFirmware.Description);

            response = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                name,
                updatedFirmware);
            response.Value.Data.Description.Should().Equals(updatedFirmware.Description);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDeleteFirmware()
        {
            var workspace = await getWorkspace();
            var _ = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                testFirmware);
            var testFirmwareId = _.Value.Data.Name;
            var response = await workspace.GetIotFirmwareAsync(testFirmwareId);
            await response.Value.DeleteAsync(WaitUntil.Completed);

            var action = async () => await workspace.GetIotFirmwareAsync(testFirmwareId);
            await action.Should().ThrowAsync<Exception>();
        }

        private async Task<FirmwareAnalysisWorkspaceResource> getWorkspace()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            var _ = await rg.GetFirmwareAnalysisWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS));
            return _.Value;
        }
    }
}
