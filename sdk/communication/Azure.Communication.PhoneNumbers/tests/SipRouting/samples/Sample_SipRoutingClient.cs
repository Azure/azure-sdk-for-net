// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.SipRouting;
using Azure.Communication.PhoneNumbers.SipRouting.Tests.Infrastructure;
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

            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            # region Snippet:CreateSipRoutingClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new SipRoutingClient(connectionString);
            #endregion Snippet:CreateSipRoutingClient

            #region Snippet:Replace SIP trunks and routes
            // Cannot delete trunks that are used in any of the routes, therefore first set the routes as empty list, and then update routes.
            //@@var newTrunks = < new_trunks_list >;
            //@@var newRoutes = < new_routes_list >;

            client.SetRoutes(new List<SipTrunkRoute>());
            client.SetTrunks(new List<SipTrunk> { TestData.NewTrunk });
            client.SetRoutes(new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk });
            #endregion Snippet:Replace SIP trunks and routes

            #region Snippet:Retrieve SIP trunks and routes
            var trunksResponse = client.GetTrunks();
            var routesResponse = client.GetRoutes();
            #endregion Snippet:Retrieve SIP trunks and routes

            Assert.AreEqual(1, trunksResponse.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Value[0]));
            Assert.AreEqual(1, routesResponse.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Value[0]));

            #region Snippet:Retrieve one trunk
            var trunkResponse = client.GetTrunk(TestData.NewTrunk.Fqdn);
            # endregion Snippet:Retrieve one trunk

            #region Snippet:Set one trunk
            var updatedTrunk = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);
            client.SetTrunk(updatedTrunk); // Modify currently used trunk
            #endregion Snippet:Set one trunk

            #region Snippet:Add one trunk
            client.SetTrunk(TestData.TrunkList[0]);
            #endregion Snippet:Add one trunk

            #region Snippet:Delete one trunk
            client.DeleteTrunk(TestData.Fqdns[0]);
            #endregion Snippet:Delete one trunk

            var trunksFinalResponse = client.GetTrunksAsync();
            var routesFinalResponse = client.GetRoutesAsync();

            Assert.AreEqual(1, trunksFinalResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(updatedTrunk, trunksFinalResponse.Result.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Result.Value.Count);
        }

        [Test]
        [AsyncOnly]
        public async Task ManageSipConfigurationAsync()
        {
            if (SkipSipRoutingLiveTests)
                Assert.Ignore("Skip SIP routing live tests flag is on.");

            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            # region Snippet:CreateSipRoutingClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new SipRoutingClient(connectionString);
            #endregion Snippet:CreateSipRoutingClient

            #region Snippet:Replace SIP trunks and routes
            // Cannot delete trunks that are used in any of the routes, therefore first set the routes as empty list, and then update routes.
            //@@var newTrunks = < new_trunks_list >;
            //@@var newRoutes = < new_routes_list >;

            await client.SetRoutesAsync(new List<SipTrunkRoute>());
            await client.SetTrunksAsync(new List<SipTrunk> { TestData.NewTrunk });
            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk });
            #endregion Snippet:Replace SIP trunks and routes

            #region Snippet:Retrieve SIP trunks and routes
            var trunksResponse = client.GetTrunksAsync();
            var routesResponse = client.GetRoutesAsync();
            #endregion Snippet:Retrieve SIP trunks and routes

            Assert.AreEqual(1, trunksResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Result.Value[0]));
            Assert.AreEqual(1, routesResponse.Result.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Result.Value[0]));

            #region Snippet:Retrieve one trunk
            var trunkResponse = client.GetTrunkAsync(TestData.NewTrunk.Fqdn);
            # endregion Snippet:Retrieve one trunk

            #region Snippet:Set one trunk
            // Set function will either modify existing item, or append the new item to the collection.
            var updatedTrunk = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);
            var updatedRoute = new SipTrunkRoute(TestData.RuleNavigateToNewTrunk.Name, TestData.RuleNavigateToNewTrunk.NumberPattern, "Alternative description");

            await client.SetTrunkAsync(updatedTrunk); // Modify currently used trunk
            await client.SetTrunkAsync(TestData.TrunkList[0]); // Add new trunk
            #endregion Snippet:Set one trunk

            #region Snippet:Delete one trunk
            await client.DeleteTrunkAsync(TestData.Fqdns[0]);
            #endregion Snippet:Delete one trunk

            var trunksFinalResponse = client.GetTrunksAsync();
            var routesFinalResponse = client.GetRoutesAsync();

            Assert.AreEqual(1, trunksFinalResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(updatedTrunk, trunksFinalResponse.Result.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Result.Value.Count);
            Assert.IsTrue(RouteAreEqual(updatedRoute, routesFinalResponse.Result.Value[0]));
        }
    }
}
