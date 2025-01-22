// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario;

public class KustoClusterMigrationTests : KustoManagementTestBase
{
    private readonly KustoSku _sku = new(KustoSkuName.StandardE2aV4, 2, KustoSkuTier.Standard, null);
    private readonly TimeSpan _postMigrationDelay = TimeSpan.FromMinutes(6);
    private readonly TimeSpan _preMigrationDelay = TimeSpan.FromMinutes(5);

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

        var clusterName = GenerateAssetName("sdkMgrCluster");

        await CreateCluster(clusterCollection, clusterName);

        await ClusterMigration(clusterCollection, clusterName);

        await DeletionTest(clusterName, clusterCollection.GetAsync, clusterCollection.ExistsAsync);
    }

    private async Task CreateCluster(KustoClusterCollection clusterCollection, string clusterName)
    {
        var clusterDataCreate = new KustoClusterData(Location, _sku);

        await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterDataCreate);
    }

    private async Task ClusterMigration(KustoClusterCollection clusterCollection, string clusterName)
    {
        var cluster = (await clusterCollection.GetAsync(clusterName)).Value;

        var databaseName = GenerateAssetName("MgrDatabase");
        var databaseData = new KustoReadWriteDatabase { Location = Location, HotCachePeriod = TimeSpan.FromDays(2), SoftDeletePeriod = TimeSpan.FromDays(3) };
        var databaseCollection = cluster.GetKustoDatabases();
        await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, databaseName, databaseData);

        // We don't want to trigger migration immediately after the cluster and database creation.
        // We want to give it sometime to settle down.
        if (Mode != RecordedTestMode.Playback)
        {
            await Task.Delay(_preMigrationDelay).ConfigureAwait(false);
        }

        var destinationCluster = (await ResourceGroup.GetKustoClusterAsync(TE.FollowingClusterName)).Value;

        var clusterMigrationContent = new ClusterMigrateContent(destinationCluster.Data.Id);
        await cluster.MigrateAsync(WaitUntil.Completed, clusterMigrationContent).ConfigureAwait(false);

        cluster = await clusterCollection.GetAsync(clusterName).ConfigureAwait(false);
        AssertEquality(KustoClusterState.Migrated, cluster.Data.State);

        // Once Migration operation is completed, the cluster might be still in maintenance mode for a few minutes.
        // To make sure the next operations would not fail on 'InMaintenance' state, we wait for a few minutes.
        // Retry logic is a bit problematic in the tests since the playback mode might not pick the right recording.
        if (Mode != RecordedTestMode.Playback)
        {
            await Task.Delay(_postMigrationDelay).ConfigureAwait(false);
        }
    }
}
