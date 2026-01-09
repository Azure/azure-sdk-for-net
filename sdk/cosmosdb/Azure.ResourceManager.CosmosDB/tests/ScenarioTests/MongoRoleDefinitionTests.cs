// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class MongoRoleDefinitionTests : CosmosDBManagementClientBase
    {
        private const string PrivilegeActionInsert = "insert";
        private const string PrivilegeActionFind = "find";

        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _mongoDBDatabaseId;
        private MongoDBDatabaseResource _mongoDBDatabase;
        private string _roleDefinitionId;

        private MongoDBRoleDefinitionResource _roleDefinition;

        public MongoRoleDefinitionTests(bool isAsync) : base(isAsync)
        {
        }

        private MongoDBRoleDefinitionCollection MongoRoleDefinitionCollection { get => _databaseAccount.GetMongoDBRoleDefinitions(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            List<CosmosDBAccountCapability> capabilities = new List<CosmosDBAccountCapability>();
            capabilities.Add(new CosmosDBAccountCapability("EnableMongo", null));
            capabilities.Add(new CosmosDBAccountCapability("EnableMongoRoleBasedAccessControl", null));
            _databaseAccount = await CreateDatabaseAccount(Recording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB, capabilities);

            _mongoDBDatabase = await MongoDBDatabaseTests.CreateMongoDBDatabase(SessionRecording.GenerateAssetName("mongodb-"), null, _databaseAccount.GetMongoDBDatabases());
            _mongoDBDatabaseId = _mongoDBDatabase.Id;
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_roleDefinition != null)
                {
                    if (await MongoRoleDefinitionCollection.ExistsAsync(this._roleDefinitionId))
                    {
                        await _roleDefinition.DeleteAsync(WaitUntil.Completed);
                    }
                }
                await _mongoDBDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoRoleDefinitionCreateAndUpdate()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoRoleDefinition(databaseName, MongoRoleDefinitionCollection);
            Assert.Multiple(() =>
            {
                Assert.That(definition.Data.Name, Is.EqualTo(_roleDefinition.Data.Name));
                Assert.That(databaseName, Is.EqualTo(definition.Data.DatabaseName));
                Assert.That(definition.Data.Privileges, Has.Count.EqualTo(1));
            });
            Assert.That(definition.Data.Privileges[0].Actions, Has.Count.EqualTo(1));
            Assert.That(definition.Data.Privileges[0].Actions[0], Is.EqualTo(PrivilegeActionInsert));

            bool ifExists = await MongoRoleDefinitionCollection.ExistsAsync(this._roleDefinitionId);
            Assert.That(ifExists, Is.True);

            MongoDBRoleDefinitionResource definition2 = await MongoRoleDefinitionCollection.GetAsync(this._roleDefinitionId);
            Assert.That(definition2.Data.Name, Is.EqualTo(_roleDefinition.Data.Name));
            VerifyMongoRoleDefinitions(definition, definition2);

            var updateParameters = new MongoDBRoleDefinitionCreateOrUpdateContent
            {
                RoleName = _roleDefinition.Data.Name,
                DatabaseName = databaseName,
                DefinitionType = MongoDBRoleDefinitionType.CustomRole,
            };

            MongoDBPrivilege privilege = new MongoDBPrivilege
            {
                Resource = new MongoDBPrivilegeResourceInfo
                {
                    DBName = databaseName,
                    Collection = "test"
                },
            };

            privilege.Actions.Add(PrivilegeActionFind);
            updateParameters.Privileges.Add(privilege);

            definition = await (await MongoRoleDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, this._roleDefinitionId, updateParameters)).WaitForCompletionAsync();
            Assert.That(definition.Data.Name, Is.EqualTo(_roleDefinition.Data.Name));
            Assert.Multiple(() =>
            {
                Assert.That(definition.Data.Name, Is.EqualTo(_roleDefinition.Data.Name));
                Assert.That(databaseName, Is.EqualTo(definition.Data.DatabaseName));
                Assert.That(definition.Data.Privileges, Has.Count.EqualTo(1));
            });
            Assert.That(definition.Data.Privileges[0].Actions, Has.Count.EqualTo(1));
            Assert.That(definition.Data.Privileges[0].Actions[0], Is.EqualTo(PrivilegeActionFind));

            definition2 = await MongoRoleDefinitionCollection.GetAsync(this._roleDefinitionId);
            VerifyMongoRoleDefinitions(definition, definition2);
        }

        [Test]
        [RecordedTest]
        public async Task MongoRoleDefinitionList()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoRoleDefinition(databaseName, MongoRoleDefinitionCollection);

            var definitions = await MongoRoleDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(definitions, Is.Not.Zero);
            Assert.That(definitions[0].Data.Name, Is.EqualTo(definition.Data.Name));

            VerifyMongoRoleDefinitions(definitions[0], definition);
        }

        [Test]
        [RecordedTest]
        public async Task MognoRoleDefinitionDelete()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoRoleDefinition(databaseName, MongoRoleDefinitionCollection);
            await definition.DeleteAsync(WaitUntil.Completed);

            Assert.That((bool)await MongoRoleDefinitionCollection.ExistsAsync(this._roleDefinition.Data.Id.Name), Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task MognoRoleDefinitionGet()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoRoleDefinition(databaseName, MongoRoleDefinitionCollection);
            var definition2 = await definition.GetAsync();

            Assert.That((bool)await MongoRoleDefinitionCollection.ExistsAsync(this._roleDefinition.Data.Id.Name), Is.True);
            VerifyMongoRoleDefinitions(definition, definition2);
        }

        private async Task<MongoDBRoleDefinitionResource> CreateMongoRoleDefinition(string databaseName, MongoDBRoleDefinitionCollection definitionCollection)
        {
            var roleDefinitionName = Recording.GenerateAssetName("mongo-role-def-");
            _roleDefinition = await CreateMongoRoleDefinition(roleDefinitionName, databaseName, definitionCollection);
            return _roleDefinition;
        }

        internal async Task<MongoDBRoleDefinitionResource> CreateMongoRoleDefinition(string roleDefinitionName, string databaseName, MongoDBRoleDefinitionCollection definitionCollection)
        {
            this._roleDefinitionId = $"{databaseName}.{roleDefinitionName}";
            var parameters = new MongoDBRoleDefinitionCreateOrUpdateContent
            {
                RoleName = roleDefinitionName,
                DatabaseName = databaseName,
                DefinitionType = MongoDBRoleDefinitionType.CustomRole,
            };

            MongoDBPrivilege privilege = new MongoDBPrivilege
            {
                Resource = new MongoDBPrivilegeResourceInfo
                {
                    DBName = databaseName,
                    Collection = "test"
                },
            };

            privilege.Actions.Add(PrivilegeActionInsert);
            parameters.Privileges.Add(privilege);

            var definition = await definitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, this._roleDefinitionId, parameters);
            return definition.Value;
        }

        private void VerifyMongoRoleDefinitions(MongoDBRoleDefinitionResource expectedValue, MongoDBRoleDefinitionResource actualValue)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
                Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
                Assert.That(actualValue.Data.ResourceType, Is.EqualTo(expectedValue.Data.ResourceType));

                Assert.That(actualValue.Data.RoleName, Is.EqualTo(expectedValue.Data.RoleName));

                Assert.That(actualValue.Data.DatabaseName, Is.EqualTo(expectedValue.Data.DatabaseName));
            });
            VerifyPrivileges(expectedValue.Data.Privileges, actualValue.Data.Privileges);
        }

        private void VerifyPrivileges(IList<MongoDBPrivilege> expected, IList<MongoDBPrivilege> actualValue)
        {
            Assert.That(actualValue, Has.Count.EqualTo(expected.Count));
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actualValue[i].Actions[0], Is.EqualTo(expected[i].Actions[0]));
                VerifyPrivilegeResource(expected[i].Resource, actualValue[i].Resource);
            }
        }

        private void VerifyPrivilegeResource(MongoDBPrivilegeResourceInfo expected, MongoDBPrivilegeResourceInfo actualValue)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualValue.DBName, Is.EqualTo(expected.DBName));
                Assert.That(actualValue.Collection, Is.EqualTo(expected.Collection));
            });
        }
    }
}
