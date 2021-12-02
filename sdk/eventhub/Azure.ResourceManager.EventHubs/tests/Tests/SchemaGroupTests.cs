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
using Azure.ResourceManager.EventHubs.Tests.Helpers;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class SchemaGroupTests : EventHubTestBase
    {
        public SchemaGroupTests(bool isAsync): base(isAsync)
        {
        }
        private ResourceGroup _resourceGroup;
        private SchemaGroupCollection _schemaGroupCollection;
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            _schemaGroupCollection = eHNamespace.GetSchemaGroups();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
                List<EventHubNamespace> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (EventHubNamespace eventHubNamespace in namespaceList)
                {
                    await eventHubNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        [Ignore("get and list not working")]
        public async Task CreateDeleteSchemaGroup()
        {
            //create schema group
            string schemaGroupName = Recording.GenerateAssetName("schemagroup");
            SchemaGroupData parameters = new SchemaGroupData()
            {
                SchemaType = SchemaType.Avro
            };
            SchemaGroup schemaGroup = (await _schemaGroupCollection.CreateOrUpdateAsync(schemaGroupName, parameters)).Value;
            Assert.NotNull(schemaGroup);
            Assert.AreEqual(schemaGroupName, schemaGroup.Id.Name);

            //validate if created successfully
            schemaGroup = await _schemaGroupCollection.GetIfExistsAsync(schemaGroupName);
            Assert.NotNull(schemaGroup);
            Assert.IsTrue(await _schemaGroupCollection.CheckIfExistsAsync(schemaGroupName));

            //delete eventhub
            await schemaGroup.DeleteAsync();

            //validate
            schemaGroup = await _schemaGroupCollection.GetIfExistsAsync(schemaGroupName);
            Assert.Null(schemaGroup);
            Assert.IsFalse(await _schemaGroupCollection.CheckIfExistsAsync(schemaGroupName));
        }

        [Test]
        [RecordedTest]
        [Ignore("get and list not working")]
        public async Task GetAllSchemaGroups()
        {
            //create a schema group
            string schemaGroupName1 = Recording.GenerateAssetName("schemagroup1");
            SchemaGroupData parameters = new SchemaGroupData()
            {
                SchemaType = SchemaType.Avro
            };
            _ = (await _schemaGroupCollection.CreateOrUpdateAsync(schemaGroupName1, parameters)).Value;

            //validate
            int count = 0;
            SchemaGroup schemaGroup1 = null;
            await foreach (SchemaGroup schemaGroup in _schemaGroupCollection.GetAllAsync())
            {
                count++;
                if (schemaGroup.Id.Name == schemaGroupName1)
                    schemaGroup1 = schemaGroup;
            }
        }
    }
}
