// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlTriggerTests : CosmosDBManagementClientBase
    {
        private CosmosDBAccountResource _databaseAccount;
        private CosmosDBSqlDatabaseResource _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private CosmosDBSqlContainerResource _sqlContainer;
        private string _triggerName;

        public SqlTriggerTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBSqlTriggerCollection SqlTriggerCollection => _sqlContainer.GetCosmosDBSqlTriggers();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            IgnoreTestInNonWindowsAgent();

            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetCosmosDBSqlDatabases());

            _sqlContainerId = (await SqlContainerTests.CreateSqlContainer(SessionRecording.GenerateAssetName("sql-container-"), null, _sqlDatabase.GetCosmosDBSqlContainers())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await _sqlContainer.DeleteAsync(WaitUntil.Completed);
                await _sqlDatabase.DeleteAsync(WaitUntil.Completed);
                await _databaseAccount.DeleteAsync(WaitUntil.Completed);
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetCosmosDBSqlContainerResource(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await SqlTriggerCollection.ExistsAsync(_triggerName))
                {
                    var id = SqlTriggerCollection.Id;
                    id = CosmosDBSqlTriggerResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Parent.Parent.Name, id.Parent.Name, id.Name, _triggerName);
                    CosmosDBSqlTriggerResource trigger = this.ArmClient.GetCosmosDBSqlTriggerResource(id);
                    await trigger.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlTriggerCreateAndUpdate()
        {
            var trigger = await CreateSqlTrigger(null);
            Assert.AreEqual(_triggerName, trigger.Data.Resource.TriggerName);
            Assert.That(trigger.Data.Resource.Body, Contains.Substring("First Hello World"));
            Assert.AreEqual(trigger.Data.Resource.TriggerOperation, CosmosDBSqlTriggerOperation.All);
            Assert.AreEqual(trigger.Data.Resource.TriggerType, CosmosDBSqlTriggerType.Pre);

            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlTriggerCollection.ExistsAsync(_triggerName);
            Assert.True(ifExists);

            CosmosDBSqlTriggerResource trigger2 = await SqlTriggerCollection.GetAsync(_triggerName);
            Assert.AreEqual(_triggerName, trigger2.Data.Resource.TriggerName);

            VerifySqlTriggers(trigger, trigger2);

            var updateOptions = new CosmosDBSqlTriggerCreateOrUpdateContent(AzureLocation.WestUS, new Models.CosmosDBSqlTriggerResourceInfo(_triggerName)
            {
                TriggerOperation = CosmosDBSqlTriggerOperation.Create,
                TriggerType = CosmosDBSqlTriggerType.Post,
                Body = @"function () { var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('Second Hello World');
}"
            });

            trigger = (await SqlTriggerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _triggerName, updateOptions)).Value;
            Assert.AreEqual(_triggerName, trigger.Data.Resource.TriggerName);
            Assert.That(trigger.Data.Resource.Body, Contains.Substring("Second Hello World"));
            Assert.AreEqual(trigger.Data.Resource.TriggerOperation, CosmosDBSqlTriggerOperation.Create);
            Assert.AreEqual(trigger.Data.Resource.TriggerType, CosmosDBSqlTriggerType.Post);

            trigger2 = await SqlTriggerCollection.GetAsync(_triggerName);
            VerifySqlTriggers(trigger, trigger2);
        }

        [Test]
        [RecordedTest]
        public async Task SqlTriggerList()
        {
            var trigger = await CreateSqlTrigger(null);

            var triggers = await SqlTriggerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(triggers, Has.Count.EqualTo(1));
            Assert.AreEqual(trigger.Data.Name, triggers[0].Data.Name);

            VerifySqlTriggers(triggers[0], trigger);
        }

        [Test]
        [RecordedTest]
        public async Task SqlTriggerDelete()
        {
            var trigger = await CreateSqlTrigger(null);
            await trigger.DeleteAsync(WaitUntil.Completed);

            bool exists = await SqlTriggerCollection.ExistsAsync(_triggerName);
            Assert.IsFalse(exists);
        }

        internal async Task<CosmosDBSqlTriggerResource> CreateSqlTrigger(AutoscaleSettings autoscale)
        {
            _triggerName = Recording.GenerateAssetName("sql-trigger-");
            var sqlDatabaseCreateUpdateOptions = new CosmosDBSqlTriggerCreateOrUpdateContent(AzureLocation.WestUS,
                new Models.CosmosDBSqlTriggerResourceInfo(_triggerName)
                {
                    TriggerOperation = CosmosDBSqlTriggerOperation.All,
                    TriggerType = CosmosDBSqlTriggerType.Pre,
                    Body = @"function () {
    var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('First Hello World');
}"
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await SqlTriggerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _triggerName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlTriggers(CosmosDBSqlTriggerResource expectedValue, CosmosDBSqlTriggerResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.TriggerName, actualValue.Data.Resource.TriggerName);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Timestamp, actualValue.Data.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Data.Resource.ETag, actualValue.Data.Resource.ETag);
            Assert.AreEqual(expectedValue.Data.Resource.Body, actualValue.Data.Resource.Body);
            Assert.AreEqual(expectedValue.Data.Resource.TriggerType, actualValue.Data.Resource.TriggerType);
            Assert.AreEqual(expectedValue.Data.Resource.TriggerOperation, actualValue.Data.Resource.TriggerOperation);
        }
    }
}
