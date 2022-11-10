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
        private readonly KustoSku _sku1 = new(KustoSkuName.StandardD13V2, 2, KustoSkuTier.Basic);
        private readonly KustoSku _sku2 = new(KustoSkuName.StandardD14V2, 3, KustoSkuTier.Standard);

        public KustoClusterTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterTests()
        {
            var clusterCollection = ResourceGroup.GetKustoClusters();

            var clusterName = GenerateAssetName("sdkCluster") + "2";

            var clusterDataCreate = new KustoClusterData(TE.Location, _sku1)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };

            var clusterDataUpdate = new KustoClusterData(TE.Location, _sku2)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned)
                {
                    UserAssignedIdentities = { [TE.UserAssignedIdentityId] = new UserAssignedIdentity() }
                },
                IsDiskEncryptionEnabled = true,
                IsStreamingIngestEnabled = true,
                OptimizedAutoscale = new OptimizedAutoscale(1, true, 2, 100),
                PublicIPType = "DualStack",
                TrustedExternalTenants = { new KustoClusterTrustedExternalTenant(TE.TenantId) },
                // TODO
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

            await ClusterResourceTests(clusterCollection, clusterName);

            await DeletionTest(clusterName, clusterCollection.GetAsync, clusterCollection.ExistsAsync);
        }

        private static async Task ClusterResourceTests(KustoClusterCollection clusterCollection, string clusterName)
        {
            var cluster = (await clusterCollection.GetAsync(clusterName)).Value;

            await cluster.StopAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(KustoClusterState.Stopped, cluster.Data.State);

            await cluster.StartAsync(WaitUntil.Completed);
            cluster = await clusterCollection.GetAsync(clusterName);
            Assert.AreEqual(KustoClusterState.Running, cluster.Data.State);
        }

        private void ValidateCluster(
            string expectedFullClusterName, KustoClusterData expectedClusterData, KustoClusterData actualClusterData
        )
        {
            Assert.AreEqual(
                expectedClusterData.IsDiskEncryptionEnabled ?? false, actualClusterData.IsDiskEncryptionEnabled
            );
            Assert.AreEqual(
                expectedClusterData.IsStreamingIngestEnabled ?? false, actualClusterData.IsStreamingIngestEnabled
            );
            Assert.AreEqual(expectedFullClusterName, actualClusterData.Name);
            Assert.IsEmpty(actualClusterData.PrivateEndpointConnections);
            Assert.AreEqual(
                expectedClusterData.PublicIPType ?? KustoClusterPublicIPType.IPv4, actualClusterData.PublicIPType
            );
            Assert.AreEqual(KustoClusterState.Running, actualClusterData.State);
            Assert.IsNull(actualClusterData.VirtualClusterGraduationProperties);

            AssertEquality(expectedClusterData.Identity, actualClusterData.Identity, IdentityEquals);
            AssertEquality(
                expectedClusterData.OptimizedAutoscale, actualClusterData.OptimizedAutoscale,
                AssertOptimizedAutoscaleEquals
            );
            AssertEquality(expectedClusterData.Sku, actualClusterData.Sku, AssertSkuEquals);
            AssertEquality(
                expectedClusterData.TrustedExternalTenants, actualClusterData.TrustedExternalTenants,
                AssertTrustedExternalTenantsEquals
            );
        }

        private void IdentityEquals(ManagedServiceIdentity expected, ManagedServiceIdentity actual)
        {
            var systemAssigned = new List<ManagedServiceIdentityType>
            {
                ManagedServiceIdentityType.SystemAssigned, ManagedServiceIdentityType.SystemAssignedUserAssigned
            }.Contains(expected.ManagedServiceIdentityType);

            if (systemAssigned)
            {
                Assert.IsNotNull(actual.PrincipalId);
            }
            else
            {
                Assert.IsNull(actual.PrincipalId);
            }

            Assert.AreEqual(Guid.Parse(TE.TenantId), actual.TenantId);
            Assert.AreEqual(expected.ManagedServiceIdentityType, actual.ManagedServiceIdentityType);

            CollectionAssert.AreEqual(
                expected.UserAssignedIdentities.Keys.Select(rId => rId.ToString()).ToList(),
                actual.UserAssignedIdentities.Keys.Select(rId => rId.ToString()).ToList()
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
            Assert.AreEqual(expected.Version, actual.Version);
            Assert.AreEqual(expected.Minimum, actual.Minimum);
            Assert.AreEqual(expected.Maximum, actual.Maximum);
            Assert.AreEqual(expected.IsEnabled, actual.IsEnabled);
        }

        private static void AssertSkuEquals(KustoSku expected, KustoSku actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Capacity, actual.Capacity);
            Assert.AreEqual(expected.Tier, actual.Tier);
        }

        private static void AssertTrustedExternalTenantsEquals(
            IList<KustoClusterTrustedExternalTenant> expected, IList<KustoClusterTrustedExternalTenant> actual
        )
        {
            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(
                expected.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList(),
                actual.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList()
            );
        }

        // private static void AssertKeyVaultPropertiesEquals(
        //     KustoKeyVaultProperties keyVaultProperties1, KustoKeyVaultProperties keyVaultProperties2
        // )
        // {
        //     Assert.AreEqual(keyVaultProperties1.KeyName, keyVaultProperties2.KeyName);
        //     Assert.AreEqual(keyVaultProperties1.KeyVersion, keyVaultProperties2.KeyVersion);
        //     Assert.AreEqual(keyVaultProperties1.KeyVaultUri, keyVaultProperties2.KeyVaultUri);
        //     Assert.AreEqual(keyVaultProperties1.UserIdentity, keyVaultProperties2.UserIdentity);
        // }
    }
}
