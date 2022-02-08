﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private DatabaseAccount _databaseAccount;
        private SqlDatabase _sqlDatabase;
        private ResourceIdentifier _sqlContainerId;
        private SqlContainer _sqlContainer;
        private string _triggerName;

        public SqlTriggerTests(bool isAsync) : base(isAsync)
        {
        }

        protected SqlTriggerCollection SqlTriggerCollection { get => _sqlContainer.GetSqlTriggers(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccount = await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.GlobalDocumentDB);

            _sqlDatabase = await SqlDatabaseTests.CreateSqlDatabase(SessionRecording.GenerateAssetName("sql-db-"), null, _databaseAccount.GetSqlDatabases());

            _sqlContainerId = (await SqlContainerTests.CreateSqlContainer(SessionRecording.GenerateAssetName("sql-container-"), null, _sqlDatabase.GetSqlContainers())).Id;

            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            _sqlContainer.Delete(true);
            _sqlDatabase.Delete(true);
            _databaseAccount.Delete(true);
        }

        [SetUp]
        public async Task SetUp()
        {
            _sqlContainer = await ArmClient.GetSqlContainer(_sqlContainerId).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            SqlTrigger trigger = await SqlTriggerCollection.GetIfExistsAsync(_triggerName);
            if (trigger != null)
            {
                await trigger.DeleteAsync(true);
            }
        }

        [Test]
        [RecordedTest]
        public async Task SqlTriggerCreateAndUpdate()
        {
            var trigger = await CreateSqlTrigger(null);
            Assert.AreEqual(_triggerName, trigger.Data.Resource.Id);
            Assert.That(trigger.Data.Resource.Body, Contains.Substring("First Hello World"));
            Assert.AreEqual(trigger.Data.Resource.TriggerOperation, TriggerOperation.All);
            Assert.AreEqual(trigger.Data.Resource.TriggerType, TriggerType.Pre);

            // Seems bug in swagger definition
            //Assert.AreEqual(TestThroughput1, container.Data.Options.Throughput);

            bool ifExists = await SqlTriggerCollection.ExistsAsync(_triggerName);
            Assert.True(ifExists);

            SqlTrigger trigger2 = await SqlTriggerCollection.GetAsync(_triggerName);
            Assert.AreEqual(_triggerName, trigger2.Data.Resource.Id);

            VerifySqlTriggers(trigger, trigger2);

            SqlTriggerCreateUpdateOptions updateOptions = new SqlTriggerCreateUpdateOptions(trigger.Id, _triggerName, trigger.Data.Type, null,
                new Dictionary<string, string>(),// TODO: use original tags see defect: https://github.com/Azure/autorest.csharp/issues/1590
                AzureLocation.WestUS, trigger.Data.Resource, new CreateUpdateOptions());
            updateOptions = new SqlTriggerCreateUpdateOptions(AzureLocation.WestUS, new SqlTriggerResource(_triggerName)
            {
                TriggerOperation = TriggerOperation.Create,
                TriggerType = TriggerType.Post,
                Body = @"function () { var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('Second Hello World');
}"
            });

            trigger = (await SqlTriggerCollection.CreateOrUpdateAsync(true, _triggerName, updateOptions)).Value;
            Assert.AreEqual(_triggerName, trigger.Data.Resource.Id);
            Assert.That(trigger.Data.Resource.Body, Contains.Substring("Second Hello World"));
            Assert.AreEqual(trigger.Data.Resource.TriggerOperation, TriggerOperation.Create);
            Assert.AreEqual(trigger.Data.Resource.TriggerType, TriggerType.Post);

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
            await trigger.DeleteAsync(true);

            trigger = await SqlTriggerCollection.GetIfExistsAsync(_triggerName);
            Assert.Null(trigger);
        }

        protected async Task<SqlTrigger> CreateSqlTrigger(AutoscaleSettings autoscale)
        {
            _triggerName = Recording.GenerateAssetName("sql-trigger-");
            SqlTriggerCreateUpdateOptions sqlDatabaseCreateUpdateOptions = new SqlTriggerCreateUpdateOptions(AzureLocation.WestUS,
                new SqlTriggerResource(_triggerName)
                {
                    TriggerOperation = TriggerOperation.All,
                    TriggerType = TriggerType.Pre,
                    Body = @"function () {
    var updatetext = getContext();
    var response = context.getResponse();
    response.setBody('First Hello World');
}"
                })
            {
                Options = BuildDatabaseCreateUpdateOptions(TestThroughput1, autoscale),
            };
            var sqlContainerLro = await SqlTriggerCollection.CreateOrUpdateAsync(true, _triggerName, sqlDatabaseCreateUpdateOptions);
            return sqlContainerLro.Value;
        }

        private void VerifySqlTriggers(SqlTrigger expectedValue, SqlTrigger actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.Resource.Id, actualValue.Data.Resource.Id);
            Assert.AreEqual(expectedValue.Data.Resource.Rid, actualValue.Data.Resource.Rid);
            Assert.AreEqual(expectedValue.Data.Resource.Ts, actualValue.Data.Resource.Ts);
            Assert.AreEqual(expectedValue.Data.Resource.Etag, actualValue.Data.Resource.Etag);
            Assert.AreEqual(expectedValue.Data.Resource.Body, actualValue.Data.Resource.Body);
            Assert.AreEqual(expectedValue.Data.Resource.TriggerType, actualValue.Data.Resource.TriggerType);
            Assert.AreEqual(expectedValue.Data.Resource.TriggerOperation, actualValue.Data.Resource.TriggerOperation);
        }
    }
}
