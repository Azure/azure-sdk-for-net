// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if false
// enable the test after https://github.com/Azure/azure-rest-api-specs/issues/16560 is resolved
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [Ignore("https://github.com/Azure/azure-rest-api-specs/issues/16560")]
    public class SqlRoleAssignmentTests : CosmosDBManagementClientBase
    {
        private const string RoleAssignmentId = "adcb35e1-e104-41c2-b76d-70a8b03e6463";
        private const string PrincipalId = "ed4c2395-a18c-4018-afb3-6e521e7534d2";
        private const string PrincipalId2 = "d60019b0-c5a8-4e38-beb9-fb80daa3ce90";

        private DatabaseAccount _databaseAccount;
        private SqlDatabase _sqlDatabase;
        private ResourceIdentifier _roleDefinitionId;
        private SqlRoleDefinition _roleDefinition;

        private string SqlRoleAssignmentScope { get => $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}"; }

        public SqlRoleAssignmentTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlRoleAssignmentCollection SqlRoleAssignmentCollection { get => _databaseAccount.GetSqlRoleAssignments(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB, new Capability("EnableGremlin"));

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases());

            _roleDefinitionId = (await SqlRoleDefinitionTests.CreateSqlRoleDefinition($"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}", _databaseAccount.GetSqlRoleDefinitions())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            _roleDefinition.Delete();
            _sqlDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _roleDefinition = await ArmClient.GetSqlRoleDefinition(_roleDefinitionId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlRoleAssignment assignment = await SqlRoleAssignmentCollection.GetIfExistsAsync(RoleAssignmentId);
            if (assignment != null)
            {
                await assignment.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleAssignmentCreateAndUpdate()
        {
            var assignment = await CreateSqlRoleAssignment();
            Assert.AreEqual(RoleAssignmentId, assignment.Data.Name);
            Assert.AreEqual(_roleDefinitionId, assignment.Data.RoleDefinitionId);
            Assert.AreEqual(SqlRoleAssignmentScope, assignment.Data.Scope);
            Assert.AreEqual(PrincipalId, assignment.Data.PrincipalId);

            bool ifExists = await SqlRoleAssignmentCollection.CheckIfExistsAsync(RoleAssignmentId);
            Assert.True(ifExists);

            SqlRoleAssignment assignment2 = await SqlRoleAssignmentCollection.GetAsync(RoleAssignmentId);
            Assert.AreEqual(RoleAssignmentId, assignment2.Data.Name);
            VerifySqlRoleAssignments(assignment, assignment2);

            var updateParameters = new SqlRoleAssignmentCreateUpdateParameters
            {
                RoleDefinitionId = _roleDefinitionId,
                Scope = $"{SqlRoleAssignmentScope}/colls",
                PrincipalId = PrincipalId2,
            };
            assignment = await (await SqlRoleAssignmentCollection.CreateOrUpdateAsync(RoleAssignmentId, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(RoleAssignmentId, assignment.Data.Name);
            Assert.AreEqual(_roleDefinitionId, assignment.Data.RoleDefinitionId);
            Assert.AreEqual($"{SqlRoleAssignmentScope}/colls", assignment.Data.Scope);
            Assert.AreEqual(PrincipalId2, assignment.Data.PrincipalId);

            assignment2 = await SqlRoleAssignmentCollection.GetAsync(RoleAssignmentId);
            VerifySqlRoleAssignments(assignment, assignment2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleAssignmentList()
        {
            var assignment = await CreateSqlRoleAssignment();

            var assignments = await SqlRoleAssignmentCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(assignments, Has.Count.EqualTo(1));
            Assert.AreEqual(assignment.Data.Name, assignments[0].Data.Name);

            VerifySqlRoleAssignments(assignments[0], assignment);
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleAssignmentDelete()
        {
            var assignment = await CreateSqlRoleAssignment();
            await assignment.DeleteAsync();

            assignment = await SqlRoleAssignmentCollection.GetIfExistsAsync(RoleAssignmentId);
            Assert.Null(assignment);
        }

        protected async Task<SqlRoleAssignment> CreateSqlRoleAssignment()
        {
            var parameters = new SqlRoleAssignmentCreateUpdateParameters
            {
                RoleDefinitionId = _roleDefinitionId,
                Scope = SqlRoleAssignmentScope,
                PrincipalId = PrincipalId,
            };
            var assignmentLro = await SqlRoleAssignmentCollection.CreateOrUpdateAsync(RoleAssignmentId, parameters);
            return assignmentLro.Value;
        }

        private void VerifySqlRoleAssignments(SqlRoleAssignment expectedValue, SqlRoleAssignment actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Type, actualValue.Data.Type);

            Assert.AreEqual(expectedValue.Data.RoleDefinitionId, actualValue.Data.RoleDefinitionId);

            Assert.AreEqual(expectedValue.Data.Scope, actualValue.Data.Scope);
            Assert.AreEqual(expectedValue.Data.PrincipalId, actualValue.Data.PrincipalId);
        }
    }
}
#endif
