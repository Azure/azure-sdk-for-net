// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoClusterTests : KustoManagementTestBase
    {
        private readonly KustoSku _sku = new(KustoSkuName.StandardE2aV4, 2, KustoSkuTier.Standard, null);

        public KustoClusterTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        // TODO break this up into smaller tests

        [TestCase]
        [RecordedTest]
        public async Task ClusterTests()
        {
            var clusterCollection = ResourceGroup.GetKustoClusters();

            var clusterName = GenerateAssetName("sdkCluster");

            var clusterDataCreate = new KustoClusterData(Location, _sku) {Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned), IsStreamingIngestEnabled = true};

            var clusterDataUpdate = new KustoClusterData(Location, _sku)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned) {UserAssignedIdentities = {[TE.UserAssignedIdentityId] = new UserAssignedIdentity()}},
                IsDiskEncryptionEnabled = true,
                IsStreamingIngestEnabled = false,
                OptimizedAutoscale = new OptimizedAutoscale(1, true, 2, 5),
                PublicIPType = "DualStack",
                TrustedExternalTenants = {new KustoClusterTrustedExternalTenant(TE.TenantId, null)},
                // TODO: figure out how to authenticate
                // KeyVaultProperties = new KustoKeyVaultProperties(
                //     TE.KeyName,
                //     TE.KeyVersion,
                //     TE.KeyVaultUri,
                //     default
                // )
            };

            async Task<ArmOperation<KustoClusterResource>> CreateOrUpdateClusterAsync(
                string clusterName, KustoClusterData clusterData
            ) => await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);

            await CollectionTests(
                clusterName,
                clusterName,
                clusterDataCreate,
                clusterDataUpdate,
                CreateOrUpdateClusterAsync,
                clusterCollection.GetAsync,
                clusterCollection.GetAllAsync,
                clusterCollection.ExistsAsync,
                ValidateCluster
            );

            await ClusterStopStartTests(clusterCollection, clusterName);

            await ClusterMigrationTests(clusterCollection, clusterName);

            await DeletionTest(clusterName, clusterCollection.GetAsync, clusterCollection.ExistsAsync);
        }

        private static async Task ClusterStopStartTests(KustoClusterCollection clusterCollection, string clusterName)
        {
            var cluster = (await clusterCollection.GetAsync(clusterName)).Value;

            await cluster.StopAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(clusterName);
            AssertEquality(KustoClusterState.Stopped, cluster.Data.State);

            await cluster.StartAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(clusterName);
            AssertEquality(KustoClusterState.Running, cluster.Data.State);
        }

        private async Task ClusterMigrationTests(KustoClusterCollection clusterCollection, string clusterName)
        {
            var cluster = (await clusterCollection.GetAsync(clusterName)).Value;

            var databaseName = GenerateAssetName("MgrDatabase");
            var databaseData = new KustoReadWriteDatabase {Location = Location, HotCachePeriod = TimeSpan.FromDays(2), SoftDeletePeriod = TimeSpan.FromDays(3)};
            var databaseCollection = cluster.GetKustoDatabases();
            await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

            var destinationCluster = (await ResourceGroup.GetKustoClusterAsync(TE.ClusterName)).Value;

            var clusterMigrationContent = new ClusterMigrateContent(destinationCluster.Data.Id);
            await cluster.MigrateAsync(WaitUntil.Completed, clusterMigrationContent).ConfigureAwait(false);

            cluster = await clusterCollection.GetAsync(clusterName).ConfigureAwait(false);
            AssertEquality(KustoClusterState.Migrated, cluster.Data.State);
        }

        private void ValidateCluster(
            string expectedFullClusterName, KustoClusterData expectedClusterData, KustoClusterData actualClusterData
        )
        {
            AssertEquality(
                expectedClusterData.IsDiskEncryptionEnabled ?? false, actualClusterData.IsDiskEncryptionEnabled
            );
            AssertEquality(
                expectedClusterData.IsStreamingIngestEnabled ?? false, actualClusterData.IsStreamingIngestEnabled
            );
            AssertEquality(expectedClusterData.Location, actualClusterData.Location);
            AssertEquality(expectedFullClusterName, actualClusterData.Name);
            AssertEquality(
                expectedClusterData.PublicIPType ?? KustoClusterPublicIPType.IPv4, actualClusterData.PublicIPType
            );
            AssertEquality(KustoClusterState.Running, actualClusterData.State);
            Assert.IsNull(actualClusterData.VirtualClusterGraduationProperties);

            AssertEquality(expectedClusterData.Identity, actualClusterData.Identity, IdentityEquals);
            AssertEquality(
                expectedClusterData.OptimizedAutoscale, actualClusterData.OptimizedAutoscale,
                AssertOptimizedAutoscaleEquals
            );
            AssertEquality(expectedClusterData.Sku, actualClusterData.Sku, AssertSkuEquals);
            AssertEquality(KustoClusterState.Running, actualClusterData.State);
            AssertEquality(
                expectedClusterData.TrustedExternalTenants, actualClusterData.TrustedExternalTenants,
                AssertTrustedExternalTenantsEquals
            );
        }

        private void IdentityEquals(ManagedServiceIdentity expected, ManagedServiceIdentity actual)
        {
            var systemAssigned = new List<ManagedServiceIdentityType> {ManagedServiceIdentityType.SystemAssigned, ManagedServiceIdentityType.SystemAssignedUserAssigned}.Contains(expected.ManagedServiceIdentityType);

            if (systemAssigned)
            {
                Assert.IsNotNull(actual.PrincipalId);
            }
            else
            {
                Assert.IsNull(actual.PrincipalId);
            }

            AssertEquality(Guid.Parse(TE.TenantId), actual.TenantId);
            AssertEquality(expected.ManagedServiceIdentityType, actual.ManagedServiceIdentityType);

            CollectionAssert.AreEqual(
                expected.UserAssignedIdentities.Keys.Select(rId => rId.ToString().ToLower()).ToList(),
                actual.UserAssignedIdentities.Keys.Select(rId => rId.ToString().ToLower()).ToList()
            );
            CollectionAssert.AllItemsAreNotNull(
                actual.UserAssignedIdentities.Values.Select(identity => identity.ClientId)
            );
            CollectionAssert.AllItemsAreNotNull(
                actual.UserAssignedIdentities.Values.Select(identity => identity.PrincipalId)
            );
        }

        private static void AssertOptimizedAutoscaleEquals(OptimizedAutoscale expected, OptimizedAutoscale actual)
        {
            AssertEquality(expected.Version, actual.Version);
            AssertEquality(expected.Minimum, actual.Minimum);
            AssertEquality(expected.Maximum, actual.Maximum);
            AssertEquality(expected.IsEnabled, actual.IsEnabled);
        }

        private static void AssertSkuEquals(KustoSku expected, KustoSku actual)
        {
            AssertEquality(expected.Name, actual.Name);
            AssertEquality(expected.Capacity, actual.Capacity);
            AssertEquality(expected.Tier, actual.Tier);
        }

        private static void AssertTrustedExternalTenantsEquals(
            IList<KustoClusterTrustedExternalTenant> expected, IList<KustoClusterTrustedExternalTenant> actual
        )
        {
            AssertEquality(expected.Count, actual.Count);
            CollectionAssert.AreEqual(
                expected.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList(),
                actual.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList()
            );
        }

        // TODO: figure out how to authenticate
        // private static void AssertKeyVaultPropertiesEquals(
        //     KustoKeyVaultProperties keyVaultProperties1, KustoKeyVaultProperties keyVaultProperties2
        // )
        // {
        //     AssertEquality(keyVaultProperties1.KeyName, keyVaultProperties2.KeyName);
        //     AssertEquality(keyVaultProperties1.KeyVersion, keyVaultProperties2.KeyVersion);
        //     AssertEquality(keyVaultProperties1.KeyVaultUri, keyVaultProperties2.KeyVaultUri);
        //     AssertEquality(keyVaultProperties1.UserIdentity, keyVaultProperties2.UserIdentity);
        // }
    }
}
