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
        private KustoDatabasePrincipalAssignmentCollection _databasePrincipalAssignmentCollection;

        private string _databasePrincipalAssignmentName;
        private KustoDatabasePrincipalAssignmentData _databasePrincipalAssignmentDataCreate;
        private KustoDatabasePrincipalAssignmentData _databasePrincipalAssignmentDataUpdate;

        private CreateOrUpdateAsync<KustoDatabasePrincipalAssignmentResource, KustoDatabasePrincipalAssignmentData>
            _createOrUpdateDatabasePrincipalAssignmentAsync;

        public KustoDatabasePrincipalAssignmentTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void DatabasePrincipalAssignmentSetup()
        {
            _databasePrincipalAssignmentCollection = Database.GetKustoDatabasePrincipalAssignments();

            _databasePrincipalAssignmentName = Recording.GenerateAssetName("sdkTestDatabasePrincipalAssignment");
            _databasePrincipalAssignmentDataCreate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoDatabasePrincipalRole.Admin,
                PrincipalType = KustoPrincipalAssignmentType.App
            };
            _databasePrincipalAssignmentDataUpdate = new KustoDatabasePrincipalAssignmentData
            {
                PrincipalId = Guid.Parse(TestEnvironment.ClientId),
                Role = KustoDatabasePrincipalRole.Viewer,
                PrincipalType = KustoPrincipalAssignmentType.App
            };

            _createOrUpdateDatabasePrincipalAssignmentAsync =
                (databasePrincipalAssignmentName, databasePrincipalAssignmentData) =>
                    _databasePrincipalAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                        databasePrincipalAssignmentName, databasePrincipalAssignmentData);
        }

        [TestCase]
        [RecordedTest]
        public async Task DatabasePrincipalAssignmentTests()
        {
            await CollectionTests(
                _databasePrincipalAssignmentName, _databasePrincipalAssignmentDataCreate,
                _databasePrincipalAssignmentDataUpdate,
                _createOrUpdateDatabasePrincipalAssignmentAsync,
                _databasePrincipalAssignmentCollection.GetAsync,
                _databasePrincipalAssignmentCollection.GetAllAsync,
                _databasePrincipalAssignmentCollection.ExistsAsync,
                ValidatePrincipalAssignment,
                databaseChild: true
            );

            await DeletionTest(
                _databasePrincipalAssignmentName,
                _databasePrincipalAssignmentCollection.GetAsync,
                _databasePrincipalAssignmentCollection.ExistsAsync
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
