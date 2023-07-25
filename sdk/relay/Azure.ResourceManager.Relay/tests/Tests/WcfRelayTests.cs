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
    public class WcfRelayTests : RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private RelayNamespaceResource _relayNamespace;
        public WcfRelayTests(bool async) : base(async)
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
        public async Task WcfRelayTest()
        {
            WcfRelayCollection _wcfRelayCollection = _relayNamespace.GetWcfRelays();
            WcfRelayResource _wcfRelayResource = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h1", new WcfRelayData()
            {
                IsClientAuthorizationRequired = true,
                UserMetadata = "test metadata",
                IsTransportSecurityRequired = false,
                RelayType = Models.RelayType.NetTcp
            })).Value;
            Assert.True(_wcfRelayResource.Data.IsClientAuthorizationRequired);
            Assert.False(_wcfRelayResource.Data.IsTransportSecurityRequired);
            Assert.AreEqual("test metadata", _wcfRelayResource.Data.UserMetadata);
            Assert.AreEqual(Models.RelayType.NetTcp, _wcfRelayResource.Data.RelayType);

            _wcfRelayResource.Data.UserMetadata = "second metadata";

            //Update Relay namespace
            _wcfRelayResource = (await _wcfRelayResource.UpdateAsync(WaitUntil.Completed, _wcfRelayResource.Data)).Value;
            Assert.True(_wcfRelayResource.Data.IsClientAuthorizationRequired);
            Assert.False(_wcfRelayResource.Data.IsTransportSecurityRequired);
            Assert.AreEqual("second metadata", _wcfRelayResource.Data.UserMetadata);
            Assert.AreEqual(Models.RelayType.NetTcp, _wcfRelayResource.Data.RelayType);

            //Create another relay namespace
            _wcfRelayResource = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h2", new WcfRelayData()
            {
                IsClientAuthorizationRequired = false,
                IsTransportSecurityRequired = false,
                RelayType = Models.RelayType.Http
            })).Value;
            Assert.False(_wcfRelayResource.Data.IsClientAuthorizationRequired);
            Assert.False(_wcfRelayResource.Data.IsTransportSecurityRequired);
            Assert.Null(_wcfRelayResource.Data.UserMetadata);
            Assert.AreEqual(Models.RelayType.Http, _wcfRelayResource.Data.RelayType);

            //Create another relay namespace
            _wcfRelayResource = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h3", new WcfRelayData()
            {
                IsClientAuthorizationRequired = true,
                IsTransportSecurityRequired = true,
                RelayType = Models.RelayType.Http
            })).Value;
            Assert.True(_wcfRelayResource.Data.IsClientAuthorizationRequired);
            Assert.True(_wcfRelayResource.Data.IsTransportSecurityRequired);
            Assert.Null(_wcfRelayResource.Data.UserMetadata);
            Assert.AreEqual(Models.RelayType.Http, _wcfRelayResource.Data.RelayType);

            WcfRelayResource _wcfRelayResource2 = (await _wcfRelayCollection.GetAsync("h1"))?.Value;
            Assert.True(_wcfRelayResource2.Data.IsClientAuthorizationRequired);
            Assert.False(_wcfRelayResource2.Data.IsTransportSecurityRequired);
            Assert.AreEqual("second metadata", _wcfRelayResource2.Data.UserMetadata);
            Assert.AreEqual(Models.RelayType.NetTcp, _wcfRelayResource2.Data.RelayType);

            // List all hybrid connections
            var listOfWcfRelay = await _wcfRelayCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, listOfWcfRelay.Count);

            await _wcfRelayResource2.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _wcfRelayResource2.GetAsync(); });
            Assert.AreEqual(404, exception.Status);
        }
    }
}
