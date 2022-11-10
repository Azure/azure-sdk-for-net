// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            await BaseSetUp(database: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabasePrincipalAssignmentTests()
        {
            var databasePrincipalAssignmentCollection = Database.GetKustoDatabasePrincipalAssignments();

            var databasePrincipalAssignmentName = GenerateAssetName("sdkDatabasePrincipalAssignment");

            var databasePrincipalAssignmentDataCreate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Cluster.Data.Identity.PrincipalId,
                PrincipalType = KustoPrincipalAssignmentType.App,
                Role = KustoDatabasePrincipalRole.Admin
            };

            var databasePrincipalAssignmentDataUpdate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Cluster.Data.Identity.PrincipalId,
                PrincipalType = KustoPrincipalAssignmentType.App,
                Role = KustoDatabasePrincipalRole.Viewer,
                TenantId = Guid.Parse(TE.TenantId)
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
            Assert.AreEqual(
                expectedFullDatabasePrincipalAssignmentName, actualDatabasePrincipalAssignmentData.Name);
            Assert.AreEqual(
                expectedDatabasePrincipalAssignmentData.PrincipalId, actualDatabasePrincipalAssignmentData.PrincipalId
            );
            Assert.AreEqual(
                expectedDatabasePrincipalAssignmentData.PrincipalType,
                actualDatabasePrincipalAssignmentData.PrincipalType
            );
            Assert.AreEqual(
                expectedDatabasePrincipalAssignmentData.Role, actualDatabasePrincipalAssignmentData.Role
            );
            Assert.AreEqual(
                expectedDatabasePrincipalAssignmentData.TenantId, actualDatabasePrincipalAssignmentData.TenantId
            );
        }
    }
}
