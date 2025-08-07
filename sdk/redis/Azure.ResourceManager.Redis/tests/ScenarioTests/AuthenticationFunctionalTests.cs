// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Redis.Tests.ScenarioTests
{
    public class AuthenticationFunctionalTests : RedisManagementTestBase
    {
        private ResourceGroupResource ResourceGroup { get; set; }
        private RedisCollection Collection { get; set; }
        public AuthenticationFunctionalTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            Collection = ResourceGroup.GetAllRedis();
        }
        [Test]
        public async Task AadTests()
        {
            // Create aad enabled cache with access keys authentication disabled
            await SetCollectionsAsync();
            string redisCacheName = Recording.GenerateAssetName("AuthenticationTestCache");
            RedisCreateOrUpdateContent redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation,
            new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                IsAccessKeyAuthenticationDisabled = true,
                RedisConfiguration = new RedisCommonConfiguration()
                {
                    IsAadEnabled = "true"
                }
            };
            RedisResource redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;

            // Verify cache is aad enabled and access keys authentication disabled
            Assert.IsTrue(string.Equals(redisResource.Data.RedisConfiguration.IsAadEnabled, "true", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(redisResource.Data.IsAccessKeyAuthenticationDisabled);

            // List access polices
            RedisCacheAccessPolicyCollection accessPolicyCollection = redisResource.GetRedisCacheAccessPolicies();
            var accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, accessPolicyList.Count);

            // Create custom access policy
            string accessPolicyName = "accessPolicy1";
            RedisCacheAccessPolicyData accessPolicyData = new RedisCacheAccessPolicyData()
            {
                Permissions = "+get +hget",
            };
            var accessPolicy = (await accessPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyName, accessPolicyData)).Value;
            Assert.AreEqual("accessPolicy1", accessPolicy.Data.Name);
            Assert.AreEqual("+get +hget allkeys", accessPolicy.Data.Permissions);

            // List access polices
            accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(4, accessPolicyList.Count);

            // Update access policy
            accessPolicyData = new RedisCacheAccessPolicyData()
            {
                Permissions = "+get",
            };
            accessPolicy = (await accessPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyName, accessPolicyData)).Value;
            Assert.AreEqual("accessPolicy1", accessPolicy.Data.Name);
            Assert.AreEqual("+get allkeys", accessPolicy.Data.Permissions);

            // Get access policy
            accessPolicy = await accessPolicyCollection.GetAsync(accessPolicyName);
            Assert.AreEqual("accessPolicy1", accessPolicy.Data.Name);
            Assert.AreEqual("+get allkeys", accessPolicy.Data.Permissions);

            // Create custom access policy assignment
            RedisCacheAccessPolicyAssignmentCollection accessPolicyAssignmentCollection = redisResource.GetRedisCacheAccessPolicyAssignments();
            string accessPolicyAssignmentName = "accessPolicyAssignmentName1";
            RedisCacheAccessPolicyAssignmentData accessPolicyAssignmentData = new RedisCacheAccessPolicyAssignmentData()
            {
                ObjectId = new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"),
                ObjectIdAlias = "kj-aad-testing",
                AccessPolicyName = "accessPolicy1"
            };
            var accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.AreEqual("accessPolicyAssignmentName1", accessPolicyAssignment.Data.Name);
            Assert.AreEqual("accessPolicy1", accessPolicyAssignment.Data.AccessPolicyName);
            Assert.AreEqual(new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"), accessPolicyAssignment.Data.ObjectId);
            Assert.AreEqual("kj-aad-testing", accessPolicyAssignment.Data.ObjectIdAlias);

            // List access policy assignments
            var accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, accessPolicyAssignmentList.Count);

            // Update access policy assignment
            accessPolicyAssignmentData = new RedisCacheAccessPolicyAssignmentData()
            {
                ObjectId = new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"),
                ObjectIdAlias = "aad testing app",
                AccessPolicyName = "accessPolicy1"
            };
            accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.AreEqual("aad testing app", accessPolicyAssignment.Data.ObjectIdAlias);

            // Get access policy assignment
            accessPolicyAssignment = await accessPolicyAssignmentCollection.GetAsync(accessPolicyAssignmentName);
            Assert.AreEqual("accessPolicyAssignmentName1", accessPolicyAssignment.Data.Name);
            Assert.AreEqual("accessPolicy1", accessPolicyAssignment.Data.AccessPolicyName);
            Assert.AreEqual(new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"), accessPolicyAssignment.Data.ObjectId);
            Assert.AreEqual("aad testing app", accessPolicyAssignment.Data.ObjectIdAlias);

            // Delete access policy assignment
            await accessPolicyAssignment.DeleteAsync(WaitUntil.Completed);
            var accessPolicyAssignmentExists = (await accessPolicyCollection.ExistsAsync(accessPolicyAssignmentName)).Value;
            Assert.IsFalse(accessPolicyAssignmentExists);

            // List access policy assignments
            accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, accessPolicyAssignmentList.Count);

            // Delete access policy
            await accessPolicy.DeleteAsync(WaitUntil.Completed);
            var accessPolicyExists = (await accessPolicyCollection.ExistsAsync(accessPolicyName)).Value;
            Assert.IsFalse(accessPolicyExists);

            // List access polices
            accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, accessPolicyList.Count);

            // Enable access keys authentication on cache
            redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                IsAccessKeyAuthenticationDisabled = false
            };
            redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;

            // Verify access keys authentication is enabled
            Assert.IsFalse(redisResource.Data.IsAccessKeyAuthenticationDisabled);

            // Disable aad on cache
            redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                RedisConfiguration = new RedisCommonConfiguration()
                {
                    IsAadEnabled = "false"
                }
            };
            redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;

            // Verify cache is aad disabled
            Assert.IsTrue(string.Equals(redisResource.Data.RedisConfiguration.IsAadEnabled, "false", StringComparison.OrdinalIgnoreCase));
        }
    }
}
