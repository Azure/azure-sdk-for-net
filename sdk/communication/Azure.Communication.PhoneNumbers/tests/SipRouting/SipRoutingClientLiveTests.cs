// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

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
            Assert.Multiple(async () =>
            {
                Assert.That((await client.SetRoutesAsync(new List<SipTrunkRoute>())).Status, Is.EqualTo(200));
                Assert.That((await client.SetTrunksAsync(new List<SipTrunk>())).Status, Is.EqualTo(200));
            });
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }

        [Test]
        public async Task SetFunctionUsingTokenAuthentication()
        {
            if (SkipSipConfigurationLiveTest)
            {
                Assert.Ignore("Skip sip configuration flag is on.");
            }

            var client = CreateClientWithTokenCredential();

            var response = await client.SetTrunkAsync(new SipTrunk(TestData!.TrunkList[0].Fqdn,5555)).ConfigureAwait(false);
            Assert.That(response.Status, Is.EqualTo(200));
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

            Assert.That(trunks, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(trunks.Count(), Is.EqualTo(TestData!.TrunkList.Count));
                Assert.That(TrunkAreEqual(TestData!.TrunkList[0], trunks[0]), Is.True);
                Assert.That(TrunkAreEqual(TestData!.TrunkList[1], trunks[1]), Is.True);
            });
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

            Assert.That(routes, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(routes.Count(), Is.EqualTo(1));
                Assert.That(RouteAreEqual(TestData!.RuleWithoutTrunks, routes[0]), Is.True);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(actualTrunks.Value.Count(), Is.EqualTo(3));
                Assert.That(actualTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData!.NewTrunk.Fqdn), Is.Not.Null);
            });
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
            Assert.That(actualTrunk.Value.SipSignalingPort, Is.EqualTo(modifiedTrunk.SipSignalingPort));
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
            Assert.That(initialTrunks.Value.Count(), Is.EqualTo(TestData!.TrunkList.Count));

            await client.DeleteTrunkAsync(TestData!.TrunkList[1].Fqdn).ConfigureAwait(false);

            var finalTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(finalTrunks.Value.Count(), Is.EqualTo(TestData!.TrunkList.Count - 1));
                Assert.That(finalTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData!.TrunkList[1].Fqdn), Is.Null);
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(trunk, Is.Not.Null);
                Assert.That(TrunkAreEqual(TestData!.TrunkList[1], trunk), Is.True);
            });
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
            Assert.That(newRoutes, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(newRoutes, Has.Count.EqualTo(1));
                Assert.That(RouteAreEqual(TestData!.RuleWithoutTrunks2, newRoutes[0]), Is.True);
            });
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
            Assert.That(newTrunks, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(newTrunks, Has.Count.EqualTo(1));
                Assert.That(TrunkAreEqual(TestData!.NewTrunk, newTrunks[0]), Is.True);
            });
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
            Assert.That(newTrunks, Is.Not.Null);
            Assert.That(newTrunks, Is.Empty);
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
            Assert.That(newTrunks, Is.Not.Null);
            Assert.That(newTrunks, Is.Empty);
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
            Assert.That(newRoutes, Is.Not.Null);
            Assert.That(newRoutes, Is.Empty);
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
            Assert.That(newRoutes, Is.Not.Null);
            Assert.That(newRoutes, Is.Empty);
        }
    }
}
