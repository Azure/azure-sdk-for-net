// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoAttachedDatabaseConfigurationTests : KustoManagementTestBase
    {
        private KustoReadWriteDatabase DatabaseData { get; set; }
        private KustoClusterResource FollowingCluster { get; set; }

        public KustoAttachedDatabaseConfigurationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(database: true);
            DatabaseData = (KustoReadWriteDatabase)Database.Data;

            FollowingCluster = (await ResourceGroup.GetKustoClusterAsync(TE.FollowingClusterName)).Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task AttachedDatabaseConfigurationTests()
        {
            var attachedDatabaseConfigurationCollection = FollowingCluster.GetKustoAttachedDatabaseConfigurations();

            var attachedDatabaseConfigurationName =
                GenerateAssetName("sdkAttachedDatabaseConfiguration");

            var attachedDatabaseConfigurationDataCreate = new KustoAttachedDatabaseConfigurationData
            {
                ClusterResourceId = Cluster.Id,
                DatabaseName = "*",
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace
            };

            var attachedDatabaseConfigurationDataUpdate = new KustoAttachedDatabaseConfigurationData
            {
                ClusterResourceId = Cluster.Id,
                DatabaseName = TE.DatabaseName,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace,
                TableLevelSharingProperties = new KustoDatabaseTableLevelSharingProperties(
                    new List<string> { "include" },
                    new List<string> { "exclude" },
                    new List<string> { "externalInclude" },
                    new List<string> { "externalExclude" },
                    new List<string> { "materializedViewInclude" },
                    new List<string> { "materializedViewExclude" }
                )
            };

            Task<ArmOperation<KustoAttachedDatabaseConfigurationResource>>
                CreateOrUpdateAttachedDatabaseConfigurationAsync(
                    string attachedDatabaseConfigurationName,
                    KustoAttachedDatabaseConfigurationData attachedDatabaseConfigurationData
                ) => attachedDatabaseConfigurationCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, attachedDatabaseConfigurationName, attachedDatabaseConfigurationData
            );

            await CollectionTests(
                attachedDatabaseConfigurationName,
                GetFullClusterChildResourceName(attachedDatabaseConfigurationName, TE.FollowingClusterName),
                attachedDatabaseConfigurationDataCreate,
                attachedDatabaseConfigurationDataUpdate,
                CreateOrUpdateAttachedDatabaseConfigurationAsync,
                attachedDatabaseConfigurationCollection.GetAsync,
                attachedDatabaseConfigurationCollection.GetAllAsync,
                attachedDatabaseConfigurationCollection.ExistsAsync,
                ValidateAttachedDatabaseConfiguration
            );

            var followingDatabase = (await FollowingCluster.GetKustoDatabaseAsync(TE.DatabaseName)).Value;
            await ReadOnlyFollowingDatabaseResourceTests(followingDatabase);

            await FollowerDatabaseActionTests(attachedDatabaseConfigurationName);

            await DeletionTest(
                attachedDatabaseConfigurationName,
                attachedDatabaseConfigurationCollection.GetAsync,
                attachedDatabaseConfigurationCollection.ExistsAsync
            );
        }

        private async Task ReadOnlyFollowingDatabaseResourceTests(KustoDatabaseResource followingDatabase)
        {
            var fullFollowingDatabaseName = GetFullClusterChildResourceName(
                TE.DatabaseName, TE.FollowingClusterName
            );
            var expectedHotCachePeriod = DatabaseData.HotCachePeriod;
            var expectedSoftDeletePeriod = DatabaseData.SoftDeletePeriod;

            var followingDatabaseData = (KustoReadOnlyFollowingDatabase)followingDatabase.Data;
            ValidateReadOnlyFollowingDatabase(
                fullFollowingDatabaseName, expectedHotCachePeriod, expectedSoftDeletePeriod, followingDatabaseData
            );

            followingDatabaseData.HotCachePeriod = expectedHotCachePeriod += TimeSpan.FromDays(1);
            followingDatabase = (await followingDatabase.UpdateAsync(WaitUntil.Completed, followingDatabaseData)).Value;

            followingDatabaseData = (KustoReadOnlyFollowingDatabase)followingDatabase.Data;
            ValidateReadOnlyFollowingDatabase(
                fullFollowingDatabaseName, expectedHotCachePeriod, expectedSoftDeletePeriod, followingDatabaseData
            );
        }

        private static void ValidateAttachedDatabaseConfiguration(
            string expectedFullAttachedDatabaseConfigurationName,
            KustoAttachedDatabaseConfigurationData expectedAttachedDatabaseConfigurationData,
            KustoAttachedDatabaseConfigurationData actualAttachedDatabaseConfigurationData
        )
        {
            Assert.AreEqual(
                expectedAttachedDatabaseConfigurationData.ClusterResourceId,
                actualAttachedDatabaseConfigurationData.ClusterResourceId
            );
            Assert.AreEqual(
                expectedAttachedDatabaseConfigurationData.DatabaseName,
                actualAttachedDatabaseConfigurationData.DatabaseName
            );
            Assert.AreEqual(
                expectedAttachedDatabaseConfigurationData.DefaultPrincipalsModificationKind,
                actualAttachedDatabaseConfigurationData.DefaultPrincipalsModificationKind);
            Assert.AreEqual(
                expectedFullAttachedDatabaseConfigurationName, actualAttachedDatabaseConfigurationData.Name
            );
            AssertEquality(
                expectedAttachedDatabaseConfigurationData.TableLevelSharingProperties,
                actualAttachedDatabaseConfigurationData.TableLevelSharingProperties,
                AssertTableLevelSharingPropertiesEquals
            );
        }

        private static void AssertTableLevelSharingPropertiesEquals(
            KustoDatabaseTableLevelSharingProperties expected, KustoDatabaseTableLevelSharingProperties actual
        )
        {
            CollectionAssert.AreEqual(expected.TablesToExclude, actual.TablesToExclude);
            CollectionAssert.AreEqual(expected.TablesToInclude, actual.TablesToInclude);
            CollectionAssert.AreEqual(expected.ExternalTablesToExclude, actual.ExternalTablesToExclude);
            CollectionAssert.AreEqual(expected.ExternalTablesToInclude, actual.ExternalTablesToInclude);
            CollectionAssert.AreEqual(expected.MaterializedViewsToExclude, actual.MaterializedViewsToExclude);
            CollectionAssert.AreEqual(expected.MaterializedViewsToInclude, actual.MaterializedViewsToInclude);
        }

        private static void ValidateReadOnlyFollowingDatabase(
            string expectedFullDatabaseName,
            TimeSpan? expectedHotCachePeriod, TimeSpan? expectedSoftDeletePeriod,
            KustoReadOnlyFollowingDatabase actualDatabaseData
        )
        {
            Assert.AreEqual(expectedHotCachePeriod, actualDatabaseData.HotCachePeriod);
            Assert.AreEqual(KustoKind.ReadOnlyFollowing, actualDatabaseData.Kind);
            Assert.AreEqual(expectedFullDatabaseName, actualDatabaseData.Name);
            Assert.AreEqual(expectedSoftDeletePeriod, actualDatabaseData.SoftDeletePeriod);
        }

        private async Task FollowerDatabaseActionTests(string attachedDatabaseConfigurationName)
        {
            var followerDatabaseDefinition = await Cluster.GetFollowerDatabasesAsync().FirstOrDefaultAsync();

            ValidateFollowerDatabaseDefinition(followerDatabaseDefinition, attachedDatabaseConfigurationName);

            await ValidateReadWriteDatabase(true);

            await FollowingCluster.DetachFollowerDatabasesAsync(WaitUntil.Completed, followerDatabaseDefinition);

            Assert.IsNull(await Cluster.GetFollowerDatabasesAsync().FirstOrDefaultAsync());

            await ValidateReadWriteDatabase(false);
        }

        private void ValidateFollowerDatabaseDefinition(
            KustoFollowerDatabaseDefinition followerDatabaseDefinition, string expectedAttachedDatabaseConfigurationName
        )
        {
            Assert.IsNotNull(followerDatabaseDefinition);
            Assert.AreEqual(
                expectedAttachedDatabaseConfigurationName,
                followerDatabaseDefinition.AttachedDatabaseConfigurationName
            );
            Assert.AreEqual(FollowingCluster.Id, followerDatabaseDefinition.ClusterResourceId);
            Assert.AreEqual(TE.DatabaseName, followerDatabaseDefinition.DatabaseName);
        }

        private async Task ValidateReadWriteDatabase(bool isFollowed)
        {
            var databaseData = (KustoReadWriteDatabase)(
                await Cluster.GetKustoDatabaseAsync(TE.DatabaseName)
            ).Value.Data;

            Assert.AreEqual(DatabaseData.HotCachePeriod, databaseData.HotCachePeriod);
            Assert.AreEqual(isFollowed, databaseData.IsFollowed);
        }
    }
}
