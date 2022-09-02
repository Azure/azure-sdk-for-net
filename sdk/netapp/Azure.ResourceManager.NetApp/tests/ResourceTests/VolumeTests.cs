// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using Azure.Core;
using FluentAssertions;
using Polly.Contrib.WaitAndRetry;
using Polly;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class VolumeTests : NetAppTestBase
    {
        private string _pool1Name = "pool1";
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts();}
        public VolumeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, ServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetVolumes();
            if (DefaultVirtualNetwork == null)
            {
                DefaultVirtualNetwork = await CreateVirtualNetwork();
            }
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Data.Name.Split('/').Last());
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    VolumeCollection volumeCollection = pool.GetVolumes();
                    List<VolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (VolumeResource volume in volumeList)
                    {
                        await volume.DeleteAsync(WaitUntil.Completed);
                    }
                    if (Mode != RecordedTestMode.Playback)
                    {
                        await Task.Delay(30000);
                    }
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(40000);
                }
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);

                ////remove vnet should be done by removing rg add if that does not work
                //VirtualNetworkCollection vnetColletion = _resourceGroup.GetVirtualNetworks();
                //foreach (string subnetId in subnetIds)
                //{
                //    ResourceIdentifier subnetResourceId = new ResourceIdentifier(subnetId);
                //    VirtualNetworkResource vnetResource = vnetColletion.Get(subnetResourceId.Parent);
                //    await vnetResource.DeleteAsync(WaitUntil.Completed);
                //}
            }
            _resourceGroup = null;
        }

        [Test]
        [RecordedTest]
        public async Task UpdateVolume()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            //validate if created successfully
            VolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);

            //Update with patch
            VolumePatch parameters = new(DefaultLocation);
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            parameters.Tags.InitializeFrom(DefaultTags);
            parameters.Tags.Add(keyValue);
            volumeResource1 = (await volumeResource1.UpdateAsync(WaitUntil.Completed, parameters)).Value;
            volumeResource1.Data.Tags.Should().Contain(keyValue);

            // validate
            VolumeResource volumeResource3 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            volumeResource3.Data.Tags.Should().Contain(keyValue);
            KeyValuePair<string, string> keyValuePair = new("key1", DefaultTags["key1"]);
            volumeResource3.Data.Tags.Should().Contain(keyValuePair);

            //usageThreshold should not change
            Assert.AreEqual(volumeResource3.Data.UsageThreshold, volumeResource3.Data.UsageThreshold);
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteVolume()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //validate if created successfully
            VolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last() + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeCollection.ExistsAsync(volumeResource1.Data.Name.Split('/').Last()));
            Assert.IsFalse(await _volumeCollection.ExistsAsync(volumeResource1.Data.Name.Split('/').Last() + "1"));

            //delete Volume
            await volumeResource2.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeResource1.Data.Name.Split('/').Last()));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumePoolNotFound()
        {
            //Delete pool
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            //create volume
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CreateVolumeWithProperties()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, exportPolicyRule: _defaultExportPolicyRule, protocolTypes: _defaultProtocolTypes);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //validate if created successfully
            VolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            Assert.NotNull(volumeResource2.Data.ProtocolTypes);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            volumeResource2.Data.ProtocolTypes.Should().Equal(_defaultProtocolTypes);
            Assert.NotNull(volumeResource2.Data.ExportPolicy);
            volumeResource2.Data.ExportPolicy.Rules.Should().NotBeEmpty();
            Assert.AreEqual(_defaultExportPolicyRule.RuleIndex, volumeResource2.Data.ExportPolicy.Rules[0].RuleIndex);
            Assert.AreEqual(_defaultExportPolicyRule.UnixReadOnly, volumeResource2.Data.ExportPolicy.Rules[0].UnixReadOnly);
            Assert.AreEqual(_defaultExportPolicyRule.Cifs, volumeResource2.Data.ExportPolicy.Rules[0].Cifs);
            Assert.AreEqual(_defaultExportPolicyRule.Nfsv3, volumeResource2.Data.ExportPolicy.Rules[0].Nfsv3);
            Assert.AreEqual(_defaultExportPolicyRule.Nfsv41, volumeResource2.Data.ExportPolicy.Rules[0].Nfsv41);
            Assert.AreEqual(_defaultExportPolicyRule.AllowedClients, volumeResource2.Data.ExportPolicy.Rules[0].AllowedClients);
            volumeResource2.Data.ProtocolTypes.Should().BeEquivalentTo(_defaultProtocolTypes);

            //delete Volume
            await volumeResource2.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeResource1.Data.Name.Split('/').Last()));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task DeletePooWithVolumePresent()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //Delete pool
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPool.DeleteAsync(WaitUntil.Completed); });
            Assert.AreEqual(409, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetVolumeByName()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            //validate if created successfully
            VolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
        }

        [Test]
        [RecordedTest]
        public async Task GetVolumeByNameNotFound()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            //Try and get a volume rom the pool, none have been created yet
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeName));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetVolumeByNamePoolNotFound()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);

            //delete Volume
            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }
            //Delete pool
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(40000);
            }

            //Try and get a volume from the pool, does not exist
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeName));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task ListVolumes()
        {
            //create volume1
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            //create volume2
            VolumeResource volumeResource2 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);

            //validate if list is returned successfully
            List<VolumeResource> volumeList = await _volumeCollection.GetAllAsync().ToEnumerableAsync();
            volumeList.Should().HaveCount(2);
            VolumeResource volumeResource3 = null;
            VolumeResource volumeResource4 = null;
            foreach (VolumeResource volume in volumeList)
            {
                if (volume.Id.Name == volumeResource1.Id.Name)
                    volumeResource3 = volume;
                if (volume.Id.Name == volumeResource2.Id.Name)
                    volumeResource3 = volume;
            }
            volumeResource3.Should().BeEquivalentTo(volumeResource3);
            volumeResource4.Should().BeEquivalentTo(volumeResource4);
        }

        [Test]
        [RecordedTest]
        public async Task LongListVolumes()
        {
            //Set pool size to fit the number of volumes
            CapacityPoolPatch parameters = new(DefaultLocation);
            long setPoolSize = 11 * _tebibyte;
            parameters.Size = setPoolSize;
            await _capacityPool.UpdateAsync(WaitUntil.Completed, parameters);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //create volumes
            int length = 103;
            int count = 0;
            List<VolumeResource> list = new List<VolumeResource>();
            for (int i = 0; i < length; i++)
            {
                VolumeResource volume = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
                list.Add(volume);
                count++;
            }
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(60000);
            }
            //validate if list is returned successfully
            List<VolumeResource> volumeList = await _volumeCollection.GetAllAsync().ToEnumerableAsync();
            Console.WriteLine($"Created {length}/{count} volumes, volumeList.Count= {volumeList.Count} in {_volumeCollection.Id}");
            volumeList.Should().HaveCount(length);
        }

        [Test]
        [RecordedTest]
        public async Task ChangePoolForVolume()
        {
            //create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            //validate if created successfully
            VolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            //create second pool
            string poolName2 = Recording.GenerateAssetName("pool-");
            CapacityPoolResource pool2 = await CreateCapacityPool(DefaultLocation, ServiceLevel.Premium, _poolSize, poolName: poolName2);
            CapacityPoolResource pool3 = await _capacityPoolCollection.GetAsync(poolName2);
            pool3.Should().BeEquivalentTo(pool2);

            //Change pools
            PoolChangeContent parameters = new(pool2.Id);
            ArmOperation poolChangeOperation = (await volumeResource2.PoolChangeAsync(WaitUntil.Completed, parameters));
            Assert.IsTrue(poolChangeOperation.HasCompleted);

            // validate, retrieve the volume from second pool and check
            VolumeCollection volumeCollection2 = pool2.GetVolumes();
            VolumeResource volumeResource3 = await volumeCollection2.GetAsync(volumeResource2.Data.Name.Split('/').Last());
            Assert.AreEqual(poolName2, volumeResource3.Id.Parent.Name);
            // try to retrieve the volume from first pool and check
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeCollection.GetAsync(volumeResource2.Data.Name.Split('/').Last() + "1"); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CheckAvailability()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string fullVolumeName = $"{_netAppAccount.Id.Name}/{_capacityPool.Id.Name.Split().Last()}/{volumeName}";
            //check account availability
            ResourceNameAvailabilityContent parameters = new(_netAppAccount.Id.Name, CheckNameResourceTypes.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name);

            //Check account existing account should be not available
            var checkNameResult = (await DefaultSubscription.CheckNameAvailabilityNetAppResourceAsync(DefaultLocation, parameters)).Value;
            Assert.IsFalse(checkNameResult.IsAvailable);

            //Check account name none existing account should be  available
            checkNameResult = (await DefaultSubscription.CheckNameAvailabilityNetAppResourceAsync(DefaultLocation, new ResourceNameAvailabilityContent(Recording.GenerateAssetName("someOtherAccount"), CheckNameResourceTypes.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name))).Value;
            Assert.IsTrue(checkNameResult.IsAvailable);

            //Check filePathAvailability
            checkNameResult = (await DefaultSubscription.CheckNameAvailabilityNetAppResourceAsync(DefaultLocation, new ResourceNameAvailabilityContent(fullVolumeName, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, _resourceGroup.Id.Name))).Value;
            Assert.IsTrue(checkNameResult.IsAvailable);

            //Create volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            //Check filePathAvailability, should be unavailable after volume creation
            checkNameResult = (await DefaultSubscription.CheckNameAvailabilityNetAppResourceAsync(DefaultLocation, new ResourceNameAvailabilityContent(fullVolumeName, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, _resourceGroup.Id.Name))).Value;
            Assert.IsFalse(checkNameResult.IsAvailable);
        }

        [Test]
        [RecordedTest]
        public async Task CreateDPVolume()
        {
            //create the source volume
            VolumeResource volumeResource1 = await CreateVolume(DefaultLocation, ServiceLevel.Premium, _defaultUsageThreshold);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(10000);
            }
            //create destination volume + resources
            //create remote resource Group
            string remoteRGName = _resourceGroup.Id.Name + "-remote";
            ResourceGroupResource remoteResourceGroup = await CreateResourceGroupAsync(remoteRGName, RemoteLocation);
            //create vnet
            VirtualNetworkResource remoteVNet = await CreateVirtualNetwork(RemoteLocation, remoteResourceGroup);

            //Create NetAppAccount
            NetAppAccountCollection remoteNetAppAccountCollection = remoteResourceGroup.GetNetAppAccounts();
            string remoteAccountName = _netAppAccount.Id.Name + "-remote";
            NetAppAccountResource remoteNetAppAccount = (await remoteNetAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, remoteAccountName, GetDefaultNetAppAccountParameters(RemoteLocation))).Value;

            //Create remote pool
            CapacityPoolCollection remoteCapacityPoolCollection = remoteNetAppAccount.GetCapacityPools();
            CapacityPoolData remoteCapactiyPoolData = new(RemoteLocation, _poolSize.Value, ServiceLevel.Premium);
            remoteCapactiyPoolData.Tags.InitializeFrom(DefaultTags);
            CapacityPoolResource remoteCapacityPool = (await remoteCapacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, remoteCapactiyPoolData)).Value;
            //Create the remote volume with dataProtection
            ReplicationObject replication = new(null, Models.EndpointType.Dst, ReplicationSchedule._10Minutely, volumeResource1.Id, RemoteLocation);
            VolumePropertiesDataProtection dataProtectionProperties = new VolumePropertiesDataProtection(null, replication: replication, null);
            VolumeCollection remoteVolumeCollection = remoteCapacityPool.GetVolumes();
            VolumeResource remoteVolume = await CreateVolume(RemoteLocation, ServiceLevel.Premium, _defaultUsageThreshold, volumeCollection: remoteVolumeCollection, dataProtection: dataProtectionProperties);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(10000);
            }
            //validate if created successfully
            VolumeResource remoteVolumeResource = await remoteVolumeCollection.GetAsync(remoteVolume.Data.Name.Split('/').Last());
            VerifyVolumeProperties(remoteVolumeResource, false);
            Assert.AreEqual(RemoteLocation, remoteVolumeResource.Data.Location);
            remoteVolumeResource.Should().BeEquivalentTo(remoteVolume);
            Assert.IsNotNull(remoteVolumeResource.Data.DataProtection);
            Assert.IsNull(remoteVolumeResource.Data.DataProtection.Backup);
            Assert.IsNull(remoteVolumeResource.Data.DataProtection.Snapshot);
            Assert.AreEqual(replication.RemoteVolumeResourceId, remoteVolumeResource.Data.DataProtection.Replication.RemoteVolumeResourceId);
            Assert.AreEqual(replication.RemoteVolumeRegion, remoteVolumeResource.Data.DataProtection.Replication.RemoteVolumeRegion);
            Assert.AreEqual(replication.ReplicationSchedule, remoteVolumeResource.Data.DataProtection.Replication.ReplicationSchedule);

            //Authorize Replication
            AuthorizeContent authorize = new()
            {
                RemoteVolumeResourceId = remoteVolumeResource.Id
            };
            ArmOperation authorizeOperation = (await volumeResource1.AuthorizeReplicationAsync(WaitUntil.Completed, authorize));
            Assert.IsTrue(authorizeOperation.HasCompleted);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(120000);
            }
            //Wait for Mirrored status this indicates a healty replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(volumeResource1, MirrorState.Mirrored);

            ///List replications
            List<Replication> replicationList = await volumeResource1.GetReplicationsAsync().ToEnumerableAsync();
            replicationList.Should().NotBeNullOrEmpty();
            replicationList.Should().HaveCount(1);

            //Break Replication
            ArmOperation breakReplicationOperation = (await remoteVolume.BreakReplicationAsync(WaitUntil.Completed, new()));
            Assert.IsTrue(breakReplicationOperation.HasCompleted);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Wait for Broken status this indicates a Broken replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, MirrorState.Broken);

            //Resync Replication
            ArmOperation resyncReplicationOperation = (await remoteVolume.ResyncReplicationAsync(WaitUntil.Completed));
            Assert.IsTrue(resyncReplicationOperation.HasCompleted);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Wait for Broken status this indicates a Broken replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, MirrorState.Mirrored);

            //Break again
            breakReplicationOperation = (await remoteVolume.BreakReplicationAsync(WaitUntil.Completed, new()));
            Assert.IsTrue(breakReplicationOperation.HasCompleted);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }
            //Wait for Broken status this indicates a Broken replication relationship, calls ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, MirrorState.Broken);

            // delete the data protection object
            //  - initiate delete replication on destination, this then releases on source, both resulting in object deletion
            ArmOperation deleteReplicationOperation = (await remoteVolume.DeleteReplicationAsync(WaitUntil.Completed));
            Assert.IsTrue(deleteReplicationOperation.HasCompleted);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            var replicationFound = true; // because it was previously present
            while (replicationFound)
            {
                try
                {
                    var replicationStatus = await remoteVolumeResource.ReplicationStatusAsync();
                }
                catch
                {
                    // an exception means the replication was not found
                    // i.e. it has been deleted
                    // ok without checking it could have been for another reason
                    // but then the delete below will fail
                    replicationFound = false;
                }
                await Task.Delay(10);
            }
            // seems the volumes are not always in a terminal state here so check again
            // and ensure the replication objects are removed
            VolumeResource sourceVolume;
            VolumeResource destinationVolume;
            do
            {
                sourceVolume = await _volumeCollection.GetAsync(volumeResource1.Id.Name.Split().Last());
                destinationVolume = await remoteVolumeCollection.GetAsync(remoteVolume.Data.Name.Split('/').Last());
                await Task.Delay(10);
            } while ((sourceVolume.Data.ProvisioningState != "Succeeded") || (destinationVolume.Data.ProvisioningState != "Succeeded") || (sourceVolume.Data.DataProtection.Replication != null) || (destinationVolume.Data.DataProtection.Replication != null));

            //delete remote Volume
            await remoteVolumeResource.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await remoteVolumeCollection.ExistsAsync(volumeResource1.Data.Name.Split('/').Last()));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteVolumeCollection.GetAsync(remoteVolumeResource.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(30000);
            }
            //delete remote pool
            await remoteCapacityPool.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteCapacityPoolCollection.GetAsync(remoteCapacityPool.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }
            //Delete remote account
            await remoteNetAppAccount.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteNetAppAccountCollection.GetAsync(remoteNetAppAccount.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);

            //Delete remote ResourceGroup
            await remoteResourceGroup.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await DefaultSubscription.GetResourceGroupAsync(remoteAccountName); });
            Assert.AreEqual(404, exception.Status);
        }

        private async Task WaitForReplicationStatus(VolumeResource volumeResource, MirrorState mirrorState)
        {
            var maxDelay = TimeSpan.FromSeconds(240);
            int count = 0;
            Console.WriteLine($"Get replication status for Volume {volumeResource.Id}");
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(20), retryCount: 2000)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount)

            Polly.Retry.AsyncRetryPolicy<bool> retryPolicy = Policy
                .HandleResult<bool>(false) // retry if delegate executed asynchronously returns false
                .WaitAndRetryAsync(delay);

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    count++;
                    ReplicationStatus replicationStatus = (await volumeResource.ReplicationStatusAsync()).Value;
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Get replication status  run {count} MirrorState: {replicationStatus.MirrorState} Healty: {replicationStatus.Healthy.Value} RelationshipStatus: {replicationStatus.RelationshipStatus} ErrorMessage {replicationStatus.ErrorMessage} ");
                    if (replicationStatus.MirrorState == mirrorState)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Final Throw {ex.Message}");
                throw;
            }
        }

        private async Task WaitForReplicationStatusOLD(VolumeResource volumeResource, MirrorState mirrorState)
        {
            ReplicationStatus replicationStatus = new();
            int attempts = 0;
            do
            {
                try
                {
                    replicationStatus =     await volumeResource.ReplicationStatusAsync();
                    attempts++;
                }
                catch (RequestFailedException ex)
                {
                    if (!ex.Message.Contains("the volume replication is: 'Creating'"))
                    {
                        throw;
                    }
                }
                await Task.Delay(20000);
            } while (replicationStatus.MirrorState != mirrorState && attempts <= 40);
            attempts = 0;
            //sometimes they dont sync up right away
            if (!replicationStatus.Healthy.Value)
            {
                do
                {
                    replicationStatus = await volumeResource.ReplicationStatusAsync();
                    attempts++;
                    if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                    {
                        await Task.Delay(5000);
                    }
                } while (replicationStatus.Healthy.Value && attempts < 10);
            }
            Assert.True(replicationStatus.Healthy);
            Assert.AreEqual(mirrorState, replicationStatus.MirrorState);
        }
    }
}
