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
    public class SqlRoleDefinitionTests : CosmosDBManagementClientBase
    {
        private const string RoleDefinitionId = "70580ac3-cd0b-4549-8336-2f0d55df111e";

        private const string PermissionDataActionCreate = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create";
        private const string PermissionDataActionRead = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/read";

        private DatabaseAccount _databaseAccount;
        private ResourceIdentifier _sqlDatabaseId;
        private SqlDatabase _sqlDatabase;

        public SqlRoleDefinitionTests(bool isAsync) : base(isAsync)
        {
        }

        private SqlRoleDefinitionCollection SqlRoleDefinitionCollection { get => _databaseAccount.GetSqlRoleDefinitions(); }
        private string SqlDatabaseActionScope { get => $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}"; }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB);

            _sqlDatabaseId = (await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            _sqlDatabase.Delete();
            _databaseAccount.Delete();
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlDatabase = await ArmClient.GetSqlDatabase(_sqlDatabaseId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlRoleDefinition definition = await SqlRoleDefinitionCollection.GetIfExistsAsync(RoleDefinitionId);
            if (definition != null)
            {
                await definition.DeleteAsync();
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleDefinitionCreateAndUpdate()
        {
            var definition = await CreateSqlRoleDefinition(SqlDatabaseActionScope, SqlRoleDefinitionCollection);
            Assert.AreEqual(RoleDefinitionId, definition.Data.Name);
            Assert.That(definition.Data.AssignableScopes, Has.Count.EqualTo(1));
            Assert.AreEqual(SqlDatabaseActionScope, definition.Data.AssignableScopes[0]);
            Assert.That(definition.Data.Permissions, Has.Count.EqualTo(1));
            Assert.That(definition.Data.Permissions[0].DataActions, Has.Count.EqualTo(1));
            Assert.IsEmpty(definition.Data.Permissions[0].NotDataActions);
            Assert.AreEqual(PermissionDataActionCreate, definition.Data.Permissions[0].DataActions[0]);

            bool ifExists = await SqlRoleDefinitionCollection.CheckIfExistsAsync(RoleDefinitionId);
            Assert.True(ifExists);

            SqlRoleDefinition definition2 = await SqlRoleDefinitionCollection.GetAsync(RoleDefinitionId);
            Assert.AreEqual(RoleDefinitionId, definition2.Data.Name);
            VerifySqlRoleDefinitions(definition, definition2);

            var updateParameters = new SqlRoleDefinitionCreateUpdateParameters
            {
                RoleName = RoleDefinitionId,
                Type = RoleDefinitionType.CustomRole,
                AssignableScopes = { SqlDatabaseActionScope },
                Permissions = { new Permission { DataActions = { PermissionDataActionRead } } },
            };
            definition = await (await SqlRoleDefinitionCollection.CreateOrUpdateAsync(RoleDefinitionId, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(RoleDefinitionId, definition.Data.Name);
            Assert.That(definition.Data.AssignableScopes, Has.Count.EqualTo(2));
            Assert.AreEqual(SqlDatabaseActionScope, definition.Data.AssignableScopes[0]);
            Assert.That(definition.Data.Permissions, Has.Count.EqualTo(1));
            Assert.That(definition.Data.Permissions[0].DataActions, Has.Count.EqualTo(1));
            Assert.IsEmpty(definition.Data.Permissions[0].NotDataActions);
            Assert.AreEqual(PermissionDataActionRead, definition.Data.Permissions[0].DataActions[0]);

            definition2 = await SqlRoleDefinitionCollection.GetAsync(RoleDefinitionId);
            VerifySqlRoleDefinitions(definition, definition2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleDefinitionList()
        {
            var definition = await CreateSqlRoleDefinition(SqlDatabaseActionScope, SqlRoleDefinitionCollection);

            var definitions = await SqlRoleDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(definitions, Has.Count.EqualTo(1));
            Assert.AreEqual(definition.Data.Name, definitions[0].Data.Name);

            VerifySqlRoleDefinitions(definitions[0], definition);
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleDefinitionDelete()
        {
            var definition = await CreateSqlRoleDefinition(SqlDatabaseActionScope, SqlRoleDefinitionCollection);
            await definition.DeleteAsync();

            definition = await SqlRoleDefinitionCollection.GetIfExistsAsync(RoleDefinitionId);
            Assert.Null(definition);
        }

        internal static async Task<SqlRoleDefinition> CreateSqlRoleDefinition(string assignableScope, SqlRoleDefinitionCollection definitionCollection)
        {
            //RoleDefinitionId = Recording.GenerateAssetName("sql-role-");
            var parameters = new SqlRoleDefinitionCreateUpdateParameters
            {
                RoleName = RoleDefinitionId,
                Type = RoleDefinitionType.CustomRole,
                AssignableScopes = { assignableScope },
                Permissions = { new Permission { DataActions = { PermissionDataActionCreate } } },
            };
            var definitionLro = await definitionCollection.CreateOrUpdateAsync(RoleDefinitionId, parameters);
            return definitionLro.Value;
        }

        private void VerifySqlRoleDefinitions(SqlRoleDefinition expectedValue, SqlRoleDefinition actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Type, actualValue.Data.Type);

            Assert.AreEqual(expectedValue.Data.RoleName, actualValue.Data.RoleName);

            Assert.AreEqual(expectedValue.Data.AssignableScopes, actualValue.Data.AssignableScopes);
            Assert.AreEqual(expectedValue.Data.Permissions, actualValue.Data.Permissions);
        }
    }
}
#endif
