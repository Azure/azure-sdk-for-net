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
            Assert.That(_wcfRelayResource.Data.IsClientAuthorizationRequired, Is.True);
            Assert.That(_wcfRelayResource.Data.IsTransportSecurityRequired, Is.False);
            Assert.That(_wcfRelayResource.Data.UserMetadata, Is.EqualTo("test metadata"));
            Assert.That(_wcfRelayResource.Data.RelayType, Is.EqualTo(Models.RelayType.NetTcp));

            _wcfRelayResource.Data.UserMetadata = "second metadata";

            //Update Relay namespace
            _wcfRelayResource = (await _wcfRelayResource.UpdateAsync(WaitUntil.Completed, _wcfRelayResource.Data)).Value;
            Assert.That(_wcfRelayResource.Data.IsClientAuthorizationRequired, Is.True);
            Assert.That(_wcfRelayResource.Data.IsTransportSecurityRequired, Is.False);
            Assert.That(_wcfRelayResource.Data.UserMetadata, Is.EqualTo("second metadata"));
            Assert.That(_wcfRelayResource.Data.RelayType, Is.EqualTo(Models.RelayType.NetTcp));

            //Create another relay namespace
            _wcfRelayResource = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h2", new WcfRelayData()
            {
                IsClientAuthorizationRequired = false,
                IsTransportSecurityRequired = false,
                RelayType = Models.RelayType.Http
            })).Value;
            Assert.That(_wcfRelayResource.Data.IsClientAuthorizationRequired, Is.False);
            Assert.That(_wcfRelayResource.Data.IsTransportSecurityRequired, Is.False);
            Assert.That(_wcfRelayResource.Data.UserMetadata, Is.Null);
            Assert.That(_wcfRelayResource.Data.RelayType, Is.EqualTo(Models.RelayType.Http));

            //Create another relay namespace
            _wcfRelayResource = (await _wcfRelayCollection.CreateOrUpdateAsync(WaitUntil.Completed, "h3", new WcfRelayData()
            {
                IsClientAuthorizationRequired = true,
                IsTransportSecurityRequired = true,
                RelayType = Models.RelayType.Http
            })).Value;
            Assert.That(_wcfRelayResource.Data.IsClientAuthorizationRequired, Is.True);
            Assert.That(_wcfRelayResource.Data.IsTransportSecurityRequired, Is.True);
            Assert.That(_wcfRelayResource.Data.UserMetadata, Is.Null);
            Assert.That(_wcfRelayResource.Data.RelayType, Is.EqualTo(Models.RelayType.Http));

            WcfRelayResource _wcfRelayResource2 = (await _wcfRelayCollection.GetAsync("h1"))?.Value;
            Assert.That(_wcfRelayResource2.Data.IsClientAuthorizationRequired, Is.True);
            Assert.That(_wcfRelayResource2.Data.IsTransportSecurityRequired, Is.False);
            Assert.That(_wcfRelayResource2.Data.UserMetadata, Is.EqualTo("second metadata"));
            Assert.That(_wcfRelayResource2.Data.RelayType, Is.EqualTo(Models.RelayType.NetTcp));

            // List all hybrid connections
            var listOfWcfRelay = await _wcfRelayCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listOfWcfRelay.Count, Is.EqualTo(3));

            await _wcfRelayResource2.DeleteAsync(WaitUntil.Completed);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _wcfRelayResource2.GetAsync(); });
            Assert.That(exception.Status, Is.EqualTo(404));
        }
    }
}
