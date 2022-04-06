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
        private ResourceGroupResource _resourceGroup;
        private SchemaGroupCollection _schemaGroupCollection;
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespaceResource eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            _schemaGroupCollection = eHNamespace.GetSchemaGroups();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
                List<EventHubNamespaceResource> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (EventHubNamespaceResource eventHubNamespace in namespaceList)
                {
                    await eventHubNamespace.DeleteAsync(WaitUntil.Completed);
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
            SchemaGroupResource schemaGroup = (await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaGroupName, parameters)).Value;
            Assert.NotNull(schemaGroup);
            Assert.AreEqual(schemaGroupName, schemaGroup.Id.Name);

            //validate if created successfully
            Assert.IsTrue(await _schemaGroupCollection.ExistsAsync(schemaGroupName));
            schemaGroup = await _schemaGroupCollection.GetAsync(schemaGroupName);

            //delete eventhub
            await schemaGroup.DeleteAsync(WaitUntil.Completed);

            //validate
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _schemaGroupCollection.GetAsync(schemaGroupName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _schemaGroupCollection.ExistsAsync(schemaGroupName));
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
            _ = (await _schemaGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaGroupName1, parameters)).Value;

            //validate
            int count = 0;
            SchemaGroupResource schemaGroup1 = null;
            await foreach (SchemaGroupResource schemaGroup in _schemaGroupCollection.GetAllAsync())
            {
                count++;
                if (schemaGroup.Id.Name == schemaGroupName1)
                    schemaGroup1 = schemaGroup;
            }
        }
    }
}
