// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileShareUpdateTests : FileSharesManagementTestBase
    {
        public FileShareUpdateTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateNfsProtocolProperties()
        {
            // Create NFS file share
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);

            // Update NFS protocol settings - change root squash
            var patch = new FileSharePatch
            {
                Properties = new FileSharePatchProperties
                {
                    NfsProtocolProperties = new NfsProtocolProperties
                    {
                        RootSquash = ShareRootSquash.RootSquash,
                    },
                },
            };
            var updateResult = await fileShare.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(ShareRootSquash.RootSquash, updateResult.Value.Data.Properties.NfsProtocolProperties.RootSquash);

            // Cleanup
            await fileShare.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateProvisionedCapacity()
        {
            // Create file share
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);

            // Update provisioned storage, IOPS, and throughput
            var patch = new FileSharePatch
            {
                Properties = new FileSharePatchProperties
                {
                    ProvisionedStorageGiB = 2048,
                    ProvisionedIOPerSec = 8048,
                    ProvisionedThroughputMiBPerSec = 456,
                },
            };
            var updateResult = await fileShare.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(2048, updateResult.Value.Data.Properties.ProvisionedStorageInGiB);

            // Cleanup
            await fileShare.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdatePublicNetworkAccess()
        {
            // Create file share with public access enabled
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);

            // Disable public network access
            var patch = new FileSharePatch
            {
                Properties = new FileSharePatchProperties
                {
                    PublicNetworkAccess = FileSharePublicNetworkAccess.Disabled,
                },
            };
            var updateResult = await fileShare.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(FileSharePublicNetworkAccess.Disabled, updateResult.Value.Data.Properties.PublicNetworkAccess);

            // Re-enable public network access
            var patchReEnabled = new FileSharePatch
            {
                Properties = new FileSharePatchProperties
                {
                    PublicNetworkAccess = FileSharePublicNetworkAccess.Enabled,
                },
            };
            var reEnabledResult = await fileShare.UpdateAsync(WaitUntil.Completed, patchReEnabled);
            Assert.AreEqual(FileSharePublicNetworkAccess.Enabled, reEnabledResult.Value.Data.Properties.PublicNetworkAccess);

            // Cleanup
            await fileShare.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateTags()
        {
            // Create file share
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);

            // Update tags
            var patch = new FileSharePatch();
            patch.Tags["environment"] = "production";
            patch.Tags["team"] = "storage";
            patch.Tags["cost-center"] = "12345";

            var updateResult = await fileShare.UpdateAsync(WaitUntil.Completed, patch);
            Assert.IsTrue(updateResult.Value.Data.Tags.ContainsKey("environment"));
            Assert.AreEqual("production", updateResult.Value.Data.Tags["environment"]);
            Assert.AreEqual("storage", updateResult.Value.Data.Tags["team"]);

            // Cleanup
            await fileShare.DeleteAsync(WaitUntil.Completed);
        }
    }
}
