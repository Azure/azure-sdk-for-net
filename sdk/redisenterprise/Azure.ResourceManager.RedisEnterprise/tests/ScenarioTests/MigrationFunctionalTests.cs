// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Redis;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using RedisModels = Azure.ResourceManager.Redis.Models;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    [NonParallelizable]
    public class MigrationFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public MigrationFunctionalTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task ValidateStartAndGetMigration()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();

            string sourceName = Recording.GenerateAssetName("RedisSource");
            string targetName = Recording.GenerateAssetName("RedisEnterpriseTarget");
            RedisModels.RedisCreateOrUpdateContent sourceData = new(
                DefaultLocation,
                new RedisModels.RedisSku(
                    RedisModels.RedisSkuName.Basic,
                    RedisModels.RedisSkuFamily.BasicOrStandard,
                    0))
            {
                MinimumTlsVersion = RedisModels.RedisTlsVersion.Tls1_2,
                PublicNetworkAccess = RedisModels.RedisPublicNetworkAccess.Enabled
            };
            RedisResource source = (await resourceGroup.GetAllRedis().CreateOrUpdateAsync(
                WaitUntil.Completed,
                sourceName,
                sourceData)).Value;

            RedisEnterpriseClusterData targetData = new(
                DefaultLocation,
                new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB1))
            {
                MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                HighAvailability = RedisEnterpriseHighAvailability.Disabled,
                PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
            };
            RedisEnterpriseClusterResource target = (await resourceGroup.GetRedisEnterpriseClusters().CreateOrUpdateAsync(
                WaitUntil.Completed,
                targetName,
                targetData)).Value;
            RedisEnterpriseDatabaseData databaseData = new()
            {
                ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                ClusteringPolicy = RedisEnterpriseClusteringPolicy.NoCluster,
                EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                NotifyKeyspaceEvents = string.Empty
            };
            await target.GetRedisEnterpriseDatabases().CreateOrUpdateAsync(
                WaitUntil.Completed,
                "default",
                databaseData);

            RedisEnterpriseMigrationResource migration = target.GetRedisEnterpriseMigration();
            RedisEnterpriseMigrationValidationRequestContent validationContent = new(source.Id)
            {
                IsSkipDataMigration = true
            };
            RedisEnterpriseMigrationValidationResponseResult validation = (await migration.ValidateAsync(validationContent)).Value;
            Assert.IsTrue(validation.IsValid);
            foreach (RedisEnterpriseMigrationValidationError error in validation.Errors)
            {
                Assert.IsEmpty(error.Disparities);
            }

            RedisEnterpriseMigrationData migrationData = new()
            {
                Properties = new AzureCacheForRedisMigrationProperties(source.Id, true, true)
                {
                    IsForceMigrate = true
                }
            };
            migration = (await migration.CreateOrUpdateAsync(WaitUntil.Completed, migrationData)).Value;

            Assert.AreEqual(source.Id, ((AzureCacheForRedisMigrationProperties)migration.Data.Properties).SourceResourceId);
            Assert.AreEqual(target.Id, migration.Data.Properties.TargetResourceId);
            Assert.AreEqual(RedisEnterpriseMigrationProvisioningState.Succeeded, migration.Data.Properties.ProvisioningState);

            migration = (await migration.GetAsync()).Value;
            Assert.AreEqual(source.Id, ((AzureCacheForRedisMigrationProperties)migration.Data.Properties).SourceResourceId);
            Assert.AreEqual(target.Id, migration.Data.Properties.TargetResourceId);
            Assert.AreEqual(RedisEnterpriseMigrationProvisioningState.Succeeded, migration.Data.Properties.ProvisioningState);

            await resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
