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
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(RedisEnterpriseRedundancyMode.ZR, clusterResponse.Data.RedundancyMode);
            Assert.AreEqual(2, clusterResponse.Data.Sku.Capacity);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);
            Assert.AreEqual(RedisEnterpriseRedundancyMode.ZR, clusterResponse.Data.RedundancyMode);
            Assert.AreEqual(2, clusterResponse.Data.Sku.Capacity);

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
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
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
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Disabled, clusterResponse.Data.HighAvailability);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Disabled, clusterResponse.Data.HighAvailability);

            var databaseCollection = clusterResponse.GetRedisEnterpriseDatabases();
            string databaseName = "default";
            var databaseData = new RedisEnterpriseDatabaseData()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.OssCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            // Disabling high availability
            data.HighAvailability = RedisEnterpriseHighAvailability.Enabled;

            clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
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
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB1, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(RedisEnterpriseHighAvailability.Enabled, clusterResponse.Data.HighAvailability);

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
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.NoCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.NoCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            // Updating Cluster policy
            databaseData.ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster;

            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.EnterpriseCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);

            // Delete database and cluster
            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.IsFalse(falseResult);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
