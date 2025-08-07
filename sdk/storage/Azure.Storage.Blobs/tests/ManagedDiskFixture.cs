// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.Storage.Test;

namespace Azure.Storage.Blobs.Tests.ManagedDisk
{
    /// <summary>
    /// This fixture makes sure that managed disk snapshots are initialized and destroyed once per whole test suite.
    ///
    /// Deleting snapshots at test class level was not viable as it led to race conditions related to access rights,
    /// i.e. if one of the middle (or first) snapshots is deleted it seems that service revokes read access while it squashes data.
    /// </summary>
    public class ManagedDiskFixture : SetUpFixtureBase<BlobTestEnvironment>
    {
        public ManagedDiskFixture()
            : base(/* RecordedTestMode.Live /* to hardocode the mode */)
        {
        }

        public static ManagedDiskFixture Instance { get; private set; }

        private ManagedDiskConfiguration _config;
        private ResourceGroupResource _resourceGroup;

        public SnapshotResource Snapshot1 { get; private set; }
        public SnapshotResource Snapshot2 { get; private set; }
        public Uri Snapshot1SASUri { get; private set; }
        public Uri Snapshot2SASUri { get; private set; }

        public override async Task SetUp()
        {
            if (Environment.Mode != RecordedTestMode.Playback)
            {
                _config = TestConfigurations.DefaultTargetManagedDisk;

                ArmClient client = new ArmClient(Environment.Credential, _config.SubsriptionId);
                SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
                _resourceGroup = await subscription.GetResourceGroups().GetAsync(_config.ResourceGroupName);
                var disks = await _resourceGroup.GetManagedDisks().GetAllAsync().ToListAsync();
                var disk = disks.Where(d => d.Data.Name.Contains(_config.DiskNamePrefix)).First();

                Snapshot1 = await CreateSnapshot(disk, _config.DiskNamePrefix + Guid.NewGuid().ToString().Replace("-", ""));

                // The disk is attached to VM, wait some time to let OS background jobs write something to disk to create delta.
                await Task.Delay(TimeSpan.FromSeconds(60));

                Snapshot2 = await CreateSnapshot(disk, _config.DiskNamePrefix + Guid.NewGuid().ToString().Replace("-", ""));

                Snapshot1SASUri = await GrantAccess(Snapshot1);
                Snapshot2SASUri = await GrantAccess(Snapshot2);
            }

            Instance = this;
        }

        public override async Task TearDown()
        {
            if (Environment.Mode != RecordedTestMode.Playback)
            {
                await RevokeAccess(Snapshot1);
                await RevokeAccess(Snapshot2);

                await DeleteSnapshot(Snapshot1);
                await DeleteSnapshot(Snapshot2);
            }
        }

        private async Task<SnapshotResource> CreateSnapshot(ManagedDiskResource disk, string name)
        {
            var snapshotCreateOperation = await _resourceGroup.GetSnapshots().CreateOrUpdateAsync(WaitUntil.Completed, name,
                new SnapshotData(_config.Location)
                {
                    CreationData = new DiskCreationData(DiskCreateOption.Copy)
                    {
                        SourceResourceId = disk.Id
                    },
                    Incremental = true,
                });
            return await snapshotCreateOperation.WaitForCompletionAsync();
        }

        private async Task DeleteSnapshot(SnapshotResource snapshot)
        {
            var snapshotDeleteOperation = await snapshot.DeleteAsync(WaitUntil.Completed);
            await snapshotDeleteOperation.WaitForCompletionResponseAsync();
        }

        private async Task<Uri> GrantAccess(SnapshotResource snapshot)
        {
            var grantOperation = await snapshot.GrantAccessAsync(WaitUntil.Completed,
                new GrantAccessData(AccessLevel.Read, 3600));
            AccessUri accessUri = await grantOperation.WaitForCompletionAsync();
            return new Uri(accessUri.AccessSas);
        }

        private async Task RevokeAccess(SnapshotResource snapshot)
        {
            var revokeOperation = await snapshot.RevokeAccessAsync(WaitUntil.Completed);
            await revokeOperation.WaitForCompletionResponseAsync();
        }
    }
}
