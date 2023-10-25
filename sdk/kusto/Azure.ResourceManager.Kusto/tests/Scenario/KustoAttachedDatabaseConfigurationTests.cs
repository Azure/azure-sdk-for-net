// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        public KustoAttachedDatabaseConfigurationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp();

            DatabaseData = (KustoReadWriteDatabase)Database.Data;
        }

        [TestCase]
        [RecordedTest]
        public async Task AttachedDatabaseConfigurationTests()
        {
            var attachedDatabaseConfigurationCollection = FollowingCluster.GetKustoAttachedDatabaseConfigurations();

            var attachedDatabaseConfigurationName = GenerateAssetName("sdkAttachedDatabaseConfiguration");

            var attachedDatabaseConfigurationDataCreate = new KustoAttachedDatabaseConfigurationData {ClusterResourceId = Cluster.Id, DatabaseName = TE.DatabaseName, DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace, Location = Location};

            var attachedDatabaseConfigurationDataUpdate = new KustoAttachedDatabaseConfigurationData
            {
                ClusterResourceId = Cluster.Id,
                DatabaseName = TE.DatabaseName,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace,
                Location = Location,
                TableLevelSharingProperties = new KustoDatabaseTableLevelSharingProperties
                {
                    TablesToInclude = {"include"},
                    TablesToExclude = {"exclude"},
                    ExternalTablesToInclude = {"externalInclude"},
                    ExternalTablesToExclude = {"externalExclude"},
                    MaterializedViewsToInclude = {"materializedViewInclude"},
                    MaterializedViewsToExclude = {"materializedViewExclude"},
                    FunctionsToInclude = {"functionsToInclude"},
                    FunctionsToExclude = {"functionsToExclude"}
                }
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

            await DeletionTest(
                attachedDatabaseConfigurationName,
                attachedDatabaseConfigurationCollection.GetAsync,
                attachedDatabaseConfigurationCollection.ExistsAsync
            );
        }

        [TestCase]
        [RecordedTest]
        public async Task FollowerDatabaseActionTests()
        {
            var attachedDatabaseConfigurationCollection = FollowingCluster.GetKustoAttachedDatabaseConfigurations();

            var attachedDatabaseConfigurationName =
                GenerateAssetName("sdkAttachedDatabaseConfiguration");

            await attachedDatabaseConfigurationCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                attachedDatabaseConfigurationName,
                new KustoAttachedDatabaseConfigurationData {ClusterResourceId = Cluster.Id, DatabaseName = TE.DatabaseName, DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace, Location = Location});

            var followerDatabaseDefinition = await Cluster.GetFollowerDatabasesAsync().FirstOrDefaultAsync();

            ValidateFollowerDatabaseDefinition(followerDatabaseDefinition, attachedDatabaseConfigurationName);

            await ValidateReadWriteDatabase(true);

            await FollowingCluster.DetachFollowerDatabasesAsync(WaitUntil.Completed, followerDatabaseDefinition);

            Assert.IsNull(await Cluster.GetFollowerDatabasesAsync().FirstOrDefaultAsync());

            await ValidateReadWriteDatabase(false);
        }

        [Test]
        [RecordedTest]
        public async Task DatabaseInviteFollowerTest()
        {
            var content = new DatabaseInviteFollowerContent("user@contoso.com");
            var invitation = await Database.InviteFollowerDatabaseAsync(content).ConfigureAwait(false);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(invitation.Value.GeneratedInvitation));
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
            AssertEquality(
                expectedAttachedDatabaseConfigurationData.ClusterResourceId,
                actualAttachedDatabaseConfigurationData.ClusterResourceId
            );
            AssertEquality(
                expectedAttachedDatabaseConfigurationData.DatabaseName,
                actualAttachedDatabaseConfigurationData.DatabaseName
            );
            AssertEquality(
                expectedAttachedDatabaseConfigurationData.DefaultPrincipalsModificationKind,
                actualAttachedDatabaseConfigurationData.DefaultPrincipalsModificationKind
            );
            AssertEquality(
                expectedFullAttachedDatabaseConfigurationName, actualAttachedDatabaseConfigurationData.Name
            );
            AssertEquality(
                expectedAttachedDatabaseConfigurationData.Location, actualAttachedDatabaseConfigurationData.Location
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
            CollectionAssert.AreEqual(expected.FunctionsToInclude, actual.FunctionsToInclude);
            CollectionAssert.AreEqual(expected.FunctionsToExclude, actual.FunctionsToExclude);
        }

        private void ValidateReadOnlyFollowingDatabase(
            string expectedFullDatabaseName,
            TimeSpan? expectedHotCachePeriod, TimeSpan? expectedSoftDeletePeriod,
            KustoReadOnlyFollowingDatabase actualDatabaseData
        )
        {
            AssertEquality(expectedHotCachePeriod, actualDatabaseData.HotCachePeriod);
            AssertEquality(KustoKind.ReadOnlyFollowing, actualDatabaseData.Kind);
            AssertEquality(expectedFullDatabaseName, actualDatabaseData.Name);
            AssertEquality(Location, actualDatabaseData.Location);
            AssertEquality(expectedSoftDeletePeriod, actualDatabaseData.SoftDeletePeriod);
        }

        private void ValidateFollowerDatabaseDefinition(
            KustoFollowerDatabaseDefinition followerDatabaseDefinition, string expectedAttachedDatabaseConfigurationName
        )
        {
            Assert.IsNotNull(followerDatabaseDefinition);
            AssertEquality(
                expectedAttachedDatabaseConfigurationName,
                followerDatabaseDefinition.AttachedDatabaseConfigurationName
            );
            AssertEquality(FollowingCluster.Id, followerDatabaseDefinition.ClusterResourceId);
            AssertEquality(TE.DatabaseName, followerDatabaseDefinition.DatabaseName);
        }

        private async Task ValidateReadWriteDatabase(bool isFollowed)
        {
            var databaseData = (KustoReadWriteDatabase)(
                await Cluster.GetKustoDatabaseAsync(TE.DatabaseName)
            ).Value.Data;

            AssertEquality(DatabaseData.HotCachePeriod, databaseData.HotCachePeriod);
            AssertEquality(isFollowed, databaseData.IsFollowed);
        }
    }
}
