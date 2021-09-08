// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs.Tests.Tests
{
    public class EHNamespaceTests: EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        public EHNamespaceTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteNamespace()
        {
            //create namespace
            string namespaceName = Recording.GenerateAssetName("namespace");
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eHNamespace, true);

            //validate if created successfully
            eHNamespace = await namespaceContainer.GetAsync(namespaceName);
            Assert.IsTrue(await namespaceContainer.CheckIfExistsAsync(namespaceName));
            VerifyNamespaceProperties(eHNamespace, true);

            //delete namespace
            await eHNamespace.DeleteAsync();

            //validate if deleted successfully
            eHNamespace = await namespaceContainer.GetIfExistsAsync(namespaceName);
            Assert.IsNull(eHNamespace);
            Assert.IsFalse(await namespaceContainer.CheckIfExistsAsync(namespaceName));
        }
        [Test]
        [RecordedTest]
        public async Task UpdateNamespace()
        {
            //create namespace
            string namespaceName = Recording.GenerateAssetName("namespace");
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            VerifyNamespaceProperties(eHNamespace, true);

            //update namespace
            var updateNamespaceParameter = eHNamespace.Data;
            updateNamespaceParameter.Tags.Add("key1", "value1");
            updateNamespaceParameter.Tags.Add("key2", "value2");
            eHNamespace=await eHNamespace.UpdateAsync(updateNamespaceParameter);

            //validate
            Assert.AreEqual(eHNamespace.Data.Tags.Count,2);
            Assert.AreEqual("value1", eHNamespace.Data.Tags["key1"]);
            Assert.AreEqual("value2", eHNamespace.Data.Tags["key2"]);
        }
        [Test]
        [RecordedTest]
        public async Task GetAllNamespaces()
        {
            //create namespace
            string namespaceName1 = Recording.GenerateAssetName("namespace1");
            string namespaceName2 = Recording.GenerateAssetName("namespace2");
            _resourceGroup = await CreateResourceGroupAsync();
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName1, new EHNamespaceData(DefaultLocation))).Value;
            _ = (await namespaceContainer.CreateOrUpdateAsync(namespaceName2, new EHNamespaceData(DefaultLocation))).Value;
            int count = 0;
            EHNamespace namespace1 = null;
            EHNamespace namespace2 = null;
            await foreach (EHNamespace eHNamespace in namespaceContainer.GetAllAsync())
            {
                count++;
                if (eHNamespace.Id.Name == namespaceName1)
                    namespace1 = eHNamespace;
                if (eHNamespace.Id.Name == namespaceName1)
                    namespace2 = eHNamespace;
            }
            Assert.AreEqual(count, 2);
            VerifyNamespaceProperties(namespace1, true);
            VerifyNamespaceProperties(namespace2, true);
        }
    }
}
