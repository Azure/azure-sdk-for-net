// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    public class CreateUpdateDeleteFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public CreateUpdateDeleteFunctionalTests(bool isAsync)
                    : base(isAsync /*,RecordedTestMode.Record*/)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private RedisEnterpriseClusterCollection Collection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetRedisEnterpriseClusters();
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/30766")]
        public async Task CreateUpdateDeleteTest()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                {
                    Capacity = 2
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Enabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled,
                Zones = { "1", "2", "3" }
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.EnterpriseE10));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
                Assert.That(clusterResponse.Data.RedundancyMode, Is.EqualTo(RedisEnterpriseRedundancyMode.ZR));
                Assert.That(clusterResponse.Data.Sku.Capacity, Is.EqualTo(2));
            });

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.EnterpriseE10));
            Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
            Assert.That(clusterResponse.Data.RedundancyMode, Is.EqualTo(RedisEnterpriseRedundancyMode.ZR));
            Assert.That(clusterResponse.Data.Sku.Capacity, Is.EqualTo(2));

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.OssCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                Persistence = new RedisPersistenceSettings()
                {
                    IsAofEnabled = true,
                    AofFrequency = PersistenceSettingAofFrequency.OneSecond
                },
                Modules =
                {
                    new RedisEnterpriseModule("RedisBloom")
                    {
                        Args = "ERROR_RATE 0.01 INITIAL_SIZE 400"
                    },
                    new RedisEnterpriseModule("RedisTimeSeries")
                    {
                        Args = "RETENTION_POLICY 20"
                    },
                    new RedisEnterpriseModule(name: "RediSearch")
                }
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
                Assert.That(databaseResponse.Data.Modules, Has.Count.EqualTo(3));
            });

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
                Assert.That(databaseResponse.Data.Modules, Has.Count.EqualTo(3));
            });

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.That(falseResult, Is.False);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }

        [Test]
        public async Task CreateUpdateDeleteTest2()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1)
                {
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Disabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Disabled));
            });

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Disabled));
            });

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.OssCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            // Disabling high availability
            data.HighAvailability = RedisEnterpriseHighAvailability.Enabled;

            clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
            });

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
            });

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.That(falseResult, Is.False);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }

       [Test]
        public async Task CreateUpdateTestWithNoClusterPolicy()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1))
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Enabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
            });

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.Multiple(() =>
            {
                Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
                Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
                Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));
                Assert.That(clusterResponse.Data.HighAvailability, Is.EqualTo(RedisEnterpriseHighAvailability.Enabled));
            });

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.NoCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                Persistence = new RedisPersistenceSettings()
                {
                    IsAofEnabled = true,
                    AofFrequency = PersistenceSettingAofFrequency.OneSecond
                },
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.NoCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.NoCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            // Updating Cluster policy
            databaseData.ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster;

            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.EnterpriseCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.Multiple(() =>
            {
                Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
                Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
                Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.EnterpriseCluster));
                Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            });

            // Delete database and cluster
            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.That(falseResult, Is.False);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
