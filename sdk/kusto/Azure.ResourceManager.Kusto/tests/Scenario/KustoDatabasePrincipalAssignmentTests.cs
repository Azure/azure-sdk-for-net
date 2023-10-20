// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoDatabasePrincipalAssignmentTests : KustoManagementTestBase
    {
        public KustoDatabasePrincipalAssignmentTests(bool isAsync)
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
        public async Task DatabasePrincipalAssignmentTests()
        {
            var databasePrincipalAssignmentCollection = Database.GetKustoDatabasePrincipalAssignments();

            var databasePrincipalAssignmentName = GenerateAssetName("sdkDatabasePrincipalAssignment");

            var databasePrincipalAssignmentDataCreate = new KustoDatabasePrincipalAssignmentData
            {
                DatabasePrincipalId = Cluster.Data.Identity.PrincipalId.ToString(),
                PrincipalType = KustoPrincipalAssignmentType.App,
                Role = KustoDatabasePrincipalRole.Admin
            };

            var databasePrincipalAssignmentDataUpdate = new KustoDatabasePrincipalAssignmentData
            {
                DatabasePrincipalId = Cluster.Data.Identity.PrincipalId.ToString(),
                PrincipalType = KustoPrincipalAssignmentType.App,
                Role = KustoDatabasePrincipalRole.Viewer
            };

            Task<ArmOperation<KustoDatabasePrincipalAssignmentResource>> CreateOrUpdateDatabasePrincipalAssignmentAsync(
                string databasePrincipalAssignmentName,
                KustoDatabasePrincipalAssignmentData databasePrincipalAssignmentData
            ) => databasePrincipalAssignmentCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, databasePrincipalAssignmentName, databasePrincipalAssignmentData
            );

            await CollectionTests(
                databasePrincipalAssignmentName,
                GetFullDatabaseChildResourceName(databasePrincipalAssignmentName),
                databasePrincipalAssignmentDataCreate,
                databasePrincipalAssignmentDataUpdate,
                CreateOrUpdateDatabasePrincipalAssignmentAsync,
                databasePrincipalAssignmentCollection.GetAsync,
                databasePrincipalAssignmentCollection.GetAllAsync,
                databasePrincipalAssignmentCollection.ExistsAsync,
                ValidatePrincipalAssignment
            );

            await DeletionTest(
                databasePrincipalAssignmentName,
                databasePrincipalAssignmentCollection.GetAsync,
                databasePrincipalAssignmentCollection.ExistsAsync
            );
        }

        private static void ValidatePrincipalAssignment(
            string expectedFullDatabasePrincipalAssignmentName,
            KustoDatabasePrincipalAssignmentData expectedDatabasePrincipalAssignmentData,
            KustoDatabasePrincipalAssignmentData actualDatabasePrincipalAssignmentData
        )
        {
            AssertEquality(
                expectedDatabasePrincipalAssignmentData.DatabasePrincipalId,
                actualDatabasePrincipalAssignmentData.DatabasePrincipalId
            );
            AssertEquality(
                expectedFullDatabasePrincipalAssignmentName, actualDatabasePrincipalAssignmentData.Name);
            AssertEquality(
                expectedDatabasePrincipalAssignmentData.PrincipalType,
                actualDatabasePrincipalAssignmentData.PrincipalType
            );
            AssertEquality(
                expectedDatabasePrincipalAssignmentData.Role, actualDatabasePrincipalAssignmentData.Role
            );
        }
    }
}
