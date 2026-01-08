// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountSchemaTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountSchemaCollection _schemaCollection => _integrationAccount.GetIntegrationAccountSchemas();

        public IntegrationAccountSchemaTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountSchemaResource> CreateSchema(string schemaName)
        {
            string content = File.ReadAllText(@"TestData/OrderFile.xsd");
            IntegrationAccountSchemaData data = new IntegrationAccountSchemaData(_integrationAccount.Data.Location, IntegrationAccountSchemaType.Xml)
            {
                Content = BinaryData.FromObjectAsJson<string>(content),
                ContentType = "application/xml",
            };
            var schema = await _schemaCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaName, data);
            return schema.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string schemaName = Recording.GenerateAssetName("schema");
            var schema = await CreateSchema(schemaName);
            Assert.That(schema, Is.Not.Null);
            Assert.That(schema.Data.Name, Is.EqualTo(schemaName));
        }

        [RecordedTest]
        public async Task Exist()
        {
            string schemaName = Recording.GenerateAssetName("schema");
            await CreateSchema(schemaName);
            bool flag = await _schemaCollection.ExistsAsync(schemaName);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            string schemaName = Recording.GenerateAssetName("schema");
            await CreateSchema(schemaName);
            var schema = await _schemaCollection.GetAsync(schemaName);
            Assert.That(schema, Is.Not.Null);
            Assert.That(schema.Value.Data.Name, Is.EqualTo(schemaName));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string schemaName = Recording.GenerateAssetName("schema");
            await CreateSchema(schemaName);
            var list = await _schemaCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string schemaName = Recording.GenerateAssetName("schema");
            var schema = await CreateSchema(schemaName);
            bool flag = await _schemaCollection.ExistsAsync(schemaName);
            Assert.That(flag, Is.True);

            await schema.DeleteAsync(WaitUntil.Completed);
            flag = await _schemaCollection.ExistsAsync(schemaName);
            Assert.That(flag, Is.False);
        }
    }
}
