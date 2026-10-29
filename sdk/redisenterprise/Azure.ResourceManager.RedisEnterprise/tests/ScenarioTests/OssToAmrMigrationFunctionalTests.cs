// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
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
    public class OssToAmrMigrationFunctionalTests : RedisEnterpriseManagementTestBase
    {
        private AzureLocation OssMigrationLocation => new("centralindia");

        public OssToAmrMigrationFunctionalTests(bool isAsync)
            : base(isAsync)
        {
            // Package and project references differ on Accept for bodyless Redis DELETE requests.
            LegacyExcludedHeaders.Add("Accept");
        }

        [TestCase(true)]
        public async Task ValidateStartAndGetMigration(bool skipDataMigration)
        {
            (ResourceGroupResource resourceGroup, RedisResource source, RedisEnterpriseClusterResource target, RedisEnterpriseMigrationResource migration) =
                await CreateCompletedMigrationAsync(skipDataMigration);

            try
            {
                AzureCacheForRedisMigrationProperties startProperties = GetAzureCacheForRedisProperties(migration);
                Assert.IsTrue(startProperties.IsSwitchDns);
                Assert.AreEqual(skipDataMigration, startProperties.IsSkipDataMigration);
                AssertPersistedMigrationState(
                    migration,
                    source.Id,
                    target.Id,
                    RedisEnterpriseMigrationProvisioningState.Succeeded,
                    expectRollbackEligibility: true);

                migration = (await migration.GetAsync()).Value;
                AssertPersistedMigrationState(
                    migration,
                    source.Id,
                    target.Id,
                    RedisEnterpriseMigrationProvisioningState.Succeeded,
                    expectRollbackEligibility: true);
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task UndoMigrationWithRollbackReason()
        {
            (ResourceGroupResource resourceGroup, RedisResource source, RedisEnterpriseClusterResource target, RedisEnterpriseMigrationResource migration) =
                await CreateCompletedMigrationAsync();

            try
            {
                await migration.UndoAsync(
                    WaitUntil.Completed,
                    new RedisEnterpriseMigrationUndoContent
                    {
                        RollbackReason = RedisEnterpriseMigrationRollbackReason.Testing
                    });

                migration = (await migration.GetAsync()).Value;
                AssertPersistedMigrationState(
                    migration,
                    source.Id,
                    target.Id,
                    RedisEnterpriseMigrationProvisioningState.Cancelled,
                    expectRollbackEligibility: false);
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task UnlinkMigratedEndpointAndRejectClusterRoute()
        {
            (ResourceGroupResource resourceGroup, RedisResource source, RedisEnterpriseClusterResource target, RedisEnterpriseMigrationResource migration) =
                await CreateCompletedMigrationAsync();

            try
            {
                RequestFailedException sourceExistsException = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await migration.UnlinkMigratedEndpointAsync(WaitUntil.Completed));
                Assert.AreEqual(400, sourceExistsException.Status);
                Assert.AreEqual("BadRequest", sourceExistsException.ErrorCode);

                RequestFailedException wrongRouteException = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await target.UnlinkMigratedEndpointAsync(WaitUntil.Completed));
                Assert.AreEqual(400, wrongRouteException.Status);
                Assert.AreEqual("BadRequest", wrongRouteException.ErrorCode);

                await source.DeleteAsync(WaitUntil.Completed);
                await migration.UnlinkMigratedEndpointAsync(WaitUntil.Completed);

                migration = (await migration.GetAsync()).Value;
                AssertUnlinkedMigrationState(migration, target.Id);
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<(ResourceGroupResource ResourceGroup, RedisResource Source, RedisEnterpriseClusterResource Target, RedisEnterpriseMigrationResource Migration)> CreateCompletedMigrationAsync()
        {
            return await CreateCompletedMigrationAsync(skipDataMigration: true);
        }

        private async Task<(ResourceGroupResource ResourceGroup, RedisResource Source, RedisEnterpriseClusterResource Target, RedisEnterpriseMigrationResource Migration)> CreateCompletedMigrationAsync(
            bool skipDataMigration)
        {
            string sourceName = Recording.GenerateAssetName("RedisSource");
            string targetName = Recording.GenerateAssetName("RedisEnterpriseTarget");
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync(OssMigrationLocation);

            try
            {
                RedisModels.RedisCreateOrUpdateContent sourceData = new(
                    OssMigrationLocation,
                    new RedisModels.RedisSku(
                        RedisModels.RedisSkuName.Basic,
                        RedisModels.RedisSkuFamily.BasicOrStandard,
                        0))
                {
                    MinimumTlsVersion = RedisModels.RedisTlsVersion.Tls1_2,
                    PublicNetworkAccess = RedisModels.RedisPublicNetworkAccess.Enabled
                };
                await resourceGroup.GetAllRedis().CreateOrUpdateAsync(
                    WaitUntil.Started,
                    sourceName,
                    sourceData);
                RedisResource source = Client.GetRedisResource(RedisResource.CreateResourceIdentifier(
                    resourceGroup.Id.SubscriptionId,
                    resourceGroup.Id.Name,
                    sourceName));
                for (int attempt = 0; attempt < 60; attempt++)
                {
                    source = (await source.GetAsync()).Value;
                    string provisioningState = source.Data.ProvisioningState?.ToString();
                    if (string.Equals(provisioningState, "Succeeded", System.StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    if (string.Equals(provisioningState, "Failed", System.StringComparison.OrdinalIgnoreCase))
                    {
                        throw new System.InvalidOperationException(
                            $"OSS source {sourceName} provisioning failed.");
                    }

                    await Delay(60_000);
                }

                if (source.Data.ProvisioningState != RedisModels.RedisProvisioningState.Succeeded)
                {
                    throw new System.TimeoutException(
                        $"OSS source {sourceName} did not finish provisioning within 60 minutes. Last state: {source.Data.ProvisioningState}.");
                }

                RedisEnterpriseClusterData targetData = new(
                    OssMigrationLocation,
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
                    EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction
                };
                await target.GetRedisEnterpriseDatabases().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    databaseData);

                RedisEnterpriseMigrationResource migration = target.GetRedisEnterpriseMigration();
                RedisEnterpriseMigrationValidationRequestContent validationContent = new(source.Id)
                {
                    IsSkipDataMigration = skipDataMigration
                };
                RedisEnterpriseMigrationValidationResponseResult validation = (await migration.ValidateAsync(validationContent)).Value;
                Assert.IsTrue(validation.IsValid);
                Assert.AreEqual(1, validation.Errors.Count);
                Assert.IsEmpty(validation.Errors[0].Disparities);
                Assert.AreEqual(1, validation.Warnings.Count);
                Assert.IsEmpty(validation.Warnings[0].Disparities);

                RedisEnterpriseMigrationData migrationData = new()
                {
                    Properties = new AzureCacheForRedisMigrationProperties(source.Id, true, skipDataMigration)
                    {
                        IsForceMigrate = true
                    }
                };
                migration = (await migration.CreateOrUpdateAsync(WaitUntil.Completed, migrationData)).Value;

                return (resourceGroup, source, target, migration);
            }
            catch
            {
                try
                {
                    await resourceGroup.DeleteAsync(WaitUntil.Started);
                }
                catch (RequestFailedException cleanupException)
                {
                    TestContext.Progress.WriteLine(
                        $"Deferred cleanup for {resourceGroup.Id}: {cleanupException.ErrorCode}: {cleanupException.Message}");
                }

                throw;
            }
        }

        private static void AssertPersistedMigrationState(
            RedisEnterpriseMigrationResource migration,
            ResourceIdentifier sourceId,
            ResourceIdentifier targetId,
            RedisEnterpriseMigrationProvisioningState expectedState,
            bool expectRollbackEligibility)
        {
            AzureCacheForRedisMigrationProperties properties = GetAzureCacheForRedisProperties(migration);
            Assert.AreEqual(sourceId, properties.SourceResourceId);
            Assert.AreEqual(targetId, properties.TargetResourceId);
            Assert.AreEqual(expectedState, properties.ProvisioningState);
            AssertMigrationTimestamps(properties);

            if (expectRollbackEligibility)
            {
                Assert.IsNotNull(properties.RollbackEligibilityExpiresOn);
                Assert.Greater(properties.RollbackEligibilityExpiresOn.Value, properties.LastModifiedOn.Value);
            }
            else
            {
                Assert.IsNull(properties.RollbackEligibilityExpiresOn);
            }
        }

        private static void AssertUnlinkedMigrationState(
            RedisEnterpriseMigrationResource migration,
            ResourceIdentifier targetId)
        {
            AzureCacheForRedisMigrationProperties properties = GetAzureCacheForRedisProperties(migration);
            Assert.AreEqual(targetId, properties.TargetResourceId);
            Assert.AreEqual(RedisEnterpriseMigrationProvisioningState.Unlinked, properties.ProvisioningState);
            AssertMigrationTimestamps(properties);
            Assert.IsNull(properties.RollbackEligibilityExpiresOn);
        }

        private static AzureCacheForRedisMigrationProperties GetAzureCacheForRedisProperties(RedisEnterpriseMigrationResource migration)
        {
            AzureCacheForRedisMigrationProperties properties = migration.Data.Properties as AzureCacheForRedisMigrationProperties;
            Assert.IsNotNull(properties);
            return properties;
        }

        private static void AssertMigrationTimestamps(AzureCacheForRedisMigrationProperties properties)
        {
            Assert.IsNotNull(properties.CreatedOn);
            Assert.IsNotNull(properties.LastModifiedOn);
            Assert.GreaterOrEqual(properties.LastModifiedOn.Value, properties.CreatedOn.Value);
        }
    }
}
