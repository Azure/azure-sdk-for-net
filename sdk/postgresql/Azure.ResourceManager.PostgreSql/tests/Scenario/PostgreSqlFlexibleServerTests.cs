// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public PostgreSqlFlexibleServerTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
            var (vnetID, subnetID) = await CreateVirtualNetwork(sourceVnetName, sourceSubnetName, rg.Data.Name, rg.Data.Location);

            // Create private DNS zone and virtual link
            var sourcePrivateDnsZone = await CreatePrivateDnsZone(sourcePrivateServerName, vnetID, rg.Data.Name);

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
                    DelegatedSubnetResourceId = subnetID,
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
                    DelegatedSubnetResourceId = subnetID,
                    PrivateDnsZoneArmResourceId = sourcePrivateDnsZone.Id,
                },
                SourceServerResourceId = sourcePrivateServer.Id,
                PointInTimeUtc = DateTime.Now,
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var targetPrivateServer = targetPrivateServerOperation.Value;

            Assert.AreEqual(targetPrivateServerName, targetPrivateServer.Data.Name);
            Assert.AreEqual(subnetID, targetPrivateServer.Data.Network.DelegatedSubnetResourceId);
            Assert.AreEqual(sourcePrivateDnsZone.Id, targetPrivateServer.Data.Network.PrivateDnsZoneArmResourceId);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, targetPrivateServer.Data.Network.PublicNetworkAccess);

            // Restore private server in different vnet
            var (targetVnetID, targetSubnetID) = await CreateVirtualNetwork(targetVnetName, targetSubnetName, rg.Data.Name, rg.Data.Location);
            var targetPrivateDnsZone = await CreatePrivateDnsZone(targetPrivateServerDiffName, targetVnetID, rg.Data.Name);

            var targetPrivateServerDiffOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPrivateServerDiffName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = targetSubnetID,
                    PrivateDnsZoneArmResourceId = targetPrivateDnsZone.Id,
                },
                SourceServerResourceId = sourcePrivateServer.Id,
                PointInTimeUtc = DateTime.Now,
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var targetPrivateServerDiff = targetPrivateServerDiffOperation.Value;

            Assert.AreEqual(targetPrivateServerDiffName, targetPrivateServerDiff.Data.Name);
            Assert.AreEqual(targetSubnetID, targetPrivateServerDiff.Data.Network.DelegatedSubnetResourceId);
            Assert.AreEqual(targetPrivateDnsZone.Id, targetPrivateServerDiff.Data.Network.PrivateDnsZoneArmResourceId);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, targetPrivateServerDiff.Data.Network.PublicNetworkAccess);
        }

        [TestCase]
        public async Task GeoRestore()
        {
            var sourcePublicServerName = Recording.GenerateAssetName("pgflexserver");
            var targetPublicServerName = Recording.GenerateAssetName("pgflexserver");
            var sourcePrivateServerName = Recording.GenerateAssetName("pgflexserver");
            var targetPrivateServerName = Recording.GenerateAssetName("pgflexserver");
            var sourceVnetName = Recording.GenerateAssetName("vnet");
            var targetVnetName = Recording.GenerateAssetName("vnet");
            var sourceSubnetName = Recording.GenerateAssetName("subnet");
            var targetSubnetName = Recording.GenerateAssetName("subnet");
            var targetLocation = AzureLocation.WestUS;

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
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                    GeoRedundantBackup = PostgreSqlFlexibleServerGeoRedundantBackupEnum.Enabled,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var sourcePublicServer = sourcePublicServerOperation.Value;

            Assert.AreEqual(sourcePublicServerName, sourcePublicServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerGeoRedundantBackupEnum.Enabled, sourcePublicServer.Data.Backup.GeoRedundantBackup);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Enabled, sourcePublicServer.Data.Network.PublicNetworkAccess);

            // Geo-restore public server to paired region
            PostgreSqlFlexibleServerResource targetPublicServer = null;
            for (var i = 0; i < 20; i++)
            {
                try
                {
                    var targetPublicServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPublicServerName, new PostgreSqlFlexibleServerData(targetLocation)
                    {
                        SourceServerResourceId = sourcePublicServer.Id,
                        PointInTimeUtc = DateTime.Now,
                        CreateMode = PostgreSqlFlexibleServerCreateMode.GeoRestore,
                    });
                    targetPublicServer = targetPublicServerOperation.Value;
                    break;
                }
                catch (RequestFailedException ex)
                {
                    if (ex.ErrorCode.Equals("GeoBackupsNotAvailable", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Recording.Mode != RecordedTestMode.Playback)
                        {
                            await Task.Delay(TimeSpan.FromMinutes(6));
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            Assert.IsNotNull(targetPublicServer, $"GeoBackups not available for server {sourcePublicServerName} after 2 hours.");

            Assert.AreEqual(targetPublicServerName, targetPublicServer.Data.Name);
            Assert.AreEqual(targetLocation, targetPublicServer.Data.Location);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Enabled, targetPublicServer.Data.Network.PublicNetworkAccess);

            // Create source vnet and subnet
            var (sourceVnetID, sourceSubnetID) = await CreateVirtualNetwork(sourceVnetName, sourceSubnetName, rg.Data.Name, rg.Data.Location);

            // Create source private DNS zone and virtual link
            var sourcePrivateDnsZone = await CreatePrivateDnsZone(sourcePrivateServerName, sourceVnetID, rg.Data.Name);

            // Create private server
            var sourcePrivateServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, sourcePrivateServerName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                Backup = new PostgreSqlFlexibleServerBackupProperties()
                {
                    GeoRedundantBackup = PostgreSqlFlexibleServerGeoRedundantBackupEnum.Enabled,
                },
                Network = new PostgreSqlFlexibleServerNetwork()
                {
                    DelegatedSubnetResourceId = sourceSubnetID,
                    PrivateDnsZoneArmResourceId = sourcePrivateDnsZone.Id,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var sourcePrivateServer = sourcePrivateServerOperation.Value;

            Assert.AreEqual(sourcePrivateServerName, sourcePrivateServer.Data.Name);
            Assert.AreEqual(PostgreSqlFlexibleServerGeoRedundantBackupEnum.Enabled, sourcePrivateServer.Data.Backup.GeoRedundantBackup);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, sourcePrivateServer.Data.Network.PublicNetworkAccess);

            // Create target vnet and subnet in paired region
            var (targetVnetID, targetSubnetID) = await CreateVirtualNetwork(targetVnetName, targetSubnetName, rg.Data.Name, targetLocation);

            // Create target private DNS zone and virtual link
            var targetPrivateDnsZone = await CreatePrivateDnsZone(targetPrivateServerName, targetVnetID, rg.Data.Name);

            // Geo-restore private server to paired region
            PostgreSqlFlexibleServerResource targetPrivateServer = null;
            for (var i = 0; i < 20; i++)
            {
                try
                {
                    var targetPrivateServerOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, targetPrivateServerName, new PostgreSqlFlexibleServerData(targetLocation)
                    {
                        Network = new PostgreSqlFlexibleServerNetwork()
                        {
                            DelegatedSubnetResourceId = targetSubnetID,
                            PrivateDnsZoneArmResourceId = targetPrivateDnsZone.Id,
                        },
                        SourceServerResourceId = sourcePrivateServer.Id,
                        PointInTimeUtc = DateTime.Now,
                        CreateMode = PostgreSqlFlexibleServerCreateMode.GeoRestore,
                    });
                    targetPrivateServer = targetPrivateServerOperation.Value;
                    break;
                }
                catch (RequestFailedException ex)
                {
                    if (ex.ErrorCode.Equals("GeoBackupsNotAvailable", StringComparison.OrdinalIgnoreCase))
                    {
                        if (Recording.Mode != RecordedTestMode.Playback)
                        {
                            await Task.Delay(TimeSpan.FromMinutes(6));
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            Assert.IsNotNull(targetPrivateServer, $"GeoBackups not available for server {sourcePrivateServerName} after 2 hours.");

            Assert.AreEqual(targetPrivateServerName, targetPrivateServer.Data.Name);
            Assert.AreEqual(targetLocation, targetPrivateServer.Data.Location);
            Assert.AreEqual(targetSubnetID, targetPrivateServer.Data.Network.DelegatedSubnetResourceId);
            Assert.AreEqual(targetPrivateDnsZone.Id, targetPrivateServer.Data.Network.PrivateDnsZoneArmResourceId);
            Assert.AreEqual(PostgreSqlFlexibleServerPublicNetworkAccessState.Disabled, targetPrivateServer.Data.Network.PublicNetworkAccess);
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
                var (vnetID, sourceSubnetID) = await CreateVirtualNetwork(vnetName, sourceSubnetName, rg.Data.Name, rg.Data.Location);
                sourcePrivateDnsZone = await CreatePrivateDnsZone(sourceServerName, vnetID, rg.Data.Name);

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
                    replicaPrivateDnsZone[i] = await CreatePrivateDnsZone(replicaServerName[i], vnetID, rg.Data.Name);
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

        [TestCase]
        [LiveOnly(alwaysRunLocally: false)]
        public async Task CMK()
        {
            var keyVaultName = Recording.GenerateAssetName("vault");
            var keyName = Recording.GenerateAssetName("key");
            var identityName = Recording.GenerateAssetName("identity");
            var keyNameUpdate = Recording.GenerateAssetName("key");
            var identityNameUpdate = Recording.GenerateAssetName("identity");
            var serverName = Recording.GenerateAssetName("pgflexserver");
            var replicaName = Recording.GenerateAssetName("pgflexserver");
            var restoreName = Recording.GenerateAssetName("pgflexserver");

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            // Create key and identity
            var (key, identity) = await CreateKeyAndIdentity(keyVaultName, keyName, identityName, rg.Data.Name);
            var (keyUpdate, identityUpdate) = await CreateKeyAndIdentity(keyVaultName, keyNameUpdate, identityNameUpdate, rg.Data.Name);

            // Create server with data encryption
            var serverOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                Identity = new PostgreSqlFlexibleServerUserAssignedIdentity(PostgreSqlFlexibleServerIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = { { identity.Id, new UserAssignedIdentity() } },
                },
                DataEncryption = new PostgreSqlFlexibleServerDataEncryption()
                {
                    PrimaryKeyUri = key.Id,
                    PrimaryUserAssignedIdentityId = identity.Id,
                    KeyType = PostgreSqlFlexibleServerKeyType.AzureKeyVault,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
            });
            var server = serverOperation.Value;

            Assert.AreEqual(key.Id, server.Data.DataEncryption.PrimaryKeyUri);
            Assert.AreEqual(identity.Id, server.Data.DataEncryption.PrimaryUserAssignedIdentityId);
            Assert.IsTrue(server.Data.Identity.UserAssignedIdentities.ContainsKey(identity.Id));

            // Create replica with same key and identity
            var replicaOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicaName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = server.Id,
                AvailabilityZone = "2",
                Identity = new PostgreSqlFlexibleServerUserAssignedIdentity(PostgreSqlFlexibleServerIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = { { identity.Id, new UserAssignedIdentity() } },
                },
                DataEncryption = new PostgreSqlFlexibleServerDataEncryption()
                {
                    PrimaryKeyUri = key.Id,
                    PrimaryUserAssignedIdentityId = identity.Id,
                    KeyType = PostgreSqlFlexibleServerKeyType.AzureKeyVault,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.Replica,
            });
            var replica = replicaOperation.Value;

            Assert.AreEqual(key.Id, replica.Data.DataEncryption.PrimaryKeyUri);
            Assert.AreEqual(identity.Id, replica.Data.DataEncryption.PrimaryUserAssignedIdentityId);
            Assert.IsTrue(replica.Data.Identity.UserAssignedIdentities.ContainsKey(identity.Id));

            // Update different key and identity in primary server
            var updateOperation = await server.UpdateAsync(WaitUntil.Completed, new PostgreSqlFlexibleServerPatch()
            {
                Identity = new PostgreSqlFlexibleServerUserAssignedIdentity(PostgreSqlFlexibleServerIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = { { identityUpdate.Id, new UserAssignedIdentity() } },
                },
                DataEncryption = new PostgreSqlFlexibleServerDataEncryption()
                {
                    PrimaryKeyUri = keyUpdate.Id,
                    PrimaryUserAssignedIdentityId = identityUpdate.Id,
                    KeyType = PostgreSqlFlexibleServerKeyType.AzureKeyVault,
                },
            });
            server = updateOperation.Value;

            Assert.AreEqual(keyUpdate.Id, server.Data.DataEncryption.PrimaryKeyUri);
            Assert.AreEqual(identityUpdate.Id, server.Data.DataEncryption.PrimaryUserAssignedIdentityId);
            Assert.IsTrue(server.Data.Identity.UserAssignedIdentities.ContainsKey(identityUpdate.Id));

            // Restore backup with data encryption
            if (Recording.Mode != RecordedTestMode.Playback)
            {
                var earliestRestore = server.Data.Backup.EarliestRestoreOn.Value;
                var millisecondsToWait = (int)(earliestRestore - DateTime.Now).TotalMilliseconds;
                await Task.Delay(Math.Max(0, millisecondsToWait));
            }

            var restoreOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, restoreName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = server.Id,
                PointInTimeUtc = DateTime.Now,
                Identity = new PostgreSqlFlexibleServerUserAssignedIdentity(PostgreSqlFlexibleServerIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = { { identity.Id, new UserAssignedIdentity() } },
                },
                DataEncryption = new PostgreSqlFlexibleServerDataEncryption()
                {
                    PrimaryKeyUri = key.Id,
                    PrimaryUserAssignedIdentityId = identity.Id,
                    KeyType = PostgreSqlFlexibleServerKeyType.AzureKeyVault,
                },
                CreateMode = PostgreSqlFlexibleServerCreateMode.PointInTimeRestore,
            });
            var restore = restoreOperation.Value;

            Assert.AreEqual(key.Id, restore.Data.DataEncryption.PrimaryKeyUri);
            Assert.AreEqual(identity.Id, restore.Data.DataEncryption.PrimaryUserAssignedIdentityId);
            Assert.IsTrue(restore.Data.Identity.UserAssignedIdentities.ContainsKey(identity.Id));
        }

        [TestCase]
        [LiveOnly(alwaysRunLocally: false)]
        public async Task AAD()
        {
            var serverName = Recording.GenerateAssetName("pgflexserver");
            var replicaName = new string[2] { Recording.GenerateAssetName("pgflexserver"), Recording.GenerateAssetName("pgflexserver") };

            var rg = await CreateResourceGroupAsync(Subscription, "pgflexrg", AzureLocation.EastUS);
            var serverCollection = rg.GetPostgreSqlFlexibleServers();

            // Get current client info
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();
            var tenantId = tenant.Data.TenantId.Value;

            var graphClient = new GraphServiceClient(TestEnvironment.Credential);
            var servicePrincipals = await graphClient.ServicePrincipals
                .Request()
                .Filter($"servicePrincipalNames/any(c:c eq '{TestEnvironment.ClientId}')")
                .Top(1)
                .GetAsync();
            var servicePrincipal = servicePrincipals.FirstOrDefault();

            // Create main server
            var serverOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverName, new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                Sku = new PostgreSqlFlexibleServerSku("Standard_D2s_v3", PostgreSqlFlexibleServerSkuTier.GeneralPurpose),
                AdministratorLogin = "testUser",
                AdministratorLoginPassword = "testPassword1!",
                Version = PostgreSqlFlexibleServerVersion.Ver14,
                StorageSizeInGB = 128,
                CreateMode = PostgreSqlFlexibleServerCreateMode.Create,
                AuthConfig = new PostgreSqlFlexibleServerAuthConfig()
                {
                    ActiveDirectoryAuth = PostgreSqlFlexibleServerActiveDirectoryAuthEnum.Enabled,
                    PasswordAuth = PostgreSqlFlexibleServerPasswordAuthEnum.Enabled,
                }
            });
            var server = serverOperation.Value;

            Assert.AreEqual(PostgreSqlFlexibleServerActiveDirectoryAuthEnum.Enabled, server.Data.AuthConfig.ActiveDirectoryAuth);
            Assert.AreEqual(PostgreSqlFlexibleServerPasswordAuthEnum.Enabled, server.Data.AuthConfig.PasswordAuth);

            // Create first replica server
            var replicaOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicaName[0], new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = server.Id,
                AvailabilityZone = "2",
                CreateMode = PostgreSqlFlexibleServerCreateMode.Replica,
            });
            var firstReplica = replicaOperation.Value;

            // Add AAD admin to main server
            await server.GetPostgreSqlFlexibleServerActiveDirectoryAdministrators().CreateOrUpdateAsync(WaitUntil.Completed, servicePrincipal.Id, new PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent()
            {
                PrincipalName = servicePrincipal.DisplayName,
                TenantId = tenantId,
                PrincipalType = PostgreSqlFlexibleServerPrincipalType.ServicePrincipal,
            });

            // Create second replica server
            replicaOperation = await serverCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicaName[1], new PostgreSqlFlexibleServerData(rg.Data.Location)
            {
                SourceServerResourceId = server.Id,
                AvailabilityZone = "2",
                CreateMode = PostgreSqlFlexibleServerCreateMode.Replica,
            });
            var secondReplica = replicaOperation.Value;

            // Main server and both replicas should have AAD
            foreach (var s in new PostgreSqlFlexibleServerResource[] { server, firstReplica, secondReplica })
            {
                var admin = (await s.GetPostgreSqlFlexibleServerActiveDirectoryAdministratorAsync(servicePrincipal.Id)).Value;
                Assert.AreEqual(PostgreSqlFlexibleServerPrincipalType.ServicePrincipal, admin.Data.PrincipalType);
                Assert.AreEqual(servicePrincipal.DisplayName, admin.Data.PrincipalName);
                Assert.AreEqual(servicePrincipal.Id, admin.Data.ObjectId.ToString());
            }
        }
    }
}
