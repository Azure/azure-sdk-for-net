// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.SipRouting.Models;
using Azure.Communication.SipRouting.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.SipRouting.Tests.SipRouting
{
    public class SipRoutingClientLiveTests : SipRoutingClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SipRoutingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public SipRoutingClientLiveTests(bool isAsync) : base(isAsync)
        {
            Environment.SetEnvironmentVariable("INCLUDE_SipRouting_LIVE_TESTS", "True");
        }

        [Test]
        [Ignore("AAD scope mapping is not setup yet")]
        public async Task GeneratesSipRoutingClientUsingTokenCredential()
        {
           var tokenCredential = GetToken();
           var client = CreateClientWithTokenCredential(tokenCredential);

            // Smoke test to ensure that client generated from token is able to work as expected.
            SipConfiguration config = await client.GetSipConfigurationAsync();

            Assert.IsNotNull(config);
            // updated value is set
            Assert.AreEqual(2, config.Trunks.Count);
            Assert.AreEqual(config.Trunks.Keys, TestData.Fqdns);
            Assert.AreEqual(1, config.Routes.Count);
            Assert.AreEqual(TestData.RuleNavigateToTrunk1.Name, config.Routes[0].Name);
        }

        [Test]
        public async Task GetSipConfigurationForResource()
        {
            var client = CreateClient();

            // Smoke test to ensure that client generated from token is able to work as expected.
            SipConfiguration config = await client.GetSipConfigurationAsync();

            Assert.IsNotNull(config);
            // updated value is set
            Assert.AreEqual(2, config.Trunks.Count);
            Assert.AreEqual(config.Trunks.Keys, TestData.Fqdns);
            Assert.AreEqual(1, config.Routes.Count);
            Assert.AreEqual(TestData.RuleNavigateToTrunk1.Name, config.Routes[0].Name);
        }

        [Test]
        public async Task UpdateSipConfigurationForResource()
        {
            var client = CreateClient();
            var trunks = TestData.TrunkDictionary;
            var routes = new List<TrunkRoute> { TestData.RuleNavigateToTrunk1 };
            await client.UpdateSipTrunkConfigurationAsync(trunks, routes);

            SipConfiguration config = await client.GetSipConfigurationAsync();
            Assert.IsNotNull(config);
            // updated value is set
            Assert.AreEqual(2, config.Trunks.Count);
            Assert.AreEqual(config.Trunks.Keys, TestData.Fqdns);
            Assert.AreEqual(1, config.Routes.Count);
            Assert.AreEqual(TestData.RuleNavigateToTrunk1.Name, config.Routes[0].Name);
        }

        [Test]
        public async Task PartialUpdateSipConfigurationForResource_Gateways()
        {
            var client = CreateClient();

            // reset SIP trunk settings
            var trunks = TestData.TrunkDictionary;
            var routes = new List<TrunkRoute> { TestData.RuleNavigateToTrunk1 };
            await client.UpdateSipTrunkConfigurationAsync(trunks, routes);

            // fill in only gateways list
            var trunkPatch = new TrunkPatch();
            var updatedTrunks = new Dictionary<string, TrunkPatch>() { { "sbs1.contoso.com", trunkPatch } };
            await client.UpdateTrunksAsync(updatedTrunks);

            SipConfiguration config = await client.GetSipConfigurationAsync();
            Assert.IsNotNull(config);
            // updated value is set
            Assert.AreEqual(1, config.Trunks.Count);
            Assert.AreEqual(config.Trunks,TestData.Fqdns[0]);
            // initial value is reserved
            Assert.AreEqual(1, config.Routes.Count);
            Assert.AreEqual(TestData.RuleNavigateToTrunk1.Name, config.Routes[0].Name);
        }

        [Test]
        public async Task PartialUpdateSipConfigurationForResource_RoutingSettings()
        {
            var client = CreateClient();

            // reset SIP trunk settings
            var trunks = TestData.TrunkDictionary;
            var routes = new List<TrunkRoute> { TestData.RuleNavigateToTrunk1 };
            await client.UpdateSipTrunkConfigurationAsync(trunks, routes);

            // fill in only routing settings
            var updatedRoutingSettings = new List<TrunkRoute> { TestData.RuleNavigateToAllTrunks };
            await client.UpdateRoutingSettingsAsync(updatedRoutingSettings);

            SipConfiguration config = await client.GetSipConfigurationAsync();
            Assert.IsNotNull(config);
            // updated value is set
            Assert.AreEqual(2, config.Trunks.Count);
            Assert.AreEqual(config.Trunks.Keys, TestData.Fqdns);
            // initial value is reserved
            Assert.AreEqual(1, config.Routes.Count);
            Assert.AreEqual(TestData.RuleNavigateToAllTrunks.Name, config.Routes[0].Name);
        }

        private TokenCredential GetToken() => Mode == RecordedTestMode.Playback
                                            ? new MockCredential()
                                            : new DefaultAzureCredential(new DefaultAzureCredentialOptions
                                            {
                                                AuthorityHost = new Uri("https://login.windows-ppe.net/")
                                            });
    }
}
