// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RedisEnterprise.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    [NonParallelizable]
    public class AcreToAmrMigrationFunctionalTests : RedisEnterpriseManagementTestBase
    {
        public AcreToAmrMigrationFunctionalTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task UnlinkMigratedEndpoint()
        {
            (ResourceGroupResource resourceGroup, RedisEnterpriseClusterResource target) =
                await CreateMigratedClusterAsync();

            try
            {
                Assert.IsNotEmpty(target.Data.MigratedEndpoint);

                await target.UnlinkMigratedEndpointAsync(WaitUntil.Completed);

                target = (await target.GetAsync()).Value;
                Assert.IsTrue(string.IsNullOrEmpty(target.Data.MigratedEndpoint));
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<(ResourceGroupResource ResourceGroup, RedisEnterpriseClusterResource Target)> CreateMigratedClusterAsync()
        {
            string targetName = Recording.GenerateAssetName("RedisEnterpriseTarget");
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();

            try
            {
                RedisEnterpriseClusterCollection clusters = resourceGroup.GetRedisEnterpriseClusters();
                RedisEnterpriseClusterData acreData = new(
                    DefaultLocation,
                    new RedisEnterpriseSku(RedisEnterpriseSkuName.EnterpriseE10)
                    {
                        Capacity = 2
                    })
                {
                    MinimumTlsVersion = RedisEnterpriseTlsVersion.Tls1_2,
                    PublicNetworkAccess = RedisEnterprisePublicNetworkAccess.Enabled
                };
                RedisEnterpriseClusterResource target = (await clusters.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    targetName,
                    acreData)).Value;

                RedisEnterpriseDatabaseData databaseData = new()
                {
                    ClientProtocol = RedisEnterpriseClientProtocol.Encrypted,
                    ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
                    EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                };
                await target.GetRedisEnterpriseDatabases().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    databaseData);

                RedisEnterpriseClusterPatch migrationPatch = new()
                {
                    Sku = new RedisEnterpriseSku(RedisEnterpriseSkuName.BalancedB20)
                };
                migrationPatch.Tags.Add("amr-migration-data-preserve", "false");

                target = (await target.UpdateAsync(WaitUntil.Completed, migrationPatch)).Value;
                target = (await target.GetAsync()).Value;

                Assert.AreEqual(RedisEnterpriseSkuName.BalancedB20, target.Data.Sku.Name);
                Assert.IsNotEmpty(target.Data.MigratedEndpoint);
                return (resourceGroup, target);
            }
            catch
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed);
                throw;
            }
        }
    }
}
