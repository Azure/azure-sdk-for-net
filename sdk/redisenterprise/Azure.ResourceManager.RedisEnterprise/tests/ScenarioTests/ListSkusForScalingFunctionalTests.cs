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
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB100));

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB100));

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
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));

            // List Skus for scaling
            var skusResponse = await clusterResponse.GetSkusForScalingAsync();
            Assert.That(skusResponse, Is.Not.Null);

            // Assert that the response contains specific SKUs
            var skus = skusResponse.Value.Skus;
            Assert.That(skus.Any(s => s.Name == RedisEnterpriseSkuName.BalancedB20), Is.True);
            Assert.That(skus.Any(s => s.Name == RedisEnterpriseSkuName.BalancedB50), Is.True);
            Assert.That(skus.Any(s => s.SizeInGB == 24.0), Is.True);

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
