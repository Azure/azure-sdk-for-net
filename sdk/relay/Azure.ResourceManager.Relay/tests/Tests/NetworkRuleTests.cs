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
    public class NetworkRuleTests : RelayTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private RelayNamespaceResource _relayNamespace;
        public NetworkRuleTests(bool async) : base(async)
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
        public async Task NetworkRuleTest()
        {
            RelayNetworkRuleSetResource _relayNetworkRuleSetResource = _relayNamespace.GetRelayNetworkRuleSet();

            _relayNetworkRuleSetResource = (await _relayNetworkRuleSetResource.GetAsync()).Value;
            Assert.That(_relayNetworkRuleSetResource.Data.DefaultAction, Is.EqualTo(Models.RelayNetworkRuleSetDefaultAction.Allow));
            Assert.That(_relayNetworkRuleSetResource.Data.PublicNetworkAccess, Is.EqualTo(Models.RelayPublicNetworkAccess.Enabled));
            Assert.That(_relayNetworkRuleSetResource.Data.IPRules.Count, Is.EqualTo(0));

            _relayNetworkRuleSetResource = (await _relayNetworkRuleSetResource.CreateOrUpdateAsync(WaitUntil.Completed, new RelayNetworkRuleSetData()
                {
                    IPRules = { new Models.RelayNetworkRuleSetIPRule() { IPMask = "1.1.1.1", Action = "Allow" },
                                new Models.RelayNetworkRuleSetIPRule() { IPMask = "2.1.1.1", Action = "Allow" }},
                    PublicNetworkAccess = "Disabled",
                    DefaultAction = "Deny"
                })).Value;

            Assert.That(_relayNetworkRuleSetResource.Data.DefaultAction, Is.EqualTo(Models.RelayNetworkRuleSetDefaultAction.Deny));
            Assert.That(_relayNetworkRuleSetResource.Data.PublicNetworkAccess, Is.EqualTo(Models.RelayPublicNetworkAccess.Disabled));
            Assert.That(_relayNetworkRuleSetResource.Data.IPRules.Count, Is.EqualTo(2));

            _relayNetworkRuleSetResource = (await _relayNetworkRuleSetResource.GetAsync()).Value;
            Assert.That(_relayNetworkRuleSetResource.Data.DefaultAction, Is.EqualTo(Models.RelayNetworkRuleSetDefaultAction.Deny));
            Assert.That(_relayNetworkRuleSetResource.Data.PublicNetworkAccess, Is.EqualTo(Models.RelayPublicNetworkAccess.Disabled));
            Assert.That(_relayNetworkRuleSetResource.Data.IPRules.Count, Is.EqualTo(2));
        }
    }
}
