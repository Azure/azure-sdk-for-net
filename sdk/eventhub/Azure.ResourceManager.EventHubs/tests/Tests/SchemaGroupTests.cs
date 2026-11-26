// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class SchemaGroupTests : EventHubTestBase
    {
        public SchemaGroupTests(bool isAsync) : base(isAsync)
        {
        }
        private ResourceGroupResource _resourceGroup;
        private EventHubsSchemaGroupCollection _schemaGroupCollection;
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubsNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eHNamespace = await CreateNamespaceAsync(_resourceGroup, namespaceName);
            _schemaGroupCollection = eHNamespace.GetEventHubsSchemaGroups();
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteSchemaGroup()
        {
            //create schema group
            string schemaGroupName = Recording.GenerateAssetName("schemagroup");
            EventHubsSchemaGroupData parameters = new EventHubsSchemaGroupData()
            {
                SchemaType = EventHubsSchemaType.Avro
            };
            EventHubsSchemaGroupResource schemaGroup = await CompleteAsync(await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, schemaGroupName, parameters));
            Assert.NotNull(schemaGroup);
            Assert.AreEqual(schemaGroupName, schemaGroup.Id.Name);

            //validate if created successfully
            Assert.IsTrue(await _schemaGroupCollection.ExistsAsync(schemaGroupName));
            schemaGroup = await _schemaGroupCollection.GetAsync(schemaGroupName);

            //delete eventhub
            await CompleteAsync(await schemaGroup.DeleteAsync(WaitUntil.Started));
            Assert.IsFalse(await _schemaGroupCollection.ExistsAsync(schemaGroupName));
            RequestFailedException failure = Assert.ThrowsAsync<RequestFailedException>(async () => await _schemaGroupCollection.GetAsync(schemaGroupName));
            Assert.AreEqual(404, failure.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllSchemaGroups()
        {
            //create a schema group
            string schemaGroupName1 = Recording.GenerateAssetName("schemagroup1");
            EventHubsSchemaGroupData parameters = new EventHubsSchemaGroupData()
            {
                SchemaType = EventHubsSchemaType.Avro
            };
            await CompleteAsync(await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Started, schemaGroupName1, parameters));

            //validate
            int count = 0;
            foreach (EventHubsSchemaGroupResource schemaGroup in await ReadAllAsync(_schemaGroupCollection.GetAllAsync()))
            {
                if (schemaGroup.Id.Name == schemaGroupName1)
                    count++;
            }
            Assert.AreEqual(1, count);
        }

        [RecordedTest]
        public async Task UpdateSchemaGroup()
        {
            string name = Recording.GenerateAssetName("schemagroup");
            EventHubsSchemaGroupResource resource = await CompleteAsync(await _schemaGroupCollection.CreateOrUpdateAsync(
                WaitUntil.Started, name, new EventHubsSchemaGroupData
                {
                    SchemaType = EventHubsSchemaType.Avro,
                    SchemaCompatibility = EventHubsSchemaCompatibility.Backward,
                    GroupProperties = { { "purpose", "initial" } }
                }));
            await CompleteAsync(await resource.UpdateAsync(WaitUntil.Started, new EventHubsSchemaGroupData
            {
                SchemaType = EventHubsSchemaType.Avro,
                SchemaCompatibility = EventHubsSchemaCompatibility.Backward,
                GroupProperties = { { "purpose", "updated" } }
            }));
            EventHubsSchemaGroupData data = null;
            for (int attempt = 0; attempt < 12; attempt++)
            {
                Response<EventHubsSchemaGroupResource> readBack = await resource.GetAsync();
                AssertStatus(readBack.GetRawResponse(), 200);
                data = readBack.Value.Data;
                if (data.GroupProperties.TryGetValue("purpose", out string purpose) && purpose == "updated")
                {
                    break;
                }
                if (attempt < 11 && Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
            Assert.AreEqual("updated", data.GroupProperties["purpose"]);
            Assert.AreEqual(EventHubsSchemaCompatibility.Backward, data.SchemaCompatibility);
            Assert.AreEqual(EventHubsSchemaType.Avro, data.SchemaType);
        }
    }
}
