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

            #region Snippet:Set whole configuration
            // Cannot delete trunks that are used in any of the routes, therefore first set the routes as empty list, and then update routes.
            //@@var newTrunks = < new_trunks_list >;
            //@@var newRoutes = < new_routes_list >;

            client.SetRoutes(new List<SipTrunkRoute>());
            client.SetTrunks(new List<SipTrunk> { TestData.NewTrunk });
            client.SetRoutes(new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk });
            #endregion Snippet:Set whole configuration

            #region Snippet:Retrieve whole configuration
            var trunksResponse = client.GetTrunks();
            var routesResponse = client.GetRoutes();
            #endregion Snippet:Retrieve whole configuration

            Assert.AreEqual(1, trunksResponse.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Value[0]));
            Assert.AreEqual(1, routesResponse.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Value[0]));

            #region Snippet:Retrieve one item
            var trunkResponse = client.GetTrunk(TestData.NewTrunk.Fqdn);
            var routeResponse = client.GetRoute(TestData.RuleNavigateToNewTrunk.Name);
            # endregion Snippet:Retrieve one item

            #region Snippet:Set one item
            // Set function will either modify existing item, or append the new item to the collection.
            var updatedTrunk = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);
            var updatedRoute = new SipTrunkRoute(TestData.RuleNavigateToNewTrunk.Name, TestData.RuleNavigateToNewTrunk.NumberPattern, "Alternative description");

            client.SetTrunk(updatedTrunk); // Modify currently used trunk
            client.SetTrunk(TestData.TrunkList[0]); // Add new trunk
            client.SetRoute(updatedRoute); // Modify currently used route
            client.SetRoute(TestData.RuleNavigateToTrunk1); // Add new route
            #endregion Snippet:Set one item

            #region Snippet:Delete one item
            client.DeleteRoute(TestData.RuleNavigateToTrunk1.Name);  //Delete route before the trunk, it depends on.
            client.DeleteTrunk(TestData.Fqdns[0]);
            #endregion Snippet:Delete one item

            var trunksFinalResponse = client.GetTrunksAsync();
            var routesFinalResponse = client.GetRoutesAsync();

            Assert.AreEqual(1, trunksFinalResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(updatedTrunk, trunksFinalResponse.Result.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Result.Value.Count);
            Assert.IsTrue(RouteAreEqual(updatedRoute, routesFinalResponse.Result.Value[0]));
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

            #region Snippet:Set whole configuration
            // Cannot delete trunks that are used in any of the routes, therefore first set the routes as empty list, and then update routes.
            //@@var newTrunks = < new_trunks_list >;
            //@@var newRoutes = < new_routes_list >;

            await client.SetRoutesAsync(new List<SipTrunkRoute>());
            await client.SetTrunksAsync(new List<SipTrunk> { TestData.NewTrunk });
            await client.SetRoutesAsync(new List<SipTrunkRoute> { TestData.RuleNavigateToNewTrunk });
            #endregion Snippet:Set whole configuration

            #region Snippet:Retrieve whole configuration
            var trunksResponse = client.GetTrunksAsync();
            var routesResponse = client.GetRoutesAsync();
            #endregion Snippet:Retrieve whole configuration

            Assert.AreEqual(1, trunksResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(TestData.NewTrunk, trunksResponse.Result.Value[0]));
            Assert.AreEqual(1, routesResponse.Result.Value.Count);
            Assert.IsTrue(RouteAreEqual(TestData.RuleNavigateToNewTrunk, routesResponse.Result.Value[0]));

            #region Snippet:Retrieve one item
            var trunkResponse = client.GetTrunkAsync(TestData.NewTrunk.Fqdn);
            var routeResponse = client.GetRouteAsync(TestData.RuleNavigateToNewTrunk.Name);
            # endregion Snippet:Retrieve one item

            #region Snippet:Set one item
            // Set function will either modify existing item, or append the new item to the collection.
            var updatedTrunk = new SipTrunk(TestData.NewTrunk.Fqdn, 9999);
            var updatedRoute = new SipTrunkRoute(TestData.RuleNavigateToNewTrunk.Name, TestData.RuleNavigateToNewTrunk.NumberPattern, "Alternative description");

            await client.SetTrunkAsync(updatedTrunk); // Modify currently used trunk
            await client.SetTrunkAsync(TestData.TrunkList[0]); // Add new trunk
            await client.SetRouteAsync(updatedRoute); // Modify currently used route
            await client.SetRouteAsync(TestData.RuleNavigateToTrunk1); // Add new route
            #endregion Snippet:Set one item

            #region Snippet:Delete one item
            await client.DeleteRouteAsync(TestData.RuleNavigateToTrunk1.Name);  //Delete route before the trunk, it depends on.
            await client.DeleteTrunkAsync(TestData.Fqdns[0]);
            #endregion Snippet:Delete one item

            var trunksFinalResponse = client.GetTrunksAsync();
            var routesFinalResponse = client.GetRoutesAsync();

            Assert.AreEqual(1, trunksFinalResponse.Result.Value.Count);
            Assert.IsTrue(TrunkAreEqual(updatedTrunk, trunksFinalResponse.Result.Value[0]));
            Assert.AreEqual(1, routesFinalResponse.Result.Value.Count);
            Assert.IsTrue(RouteAreEqual(updatedRoute, routesFinalResponse.Result.Value[0]));
        }
    }
}
