// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlRoleAssignmentTests : CosmosDBManagementClientBase
    {
        // this is actually a resource name though its name is `sqlRoleAssignmentId`
        // it follows GUID format, not Azure resource identifier
        // see azure cli sample: https://docs.microsoft.com/en-us/cli/azure/cosmosdb/sql/role/assignment?view=azure-cli-latest#az-cosmosdb-sql-role-assignment-create-examples
        private const string RoleAssignmentId = "cb8ed2d7-2371-4e3c-bd31-6cc1560e84f8";
        private const string RoleDefinitionId2 ="851363f2-1fe6-477b-ae76-9ef3ba3d4a31";
        private Guid PrincipalId = new Guid("ed4c2395-a18c-4018-afb3-6e521e7534d2");

        private CosmosDBAccountResource _databaseAccount;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private CosmosDBSqlRoleDefinitionResource _roleDefinition;
        private CosmosDBSqlRoleAssignmentResource _roleAssignment;

        private string SqlRoleAssignmentScope { get => $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}"; }

        public SqlRoleAssignmentTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlRoleAssignmentCollection SqlRoleAssignmentCollection { get => _databaseAccount.GetCosmosDBSqlRoleAssignments(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(Recording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetCosmosDBSqlDatabases());

            _roleDefinition = (await SqlRoleDefinitionTests.CreateSqlRoleDefinition(Recording.GenerateAssetName("sql-role-def-"), $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}", _databaseAccount.GetCosmosDBSqlRoleDefinitions()));
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_roleAssignment != null)
                {
                    if (await SqlRoleAssignmentCollection.ExistsAsync(RoleAssignmentId))
                    {
                        await _roleAssignment.DeleteAsync(WaitUntil.Completed);
                    }
                }
                await _roleDefinition.DeleteAsync(WaitUntil.Completed);
                await _sqlDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        [LiveOnly]
        public async Task SqlRoleAssignmentCreateAndUpdate()
        {
            var assignment = await CreateSqlRoleAssignment();
            Assert.AreEqual(_roleAssignment.Data.Name, assignment.Data.Name);
            Assert.AreEqual(_roleDefinition.Id, assignment.Data.RoleDefinitionId);
            Assert.AreEqual(SqlRoleAssignmentScope, assignment.Data.Scope);
            Assert.AreEqual(PrincipalId, assignment.Data.PrincipalId);

            bool ifExists = await SqlRoleAssignmentCollection.ExistsAsync(RoleAssignmentId);
            Assert.True(ifExists);

            CosmosDBSqlRoleAssignmentResource assignment2 = await SqlRoleAssignmentCollection.GetAsync(RoleAssignmentId);
            Assert.AreEqual(_roleAssignment.Data.Name, assignment2.Data.Name);
            VerifySqlRoleAssignments(assignment, assignment2);

            var roleDefinition2 = await SqlRoleDefinitionTests.CreateSqlRoleDefinition(RoleDefinitionId2, Recording.GenerateAssetName("sql-role-def-"), $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}", _databaseAccount.GetCosmosDBSqlRoleDefinitions());
            var updateParameters = new CosmosDBSqlRoleAssignmentCreateOrUpdateContent
            {
                RoleDefinitionId = roleDefinition2.Id,
                Scope = SqlRoleAssignmentScope,
                PrincipalId = PrincipalId,
            };
            assignment = await (await SqlRoleAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, RoleAssignmentId, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(_roleAssignment.Data.Name, assignment.Data.Name);
            Assert.AreEqual(roleDefinition2.Id, assignment.Data.RoleDefinitionId);
            Assert.AreEqual(SqlRoleAssignmentScope, assignment.Data.Scope);
            Assert.AreEqual(PrincipalId, assignment.Data.PrincipalId);

            assignment2 = await SqlRoleAssignmentCollection.GetAsync(RoleAssignmentId);
            VerifySqlRoleAssignments(assignment, assignment2);
        }

        [Test]
        [RecordedTest]
        [LiveOnly]
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
        [LiveOnly]
        public async Task SqlRoleAssignmentDelete()
        {
            var assignment = await CreateSqlRoleAssignment();
            await assignment.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await SqlRoleAssignmentCollection.ExistsAsync(RoleAssignmentId));
        }

        protected async Task<CosmosDBSqlRoleAssignmentResource> CreateSqlRoleAssignment()
        {
            var parameters = new CosmosDBSqlRoleAssignmentCreateOrUpdateContent
            {
                RoleDefinitionId = _roleDefinition.Id,
                Scope = SqlRoleAssignmentScope,
                PrincipalId = PrincipalId,
            };
            var assignmentLro = await SqlRoleAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, RoleAssignmentId, parameters);

            _roleAssignment = assignmentLro.Value;
            return _roleAssignment;
        }

        private void VerifySqlRoleAssignments(CosmosDBSqlRoleAssignmentResource expectedValue, CosmosDBSqlRoleAssignmentResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.RoleDefinitionId, actualValue.Data.RoleDefinitionId);

            Assert.AreEqual(expectedValue.Data.Scope, actualValue.Data.Scope);
            Assert.AreEqual(expectedValue.Data.PrincipalId, actualValue.Data.PrincipalId);
        }
    }
}
