// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication.PhoneNumbers.SipRouting.Tests
{
    public class SipRoutingClientLiveTests : SipRoutingClientLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SipRoutingClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public SipRoutingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }
        public bool SkipSipConfigurationLiveTest
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_SIPROUTING_LIVE_TESTS") == "TRUE";

        public SipRoutingClient InitializeTest()
        {
            var client = CreateClient();
            client.SetRoutesAsync(new List<SipTrunkRoute>()).Wait();
            client.SetTrunksAsync(TestData!.TrunkList).Wait();
            client.SetRoutesAsync(new List<SipTrunkRoute> { TestData!.RuleWithoutTrunks }).Wait();

            return client;
        }

        [TearDown]
        public async Task ClearConfiguration()
        {
            var client = CreateClient();
            ClassicAssert.AreEqual(200, (await client.SetRoutesAsync(new List<SipTrunkRoute>())).Status);
            ClassicAssert.AreEqual(200, (await client.SetTrunksAsync(new List<SipTrunk>())).Status);
        }

        [Test]
        public async Task GetFunctionUsingTokenAuthentication()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClientWithTokenCredential();

            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            ClassicAssert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public async Task SetFunctionUsingTokenAuthentication()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClientWithTokenCredential();

            var response = await client.SetTrunkAsync(new SipTrunk(TestData!.TrunkList[0].Fqdn, 5555)).ConfigureAwait(false);
            ClassicAssert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task GetSipTrunksForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = InitializeTest();
            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var trunks = response.Value;

            ClassicAssert.IsNotNull(trunks);
            ClassicAssert.AreEqual(TestData!.TrunkList.Count, trunks.Count());
            ClassicAssert.IsTrue(TrunkAreEqual(TestData!.TrunkList[0], trunks[0]));
            ClassicAssert.IsTrue(TrunkAreEqual(TestData!.TrunkList[1], trunks[1]));
        }

        [Test]
        public async Task GetSipRoutesForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();
            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData!.RuleWithoutTrunks }).ConfigureAwait(false);
            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var routes = response.Value;

            ClassicAssert.IsNotNull(routes);
            ClassicAssert.AreEqual(1, routes.Count());
            ClassicAssert.IsTrue(RouteAreEqual(TestData!.RuleWithoutTrunks, routes[0]));
        }

        [Test]
        public async Task AddSipTrunkForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = InitializeTest();
            var response = await client.SetTrunkAsync(TestData!.NewTrunk).ConfigureAwait(false);
            var actualTrunks = await client.GetTrunksAsync().ConfigureAwait(false);

            ClassicAssert.AreEqual(3, actualTrunks.Value.Count());
            ClassicAssert.IsNotNull(actualTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData!.NewTrunk.Fqdn));
        }

        [Test]
        public async Task SetSipTrunkForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }
            var modifiedTrunk = new SipTrunk(TestData!.TrunkList[0].Fqdn, 9999);
            var client = InitializeTest();

            await client.SetTrunkAsync(modifiedTrunk).ConfigureAwait(false);

            var actualTrunk = await client.GetTrunkAsync(TestData!.TrunkList[0].Fqdn).ConfigureAwait(false);
            ClassicAssert.AreEqual(modifiedTrunk.SipSignalingPort, actualTrunk.Value.SipSignalingPort);
        }

        [Test]
        public async Task DeleteSipTrunkForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = InitializeTest();
            var initialTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            ClassicAssert.AreEqual(TestData!.TrunkList.Count, initialTrunks.Value.Count());

            await client.DeleteTrunkAsync(TestData!.TrunkList[1].Fqdn).ConfigureAwait(false);

            var finalTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            ClassicAssert.AreEqual(TestData!.TrunkList.Count - 1, finalTrunks.Value.Count());
            ClassicAssert.IsNull(finalTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData!.TrunkList[1].Fqdn));
        }

        [Test]
        public async Task GetSipTrunkForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = InitializeTest();

            var response = await client.GetTrunkAsync(TestData!.TrunkList[1].Fqdn).ConfigureAwait(false);

            var trunk = response.Value;
            ClassicAssert.IsNotNull(trunk);
            ClassicAssert.IsTrue(TrunkAreEqual(TestData!.TrunkList[1], trunk));
        }

        [Test]
        public async Task ReplaceSipRoutesForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();

            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData!.RuleWithoutTrunks }).ConfigureAwait(false);
            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData!.RuleWithoutTrunks2 }).ConfigureAwait(false);
            var response = await client.GetRoutesAsync().ConfigureAwait(false);

            var newRoutes = response.Value;
            ClassicAssert.IsNotNull(newRoutes);
            ClassicAssert.AreEqual(1, newRoutes.Count);
            ClassicAssert.IsTrue(RouteAreEqual(TestData!.RuleWithoutTrunks2, newRoutes[0]));
        }

        [Test]
        public async Task ReplaceSipTrunksForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }
            var client = InitializeTest();

            await client.SetRoutesAsync(new List<SipTrunkRoute>()).ConfigureAwait(false);  // Need to clear the routes first
            await client.SetTrunksAsync(new List<SipTrunk> { TestData!.NewTrunk });
            var response = await client.GetTrunksAsync().ConfigureAwait(false);

            var newTrunks = response.Value;
            ClassicAssert.IsNotNull(newTrunks);
            ClassicAssert.AreEqual(1, newTrunks.Count);
            ClassicAssert.IsTrue(TrunkAreEqual(TestData!.NewTrunk, newTrunks[0]));
        }

        [Test]
        public async Task ClearSipTrunksForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();
            client.SetTrunksAsync(TestData!.TrunkList).Wait();

            await client.SetTrunksAsync(new List<SipTrunk>()).ConfigureAwait(false);

            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var newTrunks = response.Value;
            ClassicAssert.IsNotNull(newTrunks);
            ClassicAssert.IsEmpty(newTrunks);
        }

        [Test]
        public async Task ClearSipTrunksForResourceWhenAlreadyEmpty()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();
            await ClearConfiguration();

            await client.SetTrunksAsync(new List<SipTrunk>()).ConfigureAwait(false);

            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var newTrunks = response.Value;
            ClassicAssert.IsNotNull(newTrunks);
            ClassicAssert.IsEmpty(newTrunks);
        }

        [Test]
        public async Task ClearSipRoutesForResource()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();
            client.SetRoutesAsync(new List<SipTrunkRoute> { TestData!.RuleWithoutTrunks }).Wait();

            await client.SetRoutesAsync(new List<SipTrunkRoute>()).ConfigureAwait(false);

            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var newRoutes = response.Value;
            ClassicAssert.IsNotNull(newRoutes);
            ClassicAssert.IsEmpty(newRoutes);
        }

        [Test]
        public async Task ClearSipRoutesForResourceWhenAlreadyEmpty()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClient();
            await ClearConfiguration();

            await client.SetRoutesAsync(new List<SipTrunkRoute>()).ConfigureAwait(false);

            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var newRoutes = response.Value;
            ClassicAssert.IsNotNull(newRoutes);
            ClassicAssert.IsEmpty(newRoutes);
        }
    }
}
