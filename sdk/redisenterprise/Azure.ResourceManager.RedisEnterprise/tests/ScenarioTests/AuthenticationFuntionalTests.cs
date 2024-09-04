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
                   : base(isAsync, RecordedTestMode.Record)
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
        public async Task AuthenticationTests()
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
                Zones = { "1", "2", "3" }
            };

            var clusterResponse = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisEnterpriseCacheName, data)).Value;
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
            Assert.AreEqual(2, clusterResponse.Data.Sku.Capacity);

            clusterResponse = await Collection.GetAsync(redisEnterpriseCacheName);
            Assert.AreEqual(DefaultLocation, clusterResponse.Data.Location);
            Assert.AreEqual(redisEnterpriseCacheName, clusterResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseSkuName.EnterpriseE10, clusterResponse.Data.Sku.Name);
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
                },
                AccessKeysAuthentication = AccessKeysAuthentication.Disabled
            };

            var databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(AccessKeysAuthentication.Disabled, databaseResponse.Data.AccessKeysAuthentication);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(AccessKeysAuthentication.Disabled, databaseResponse.Data.AccessKeysAuthentication);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            // Create custom access policy assignment
            AccessPolicyAssignmentCollection accessPolicyAssignmentCollection = databaseResponse.GetAccessPolicyAssignments();
            string accessPolicyAssignmentName = "accessPolicyAssignmentName1";
            AccessPolicyAssignmentData accessPolicyAssignmentData = new AccessPolicyAssignmentData()
            {
                AccessPolicyName = "default",
                UserObjectId = "6497c918-11ad-41e7-1b0f-7c518a87d0b0",
            };
            var accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.AreEqual("accessPolicyAssignmentName1", accessPolicyAssignment.Data.Name);
            Assert.AreEqual("default", accessPolicyAssignment.Data.AccessPolicyName);
            Assert.AreEqual(new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"), accessPolicyAssignment.Data.UserObjectId);

            // List access policy assignments
            var accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, accessPolicyAssignmentList.Count);

            // Update access policy assignment
            accessPolicyAssignmentData = new AccessPolicyAssignmentData()
            {
                UserObjectId = "78d700c5-ca77-4335-947e-4f823dd00e1a",
                AccessPolicyName = "default"
            };
            accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.AreEqual("aad testing app", accessPolicyAssignment.Data.UserObjectId);

            // Get access policy assignment
            accessPolicyAssignment = await accessPolicyAssignmentCollection.GetAsync(accessPolicyAssignmentName);
            Assert.AreEqual("accessPolicyAssignmentName1", accessPolicyAssignment.Data.Name);
            Assert.AreEqual("default", accessPolicyAssignment.Data.AccessPolicyName);
            Assert.AreEqual(new Guid("78d700c5-ca77-4335-947e-4f823dd00e1a"), accessPolicyAssignment.Data.UserObjectId);

            // Delete access policy assignment
            await accessPolicyAssignment.DeleteAsync(WaitUntil.Completed);
            var accessPolicyAssignmentExists = (await accessPolicyAssignmentCollection.ExistsAsync(accessPolicyAssignmentName)).Value;
            Assert.IsFalse(accessPolicyAssignmentExists);

            // List access policy assignments
            accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, accessPolicyAssignmentList.Count);

            //Enabling access keys authentication
            databaseData.AccessKeysAuthentication = AccessKeysAuthentication.Enabled;

            databaseResponse = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData)).Value;
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(AccessKeysAuthentication.Enabled, databaseResponse.Data.AccessKeysAuthentication);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

            databaseResponse = await databaseCollection.GetAsync(databaseName);
            Assert.AreEqual(databaseName, databaseResponse.Data.Name);
            Assert.AreEqual(RedisEnterpriseClientProtocol.Encrypted, databaseResponse.Data.ClientProtocol);
            Assert.AreEqual(RedisEnterpriseClusteringPolicy.OssCluster, databaseResponse.Data.ClusteringPolicy);
            Assert.AreEqual(RedisEnterpriseEvictionPolicy.NoEviction, databaseResponse.Data.EvictionPolicy);
            Assert.AreEqual(AccessKeysAuthentication.Enabled, databaseResponse.Data.AccessKeysAuthentication);
            Assert.AreEqual(3, databaseResponse.Data.Modules.Count);

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
