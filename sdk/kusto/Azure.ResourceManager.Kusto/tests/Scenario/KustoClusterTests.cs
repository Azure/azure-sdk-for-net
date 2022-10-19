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
        private KustoClusterCollection _clusterCollection;

        private string _clusterName;
        private KustoClusterData _clusterDataCreate;
        private KustoClusterData _clusterDataUpdate;

        private CreateOrUpdateAsync<KustoClusterResource, KustoClusterData> _createOrUpdateClusterAsync;

        public KustoClusterTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void ClusterTestsSetup()
        {
            _clusterCollection = ResourceGroup.GetKustoClusters();

            _clusterName = Recording.GenerateAssetName("sdkTestCluster");
            _clusterDataCreate = new KustoClusterData(Location, Sku1)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                TrustedExternalTenants = { new KustoClusterTrustedExternalTenant(TestEnvironment.TenantId) }
            };
            _clusterDataUpdate = new KustoClusterData(Location, Sku2)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                TrustedExternalTenants = { new KustoClusterTrustedExternalTenant(TestEnvironment.TenantId) },
                PublicIPType = "DualStack"
            };

            _createOrUpdateClusterAsync = (clusterName, clusterData) =>
                _clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterTests()
        {
            await CollectionTests(
                _clusterName, _clusterName,
                _clusterDataCreate, _clusterDataUpdate,
                _createOrUpdateClusterAsync,
                _clusterCollection.GetAsync,
                _clusterCollection.GetAllAsync,
                _clusterCollection.ExistsAsync,
                ValidateCluster
            );

            KustoClusterResource cluster;
            bool exists;

            cluster = await _clusterCollection.GetAsync(_clusterName);

            await cluster.StopAsync(WaitUntil.Completed);
            cluster = await _clusterCollection.GetAsync(_clusterName);
            Assert.AreEqual(KustoClusterState.Stopped, cluster.Data.State);

            await cluster.StartAsync(WaitUntil.Completed);
            cluster = await _clusterCollection.GetAsync(_clusterName);
            Assert.AreEqual(KustoClusterState.Running, cluster.Data.State);

            await cluster.DeleteAsync(WaitUntil.Completed);
            exists = await _clusterCollection.ExistsAsync(_clusterName);
            Assert.IsFalse(exists);
        }

        private void ValidateCluster(
            KustoClusterResource cluster,
            string clusterName,
            KustoClusterData clusterData
        )
        {
            Assert.AreEqual(clusterName, cluster.Data.Name);
            Assert.AreEqual(clusterData.Location, cluster.Data.Location);
            AssertSkuEquality(clusterData.Sku, cluster.Data.Sku);
            AssertIdentityEquality(cluster.Data.Identity);
            Assert.AreEqual(KustoClusterState.Running, cluster.Data.State);
            AssertExternalTenantsEquality(clusterData.TrustedExternalTenants, cluster.Data.TrustedExternalTenants);
            Assert.AreEqual(clusterData.PublicIPType ?? KustoClusterPublicIPType.IPv4, cluster.Data.PublicIPType);
            Assert.IsNull(cluster.Data.VirtualClusterGraduationProperties);
            Assert.IsEmpty(cluster.Data.PrivateEndpointConnections);
        }

        private void AssertSkuEquality(KustoSku sku1, KustoSku sku2)
        {
            Assert.AreEqual(sku1.Name, sku2.Name);
            Assert.AreEqual(sku1.Capacity, sku2.Capacity);
            Assert.AreEqual(sku1.Tier, sku2.Tier);
        }

        private void AssertExternalTenantsEquality(IList<KustoClusterTrustedExternalTenant> trustedExternalTenants1,
            IList<KustoClusterTrustedExternalTenant> trustedExternalTenants2)
        {
            Assert.AreEqual(trustedExternalTenants1.Count, trustedExternalTenants2.Count);
            CollectionAssert.AreEqual(
                trustedExternalTenants1.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList(),
                trustedExternalTenants2.Select(trustedExternalTenant => trustedExternalTenant.Value).ToList());
        }

        private void AssertIdentityEquality(ManagedServiceIdentity identity)
        {
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, identity.ManagedServiceIdentityType);
            // TODO: find expected value Assert.AreEqual(Guid.Parse(___), identity.PrincipalId);
            Assert.AreEqual(Guid.Parse(TestEnvironment.TenantId), identity.TenantId);
        }
    }
}
