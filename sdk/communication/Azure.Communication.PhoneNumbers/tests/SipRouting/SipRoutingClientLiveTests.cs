// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.SipRouting;
using Azure.Communication.PhoneNumbers.SipRouting.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.SipRouting.Tests
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
            Environment.SetEnvironmentVariable("COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING", "endpoint=https://e2e_test.communication.azure.com/;accesskey=qGUv+J0z5Xv8TtjC0qZhy34sodSOMKG5HS7NfsjhqxaB/ZP4UnuS4FspWPo3JowuqAb+75COGi4ErREkB76/UQ==");
        }

        [SetUp]
        public void SetUp()
        {
            var client = CreateClient();
            client.SetRoutesAsync(new List<SipTrunkRoute>()).Wait();
            client.SetTrunksAsync(TestData.TrunkList).Wait();
            client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToTrunk1 }).Wait();
        }

        [Test]
        public async Task GetSipTrunksForResource()
        {
            var client = CreateClient();
            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var trunks = response.Value;

            Assert.IsNotNull(trunks);
            Assert.AreEqual(2, trunks.Count());
            TrunkAreEqual(TestData.TrunkList[0], trunks[0]);
            TrunkAreEqual(TestData.TrunkList[1], trunks[1]);
        }

        [Test]
        public async Task GetSipRoutesForResource()
        {
            var client = CreateClient();
            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var routes = response.Value;

            Assert.IsNotNull(routes);
            Assert.AreEqual(routes.Count(), 1);
            RouteAreEqual(TestData.RuleNavigateToTrunk1, routes[0]);
        }

        [Test]
        public async Task AddSipTrunkForResource()
        {
            var client = CreateClient();
            var response = await client.SetTrunkAsync(TestData.NewTrunk).ConfigureAwait(false);
            var actualTrunks = await client.GetTrunksAsync().ConfigureAwait(false);

            Assert.AreEqual(3, actualTrunks.Value.Count());
            Assert.IsNotNull(actualTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData.NewTrunk.Fqdn));
        }

        [Test]
        public async Task AddSipRouteForResource()
        {
            var client = CreateClient();
            await client.SetRouteAsync(TestData.RuleNavigateToAllTrunks).ConfigureAwait(false);
            var response = await client.GetRoutesAsync().ConfigureAwait(false);

            var actualRoutes = response.Value;

            Assert.AreEqual(2, actualRoutes.Count());
            RouteAreEqual(TestData.RuleNavigateToAllTrunks, actualRoutes[1]);
        }

        [Test]
        public async Task SetSipTrunkForResource()
        {
            var modifiedTrunk = new SipTrunk(TestData.TrunkList[0].Fqdn, 9999);

            var client = CreateClient();
            await client.SetTrunkAsync(modifiedTrunk).ConfigureAwait(false);

            var actualTrunk = await client.GetTrunkAsync(TestData.TrunkList[0].Fqdn).ConfigureAwait(false);
            Assert.AreEqual(modifiedTrunk.SipSignalingPort, actualTrunk.Value.SipSignalingPort);
        }

        [Test]
        public async Task SetSipRouteForResource()
        {
            var modifiedRoute = new SipTrunkRoute(TestData.RuleNavigateToTrunk1.Name, TestData.RuleNavigateToAllTrunks.NumberPattern, TestData.RuleNavigateToTrunk1.Description, TestData.RuleNavigateToTrunk1.Trunks);

            var client = CreateClient();
            await client.SetRouteAsync(modifiedRoute).ConfigureAwait(false);

            var actualRoute = await client.GetRouteAsync(TestData.RuleNavigateToTrunk1.Name).ConfigureAwait(false);
            Assert.AreEqual(modifiedRoute.NumberPattern, actualRoute.Value.NumberPattern);
        }

        [Test]
        public async Task DeleteSipTrunkForResource()
        {
            var client = CreateClient();
            await client.DeleteTrunkAsync(TestData.TrunkList[1].Fqdn).ConfigureAwait(false);

            var actualTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            Assert.AreEqual(1, actualTrunks.Value.Count());
            Assert.IsNull(actualTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData.TrunkList[1].Fqdn));
        }

        [Test]
        public async Task DeleteSipRouteForResource()
        {
            var expectedRoutes = new List<SipTrunkRoute>();
            var client = CreateClient();
            await client.DeleteRouteAsync(TestData.RuleNavigateToTrunk1.Name).ConfigureAwait(false);
            var actualRoutes = await client.GetRoutesAsync().ConfigureAwait(false);

            Assert.AreEqual(expectedRoutes, actualRoutes.Value);
        }

        [Test]
        public async Task GetSipTrunkForResource()
        {
            var client = CreateClient();
            var response = await client.GetTrunkAsync(TestData.TrunkList[1].Fqdn).ConfigureAwait(false);
            var trunk = response.Value;

            Assert.IsNotNull(trunk);
            TrunkAreEqual(TestData.TrunkList[1], trunk);
        }

        [Test]
        public async Task GetSipRouteForResource()
        {
            var client = CreateClient();
            var response = await client.GetRouteAsync(TestData.RuleNavigateToTrunk1.Name).ConfigureAwait(false);
            var route = response.Value;

            Assert.IsNotNull(route);
            RouteAreEqual(TestData.RuleNavigateToTrunk1, route);
        }

        [Test]
        public async Task ReplaceSipRoutesForResource()
        {
            var client = CreateClient();
            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToAllTrunks }).ConfigureAwait(false);

            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var newRoutes = response.Value;

            Assert.IsNotNull(newRoutes);
            Assert.AreEqual(1, newRoutes.Count);
            RouteAreEqual(TestData.RuleNavigateToAllTrunks, newRoutes[0]);
        }

        [Test]
        public async Task ReplaceSipTrunksForResource()
        {
            var client = CreateClient();
            await client.SetRoutesAsync(new List<SipTrunkRoute> ()).ConfigureAwait(false);  // Need to clear the routes first
            await client.SetTrunksAsync(new List<SipTrunk> { TestData.NewTrunk });

            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var newTrunks = response.Value;

            Assert.IsNotNull(newTrunks);
            Assert.AreEqual(1, newTrunks.Count);
            TrunkAreEqual(TestData.NewTrunk, newTrunks[0]);
        }

        private void RouteAreEqual(SipTrunkRoute expected, SipTrunkRoute actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.NumberPattern, actual.NumberPattern);
            Assert.AreEqual(expected.Trunks.Count, actual.Trunks.Count);

            for (int i = 0; i < expected.Trunks.Count; i++)
            {
                Assert.AreEqual(expected.Trunks[i], actual.Trunks[i]);
            }
        }

        private void TrunkAreEqual(SipTrunk expected, SipTrunk actual)
        {
            Assert.AreEqual(expected.Fqdn, actual.Fqdn);
            Assert.AreEqual(expected.SipSignalingPort, actual.SipSignalingPort);
        }

        private TokenCredential GetToken() => Mode == RecordedTestMode.Playback
                                            ? new MockCredential()
                                            : new DefaultAzureCredential(new DefaultAzureCredentialOptions
                                            {
                                                AuthorityHost = new Uri("https://login.windows-ppe.net/")
                                            });
    }
}
