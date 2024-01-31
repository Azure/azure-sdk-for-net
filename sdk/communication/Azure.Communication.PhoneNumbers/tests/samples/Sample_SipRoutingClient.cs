// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.SipRouting;
using Azure.Communication.PhoneNumbers.SipRouting.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests.Samples
{
    /// <summary>
    /// Basic Azure Communication Phone Numbers samples.
    /// </summary>
    public class Sample_SipRoutingClient : SipRoutingClientLiveTestBase
    {
        public Sample_SipRoutingClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [SyncOnly]
        public void ManageSipConfiguration()
        {
            if (SkipSipRoutingLiveTests)
                Assert.Ignore("Skip SIP routing live tests flag is on.");

            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;

            #region Snippet:CreateSipRoutingClient
            // Get a connection string to Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new SipRoutingClient(connectionString);
            #endregion Snippet:CreateSipRoutingClient

            #region Snippet:CreateSipRoutingClientWithTokenCredential
            // Get an endpoint to our Azure Communication resource.
            //@@var endpoint = new Uri("<endpoint_url>");
            //@@TokenCredential tokenCredential = new DefaultAzureCredential();
            //@@client = new SipRoutingClient(endpoint, tokenCredential);
            #endregion Snippet:CreateSipRoutingClientWithTokenCredential

            client = CreateClient();
            var newTrunks = new List<SipTrunk> { TestData!.NewTrunk };
            var newRoutes = new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk };

            #region Snippet:Replace
            // The service will not allow trunks that are used in any of the routes to be deleted, therefore first set the routes as empty list, and then update the routes.
            //@@var newTrunks = "<new_trunks_list>";
            //@@var newRoutes = "<new_routes_list>";
            client.SetRoutes(new List<SipTrunkRoute>());
            client.SetTrunks(newTrunks);
            client.SetRoutes(newRoutes);
            #endregion Snippet:Replace

            #region Snippet:RetrieveList
            var trunksResponse = client.GetTrunks();
            var routesResponse = client.GetRoutes();
            #endregion Snippet:RetrieveList

            Assert.AreEqual(1, trunksResponse.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Value[0]));
            Assert.AreEqual(1, routesResponse.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Value[0]));

            var fqdnToRetrieve = TestData.NewTrunk.Fqdn;

            #region Snippet:RetrieveTrunk
            // Get trunk object, based on it's FQDN.
            //@@var fqdnToRetrieve = "<fqdn>";
            var trunkResponse = client.GetTrunk(fqdnToRetrieve);
            #endregion Snippet:RetrieveTrunk

            var trunkToSet = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);

            #region Snippet:SetTrunk
            // Set function will either modify existing item or add new item to the collection.
            // The trunk is matched based on it's FQDN.
            //@@var trunkToSet = "<trunk_to_set>";
            client.SetTrunk(trunkToSet);
            #endregion Snippet:SetTrunk

            client.SetTrunk(TestData.TrunkList[0]);
            var fqdnToDelete = TestData.Fqdns[0];

            #region Snippet:DeleteTrunk
            // Deletes trunk with supplied FQDN.
            //@@var fqdnToDelete = "<fqdn>";
            client.DeleteTrunk(fqdnToDelete);
            #endregion Snippet:DeleteTrunk

            var trunksFinalResponse = client.GetTrunks();
            var routesFinalResponse = client.GetRoutes();

            Assert.AreEqual(1, trunksFinalResponse.Value.Count);
            Assert.IsTrue(TrunkAreEqual(trunkToSet, trunksFinalResponse.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Value.Count);
        }

        [Test]
        [AsyncOnly]
        public async Task ManageSipConfigurationAsync()
        {
            if (SkipSipRoutingLiveTests)
                Assert.Ignore("Skip SIP routing live tests flag is on.");

            var client = CreateClient();
            var newTrunks = new List<SipTrunk> { TestData!.NewTrunk };
            var newRoutes = new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk };

            #region Snippet:ReplaceAsync
            // The service will not allow trunks that are used in any of the routes to be deleted, therefore first set the routes as empty list, and then update the routes.
            //@@var newTrunks = "<new_trunks_list>";
            //@@var newRoutes = "<new_routes_list>";
            await client.SetRoutesAsync(new List<SipTrunkRoute>());
            await client.SetTrunksAsync(newTrunks);
            await client.SetRoutesAsync(newRoutes);
            #endregion Snippet:ReplaceAsync

            #region Snippet:RetrieveListAsync
            var trunksResponse = await client.GetTrunksAsync();
            var routesResponse = await client.GetRoutesAsync();
            #endregion Snippet:RetrieveListAsync

            Assert.AreEqual(1, trunksResponse.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Value[0]));
            Assert.AreEqual(1, routesResponse.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Value[0]));

            var fqdnToRetrieve = TestData.NewTrunk.Fqdn;

            #region Snippet:RetrieveTrunkAsync
            // Get trunk object, based on it's FQDN.
            //@@var fqdnToRetrieve = "<fqdn>";
            var trunkResponse = await client.GetTrunkAsync(fqdnToRetrieve);
            #endregion Snippet:RetrieveTrunkAsync

            var trunkToSet = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);

            #region Snippet:SetTrunkAsync
            // Set function will either modify existing item or add new item to the collection.
            // The trunk is matched based on it's FQDN.
            //@@var trunkToSet = "<trunk_to_set>";
            await client.SetTrunkAsync(trunkToSet);
            #endregion Snippet:SetTrunkAsync

            await client.SetTrunkAsync(TestData.TrunkList[0]);
            var fqdnToDelete = TestData.Fqdns[0];

            #region Snippet:DeleteTrunkAsync
            // Deletes trunk with supplied FQDN.
            //@@var fqdnToDelete = "<fqdn>";
            await client.DeleteTrunkAsync(fqdnToDelete);
            #endregion Snippet:DeleteTrunkAsync

            var trunksFinalResponse = client.GetTrunksAsync();
            var routesFinalResponse = client.GetRoutesAsync();

            Assert.AreEqual(1, trunksFinalResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(trunkToSet, trunksFinalResponse.Result.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Result.Value.Count);
        }
    }
}
