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
    public class MongoUserDefinitionTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private ResourceIdentifier _mongoDBDatabaseId;
        private MongoDBDatabaseResource _mongoDBDatabase;
        private string _userDefinitionId;

        private MongoDBUserDefinitionResource _userDefinition;

        public MongoUserDefinitionTests(bool isAsync) : base(isAsync)
        {
        }

        private MongoDBUserDefinitionCollection MongoUserDefinitionCollection { get => _databaseAccount.GetMongoDBUserDefinitions(); }

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
                if (_userDefinition != null)
                {
                    if (await MongoUserDefinitionCollection.ExistsAsync(this._userDefinitionId))
                    {
                        await _userDefinition.DeleteAsync(WaitUntil.Completed);
                    }
                }
                await _mongoDBDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task MongoUserDefinitionCreateAndUpdate()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoUserDefinition(databaseName, MongoUserDefinitionCollection);
            Assert.AreEqual(_userDefinition.Data.Name, definition.Data.Name);
            Assert.AreEqual(definition.Data.DatabaseName, databaseName);
            Assert.AreEqual(definition.Data.UserName, _userDefinition.Data.UserName);
            Assert.AreEqual(definition.Data.CustomData, _userDefinition.Data.CustomData);
            Assert.AreEqual(definition.Data.Mechanisms, _userDefinition.Data.Mechanisms);
            Assert.That(definition.Data.Roles, Has.Count.EqualTo(1));

            bool ifExists = await MongoUserDefinitionCollection.ExistsAsync(this._userDefinitionId);
            Assert.True(ifExists);

            MongoDBUserDefinitionResource definition2 = await MongoUserDefinitionCollection.GetAsync(this._userDefinitionId);
            Assert.AreEqual(_userDefinition.Data.Name, definition2.Data.Name);
            VerifyMongoUserDefinitions(definition, definition2);

            var password = Recording.GenerateAssetName("mongo-user-pass-");
            var updateParameters = new MongoDBUserDefinitionCreateOrUpdateContent
            {
                UserName = _userDefinition.Data.Name,
                DatabaseName = _userDefinition.Data.DatabaseName,
                Password = password,
                CustomData = _userDefinition.Data.CustomData,
                Mechanisms = _userDefinition.Data.Mechanisms
            };

            MongoDBRole role = new MongoDBRole
            {
                DBName = databaseName,
                Role = "readWrite"
            };
            updateParameters.Roles.Add(role);

            definition = await (await MongoUserDefinitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, this._userDefinitionId, updateParameters)).WaitForCompletionAsync();
            Assert.AreEqual(_userDefinition.Data.Name, definition.Data.Name);
            Assert.AreEqual(definition.Data.DatabaseName, databaseName);
            Assert.AreEqual(definition.Data.UserName, _userDefinition.Data.UserName);
            Assert.AreEqual(definition.Data.CustomData, _userDefinition.Data.CustomData);
            Assert.AreEqual(definition.Data.Mechanisms, _userDefinition.Data.Mechanisms);
            Assert.That(definition.Data.Roles, Has.Count.EqualTo(1));

            definition2 = await MongoUserDefinitionCollection.GetAsync(this._userDefinitionId);
            VerifyMongoUserDefinitions(definition, definition2);
        }

        [Test]
        [RecordedTest]
        public async Task MongoUserDefinitionList()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoUserDefinition(databaseName, MongoUserDefinitionCollection);

            var definitions = await MongoUserDefinitionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(definitions, Is.Not.Zero);
            Assert.AreEqual(definition.Data.Name, definitions[0].Data.Name);

            VerifyMongoUserDefinitions(definitions[0], definition);
        }

        [Test]
        [RecordedTest]
        public async Task MognoUserDefinitionDelete()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoUserDefinition(databaseName, MongoUserDefinitionCollection);
            await definition.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await MongoUserDefinitionCollection.ExistsAsync(this._userDefinition.Data.Id.Name));
        }

        [Test]
        [RecordedTest]
        public async Task MognoUserDefinitionGet()
        {
            string databaseName = _mongoDBDatabaseId.Name;
            var definition = await CreateMongoUserDefinition(databaseName, MongoUserDefinitionCollection);
            var definition2 = await definition.GetAsync();

            Assert.IsTrue(await MongoUserDefinitionCollection.ExistsAsync(this._userDefinition.Data.Id.Name));
            VerifyMongoUserDefinitions(definition, definition2);
        }

        private async Task<MongoDBUserDefinitionResource> CreateMongoUserDefinition(string databaseName, MongoDBUserDefinitionCollection definitionCollection)
        {
            var userName = Recording.GenerateAssetName("mongo-user-def-");
            var password = Recording.GenerateAssetName("mongo-user-pass-");
            _userDefinition = await CreateMongoUserDefinition(userName, password, databaseName, definitionCollection);
            return _userDefinition;
        }

        internal async Task<MongoDBUserDefinitionResource> CreateMongoUserDefinition(string userName, string password, string databaseName, MongoDBUserDefinitionCollection definitionCollection)
        {
            this._userDefinitionId = $"{databaseName}.{userName}";
            var parameters = new MongoDBUserDefinitionCreateOrUpdateContent
            {
                UserName  = userName,
                Password = password,
                DatabaseName = databaseName,
                CustomData = "My Custm Data",
                Mechanisms = "SCRAM-SHA-256"
            };

            MongoDBRole role = new MongoDBRole
            {
                DBName = databaseName,
                Role = "read"
            };
            parameters.Roles.Add(role);

            var definition = await definitionCollection.CreateOrUpdateAsync(WaitUntil.Completed, this._userDefinitionId, parameters);
            return definition.Value;
        }

        private void VerifyMongoUserDefinitions(MongoDBUserDefinitionResource expectedValue, MongoDBUserDefinitionResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.ResourceType, actualValue.Data.ResourceType);

            Assert.AreEqual(expectedValue.Data.UserName, actualValue.Data.UserName);
            Assert.AreEqual(expectedValue.Data.Mechanisms, actualValue.Data.Mechanisms);
            Assert.AreEqual(expectedValue.Data.CustomData, actualValue.Data.CustomData);

            VerifyRoles(expectedValue.Data.Roles, actualValue.Data.Roles);
        }

        private void VerifyRoles(IList<MongoDBRole> expected, IList<MongoDBRole> actualValue)
        {
            Assert.AreEqual(expected.Count, actualValue.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].DBName, actualValue[i].DBName);
                Assert.AreEqual(expected[i].Role, actualValue[i].Role);
            }
        }
    }
}
