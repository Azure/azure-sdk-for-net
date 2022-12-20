// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Relay.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Relay.Tests
{
    public class HybridConnectionTests: RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private RelayNamespaceResource _relayNamespace;
        private RelayPrivateEndpointConnectionCollection _privateEndpointConnectionCollection { get => _relayNamespace.GetRelayPrivateEndpointConnections(); }
        public HybridConnectionTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            RelayNamespaceCollection namespaceCollection = _resourceGroup.GetRelayNamespaces();
            _relayNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new RelayNamespaceData(DefaultLocation))).Value;
        }

        [Test]
        [RecordedTest]
        public async Task HybridConnectionTest()
        {
            RelayHybridConnectionCollection _relayHybridConnectionCollection = _relayNamespace.GetRelayHybridConnections();
            RelayHybridConnectionResource _relayHybridConnectionResource = (await _relayHybridConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h1", new RelayHybridConnectionData()
                {
                    IsClientAuthorizationRequired = true,
                    UserMetadata = "test metadata"
                })).Value;
            Assert.True(_relayHybridConnectionResource.Data.IsClientAuthorizationRequired);
            Assert.AreEqual("test metadata", _relayHybridConnectionResource.Data.UserMetadata);

            _relayHybridConnectionResource.Data.UserMetadata = "second metadata";

            //Update Relay namespace
            _relayHybridConnectionResource = (await _relayHybridConnectionResource.UpdateAsync(WaitUntil.Completed, _relayHybridConnectionResource.Data)).Value;
            Assert.True(_relayHybridConnectionResource.Data.IsClientAuthorizationRequired);
            Assert.AreEqual("second metadata", _relayHybridConnectionResource.Data.UserMetadata);

            //Create another relay namespace
            _relayHybridConnectionResource = (await _relayHybridConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h2", new RelayHybridConnectionData()
                {
                    IsClientAuthorizationRequired = false
                })).Value;
            Assert.False(_relayHybridConnectionResource.Data.IsClientAuthorizationRequired);
            Assert.Null(_relayHybridConnectionResource.Data.UserMetadata);

            RelayHybridConnectionResource _relayHybridConnectionResource2 = (await _relayHybridConnectionCollection.GetAsync("h1"))?.Value;
            Assert.True(_relayHybridConnectionResource2.Data.IsClientAuthorizationRequired);
            Assert.AreEqual("second metadata", _relayHybridConnectionResource2.Data.UserMetadata);

            // List all hybrid connections
            var listOfHybridConnections = await _relayHybridConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, listOfHybridConnections.Count);

            await _relayHybridConnectionResource2.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _relayHybridConnectionResource2.GetAsync(); });
            Assert.AreEqual(404, exception.Status);
        }
    }
}
