// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relay.Models;
using Azure.ResourceManager.Relay.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Relay.Tests
{
    public class RelayNamespaceTests: RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private RelayNamespaceResource _relayNamespace;

        public RelayNamespaceTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
        }

        [Test]
        [RecordedTest]
        public async Task RelayNamespaceandCreateOrUpdateTest()
        {
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            RelayNamespaceCollection _relayNamespaceCollection = _resourceGroup.GetRelayNamespaces();

            RelayNamespaceData relayNamespaceData = new RelayNamespaceData(DefaultLocation)
                {
                    Sku = new Models.RelaySku("Standard")
                    {
                        Tier = "Standard"
                    }
                };

            _relayNamespace = (await _relayNamespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, relayNamespaceData)).Value;
            Assert.AreEqual(RelaySkuName.Standard, _relayNamespace.Data.Sku.Name);

            var listOfRelayNamespaces = await _relayNamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, listOfRelayNamespaces.Count);

            /*await _relayNamespace.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _relayNamespace.GetAsync(); });
            Assert.AreEqual(404, exception.Status);*/
        }
    }
}
