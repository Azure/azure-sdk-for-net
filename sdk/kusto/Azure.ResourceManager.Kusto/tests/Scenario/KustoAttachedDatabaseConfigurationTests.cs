// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoAttachedDatabaseConfigurationTests : KustoManagementTestBase
    {
        protected KustoClusterResource FollowerCluster { get; set; }

        public KustoAttachedDatabaseConfigurationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(database: true);

            FollowerCluster = (await ResourceGroup.GetKustoClusterAsync(TestEnvironment.FollowerClusterName)).Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task AttachedDatabaseConfigurationTests()
        {
            var attachedDatabaseConfigurationCollection = FollowerCluster.GetKustoAttachedDatabaseConfigurations();

            var attachedDatabaseConfigurationName =
                TestEnvironment.GenerateAssetName("sdkAttachedDatabaseConfiguration");

            var attachedDatabaseConfigurationDataCreate = new KustoAttachedDatabaseConfigurationData
            {
                Location = Location,
                DatabaseName = TestEnvironment.DatabaseName,
                ClusterResourceId = Cluster.Id,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace
            };

            var attachedDatabaseConfigurationDataUpdate = new KustoAttachedDatabaseConfigurationData
            {
                Location = Location,
                DatabaseName = TestEnvironment.DatabaseName,
                ClusterResourceId = Cluster.Id,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace,
                TableLevelSharingProperties = new KustoDatabaseTableLevelSharingProperties(
                    new List<string> { "include" }, new List<string> { "exclude" },
                    new List<string> { "externalInclude" }, new List<string> { "externalExclude" },
                    new List<string> { "materializedViewInclude" }, new List<string> { "materializedViewExclude" }
                )
            };

            Task<ArmOperation<KustoAttachedDatabaseConfigurationResource>>
                CreateOrUpdateAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName,
                    KustoAttachedDatabaseConfigurationData attachedDatabaseConfigurationData, bool create) =>
                attachedDatabaseConfigurationCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                    attachedDatabaseConfigurationName, attachedDatabaseConfigurationData);

            await CollectionTests(
                attachedDatabaseConfigurationName,
                attachedDatabaseConfigurationDataCreate,
                attachedDatabaseConfigurationDataUpdate,
                CreateOrUpdateAttachedDatabaseConfigurationAsync,
                attachedDatabaseConfigurationCollection.GetAsync,
                attachedDatabaseConfigurationCollection.GetAllAsync,
                attachedDatabaseConfigurationCollection.ExistsAsync,
                ValidateAttachedDatabaseConfiguration,
                clusterChild: true
            );

            await DeletionTest(
                attachedDatabaseConfigurationName,
                attachedDatabaseConfigurationCollection.GetAsync,
                attachedDatabaseConfigurationCollection.ExistsAsync
            );
        }

        private void ValidateAttachedDatabaseConfiguration(
            KustoAttachedDatabaseConfigurationResource attachedDatabaseConfiguration,
            string attachedDatabaseConfigurationName,
            KustoAttachedDatabaseConfigurationData attachedDatabaseConfigurationData)
        {
            Assert.AreEqual(attachedDatabaseConfigurationData.Name, attachedDatabaseConfiguration.Data.Name);
            Assert.AreEqual(attachedDatabaseConfigurationData.DatabaseName,
                attachedDatabaseConfiguration.Data.DatabaseName);
            Assert.AreEqual(attachedDatabaseConfigurationData.ClusterResourceId,
                attachedDatabaseConfiguration.Data.ClusterResourceId);
            Assert.AreEqual(attachedDatabaseConfigurationData.DefaultPrincipalsModificationKind,
                attachedDatabaseConfiguration.Data.DefaultPrincipalsModificationKind);
        }

        /*
         * TODO:
         * add follower database resource tests
         * add followed database resource tests
         * add follower cluster resource tests
         * add followed cluster resource tests
        */
    }
}
