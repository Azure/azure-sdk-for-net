// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests.ScenarioTests
{
    public class ListSkusForScalingFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public ListSkusForScalingFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
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
        public async Task ListSkusForScalingTest()
        {
            await SetCollectionsAsync();

            string redisEnterpriseCacheName = Recording.GenerateAssetName("RedisEnterpriseBegin");
            var data = new RedisEnterpriseClusterData(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB100)
                {
                })
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled,
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB100, clusterResponse.Data.Sku.Name);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.BalancedB100, clusterResponse.Data.Sku.Name);

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

            // List Skus for scaling
            var skusResponse = await clusterResponse.GetSkusForScalingAsync();
            Assert.IsNotNull(skusResponse);

            // Assert that the response contains specific SKUs
            var skus = skusResponse.Value.Skus;
            Assert.IsTrue(skus.Any(s => s.Name == RedisEnterpriseSkuName.BalancedB20));
            Assert.IsTrue(skus.Any(s => s.Name == RedisEnterpriseSkuName.BalancedB50));
            Assert.IsTrue(skus.Any(s => s.SizeInGB == 24.0));

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
