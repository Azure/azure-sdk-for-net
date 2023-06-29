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
    public class KustoClusterMigrationTests : KustoManagementTestBase
    {
        private readonly KustoSku _sku = new(KustoSkuName.DevNoSlaStandardE2aV4, 1, KustoSkuTier.Basic);

        public KustoClusterMigrationTests(bool isAsync)
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
        public async Task ClusterMigrationTests()
        {
            var clusterCollection = ResourceGroup.GetKustoClusters();

            var migrationClusterName = GenerateAssetName("sdkMigrationCluster");

            var clusterDataCreate = new KustoClusterData(Location, _sku);

            var migrationCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, migrationClusterName, clusterDataCreate)).Value;

            var clusterMigrationContent = new ClusterMigrateContent(Cluster.Data.Id);

            await migrationCluster.MigrateAsync(WaitUntil.Completed, clusterMigrationContent).ConfigureAwait(false);

            migrationCluster = await clusterCollection.GetAsync(migrationClusterName).ConfigureAwait(false);

            var cluster = await clusterCollection.GetAsync(migrationCluster.Data.Name).ConfigureAwait(false);
            AssertEquality(KustoClusterState.Migrated, cluster.Value.Data.State);

            await migrationCluster.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
        }
    }
}
