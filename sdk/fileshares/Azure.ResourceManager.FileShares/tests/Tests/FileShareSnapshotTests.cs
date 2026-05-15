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
    public class FileShareSnapshotTests : FileSharesManagementTestBase
    {
        public FileShareSnapshotTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task SnapshotCrudLifecycle()
        {
            // Setup - create file share first
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            var fileShare = await CreateFileShare(resourceGroup, fileShareName);

            string snapshotName = Recording.GenerateAssetName("snapshot");

            // Create snapshot
            var snapshot = await CreateSnapshot(fileShare, snapshotName);
            Assert.AreEqual(snapshotName, snapshot.Data.Name);
            Assert.IsNotNull(snapshot.Data.Properties);
            Assert.IsTrue(snapshot.Data.Properties.Metadata.ContainsKey("purpose"));
            Assert.AreEqual("testing", snapshot.Data.Properties.Metadata["purpose"]);

            // Get snapshot
            var getResult = await fileShare.GetFileShareSnapshots().GetAsync(snapshotName);
            Assert.AreEqual(snapshotName, getResult.Value.Data.Name);

            // List snapshots
            var listResult = await fileShare.GetFileShareSnapshots().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listResult);
            Assert.IsTrue(listResult.Any(s => s.Data.Name == snapshotName));

            // Update snapshot metadata
            var patch = new FileShareSnapshotPatch();
            patch.FileShareSnapshotUpdateMetadata["purpose"] = "updated";
            patch.FileShareSnapshotUpdateMetadata["newKey"] = "newValue";
            var updateResult = await snapshot.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual("updated", updateResult.Value.Data.Properties.Metadata["purpose"]);

            // Delete snapshot
            await snapshot.DeleteAsync(WaitUntil.Completed);

            // Verify deleted
            var exists = await fileShare.GetFileShareSnapshots().ExistsAsync(snapshotName);
            Assert.IsFalse(exists.Value);

            // Cleanup - delete file share
            await fileShare.DeleteAsync(WaitUntil.Completed);
        }
    }
}
