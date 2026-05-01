// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileShareCrudTests : FileSharesManagementTestBase
    {
        public FileShareCrudTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetListUpdateDelete()
        {
            // Setup
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");

            // Create - NFS share with SSD tier, matching PowerShell test CreateExpanded scenario
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);
            Assert.AreEqual(fileShareName, fileShare.Data.Name);
            Assert.IsNotNull(fileShare.Data.Properties);
            Assert.AreEqual(FileShareMediaTier.Ssd, fileShare.Data.Properties.MediaTier);
            Assert.AreEqual(FileShareProtocol.Nfs, fileShare.Data.Properties.Protocol);
            Assert.AreEqual(1024, fileShare.Data.Properties.ProvisionedStorageInGiB);
            Assert.AreEqual(FileShareRedundancyLevel.Local, fileShare.Data.Properties.Redundancy);

            // Get by name
            var getResult = await resourceGroup.GetFileShares().GetAsync(fileShareName);
            Assert.AreEqual(fileShareName, getResult.Value.Data.Name);
            Assert.AreEqual(FileShareMediaTier.Ssd, getResult.Value.Data.Properties.MediaTier);

            // Get via resource
            var getViaResource = await fileShare.GetAsync();
            Assert.AreEqual(fileShareName, getViaResource.Value.Data.Name);

            // List in resource group
            var listResult = await resourceGroup.GetFileShares().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listResult);
            Assert.IsTrue(listResult.Any(fs => fs.Data.Name == fileShareName));

            // Update - change tags and provisioned storage
            var patch = new FileSharePatch
            {
                Properties = new FileSharePatchProperties
                {
                    ProvisionedStorageGiB = 2048,
                },
                Tags = { { "environment", "updated" }, { "stage", "testing" } },
            };
            var updateResult = await fileShare.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(2048, updateResult.Value.Data.Properties.ProvisionedStorageInGiB);

            // Delete
            await fileShare.DeleteAsync(WaitUntil.Completed);

            // Verify deleted
            var exists = await resourceGroup.GetFileShares().ExistsAsync(fileShareName);
            Assert.IsFalse(exists.Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            // Setup - create a file share to ensure at least one exists
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            await CreateFileShare(resourceGroup, fileShareName);

            // List file shares across the subscription
            var listResult = await DefaultSubscription.GetFileSharesAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listResult);
            Assert.IsTrue(listResult.Any(fs => fs.Data.Name == fileShareName));
        }
    }
}
