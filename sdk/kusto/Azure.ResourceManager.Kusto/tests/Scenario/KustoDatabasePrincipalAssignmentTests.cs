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

            var databasePrincipalAssignmentName = TestEnvironment.GenerateAssetName("sdkDatabasePrincipalAssignment");

            var databasePrincipalAssignmentDataCreate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoDatabasePrincipalRole.Admin,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            var databasePrincipalAssignmentDataUpdate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoDatabasePrincipalRole.Viewer,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            Task<ArmOperation<KustoDatabasePrincipalAssignmentResource>>
                CreateCreateOrUpdateDatabasePrincipalAssignmentAsync(string databasePrincipalAssignmentName,
                    KustoDatabasePrincipalAssignmentData databasePrincipalAssignmentData, bool create) =>
                databasePrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                    databasePrincipalAssignmentName, databasePrincipalAssignmentData);

            await CollectionTests(
                databasePrincipalAssignmentName, databasePrincipalAssignmentDataCreate,
                databasePrincipalAssignmentDataUpdate,
                CreateCreateOrUpdateDatabasePrincipalAssignmentAsync,
                databasePrincipalAssignmentCollection.GetAsync,
                databasePrincipalAssignmentCollection.GetAllAsync,
                databasePrincipalAssignmentCollection.ExistsAsync,
                ValidatePrincipalAssignment,
                databaseChild: true
            );

            await DeletionTest(
                databasePrincipalAssignmentName,
                databasePrincipalAssignmentCollection.GetAsync,
                databasePrincipalAssignmentCollection.ExistsAsync
            );

            /*
             * TODO:
             * add database resource principal tests
             */
        }

        private void ValidatePrincipalAssignment(KustoDatabasePrincipalAssignmentResource databasePrincipalAssignment,
            string databasePrincipalAssignmentName,
            KustoDatabasePrincipalAssignmentData databasePrincipalAssignmentData)
        {
            Assert.AreEqual(databasePrincipalAssignmentName, databasePrincipalAssignment.Data.Name);
            Assert.AreEqual(databasePrincipalAssignmentData.PrincipalId, databasePrincipalAssignment.Data.PrincipalId);
            Assert.AreEqual(databasePrincipalAssignmentData.Role, databasePrincipalAssignment.Data.Role);
            Assert.AreEqual(databasePrincipalAssignmentData.PrincipalType,
                databasePrincipalAssignment.Data.PrincipalType);
        }
    }
}
