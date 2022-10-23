// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoAttachedDatabaseConfigurationTests : KustoManagementTestBase
    {
        public KustoAttachedDatabaseConfigurationTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task AttachedDatabaseConfigurationTests()
        {
            var attachedDatabaseConfigurationCollection = Cluster.GetKustoAttachedDatabaseConfigurations();
            var attachedDatabaseConfigurationName = Recording.GenerateAssetName("sdkTestAttachedDatabaseConfiguration");
            var attachedDatabaseConfigurationDataCreate = new KustoAttachedDatabaseConfigurationData
            {
                Location = KustoTestUtils.Location,
                DatabaseName = "databasetest",
                ClusterResourceId = Cluster.Id,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Replace
            };
            var attachedDatabaseConfigurationDataUpdate = new KustoAttachedDatabaseConfigurationData
            {
                Location = KustoTestUtils.Location,
                DatabaseName = "databasetest",
                ClusterResourceId = ClientTestCluster.Id,
                DefaultPrincipalsModificationKind = KustoDatabaseDefaultPrincipalsModificationKind.Union
            };

            Task<ArmOperation<KustoAttachedDatabaseConfigurationResource>>
                CreateOrUpdateAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName,
                    KustoAttachedDatabaseConfigurationData attachedDatabaseConfigurationData) =>
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
