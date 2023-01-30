// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.PrivateDns;
using Azure.ResourceManager.Resources;
using Microsoft.Graph;
using NUnit.Framework;

namespace Azure.ResourceManager.PostgreSql.Tests
{
    public class PostgreSqlFlexibleServerTests: PostgreSqlManagementTestBase
    {
        public PostgreSqlFlexibleServerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateGetList()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            PostgreSqlFlexibleServerCollection serverCollection = rg.GetPostgreSqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("pgflexserver");
            var data = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D4s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "13",
                Storage = new PostgreSqlFlexibleServerStorage() {StorageSizeInGB = 128},
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                   BackupRetentionDays = 7
                },
                Network = new PostgreSqlFlexibleServerNetwork(),
                HighAvailability = new PostgreSqlFlexibleServerHighAvailability() { Mode = PostgreSqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            PostgreSqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Get
            PostgreSqlFlexibleServerResource serverFromGet = await serverCollection.GetAsync(serverName);
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // List
            await foreach (PostgreSqlFlexibleServerResource serverFromList in serverCollection)
            {
                Assert.AreEqual(serverName, serverFromList.Data.Name);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateUpdateGetDelete()
        {
            // Create
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            PostgreSqlFlexibleServerCollection serverCollection = rg.GetPostgreSqlFlexibleServers();
            string serverName = Recording.GenerateAssetName("pgflexserver");
            var data = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D4s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = "13",
                Storage = new PostgreSqlFlexibleServerStorage() { StorageSizeInGB = 128 },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                    BackupRetentionDays = 7
                },
                Network = new PostgreSqlFlexibleServerNetwork(),
                HighAvailability = new PostgreSqlFlexibleServerHighAvailability() { Mode = PostgreSqlFlexibleServerHighAvailabilityMode.Disabled },
            };
            var lro = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, data);
            PostgreSqlFlexibleServerResource server = lro.Value;
            Assert.AreEqual(serverName, server.Data.Name);
            // Update
            lro = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                Tags = {{"key", "value"}}
            });
            PostgreSqlFlexibleServerResource serverFromUpdate = lro.Value;
            Assert.AreEqual(serverName, serverFromUpdate.Data.Name);
            Assert.AreEqual("value", serverFromUpdate.Data.Tags["key"]);
            // Get
            PostgreSqlFlexibleServerResource serverFromGet = await serverFromUpdate.GetAsync();
            Assert.AreEqual(serverName, serverFromGet.Data.Name);
            // Delete
            await serverFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Restore()
        {
            var sourcePublicServerName = Recording.GenerateAssetName("pgflexserver");
            var targetPublicServerName = Recording.GenerateAssetName("pgflexserver");
            var sourcePrivateServerName = Recording.GenerateAssetName("pgflexserver");
            var targetPrivateServerName = Recording.GenerateAssetName("pgflexserver");
            var targetPrivateServerDiffName = Recording.GenerateAssetName("pgflexserver");
            var sourceVnetName = Recording.GenerateAssetName("vnet");
            var targetVnetName = Recording.GenerateAssetName("vnet");
            var sourceSubnetName = Recording.GenerateAssetName("subnet");
            var targetSubnetName = Recording.GenerateAssetName("subnet");

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            // Create public server
            var sourcePublicServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, sourcePublicServerName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var sourcePublicServer = sourcePublicServerOperation.Value;

            Assert.AreEqual(sourcePublicServerName, sourcePublicServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Enabled, sourcePublicServer.Data.Network.PublicNetworkAccess);

            if (Recording.Mode != RecordedTestMode.Playback)
            {
                var earliestRestore = sourcePublicServer.Data.Backup.EarliestRestoreOn.Value;
                var millisecondsToWait = (int)(earliestRestore - DateTime.Now).TotalMilliseconds;
                await Task.Delay(Math.Max(0, millisecondsToWait) + 180000);
            }

            // Restore public server
            var targetPublicServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPublicServerName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = sourcePublicServer.Id,
                PointInTimeUtc = DateTime.Now,
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var targetPublicServer = targetPublicServerOperation.Value;

            Assert.AreEqual(targetPublicServerName, targetPublicServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Enabled, targetPublicServer.Data.Network.PublicNetworkAccess);

            // Create vnet and subnet
            var (sourceVnet, sourceSubnet) = await CreateVirtualNetwork(sourceVnetName, sourceSubnetName, rg.Data.Name, rg.Data.Location);

            // Create private DNS zone and virtual link
            var sourcePrivateDnsZone = await CreatePrivateDnsZone(sourcePrivateServerName, sourceVnet, rg.Data.Name);

            // Create private server
            var sourcePrivateServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, sourcePrivateServerName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = sourceSubnet.Id,
                    PrivateDnsZoneArmResourceId = sourcePrivateDnsZone.Id,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var sourcePrivateServer = sourcePrivateServerOperation.Value;

            Assert.AreEqual(sourcePrivateServerName, sourcePrivateServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, sourcePrivateServer.Data.Network.PublicNetworkAccess);

            if (Recording.Mode != RecordedTestMode.Playback)
            {
                var earliestRestore = sourcePrivateServer.Data.Backup.EarliestRestoreOn.Value;
                var millisecondsToWait = (int)(earliestRestore - DateTime.Now).TotalMilliseconds;
                await Task.Delay(Math.Max(0, millisecondsToWait) + 180000);
            }

            // Restore private server in same vnet
            var targetPrivateServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPrivateServerName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = sourceSubnet.Id,
                    PrivateDnsZoneArmResourceId = sourcePrivateDnsZone.Id,
                },
                SourceServerResourceId = sourcePrivateServer.Id,
                PointInTimeUtc = DateTime.Now,
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var targetPrivateServer = targetPrivateServerOperation.Value;

            Assert.AreEqual(targetPrivateServerName, targetPrivateServer.Data.Name);
            Assert.AreEqual(sourceSubnet.Id, targetPrivateServer.Data.Network.DelegatedSubnetResourceId);
            Assert.AreEqual(sourcePrivateDnsZone.Id, targetPrivateServer.Data.Network.PrivateDnsZoneArmResourceId);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, targetPrivateServer.Data.Network.PublicNetworkAccess);

            // Restore private server in different vnet
            var (targetVnet, targetSubnet) = await CreateVirtualNetwork(targetVnetName, targetSubnetName, rg.Data.Name, rg.Data.Location);
            var targetPrivateDnsZone = await CreatePrivateDnsZone(targetPrivateServerDiffName, targetVnet, rg.Data.Name);

            var targetPrivateServerDiffOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPrivateServerDiffName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = targetSubnet.Id,
                    PrivateDnsZoneArmResourceId = targetPrivateDnsZone.Id,
                },
                SourceServerResourceId = sourcePrivateServer.Id,
                PointInTimeUtc = DateTime.Now,
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var targetPrivateServerDiff = targetPrivateServerDiffOperation.Value;

            Assert.AreEqual(targetPrivateServerDiffName, targetPrivateServerDiff.Data.Name);
            Assert.AreEqual(targetSubnet.Id, targetPrivateServerDiff.Data.Network.DelegatedSubnetResourceId);
            Assert.AreEqual(targetPrivateDnsZone.Id, targetPrivateServerDiff.Data.Network.PrivateDnsZoneArmResourceId);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, targetPrivateServerDiff.Data.Network.PublicNetworkAccess);
        }

        [TestCase(true)]
        [TestCase(false)]
        [RecordedTest]
        public async Task Replica(bool vnetEnabled)
        {
            var sourceServerName = Recording.GenerateAssetName("pgflexserver");
            var replicaServerName = new string[2];
            var vnetName = Recording.GenerateAssetName("vnet");
            var sourceSubnetName = Recording.GenerateAssetName("subnet");
            var replicaSubnetName = new string[2];

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            VirtualNetworkResource vnet = null;

            SubnetResource sourceSubnet = null;
            PrivateDnsZoneResource sourcePrivateDnsZone = null;

            var replicaSubnet = new SubnetResource[2];
            var replicaPrivateDnsZone = new PrivateDnsZoneResource[2];

            for (var i = 0; i < 2; i++)
            {
                replicaServerName[i] = Recording.GenerateAssetName("pgflexserver");
                replicaSubnetName[i] = Recording.GenerateAssetName("subnet");
            }

            if (vnetEnabled)
            {
                (vnet, sourceSubnet) = await CreateVirtualNetwork(vnetName, sourceSubnetName, rg.Data.Name, rg.Data.Location);
                sourcePrivateDnsZone = await CreatePrivateDnsZone(sourceServerName, vnet, rg.Data.Name);

                for (var i = 0; i < 2; ++i)
                {
                    var replicaSubnetOperation = await vnet.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, replicaSubnetName[i], new SubnetData()
                    {
                        Name = replicaSubnetName[i],
                        AddressPrefix = $"10.0.{i+1}.0/24",
                        PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Disabled,
                        Delegations = {
                            new ServiceDelegation()
                            {
                                Name = "Microsoft.DBforPostgreSQL/flexibleServers",
                                ServiceName = "Microsoft.DBforPostgreSQL/flexibleServers",
                            },
                        },
                        PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Enabled,
                    });
                    replicaSubnet[i] = replicaSubnetOperation.Value;
                    replicaPrivateDnsZone[i] = await CreatePrivateDnsZone(replicaServerName[i], vnet, rg.Data.Name);
                }
            }

            // Create source server
            var sourceServerData = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            };
            if (vnetEnabled)
            {
                sourceServerData.Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = sourceSubnet.Id,
                    PrivateDnsZoneArmResourceId = sourcePrivateDnsZone.Id,
                };
            }
            var sourceServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, sourceServerName, sourceServerData);
            var sourceServer = sourceServerOperation.Value;

            Assert.AreEqual(sourceServerName, sourceServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerReplicationRole.Primary, sourceServer.Data.ReplicationRole);
            if (vnetEnabled)
            {
                Assert.AreEqual(sourceSubnet.Id, sourceServer.Data.Network.DelegatedSubnetResourceId);
                Assert.AreEqual(sourcePrivateDnsZone.Id, sourceServer.Data.Network.PrivateDnsZoneArmResourceId);
            }

            // Create replica 0
            var replica0ServerData = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = sourceServer.Id,
                AvailabilityZone = "2",
                CreateMode = PostgreSqlFlexibleServerCreateMode.Replica,
            };
            if (vnetEnabled)
            {
                replica0ServerData.Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = replicaSubnet[0].Id,
                    PrivateDnsZoneArmResourceId = replicaPrivateDnsZone[0].Id,
                };
            }
            var replica0ServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicaServerName[0], replica0ServerData);
            var replica0Server = replica0ServerOperation.Value;

            Assert.AreEqual(replicaServerName[0], replica0Server.Data.Name);
            Assert.AreEqual("2", replica0Server.Data.AvailabilityZone);
            Assert.AreEqual(sourceServer.Data.Sku.Name, replica0Server.Data.Sku.Name);
            Assert.AreEqual(sourceServer.Data.Sku.Tier, replica0Server.Data.Sku.Tier);
            Assert.AreEqual(PostgreSqlFlexibleServerReplicationRole.AsyncReplica, replica0Server.Data.ReplicationRole);
            Assert.AreEqual(sourceServer.Id, replica0Server.Data.SourceServerResourceId);
            Assert.AreEqual(0, replica0Server.Data.ReplicaCapacity);
            if (vnetEnabled)
            {
                Assert.AreEqual(replicaSubnet[0].Id, replica0Server.Data.Network.DelegatedSubnetResourceId);
                Assert.AreEqual(replicaPrivateDnsZone[0].Id, replica0Server.Data.Network.PrivateDnsZoneArmResourceId);
            }

            // Create replica 1
            var replica1ServerData = new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = sourceServer.Id,
                AvailabilityZone = "2",
                CreateMode = PostgreSqlFlexibleServerCreateMode.Replica,
            };
            if (vnetEnabled)
            {
                replica1ServerData.Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = replicaSubnet[1].Id,
                    PrivateDnsZoneArmResourceId = replicaPrivateDnsZone[1].Id,
                };
            }
            var replica1ServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicaServerName[1], replica1ServerData);
            var replica1Server = replica1ServerOperation.Value;

            Assert.AreEqual(replicaServerName[1], replica1Server.Data.Name);
            Assert.AreEqual("2", replica1Server.Data.AvailabilityZone);
            Assert.AreEqual(sourceServer.Data.Sku.Name, replica1Server.Data.Sku.Name);
            Assert.AreEqual(sourceServer.Data.Sku.Tier, replica1Server.Data.Sku.Tier);
            Assert.AreEqual(PostgreSqlFlexibleServerReplicationRole.AsyncReplica, replica1Server.Data.ReplicationRole);
            Assert.AreEqual(sourceServer.Id, replica1Server.Data.SourceServerResourceId);
            Assert.AreEqual(0, replica1Server.Data.ReplicaCapacity);
            if (vnetEnabled)
            {
                Assert.AreEqual(replicaSubnet[1].Id, replica1Server.Data.Network.DelegatedSubnetResourceId);
                Assert.AreEqual(replicaPrivateDnsZone[1].Id, replica1Server.Data.Network.PrivateDnsZoneArmResourceId);
            }

            var replicaList = await serverCollection.GetReplicasAsync(sourceServerName).ToEnumerableAsync();
            Assert.AreEqual(2, replicaList.Count);

            // Stop replication on replica 0
            var replica0ServerUpdate = await replica0Server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                ReplicationRole = PostgreSqlFlexibleServerReplicationRole.None,
            });
            replica0Server = replica0ServerUpdate.Value;

            Assert.AreEqual(replicaServerName[0], replica0Server.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerReplicationRole.Primary, replica0Server.Data.ReplicationRole);
            Assert.IsNull(replica0Server.Data.SourceServerResourceId);

            // Can't delete source server if it has replicas
            RequestFailedException deleteException = null;
            try
            {
                await sourceServer.DeleteAsync(WaitUntil.Completed);
            }
            catch (RequestFailedException ex)
            {
                deleteException = ex;
            }
            Assert.NotNull(deleteException);

            // Delete replica 1
            await replica1Server.DeleteAsync(WaitUntil.Completed);

            // Now delete source server
            await sourceServer.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase("11", "12")]
        [TestCase("11", "13")]
        [TestCase("11", "14")]
        [TestCase("12", "13")]
        [TestCase("12", "14")]
        [TestCase("13", "14")]
        [RecordedTest]
        public async Task MajorVersionUpgrade(string source, string dest)
        {
            PostgreSqlFlexibleServerVersion sourceVersion = source;
            PostgreSqlFlexibleServerVersion destVersion = dest;

            var serverName = Recording.GenerateAssetName("pgflexserver");

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            var serverOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = sourceVersion,
                StorageSizeInGB = 128,
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var server = serverOperation.Value;

            Assert.AreEqual(sourceVersion, server.Data.Version);

            var updateOperation = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                Version = destVersion,
            });
            server = updateOperation.Value;

            Assert.AreEqual(destVersion, server.Data.Version);
        }

        [TestCase]
        [RecordedTest]
        public async Task Backups()
        {
            var serverName = Recording.GenerateAssetName("pgflexserver");

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            var serverOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var server = serverOperation.Value;

            var backups = new List<PostgreSqlFlexibleServerBackupResource>();
            for (var i = 0; i < 10; ++i)
            {
                backups = await server.GetPostgreSqlFlexibleServerBackups().GetAllAsync().ToEnumerableAsync();
                if (backups.Count > 0)
                {
                    break;
                }
                if (Recording.Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            }
            Assert.AreEqual(1, backups.Count);

            var automaticBackup = (await server.GetPostgreSqlFlexibleServerBackupAsync(backups[0].Data.Name)).Value;
            Assert.AreEqual(automaticBackup.Data.Name, backups[0].Data.Name);
            Assert.AreEqual(automaticBackup.Data.BackupType, backups[0].Data.BackupType);
            Assert.AreEqual(automaticBackup.Data.CompletedOn, backups[0].Data.CompletedOn);
        }
    }
}
