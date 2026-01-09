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

            Assert.Multiple(() =>
            {
                // Verify cache is aad enabled and access keys authentication disabled
                Assert.That(string.Equals(redisResource.Data.RedisConfiguration.IsAadEnabled, "true", StringComparison.OrdinalIgnoreCase), Is.True);
                Assert.That(redisResource.Data.IsAccessKeyAuthenticationDisabled, Is.True);
            });

            // List access polices
            RedisCacheAccessPolicyCollection accessPolicyCollection = redisResource.GetRedisCacheAccessPolicies();
            var accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyList, Has.Count.EqualTo(3));

            // Create custom access policy
            string accessPolicyName = "accessPolicy1";
            RedisCacheAccessPolicyData accessPolicyData = new RedisCacheAccessPolicyData()
            {
                Permissions = "+get +hget",
            };
            var accessPolicy = (await accessPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyName, accessPolicyData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(accessPolicy.Data.Name, Is.EqualTo("accessPolicy1"));
                Assert.That(accessPolicy.Data.Permissions, Is.EqualTo("+get +hget allkeys"));
            });

            // List access polices
            accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyList, Has.Count.EqualTo(4));

            // Update access policy
            accessPolicyData = new RedisCacheAccessPolicyData()
            {
                Permissions = "+get",
            };
            accessPolicy = (await accessPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyName, accessPolicyData)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(accessPolicy.Data.Name, Is.EqualTo("accessPolicy1"));
                Assert.That(accessPolicy.Data.Permissions, Is.EqualTo("+get allkeys"));
            });

            // Get access policy
            accessPolicy = await accessPolicyCollection.GetAsync(accessPolicyName);
            Assert.Multiple(() =>
            {
                Assert.That(accessPolicy.Data.Name, Is.EqualTo("accessPolicy1"));
                Assert.That(accessPolicy.Data.Permissions, Is.EqualTo("+get allkeys"));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(accessPolicyAssignment.Data.Name, Is.EqualTo("accessPolicyAssignmentName1"));
                Assert.That(accessPolicyAssignment.Data.AccessPolicyName, Is.EqualTo("accessPolicy1"));
                Assert.That(accessPolicyAssignment.Data.ObjectId, Is.EqualTo(new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a")));
                Assert.That(accessPolicyAssignment.Data.ObjectIdAlias, Is.EqualTo("kj-aad-testing"));
            });

            // List access policy assignments
            var accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyAssignmentList, Has.Count.EqualTo(1));

            // Update access policy assignment
            accessPolicyAssignmentData = new RedisCacheAccessPolicyAssignmentData()
            {
                ObjectId = new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a"),
                ObjectIdAlias = "aad testing app",
                AccessPolicyName = "accessPolicy1"
            };
            accessPolicyAssignment = (await accessPolicyAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, accessPolicyAssignmentName, accessPolicyAssignmentData)).Value;
            Assert.That(accessPolicyAssignment.Data.ObjectIdAlias, Is.EqualTo("aad testing app"));

            // Get access policy assignment
            accessPolicyAssignment = await accessPolicyAssignmentCollection.GetAsync(accessPolicyAssignmentName);
            Assert.Multiple(() =>
            {
                Assert.That(accessPolicyAssignment.Data.Name, Is.EqualTo("accessPolicyAssignmentName1"));
                Assert.That(accessPolicyAssignment.Data.AccessPolicyName, Is.EqualTo("accessPolicy1"));
                Assert.That(accessPolicyAssignment.Data.ObjectId, Is.EqualTo(new Guid("69d700c5-ca77-4335-947e-4f823dd00e1a")));
                Assert.That(accessPolicyAssignment.Data.ObjectIdAlias, Is.EqualTo("aad testing app"));
            });

            // Delete access policy assignment
            await accessPolicyAssignment.DeleteAsync(WaitUntil.Completed);
            var accessPolicyAssignmentExists = (await accessPolicyCollection.ExistsAsync(accessPolicyAssignmentName)).Value;
            Assert.That(accessPolicyAssignmentExists, Is.False);

            // List access policy assignments
            accessPolicyAssignmentList = await accessPolicyAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyAssignmentList.Count, Is.EqualTo(0));

            // Delete access policy
            await accessPolicy.DeleteAsync(WaitUntil.Completed);
            var accessPolicyExists = (await accessPolicyCollection.ExistsAsync(accessPolicyName)).Value;
            Assert.That(accessPolicyExists, Is.False);

            // List access polices
            accessPolicyList = await accessPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(accessPolicyList, Has.Count.EqualTo(3));

            // Enable access keys authentication on cache
            redisCreationParameters = new RedisCreateOrUpdateContent(DefaultLocation, new RedisSku(RedisSkuName.Premium, RedisSkuFamily.Premium, 1))
            {
                IsAccessKeyAuthenticationDisabled = false
            };
            redisResource = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, redisCacheName, redisCreationParameters)).Value;

            // Verify access keys authentication is enabled
            Assert.That(redisResource.Data.IsAccessKeyAuthenticationDisabled, Is.False);

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
            Assert.That(string.Equals(redisResource.Data.RedisConfiguration.IsAadEnabled, "false", StringComparison.OrdinalIgnoreCase), Is.True);
        }
    }
}
