// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests.ScenarioTests
{
    public class AuthenticationFuntionalTests : RedisEnterpriseManagementTestBase
    {
        public AuthenticationFuntionalTests(bool isAsync)
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
       // [Ignore("Tested in dog food environment and its working with record and playback mode. But disabling this for now as test framework does not seems to support dog food officialy. Will activate this test at the time of GA release.")]
        public async Task AuthenticationTestAccessPolicyAssingment()
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
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));

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

            // Create custom access policy assignment
            AccessPolicyAssignmentCollection accessPolicyAssignmentCollection = databaseResponse.GetAccessPolicyAssignments();
            string accessPolicyAssignmentName = "accessPolicyAssignmentName1";
            AccessPolicyAssignmentData accessPolicyAssignmentData = new AccessPolicyAssignmentData()
            {
                AccessPolicyName = "default",
                UserObjectId = new Guid("5eb3eb10-a8a2-4db7-8bb4-e377180f7427"),
            };
            var accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.That(accessPolicyAssignment.Data.AccessPolicyName, Is.EqualTo("default"));
            Assert.That(accessPolicyAssignment.Data.UserObjectId, Is.EqualTo(new Guid("5eb3eb10-a8a2-4db7-8bb4-e377180f7427")));
            Assert.That(accessPolicyAssignment.Data.Name, Is.EqualTo("accessPolicyAssignmentName1"));

            // List access policy assignments
            var accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyAssignmentList.Count, Is.EqualTo(1));

            // Delete access policy assignment
            await accessPolicyAssignment.DeleteAsync(WaitUntil.Completed);
            var accessPolicyAssignmentExists = (await accessPolicyAssignmentCollection.ExistsAsync(accessPolicyAssignmentName)).Value;
            Assert.That(accessPolicyAssignmentExists, Is.False);

            // List access policy assignments
            accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyAssignmentList.Count, Is.EqualTo(0));

            // Delete database and cluster
            await databaseResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await databaseCollection.ExistsAsync(databaseName)).Value;
            Assert.That(falseResult, Is.False);

            await clusterResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await Collection.ExistsAsync(redisEnterpriseCacheName)).Value;
            Assert.That(falseResult, Is.False);
        }

        [Test]
       // [Ignore("Tested in dog food environment and its working with record and playback mode. But disabling this for now as test framework does not seems to support dog food officialy. Will activate this test at the time of GA release.")]
        public async Task AuthenticationTestAuthenticationKeyAccess()
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
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.That(clusterResponse.Data.Location, Is.EqualTo(DefaultLocation));
            Assert.That(clusterResponse.Data.Name, Is.EqualTo(redisEnterpriseCacheName));
            Assert.That(clusterResponse.Data.Sku.Name, Is.EqualTo(RedisEnterpriseSkuName.BalancedB1));

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
                AccessKeysAuthentication = AccessKeysAuthentication.Disabled
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse.Data.AccessKeysAuthentication, Is.EqualTo(AccessKeysAuthentication.Disabled));

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse.Data.AccessKeysAuthentication, Is.EqualTo(AccessKeysAuthentication.Disabled));

            //Enabling access keys authentication
            databaseData.AccessKeysAuthentication = AccessKeysAuthentication.Enabled;

            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse.Data.AccessKeysAuthentication, Is.EqualTo(AccessKeysAuthentication.Enabled));

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.That(databaseResponse.Data.Name, Is.EqualTo(databaseName));
            Assert.That(databaseResponse.Data.ClientProtocol, Is.EqualTo(RedisEnterpriseClientProtocol.Encrypted));
            Assert.That(databaseResponse.Data.ClusteringPolicy, Is.EqualTo(RedisEnterpriseClusteringPolicy.OssCluster));
            Assert.That(databaseResponse.Data.EvictionPolicy, Is.EqualTo(RedisEnterpriseEvictionPolicy.NoEviction));
            Assert.That(databaseResponse.Data.AccessKeysAuthentication, Is.EqualTo(AccessKeysAuthentication.Enabled));

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
