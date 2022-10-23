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
        public KustoClusterTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterTests()
        {
            var clusterCollection = ResourceGroup.GetKustoClusters();
            var clusterIdentity = ClusterData.Identity;
            var userAssignedIdentityResourceId = clusterIdentity.UserAssignedIdentities.Keys.First().ToString();
            var clusterDataUpdate = new KustoClusterData(KustoTestUtils.Location, KustoTestUtils.Sku2)
            {
                Identity = clusterIdentity,
                TrustedExternalTenants = { new KustoClusterTrustedExternalTenant(TestEnvironment.TenantId) },
                OptimizedAutoscale = new OptimizedAutoscale(1, true, 2, 100),
                IsDiskEncryptionEnabled = true,
                IsStreamingIngestEnabled = true,
                // KeyVaultProperties = new KustoKeyVaultProperties(
                //     "clientstestkv",
                //     "6fd57d53ad6b4b53bacb062c98c761a0",
                //     new Uri("https://clientstestkv.vault.azure.net/"),
                //     userAssignedIdentityResourceId
                // ),
                PublicIPType = "DualStack"
            };

            Task<ArmOperation<KustoClusterResource>> CreateOrUpdateClusterAsync(string clusterName,
                KustoClusterData clusterData) =>
                clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);

            await CollectionTests(
                ClusterName,
                ClusterData, clusterDataUpdate,
                CreateOrUpdateClusterAsync,
                clusterCollection.GetAsync,
                clusterCollection.GetAllAsync,
                clusterCollection.ExistsAsync,
                ValidateCluster,
                resource: Cluster
            );

            var cluster = (await clusterCollection.GetAsync(ClusterName)).Value;
            await cluster.StopAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(ClusterName);
            // Assert.AreEqual(KustoClusterState.Stopped, cluster.Data.State);
            await cluster.StartAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(ClusterName);
            // Assert.AreEqual(KustoClusterState.Running, cluster.Data.State);

            await DeletionTest(ClusterName, clusterCollection.GetAsync, clusterCollection.ExistsAsync);
        }

        private void ValidateCluster(
            KustoClusterResource cluster,
            string clusterName,
            KustoClusterData clusterData
        )
        {
            Assert.IsNotNull(cluster);
            Assert.IsNotNull(cluster.Data);
            Assert.AreEqual(clusterName, cluster.Data.Name);
            AssertSkuEquality(clusterData.Sku, cluster.Data.Sku);
            AssertIdentityEquality(clusterData.Identity, cluster.Data.Identity);
            Assert.AreEqual(KustoClusterState.Running, cluster.Data.State);
            AssertExternalTenantsEquality(
                clusterData.TrustedExternalTenants ?? new List<KustoClusterTrustedExternalTenant>(),
                cluster.Data.TrustedExternalTenants);
            AssertOptimizedAutoscaleEquality(clusterData.OptimizedAutoscale, cluster.Data.OptimizedAutoscale);
            Assert.AreEqual(clusterData.IsDiskEncryptionEnabled ?? false, cluster.Data.IsDiskEncryptionEnabled);
            Assert.AreEqual(clusterData.IsStreamingIngestEnabled ?? false, cluster.Data.IsStreamingIngestEnabled);
            AssertKeyVaultPropertiesEquality(clusterData.KeyVaultProperties, cluster.Data.KeyVaultProperties);
            Assert.AreEqual(clusterData.PublicIPType ?? KustoClusterPublicIPType.IPv4, cluster.Data.PublicIPType);
        }

        private void AssertIdentityEquality(ManagedServiceIdentity identity1, ManagedServiceIdentity identity2)
        {
            // Assert.IsNotNull(identity2?.PrincipalId);
            // Assert.AreEqual(Guid.Parse(TestEnvironment.TenantId), identity2?.TenantId);
            CollectionAssert.AreEqual(
                identity1?.UserAssignedIdentities?.Keys.Select(resourceId => resourceId.ToString()).ToList(),
                identity2?.UserAssignedIdentities?.Keys.Select(resourceId => resourceId.ToString()).ToList()
            );
            Assert.AreEqual(identity1?.ManagedServiceIdentityType, identity2?.ManagedServiceIdentityType);
        }

        private void AssertSkuEquality(KustoSku sku1, KustoSku sku2)
        {
            Assert.AreEqual(sku1?.Name, sku2?.Name);
            Assert.AreEqual(sku1?.Capacity, sku2?.Capacity);
            Assert.AreEqual(sku1?.Tier, sku2?.Tier);
        }

        private void AssertExternalTenantsEquality(IList<KustoClusterTrustedExternalTenant> trustedExternalTenants1,
            IList<KustoClusterTrustedExternalTenant> trustedExternalTenants2)
        {
            Assert.AreEqual(trustedExternalTenants1?.Count, trustedExternalTenants2?.Count);
            CollectionAssert.AreEqual(
                trustedExternalTenants1?.Select(trustedExternalTenant => trustedExternalTenant?.Value).ToList(),
                trustedExternalTenants2?.Select(trustedExternalTenant => trustedExternalTenant?.Value).ToList());
        }

        private void AssertOptimizedAutoscaleEquality(OptimizedAutoscale optimizedAutoscale1,
            OptimizedAutoscale optimizedAutoscale2)
        {
            Assert.AreEqual(optimizedAutoscale1?.Version, optimizedAutoscale2?.Version);
            Assert.AreEqual(optimizedAutoscale1?.Minimum, optimizedAutoscale2?.Minimum);
            Assert.AreEqual(optimizedAutoscale1?.Maximum, optimizedAutoscale2?.Maximum);
            Assert.AreEqual(optimizedAutoscale1?.IsEnabled, optimizedAutoscale2?.IsEnabled);
        }

        private void AssertKeyVaultPropertiesEquality(KustoKeyVaultProperties keyVaultProperties1,
            KustoKeyVaultProperties keyVaultProperties2)
        {
            Assert.AreEqual(keyVaultProperties1?.KeyName, keyVaultProperties2?.KeyName);
            Assert.AreEqual(keyVaultProperties1?.KeyVersion, keyVaultProperties2?.KeyVersion);
            Assert.AreEqual(keyVaultProperties1?.KeyVaultUri, keyVaultProperties2?.KeyVaultUri);
            Assert.AreEqual(keyVaultProperties1?.UserIdentity, keyVaultProperties2?.UserIdentity);
        }
    }
}
