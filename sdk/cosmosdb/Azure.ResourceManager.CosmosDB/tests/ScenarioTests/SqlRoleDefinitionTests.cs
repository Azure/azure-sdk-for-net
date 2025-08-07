// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlRoleDefinitionTests : CosmosDBManagementClientBase
    {
        // this is actually a resource name though its name is `sqlRoleDefinitionId`
        // it follows GUID format, not Azure resource identifier
        // see azure cli sample: https://docs.microsoft.com/en-us/cli/azure/cosmosdb/sql/role/definition?view=azure-cli-latest#az-cosmosdb-sql-role-definition-create-examples
        internal const string RoleDefinitionId = "be79875a-2cc4-40d5-8958-566017875b39";
        private const string PermissionDataActionCreate = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create";
        private const string PermissionDataActionRead = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/read";

        private CosmosDBAccountResource _databaseAccount;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private CosmosDBSqlRoleDefinitionResource _roleDefinition;

        public SqlRoleDefinitionTests(bool isAsync) : base(isAsync)
        {
        }

        private CosmosDBSqlRoleDefinitionCollection SqlRoleDefinitionCollection { get => _databaseAccount.GetCosmosDBSqlRoleDefinitions(); }
        private string SqlDatabaseActionScope { get => $"{_databaseAccount.Id}/dbs/{_sqlDatabase.Data.Name}"; }
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
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_roleDefinition != null)
                {
                    if (await SqlRoleDefinitionCollection.ExistsAsync(RoleDefinitionId))
                    {
                        await _roleDefinition.DeleteAsync(WaitUntil.Completed);
                    }
                }
                await _sqlDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleDefinitionCreateAndUpdate()
        {
            var definition = await CreateSqlRoleDefinition(SqlDatabaseActionScope, SqlRoleDefinitionCollection);
            Assert.AreEqual(_roleDefinition.Data.Name, definition.Data.Name);
            Assert.That(definition.Data.AssignableScopes, Has.Count.EqualTo(1));
            Assert.AreEqual(SqlDatabaseActionScope, definition.Data.AssignableScopes[0]);
            Assert.That(definition.Data.Permissions, Has.Count.EqualTo(1));
            Assert.That(definition.Data.Permissions[0].DataActions, Has.Count.EqualTo(1));
            Assert.IsEmpty(definition.Data.Permissions[0].NotDataActions);
            Assert.AreEqual(PermissionDataActionCreate, definition.Data.Permissions[0].DataActions[0]);

            bool ifExists = await SqlRoleDefinitionCollection.ExistsAsync(RoleDefinitionId);
            Assert.True(ifExists);

            CosmosDBSqlRoleDefinitionResource definition2 = await SqlRoleDefinitionCollection.GetAsync(RoleDefinitionId);
            Assert.AreEqual(_roleDefinition.Data.Name, definition2.Data.Name);
            VerifySqlRoleDefinitions(definition, definition2);

            var updateParameters = new CosmosDBSqlRoleDefinitionCreateOrUpdateContent
            {
                RoleName = _roleDefinition.Data.Name,
                RoleDefinitionType = CosmosDBSqlRoleDefinitionType.CustomRole,
                AssignableScopes = { SqlDatabaseActionScope },
                Permissions = { new CosmosDBSqlRolePermission { DataActions = { PermissionDataActionRead } } },
            };
            definition = await (await SqlRoleDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, RoleDefinitionId, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(_roleDefinition.Data.Name, definition.Data.Name);
            Assert.That(definition.Data.AssignableScopes, Has.Count.EqualTo(1));
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
            Assert.That(definitions, Is.Not.Zero);
            Assert.AreEqual(definition.Data.Name, definitions[0].Data.Name);

            VerifySqlRoleDefinitions(definitions[0], definition);
        }

        [Test]
        [RecordedTest]
        public async Task SqlRoleDefinitionDelete()
        {
            var definition = await CreateSqlRoleDefinition(SqlDatabaseActionScope, SqlRoleDefinitionCollection);
            await definition.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await SqlRoleDefinitionCollection.ExistsAsync(RoleDefinitionId));
        }

        private async Task<CosmosDBSqlRoleDefinitionResource> CreateSqlRoleDefinition(string assignableScope, CosmosDBSqlRoleDefinitionCollection definitionCollection)
        {
            var roleDefinitionName = Recording.GenerateAssetName("sql-role-def-");
            _roleDefinition = await CreateSqlRoleDefinition(roleDefinitionName, assignableScope, definitionCollection);
            return _roleDefinition;
        }

        internal static async Task<CosmosDBSqlRoleDefinitionResource> CreateSqlRoleDefinition(string name, string assignableScope, CosmosDBSqlRoleDefinitionCollection definitionCollection)
        {
            return await CreateSqlRoleDefinition(RoleDefinitionId, name, assignableScope, definitionCollection).ConfigureAwait(false);
        }

        internal static async Task<CosmosDBSqlRoleDefinitionResource> CreateSqlRoleDefinition(string roleDefinitionId, string name, string assignableScope, CosmosDBSqlRoleDefinitionCollection definitionCollection)
        {
            //RoleDefinitionId = Recording.GenerateAssetName("sql-role-");
            var parameters = new CosmosDBSqlRoleDefinitionCreateOrUpdateContent
            {
                RoleName = name,
                RoleDefinitionType = CosmosDBSqlRoleDefinitionType.CustomRole,
                AssignableScopes = { assignableScope },
                Permissions = { new CosmosDBSqlRolePermission { DataActions = { PermissionDataActionCreate } } },
            };
            var definitionLro = await definitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, roleDefinitionId, parameters);
            return definitionLro.Value;
        }

        private void VerifySqlRoleDefinitions(CosmosDBSqlRoleDefinitionResource expectedValue, CosmosDBSqlRoleDefinitionResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.RoleName, actualValue.Data.RoleName);

            Assert.AreEqual(expectedValue.Data.AssignableScopes, actualValue.Data.AssignableScopes);
            VerifyPermissions(expectedValue.Data.Permissions, actualValue.Data.Permissions);
        }

        private void VerifyPermissions(IList<CosmosDBSqlRolePermission> expected, IList<CosmosDBSqlRolePermission> actualValue)
        {
            Assert.AreEqual(expected.Count, actualValue.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                VerifyPermission(expected[i], actualValue[i]);
            }
        }

        private void VerifyPermission(CosmosDBSqlRolePermission expected, CosmosDBSqlRolePermission actualValue)
        {
            Assert.AreEqual(expected.DataActions, actualValue.DataActions);
            Assert.AreEqual(expected.NotDataActions, actualValue.NotDataActions);
        }
    }
}
