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
using System.Net;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class VolumeTests : NetAppTestBase
    {
        private string _pool1Name = "pool1";
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts();}
        public VolumeTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("VolumeTEST Setup");
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;
            _volumeCollection = _capacityPool.GetNetAppVolumes();

            Console.WriteLine("VolumeTEST Setup create vnet");
        }

        [TearDown]
        public async Task ClearVolumes()
        {
            //remove all volumes under current capcityPool, remove pool and netAppAccount
            if (_resourceGroup != null)
            {
                bool exists = await _capacityPoolCollection.ExistsAsync(_capacityPool.Id.Name);
                CapacityPoolCollection poolCollection = _netAppAccount.GetCapacityPools();
                List<CapacityPoolResource> poolList = await poolCollection.GetAllAsync().ToEnumerableAsync();
                foreach (CapacityPoolResource pool in poolList)
                {
                    NetAppVolumeCollection volumeCollection = pool.GetNetAppVolumes();
                    List<NetAppVolumeResource> volumeList = await volumeCollection.GetAllAsync().ToEnumerableAsync();
                    foreach (NetAppVolumeResource volume in volumeList)
                    {
                        Console.WriteLine($"Cleanup volume: {volume.Id}");
                        if (volume.Data.DataProtection?.Replication?.EndpointType == NetAppEndpointType.Source)
                        {
                            NetAppVolumeReplicationStatus replicationStatus = (await volume.GetReplicationStatusAsync()).Value;
                            if (replicationStatus.MirrorState != NetAppMirrorState.Mirrored)
                            {
                                Console.WriteLine($"Cleanup volume replicationMirrorState is: {replicationStatus.MirrorState}");
                                try
                                {
                                    await CleanupRemoteResources(volume);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error during clean upp, remove replication: {ex}");
                                }
                            }
                        }
                        if (await volumeCollection.ExistsAsync(volume.Id.Name))
                        {
                            await volume.DeleteAsync(WaitUntil.Completed);
                        }
                    }
                    await LiveDelay(30000);
                    await pool.DeleteAsync(WaitUntil.Completed);
                }
                await LiveDelay(40000);
                //remove
                //await _capacityPool.DeleteAsync(WaitUntil.Completed);
                //await LiveDelay(40000);
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

        private async Task CleanupRemoteResources(NetAppVolumeResource volume)
        {
            await CreateVirtualNetwork();
            Console.WriteLine($"Cleaning up remote resources: {volume.Data.DataProtection.Replication.RemoteVolumeResourceId}");
            NetAppVolumeResource remoteVolume = Client.GetNetAppVolumeResource(volume.Data.DataProtection.Replication.RemoteVolumeResourceId);

            // delete the data protection object
            ArmOperation deleteReplicationOperation = (await remoteVolume.DeleteReplicationAsync(WaitUntil.Completed));
            Assert.IsTrue(deleteReplicationOperation.HasCompleted);
            await LiveDelay(5000);
            CapacityPoolResource remotePool = Client.GetCapacityPoolResource(remoteVolume.Id.Parent);

            //Delete remote volume
            await remoteVolume.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(30000);
            Response<ResourceGroupResource> remoteGroup = DefaultSubscription.GetResourceGroup(remotePool.Id.ResourceGroupName);
            await remoteGroup.Value.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(30000);
        }

        [RecordedTest]
        public async Task UpdateVolume()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);

            //Update with patch
            NetAppVolumePatch parameters = new(DefaultLocation);
            var keyValue = new KeyValuePair<string, string>("Tag2", "value2");
            parameters.Tags.InitializeFrom(DefaultTags);
            parameters.Tags.Add(keyValue);
            parameters.IsSnapshotDirectoryVisible = false;
            volumeResource1 = (await volumeResource1.UpdateAsync(WaitUntil.Completed, parameters)).Value;
            volumeResource1.Data.Tags.Should().Contain(keyValue);

            // validate
            NetAppVolumeResource volumeResource3 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            volumeResource3.Data.Tags.Should().Contain(keyValue);
            KeyValuePair<string, string> keyValuePair = new("key1", DefaultTags["key1"]);
            volumeResource3.Data.Tags.Should().Contain(keyValuePair);
            Assert.IsFalse(volumeResource3.Data.IsSnapshotDirectoryVisible);
            //usageThreshold should not change
            Assert.AreEqual(volumeResource3.Data.UsageThreshold, volumeResource3.Data.UsageThreshold);
        }

        [RecordedTest]
        public async Task CreateDeleteVolume()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Id.Name);
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeCollection.GetAsync(volumeResource1.Id.Name + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await _volumeCollection.ExistsAsync(volumeResource1.Id.Name));
            Assert.IsFalse(await _volumeCollection.ExistsAsync(volumeResource1.Id.Name + "1"));

            //delete Volume
            await volumeResource2.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeResource1.Id.Name));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeResource1.Id.Name); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task CreateVolumePoolNotFound()
        {
            //Delete pool
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);
            //create volume
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task CreateVolumeWithProperties()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, exportPolicyRule: _defaultExportPolicyRule, protocolTypes: _defaultProtocolTypes, volumeName: volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            Assert.NotNull(volumeResource2.Data.ProtocolTypes);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            volumeResource2.Data.ProtocolTypes.Should().Equal(_defaultProtocolTypes);
            Assert.NotNull(volumeResource2.Data.ExportPolicy);
            volumeResource2.Data.ExportPolicy.Rules.Should().NotBeEmpty();
            Assert.AreEqual(_defaultExportPolicyRule.RuleIndex, volumeResource2.Data.ExportPolicy.Rules[0].RuleIndex);
            Assert.AreEqual(_defaultExportPolicyRule.IsUnixReadOnly, volumeResource2.Data.ExportPolicy.Rules[0].IsUnixReadOnly);
            Assert.AreEqual(_defaultExportPolicyRule.AllowCifsProtocol, volumeResource2.Data.ExportPolicy.Rules[0].AllowCifsProtocol);
            Assert.AreEqual(_defaultExportPolicyRule.AllowNfsV3Protocol, volumeResource2.Data.ExportPolicy.Rules[0].AllowNfsV3Protocol);
            Assert.AreEqual(_defaultExportPolicyRule.AllowNfsV41Protocol, volumeResource2.Data.ExportPolicy.Rules[0].AllowNfsV41Protocol);
            Assert.AreEqual(_defaultExportPolicyRule.AllowedClients, volumeResource2.Data.ExportPolicy.Rules[0].AllowedClients);
            volumeResource2.Data.ProtocolTypes.Should().BeEquivalentTo(_defaultProtocolTypes);

            //delete Volume
            await volumeResource2.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeResource1.Id.Name));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task DeletePooWithVolumePresent()
        {
            Console.WriteLine("TEST DeletePooWithVolumePresent");
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);

            //Delete pool
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPool.DeleteAsync(WaitUntil.Completed); });
            Assert.AreEqual(409, exception.Status);
        }

        [RecordedTest]
        public async Task GetVolumeByName()
        {
            Console.WriteLine("TEST GetVolumeByName");
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
        }

        [RecordedTest]
        public async Task GetVolumeByNameNotFound()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            //Try and get a volume rom the pool, none have been created yet
            await CreateVirtualNetwork();
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeName));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task GetVolumeByNamePoolNotFound()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            //create volume
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            //delete Volume
            await volumeResource1.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);
            //Delete pool
            await _capacityPool.DeleteAsync(WaitUntil.Completed);
            await LiveDelay(40000);

            //Try and get a volume from the pool, does not exist
            Assert.IsFalse(await _capacityPoolCollection.ExistsAsync(volumeName));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _capacityPoolCollection.GetAsync(volumeName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task ListVolumes()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string volumeName2 = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            //create volume1
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            //create volume2
            NetAppVolumeResource volumeResource2 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName2);

            //validate if list is returned successfully
            List<NetAppVolumeResource> volumeList = await _volumeCollection.GetAllAsync().ToEnumerableAsync();
            volumeList.Should().HaveCount(2);
            NetAppVolumeResource volumeResource3 = null;
            NetAppVolumeResource volumeResource4 = null;
            foreach (NetAppVolumeResource volume in volumeList)
            {
                if (volume.Id.Name == volumeResource1.Id.Name)
                    volumeResource3 = volume;
                if (volume.Id.Name == volumeResource2.Id.Name)
                    volumeResource3 = volume;
            }
            volumeResource3.Should().BeEquivalentTo(volumeResource3);
            volumeResource4.Should().BeEquivalentTo(volumeResource4);
        }

        [Ignore("Ignore for now due to CI pipeline timeout.")]
        [RecordedTest]
        public async Task LongListVolumes()
        {
            //Set pool size to fit the number of volumes
            CapacityPoolPatch parameters = new(DefaultLocation);
            await CreateVirtualNetwork();
            long setPoolSize = 11 * _tebibyte;
            parameters.Size = setPoolSize;
            await _capacityPool.UpdateAsync(WaitUntil.Completed, parameters);
            await LiveDelay(5000);
            //create volumes
            int length = 103;
            int count = 0;
            List<NetAppVolumeResource> list = new List<NetAppVolumeResource>();
            for (int i = 0; i < length; i++)
            {
                var volumeName = Recording.GenerateAssetName("volumeName-");
                NetAppVolumeResource volume = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
                list.Add(volume);
                count++;
            }
            await LiveDelay(120000);
            //validate if list is returned successfully
            List<NetAppVolumeResource> volumeList = await _volumeCollection.GetAllAsync().ToEnumerableAsync();
            Console.WriteLine($"Created {length}/{count} volumes, volumeList.Count= {volumeList.Count} in {_volumeCollection.Id}");
            volumeList.Should().HaveCount(length);
        }

        [RecordedTest]
        public async Task ChangePoolForVolume()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string poolName2 = Recording.GenerateAssetName("pool-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);
            volumeResource2.Should().BeEquivalentTo(volumeResource1);
            //create second pool
            CapacityPoolResource pool2 = await CreateCapacityPool(DefaultLocation, NetAppFileServiceLevel.Premium, _poolSize, poolName: poolName2);
            CapacityPoolResource pool3 = await _capacityPoolCollection.GetAsync(poolName2);
            pool3.Should().BeEquivalentTo(pool2);

            //Change pools
            NetAppVolumePoolChangeContent parameters = new(pool2.Id);
            ArmOperation poolChangeOperation = (await volumeResource2.PoolChangeAsync(WaitUntil.Completed, parameters));
            Assert.IsTrue(poolChangeOperation.HasCompleted);

            // validate, retrieve the volume from second pool and check
            NetAppVolumeCollection volumeCollection2 = pool2.GetNetAppVolumes();
            NetAppVolumeResource volumeResource3 = await volumeCollection2.GetAsync(volumeResource2.Id.Name);
            Assert.AreEqual(poolName2, volumeResource3.Id.Parent.Name);
            // try to retrieve the volume from first pool and check
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _volumeCollection.GetAsync(volumeResource2.Id.Name + "1"); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task CheckAvailability()
        {
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string otherName = Recording.GenerateAssetName("someOtherAccount");
            await CreateVirtualNetwork();
            string fullVolumeName = $"{_netAppAccount.Id.Name}/{_capacityPool.Id.Name.Split().Last()}/{volumeName}";
            //check account availability
            NetAppNameAvailabilityContent parameters = new(_netAppAccount.Id.Name, NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name);

            //Check account existing account should be not available
            var checkNameResult = (await DefaultSubscription.CheckNetAppNameAvailabilityAsync(DefaultLocation, parameters)).Value;
            Assert.IsFalse(checkNameResult.IsAvailable);

            //Check account name none existing account should be  available
            checkNameResult = (await DefaultSubscription.CheckNetAppNameAvailabilityAsync(DefaultLocation, new NetAppNameAvailabilityContent(otherName, NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name))).Value;
            Assert.IsTrue(checkNameResult.IsAvailable);

            //Check filePathAvailability
            checkNameResult = (await DefaultSubscription.CheckNetAppNameAvailabilityAsync(DefaultLocation, new NetAppNameAvailabilityContent(fullVolumeName, NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, _resourceGroup.Id.Name))).Value;
            Assert.IsTrue(checkNameResult.IsAvailable);

            //Create volume
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            //Check filePathAvailability, should be unavailable after volume creation
            checkNameResult = (await DefaultSubscription.CheckNetAppNameAvailabilityAsync(DefaultLocation, new NetAppNameAvailabilityContent(fullVolumeName, NetAppNameAvailabilityResourceType.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, _resourceGroup.Id.Name))).Value;
            Assert.IsFalse(checkNameResult.IsAvailable);
        }

        [RecordedTest]
        public async Task CreateDPVolume()
        {
            //create the source volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            string volumeName2 = Recording.GenerateAssetName("volumeName-");
            string remoteRGName = Recording.GenerateAssetName(_resourceGroup.Id.Name + "-remote");
            string remotevnetName = Recording.GenerateAssetName("vnet-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            await LiveDelay(10000);
            //create destination volume + resources
            //create remote resource Group
            //string remoteRGName = _resourceGroup.Id.Name + "-remote";
            ResourceGroupResource remoteResourceGroup = await CreateResourceGroupAsync(remoteRGName, RemoteLocation);
            //create vnet
            await CreateVirtualNetwork(RemoteLocation, remoteResourceGroup, remotevnetName);

            //Create NetAppAccount
            NetAppAccountCollection remoteNetAppAccountCollection = remoteResourceGroup.GetNetAppAccounts();
            string remoteAccountName = _netAppAccount.Id.Name + "-remote";
            NetAppAccountResource remoteNetAppAccount = (await remoteNetAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, remoteAccountName, GetDefaultNetAppAccountParameters(RemoteLocation))).Value;

            //Create remote pool
            CapacityPoolCollection remoteCapacityPoolCollection = remoteNetAppAccount.GetCapacityPools();
            CapacityPoolData remoteCapactiyPoolData = new(RemoteLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            remoteCapactiyPoolData.Tags.InitializeFrom(DefaultTags);
            CapacityPoolResource remoteCapacityPool = (await remoteCapacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, remoteCapactiyPoolData)).Value;
            //Create the remote volume with dataProtection
            NetAppReplicationObject replication = new(null, NetAppEndpointType.Destination, NetAppReplicationSchedule.TenMinutely, volumeResource1.Id, RemoteLocation, serializedAdditionalRawData: null);
            NetAppVolumeDataProtection dataProtectionProperties = new NetAppVolumeDataProtection() { Replication = replication };
            NetAppVolumeCollection remoteVolumeCollection = remoteCapacityPool.GetNetAppVolumes();
            NetAppVolumeResource remoteVolume = await CreateVolume(RemoteLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeCollection: remoteVolumeCollection, dataProtection: dataProtectionProperties, volumeName: volumeName2);
            await LiveDelay(10000);
            //validate if created successfully
            NetAppVolumeResource remoteVolumeResource = await remoteVolumeCollection.GetAsync(remoteVolume.Id.Name);
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
            NetAppVolumeAuthorizeReplicationContent authorize = new()
            {
                RemoteVolumeResourceId = remoteVolumeResource.Id
            };
            ArmOperation authorizeOperation = (await volumeResource1.AuthorizeReplicationAsync(WaitUntil.Completed, authorize));
            Assert.IsTrue(authorizeOperation.HasCompleted);
            await LiveDelay(240000);
            //Wait for Mirrored status this indicates a healty replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(volumeResource1, NetAppMirrorState.Mirrored);

            ///List replications
            List<NetAppVolumeReplication> replicationList = await volumeResource1.GetReplicationsAsync().ToEnumerableAsync();
            replicationList.Should().NotBeNullOrEmpty();
            replicationList.Should().HaveCount(1);

            //Break Replication
            ArmOperation breakReplicationOperation = (await remoteVolume.BreakReplicationAsync(WaitUntil.Completed, new()));
            Assert.IsTrue(breakReplicationOperation.HasCompleted);
            await LiveDelay(5000);
            //Wait for Broken status this indicates a Broken replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, NetAppMirrorState.Broken);

            //Resync Replication
            ArmOperation resyncReplicationOperation = (await remoteVolume.ResyncReplicationAsync(WaitUntil.Completed));
            Assert.IsTrue(resyncReplicationOperation.HasCompleted);
            await LiveDelay(5000);
            //Wait for Broken status this indicates a Broken replication relationship, tests ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, NetAppMirrorState.Mirrored);

            //Break again
            breakReplicationOperation = (await remoteVolume.BreakReplicationAsync(WaitUntil.Completed, new()));
            Assert.IsTrue(breakReplicationOperation.HasCompleted);
            await LiveDelay(5000);
            //Wait for Broken status this indicates a Broken replication relationship, calls ReplicationStatusAsync() operation
            await WaitForReplicationStatus(remoteVolume, NetAppMirrorState.Broken);

            // delete the data protection object
            //  - initiate delete replication on destination, this then releases on source, both resulting in object deletion
            ArmOperation deleteReplicationOperation = (await remoteVolume.DeleteReplicationAsync(WaitUntil.Completed));
            Assert.IsTrue(deleteReplicationOperation.HasCompleted);
            await LiveDelay(5000);

            var replicationFound = true; // because it was previously present
            while (replicationFound)
            {
                try
                {
                    var replicationStatus = await remoteVolumeResource.GetReplicationStatusAsync();
                }
                catch
                {
                    // an exception means the replication was not found
                    // i.e. it has been deleted
                    // ok without checking it could have been for another reason
                    // but then the delete below will fail
                    replicationFound = false;
                }
                await LiveDelay(10);
            }
            // seems the volumes are not always in a terminal state here so check again
            // and ensure the replication objects are removed
            NetAppVolumeResource sourceVolume;
            NetAppVolumeResource destinationVolume;
            do
            {
                sourceVolume = await _volumeCollection.GetAsync(volumeResource1.Id.Name.Split().Last());
                destinationVolume = await remoteVolumeCollection.GetAsync(remoteVolume.Data.Name.Split('/').Last());
                await LiveDelay(10);
            } while ((sourceVolume.Data.ProvisioningState != "Succeeded") || (destinationVolume.Data.ProvisioningState != "Succeeded") || (sourceVolume.Data.DataProtection.Replication != null) || (destinationVolume.Data.DataProtection.Replication != null));

            //delete remote Volume
            await remoteVolumeResource.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await remoteVolumeCollection.ExistsAsync(volumeResource1.Id.Name));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteVolumeCollection.GetAsync(remoteVolumeResource.Id.Name); });
            Assert.AreEqual(404, exception.Status);

            await LiveDelay(30000);
            //delete remote pool
            await remoteCapacityPool.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteCapacityPoolCollection.GetAsync(remoteCapacityPool.Id.Name); });
            Assert.AreEqual(404, exception.Status);
            await LiveDelay(20000);
            //Delete remote account
            await remoteNetAppAccount.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await remoteNetAppAccountCollection.GetAsync(remoteNetAppAccount.Data.Name.Split('/').Last()); });
            Assert.AreEqual(404, exception.Status);

            //Delete remote ResourceGroup
            await remoteResourceGroup.DeleteAsync(WaitUntil.Completed);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await DefaultSubscription.GetResourceGroupAsync(remoteAccountName); });
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task BreakFileLocksVolumeNoFiles()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);

            //Call break file locks
            NetAppVolumeBreakFileLocksContent parameters = new()
            {
                ConfirmRunningDisruptiveOperation = true,
                ClientIP = IPAddress.Parse("101.102.103.104")
            };

            await volumeResource1.BreakFileLocksAsync(WaitUntil.Completed, parameters);
        }

        [RecordedTest]
        public async Task GetGetGroupIdListForLdapUserNonLDAPVolumeShouldReturnError()
        {
            //create volume
            string volumeName = Recording.GenerateAssetName("volumeName-");
            await CreateVirtualNetwork();
            NetAppVolumeResource volumeResource1 = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, volumeName: volumeName);
            VerifyVolumeProperties(volumeResource1, true);
            volumeResource1.Should().BeEquivalentTo((await volumeResource1.GetAsync()).Value);
            //validate if created successfully
            NetAppVolumeResource volumeResource2 = await _volumeCollection.GetAsync(volumeResource1.Data.Name.Split('/').Last());
            VerifyVolumeProperties(volumeResource2, true);

            //Call break file locks
            GetGroupIdListForLdapUserContent parameters = new("fakeUser");
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await volumeResource1.GetGetGroupIdListForLdapUserAsync(WaitUntil.Completed, parameters); });
            Assert.AreEqual(400, exception.Status);
        }

        private async Task WaitForReplicationStatus(NetAppVolumeResource volumeResource, NetAppMirrorState mirrorState)
        {
            var maxDelay = TimeSpan.FromSeconds(240);
            int count = 0;
            Console.WriteLine($"Get replication status for Volume {volumeResource.Id}");
            if (Mode == RecordedTestMode.Playback)
            {
                maxDelay = TimeSpan.FromMilliseconds(50);
            }
            Console.WriteLine($"...decorrelated maxdelay {maxDelay}");
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
                    NetAppVolumeReplicationStatus replicationStatus = (await volumeResource.GetReplicationStatusAsync()).Value;
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Get replication status  run {count} MirrorState: {replicationStatus.MirrorState} Healty: {replicationStatus.IsHealthy.Value} RelationshipStatus: {replicationStatus.RelationshipStatus} ErrorMessage {replicationStatus.ErrorMessage} ");
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

        private async Task WaitForReplicationStatusOLD(NetAppVolumeResource volumeResource, NetAppMirrorState mirrorState)
        {
            NetAppVolumeReplicationStatus replicationStatus = new();
            int attempts = 0;
            do
            {
                try
                {
                    replicationStatus =     await volumeResource.GetReplicationStatusAsync();
                    attempts++;
                }
                catch (RequestFailedException ex)
                {
                    if (!ex.Message.Contains("the volume replication is: 'Creating'"))
                    {
                        throw;
                    }
                }
                await LiveDelay(20000);
            } while (replicationStatus.MirrorState != mirrorState && attempts <= 40);
            attempts = 0;
            //sometimes they dont sync up right away
            if (!replicationStatus.IsHealthy.Value)
            {
                do
                {
                    replicationStatus = await volumeResource.GetReplicationStatusAsync();
                    attempts++;
                    await LiveDelay(5000);
                } while (replicationStatus.IsHealthy.Value && attempts < 10);
            }
            Assert.True(replicationStatus.IsHealthy);
            Assert.AreEqual(mirrorState, replicationStatus.MirrorState);
        }
    }
}
