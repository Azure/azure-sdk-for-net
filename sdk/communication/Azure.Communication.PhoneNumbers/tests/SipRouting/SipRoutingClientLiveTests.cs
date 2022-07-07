// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public SipRoutingClient InitializeTest()
        {
            var client = CreateClient();
            client.SetRoutesAsync(new List<SipTrunkRoute>()).Wait();
            client.SetTrunksAsync(TestData.TrunkList).Wait();
            client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToTrunk1 }).Wait();
            client.SetDomainsAsync(TestData.DomainList).Wait();

            return client;
        }

        [Test]
        public async Task GetFunctionUsingTokenAuthentication()
        {
            var client = CreateClientWithTokenCredential();

            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public async Task SetFunctionUsingTokenAuthentication()
        {
            var client = CreateClientWithTokenCredential();

            var response = await client.SetTrunkAsync(new SipTrunk(TestData.TrunkList[0].Fqdn,5555)).ConfigureAwait(false);
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task GetSipTrunksForResource()
        {
            var client = InitializeTest();
            var response = await client.GetTrunksAsync().ConfigureAwait(false);
            var trunks = response.Value;

            Assert.IsNotNull(trunks);
            Assert.AreEqual(TestData.TrunkList.Count, trunks.Count());
            Assert.IsTrue(TrunkAreEqual(TestData.TrunkList[0], trunks[0]));
            Assert.IsTrue(TrunkAreEqual(TestData.TrunkList[1], trunks[1]));
        }

        [Test]
        public async Task GetSipRoutesForResource()
        {
            var client = InitializeTest();
            var response = await client.GetRoutesAsync().ConfigureAwait(false);
            var routes = response.Value;

            Assert.IsNotNull(routes);
            Assert.AreEqual(1, routes.Count());
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToTrunk1, routes[0]));
        }

        [Test]
        public async Task AddSipTrunkForResource()
        {
            var client = InitializeTest();
            var response = await client.SetTrunkAsync(TestData.NewTrunk).ConfigureAwait(false);
            var actualTrunks = await client.GetTrunksAsync().ConfigureAwait(false);

            Assert.AreEqual(3, actualTrunks.Value.Count());
            Assert.IsNotNull(actualTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData.NewTrunk.Fqdn));
        }

        [Test]
        public async Task SetSipTrunkForResource()
        {
            var modifiedTrunk = new SipTrunk(TestData.TrunkList[0].Fqdn, 9999);
            var client = InitializeTest();

            await client.SetTrunkAsync(modifiedTrunk).ConfigureAwait(false);

            var actualTrunk = await client.GetTrunkAsync(TestData.TrunkList[0].Fqdn).ConfigureAwait(false);
            Assert.AreEqual(modifiedTrunk.SipSignalingPort, actualTrunk.Value.SipSignalingPort);
        }

        [Test]
        public async Task DeleteSipTrunkForResource()
        {
            var client = InitializeTest();
            var initialTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            Assert.AreEqual(TestData.TrunkList.Count, initialTrunks.Value.Count());

            await client.DeleteTrunkAsync(TestData.TrunkList[1].Fqdn).ConfigureAwait(false);

            var finalTrunks = await client.GetTrunksAsync().ConfigureAwait(false);
            Assert.AreEqual(TestData.TrunkList.Count-1, finalTrunks.Value.Count());
            Assert.IsNull(finalTrunks.Value.FirstOrDefault(x => x.Fqdn == TestData.TrunkList[1].Fqdn));
        }

        [Test]
        public async Task GetSipTrunkForResource()
        {
            var client = InitializeTest();

            var response = await client.GetTrunkAsync(TestData.TrunkList[1].Fqdn).ConfigureAwait(false);

            var trunk = response.Value;
            Assert.IsNotNull(trunk);
            Assert.IsTrue(TrunkAreEqual(TestData.TrunkList[1], trunk));
        }

        [Test]
        public async Task ReplaceSipRoutesForResource()
        {
            var client = InitializeTest();

            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToAllTrunks }).ConfigureAwait(false);
            var response = await client.GetRoutesAsync().ConfigureAwait(false);

            var newRoutes = response.Value;
            Assert.IsNotNull(newRoutes);
            Assert.AreEqual(1, newRoutes.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToAllTrunks, newRoutes[0]));
        }

        [Test]
        public async Task ReplaceSipTrunksForResource()
        {
            var client = InitializeTest();

            await client.SetRoutesAsync(new List<SipTrunkRoute>()).ConfigureAwait(false);  // Need to clear the routes first
            await client.SetTrunksAsync(new List<SipTrunk> { TestData.NewTrunk });
            var response = await client.GetTrunksAsync().ConfigureAwait(false);

            var newTrunks = response.Value;
            Assert.IsNotNull(newTrunks);
            Assert.AreEqual(1, newTrunks.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, newTrunks[0]));
        }

        [Test]
        public async Task AddSipDomainForResource()
        {
            var client = InitializeTest();
            var response = await client.SetDomainAsync(TestData.NewDomain).ConfigureAwait(false);
            var actualDomains = await client.GetDomainsAsync().ConfigureAwait(false);

            Assert.AreEqual(3, actualDomains.Value.Count());
            Assert.IsNotNull(actualDomains.Value.FirstOrDefault(x => x.DomainUri == TestData.NewDomain.DomainUri));
        }

        [Test]
        public async Task GetSipDomainForResource()
        {
            var client = InitializeTest();

            var response = await client.GetDomainAsync(TestData.DomainList[1].DomainUri).ConfigureAwait(false);

            var domain = response.Value;
            Assert.IsNotNull(domain);
            Assert.IsTrue(DomainAreEqual(TestData.DomainList[1], domain));
        }

        [Test]
        public async Task GetSipDomainsForResource()
        {
            var client = InitializeTest();
            var response = await client.GetDomainsAsync().ConfigureAwait(false);
            var domains = response.Value;

            Assert.IsNotNull(domains);
            Assert.AreEqual(TestData.DomainList.Count, domains.Count());
            Assert.IsTrue(DomainAreEqual(TestData.DomainList[0], domains[0]));
            Assert.IsTrue(DomainAreEqual(TestData.DomainList[1], domains[1]));
        }

        [Test]
        public async Task ReplaceSipDomainsForResource()
        {
            var client = InitializeTest();

            await client.SetRoutesAsync(new List<SipTrunkRoute>()).ConfigureAwait(false);  // Need to clear the routes first
            await client.SetTrunksAsync(new List<SipTrunk> ()).ConfigureAwait(false); //Need to clear  trunks first
            await client.SetDomainsAsync(new List<SipDomain> { TestData.NewDomain }).ConfigureAwait(false);
            var response = await client.GetDomainsAsync().ConfigureAwait(false);

            var newDomains = response.Value;
            Assert.IsNotNull(newDomains);
            Assert.AreEqual(1, newDomains.Count);
            Assert.IsTrue(DomainAreEqual(TestData.NewDomain, newDomains[0]));
        }

        [Test]
        public async Task DeleteSipDomainForResource()
        {
            var client = InitializeTest();
            var initialDomains = await client.GetDomainsAsync().ConfigureAwait(false);
            Assert.AreEqual(TestData.DomainList.Count, initialDomains.Value.Count());

            await client.DeleteDomainAsync(TestData.DomainList[1].DomainUri).ConfigureAwait(false);

            var finalDomains = await client.GetDomainsAsync().ConfigureAwait(false);
            Assert.AreEqual(TestData.DomainList.Count - 1, finalDomains.Value.Count());
            Assert.IsNull(finalDomains.Value.FirstOrDefault(x => x.DomainUri == TestData.DomainList[1].DomainUri));
        }
    }
}
