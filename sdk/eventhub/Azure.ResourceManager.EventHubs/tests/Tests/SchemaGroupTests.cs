// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class SchemaGroupTests : EventHubTestBase
    {
        public SchemaGroupTests(bool isAsync): base(isAsync)
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
            EventHubsNamespaceResource eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(DefaultLocation))).Value;
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
            EventHubsSchemaGroupResource schemaGroup = (await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaGroupName, parameters)).Value;
            Assert.NotNull(schemaGroup);
            Assert.AreEqual(schemaGroupName, schemaGroup.Id.Name);

            //validate if created successfully
            Assert.IsTrue(await _schemaGroupCollection.ExistsAsync(schemaGroupName));
            schemaGroup = await _schemaGroupCollection.GetAsync(schemaGroupName);

            //delete eventhub
            await schemaGroup.DeleteAsync(WaitUntil.Completed);
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
            _ = (await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaGroupName1, parameters)).Value;

            //validate
            int count = 0;
            await foreach (EventHubsSchemaGroupResource schemaGroup in _schemaGroupCollection.GetAllAsync())
            {
                if (schemaGroup.Id.Name == schemaGroupName1)
                    count++;
            }
            Assert.AreEqual(1, count);
        }
    }
}
