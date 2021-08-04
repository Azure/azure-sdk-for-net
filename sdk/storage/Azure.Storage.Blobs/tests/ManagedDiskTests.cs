// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class ManagedDiskTests : BlobTestBase
    {
        private ManagedDiskConfiguration config;
        private ComputeManagementClient computeClient;
        private Snapshot snapshot1;
        private Snapshot snapshot2;
        private Uri snapshot1SASUri;
        private Uri snapshot2SASUri;

        public ManagedDiskTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                config = TestConfigurations.DefaultTargetManagedDisk;

                TokenCredential tokenCredentials = new Identity.ClientSecretCredential(
                    config.ActiveDirectoryTenantId, config.ActiveDirectoryApplicationId, config.ActiveDirectoryApplicationSecret);
                computeClient = new ComputeManagementClient(config.SubsriptionId, tokenCredentials);

                var disks = await computeClient.Disks.ListByResourceGroupAsync(config.ResourceGroupName).ToListAsync();
                var disk = disks.Where(d => d.Name.Contains(config.DiskNamePrefix)).First();

                snapshot1 = await CreateSnapshot(disk, config.DiskNamePrefix + Guid.NewGuid().ToString().Replace("-", ""));

                // The disk is attached to VM, wait some time to let OS background jobs write something to disk to create delta.
                await Task.Delay(TimeSpan.FromSeconds(60));

                snapshot2 = await CreateSnapshot(disk, config.DiskNamePrefix + Guid.NewGuid().ToString().Replace("-", ""));

                snapshot1SASUri = await GrantAccess(snapshot1);
                snapshot2SASUri = await GrantAccess(snapshot2);
            }
        }

        [SetUp]
        public void Setup()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                snapshot1SASUri = new Uri(Recording.GetVariable(nameof(snapshot1SASUri), ""));
                snapshot2SASUri = new Uri(Recording.GetVariable(nameof(snapshot2SASUri), ""));
            }
            else
            {
                Recording.SetVariable(nameof(snapshot1SASUri), Sanitizer.SanitizeUri(snapshot1SASUri.AbsoluteUri));
                Recording.SetVariable(nameof(snapshot2SASUri), Sanitizer.SanitizeUri(snapshot2SASUri.AbsoluteUri));
            }
        }

        [OneTimeTearDown]
        public async Task GlobalCleanup()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await RevokeAccess(snapshot1);
                await RevokeAccess(snapshot2);

                await DeleteSnapshot(snapshot1);
                await DeleteSnapshot(snapshot2);
            }
        }

        [Test]
        public async Task CanDiffPagesBetweenSnapshots()
        {
            // Arrange
            var snapshot1Client = InstrumentClient(new PageBlobClient(snapshot1SASUri, GetOptions()));
            var snapshot2Client = InstrumentClient(new PageBlobClient(snapshot2SASUri, GetOptions()));

            // Act
            PageRangesInfo pageRangesInfo = await snapshot2Client.GetManagedDiskPageRangesDiffAsync(previousSnapshotUri: snapshot1SASUri);

            // Assert
            Assert.IsNotNull(pageRangesInfo.LastModified);
            Assert.IsNotNull(pageRangesInfo.ETag);
            CollectionAssert.IsNotEmpty(pageRangesInfo.ClearRanges);
            CollectionAssert.IsNotEmpty(pageRangesInfo.PageRanges);

            // Assert page diff
            var pageRange = pageRangesInfo.PageRanges.First();
            var range1 = await DownloadRange(snapshot1Client, pageRange);
            var range2 = await DownloadRange(snapshot2Client, pageRange);

            Assert.AreNotEqual(range1, range2);

            // Assert page clean
            var cleanRange = pageRangesInfo.ClearRanges.First();
            range2 = await DownloadRange(snapshot2Client, cleanRange);
            foreach (byte b in range2)
            {
                Assert.AreEqual(0, b);
            }
        }

        private async Task<byte[]> DownloadRange(PageBlobClient client, HttpRange range)
        {
            var memoryStream = new MemoryStream();
            using BlobDownloadStreamingResult result1 = await client.DownloadStreamingAsync(range: range);
            await result1.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        private async Task<Snapshot> CreateSnapshot(Disk disk, string name)
        {
            var snapshotCreateOperation = await computeClient.Snapshots.StartCreateOrUpdateAsync(config.ResourceGroupName, name,
                new Snapshot(config.Location)
                {
                    CreationData = new CreationData(DiskCreateOption.Copy)
                    {
                        SourceResourceId = disk.Id
                    },
                    Incremental = true,
                });
            return await snapshotCreateOperation.WaitForCompletionAsync();
        }

        private async Task DeleteSnapshot(Snapshot snapshot)
        {
            var snapshotDeleteOperation = await computeClient.Snapshots.StartDeleteAsync(config.ResourceGroupName, snapshot.Name);
            await snapshotDeleteOperation.WaitForCompletionAsync();
        }

        private async Task<Uri> GrantAccess(Snapshot snapshot)
        {
            var grantOperation = await computeClient.Snapshots.StartGrantAccessAsync(config.ResourceGroupName, snapshot.Name,
                new GrantAccessData(AccessLevel.Read, 3600));
            AccessUri accessUri = await grantOperation.WaitForCompletionAsync();
            return new Uri(accessUri.AccessSAS);
        }

        private async Task RevokeAccess(Snapshot snapshot)
        {
            var revokeOperation = await computeClient.Snapshots.StartRevokeAccessAsync(config.ResourceGroupName, snapshot.Name);
            await revokeOperation.WaitForCompletionAsync();
        }
    }
}
