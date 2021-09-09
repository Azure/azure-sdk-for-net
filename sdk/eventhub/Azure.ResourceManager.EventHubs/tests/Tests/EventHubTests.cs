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
    public class EventhubTests: EventHubTestBase
    {
        private ResourceGroup _resourceGroup;
        private EventhubContainer _eventhubContainer;
        public EventhubTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = Recording.GenerateAssetName("namespace");
            EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(DefaultLocation))).Value;
            _eventhubContainer=eHNamespace.GetEventhubs();
        }
        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EHNamespaceContainer namespaceContainer = _resourceGroup.GetEHNamespaces();
                List<EHNamespace> namespaceList = await namespaceContainer.GetAllAsync().ToEnumerableAsync();
                foreach (EHNamespace eHNamespace in namespaceList)
                {
                    await eHNamespace.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteEventHub()
        {
            string eventhubName = Recording.GenerateAssetName("eventhub");
            Eventhub eventhub = (await _eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
        }
    }
}
