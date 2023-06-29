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
        private KustoClusterResource MigrationCluster { get; set; }
        private KustoClusterResource DestinationCluster { get; set; }

        public KustoClusterMigrationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();

            MigrationCluster = (await ResourceGroup.GetKustoClusterAsync(TE.MigrationClusterName)).Value;
            DestinationCluster = (await ResourceGroup.GetKustoClusterAsync(TE.ClusterName)).Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task ClusterTests()
        {
            var clusterCollection = ResourceGroup.GetKustoClusters();
            var clusterMigrationContent = new ClusterMigrateContent(DestinationCluster.Data.Id);

            await MigrationCluster.MigrateAsync(WaitUntil.Completed, clusterMigrationContent).ConfigureAwait(false);

            var cluster = await clusterCollection.GetAsync(MigrationCluster.Data.Name).ConfigureAwait(false);
            AssertEquality(KustoClusterState.Migrated, cluster.Value.Data.State);
        }
    }
}
