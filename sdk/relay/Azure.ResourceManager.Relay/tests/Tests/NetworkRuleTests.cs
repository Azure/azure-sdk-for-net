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
            Assert.AreEqual(Models.RelayNetworkRuleSetDefaultAction.Allow, _relayNetworkRuleSetResource.Data.DefaultAction);
            Assert.AreEqual(Models.RelayPublicNetworkAccess.Enabled, _relayNetworkRuleSetResource.Data.PublicNetworkAccess);
            Assert.AreEqual(0, _relayNetworkRuleSetResource.Data.IPRules.Count);

            _relayNetworkRuleSetResource = (await _relayNetworkRuleSetResource.CreateOrUpdateAsync(WaitUntil.Completed, new RelayNetworkRuleSetData()
                {
                    IPRules = { new Models.RelayNetworkRuleSetIPRule() { IPMask = "1.1.1.1", Action = "Allow" },
                                new Models.RelayNetworkRuleSetIPRule() { IPMask = "2.1.1.1", Action = "Allow" }},
                    PublicNetworkAccess = "Disabled",
                    DefaultAction = "Deny"
                })).Value;

            Assert.AreEqual(Models.RelayNetworkRuleSetDefaultAction.Deny, _relayNetworkRuleSetResource.Data.DefaultAction);
            Assert.AreEqual(Models.RelayPublicNetworkAccess.Disabled, _relayNetworkRuleSetResource.Data.PublicNetworkAccess);
            Assert.AreEqual(2, _relayNetworkRuleSetResource.Data.IPRules.Count);

            _relayNetworkRuleSetResource = (await _relayNetworkRuleSetResource.GetAsync()).Value;
            Assert.AreEqual(Models.RelayNetworkRuleSetDefaultAction.Deny, _relayNetworkRuleSetResource.Data.DefaultAction);
            Assert.AreEqual(Models.RelayPublicNetworkAccess.Disabled, _relayNetworkRuleSetResource.Data.PublicNetworkAccess);
            Assert.AreEqual(2, _relayNetworkRuleSetResource.Data.IPRules.Count);
        }
    }
}
