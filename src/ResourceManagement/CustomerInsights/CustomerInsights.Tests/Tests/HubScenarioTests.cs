//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class HubScenarioTests
    {
        /// <summary>
        ///     Constructor to use same resource group in all the test.
        /// </summary>
        static HubScenarioTests()
        {
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Resource Group name
        /// </summary>
        private static readonly string ResourceGroupName;

        /// <summary>
        ///     CRUD Opoeration for hub
        /// </summary>
        [Fact]
        public void CrdHubFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var hubName = TestUtilities.GenerateName("testHub");

                // Create hub and verify response
                var hub = new Hub
                              {
                                  Location = AppSettings.Region,
                                  HubBillingInfo = new HubBillingInfoFormat { SkuName = "B0", MinUnits = 1, MaxUnits = 5 }
                              };

                var hubResult = aciClient.Hubs.CreateOrUpdate(ResourceGroupName, hubName, hub);
                Assert.Equal(hubName, hubResult.Name);
                Assert.False(string.IsNullOrEmpty(hubResult.ApiEndpoint));

                // Retrieve the hub after create and verify response
                var getResult = aciClient.Hubs.Get(ResourceGroupName, hubName);
                Assert.Equal(hubName, getResult.Name);

                // Delete the hub
                var deleteResult = aciClient.Hubs.DeleteWithHttpMessagesAsync(ResourceGroupName, hubName).Result;
                Assert.Equal(HttpStatusCode.OK, deleteResult.Response.StatusCode);
            }
        }

        /// <summary>
        ///     List all the hub for the resource group given
        /// </summary>
        [Fact]
        public void ListHubsInResourceGroup()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var hubName1 = TestUtilities.GenerateName("testHub");
                var hubName2 = TestUtilities.GenerateName("testHub");

                var hub = new Hub
                              {
                                  Location = AppSettings.Region,
                                  HubBillingInfo = new HubBillingInfoFormat { SkuName = "B0", MinUnits = 1, MaxUnits = 5 }
                              };

                // Create hub and verify response
                aciClient.Hubs.CreateOrUpdate(ResourceGroupName, hubName1, hub);
                aciClient.Hubs.CreateOrUpdate(ResourceGroupName, hubName2, hub);

                // Retrieve the hub after create and verify response
                var result = aciClient.Hubs.ListByResourceGroup(ResourceGroupName).ToList();
                Assert.True(result.Count >= 2);
                Assert.True(
                    result.Any(hubReturned => hubName1 == hubReturned.Name)
                    && result.Any(hubReturned => hubName2 == hubReturned.Name));

                // Delete the hub
                var deleteResult1 = aciClient.Hubs.DeleteWithHttpMessagesAsync(ResourceGroupName, hubName1).Result;
                Assert.Equal(HttpStatusCode.OK, deleteResult1.Response.StatusCode);

                // Delete the hub
                var deleteResult2 = aciClient.Hubs.DeleteWithHttpMessagesAsync(ResourceGroupName, hubName2).Result;
                Assert.Equal(HttpStatusCode.OK, deleteResult2.Response.StatusCode);
            }
        }

        /// <summary>
        ///     List all hub for the Subscription
        /// </summary>
        [Fact]
        public void ListHubsInSubscription()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var hubName1 = TestUtilities.GenerateName("testHub");
                var hubName2 = TestUtilities.GenerateName("testHub");

                var hub = new Hub
                              {
                                  Location = AppSettings.Region,
                                  HubBillingInfo = new HubBillingInfoFormat { SkuName = "B0", MinUnits = 1, MaxUnits = 5 }
                              };

                // Create hub and verify response
                aciClient.Hubs.CreateOrUpdate(ResourceGroupName, hubName1, hub);
                aciClient.Hubs.CreateOrUpdate(ResourceGroupName, hubName2, hub);

                // Retrieve the hub after create and verify response
                var result = aciClient.Hubs.List().ToList();
                Assert.True(result.Count >= 2);
                Assert.True(
                    result.Any(hubReturned => hubName1 == hubReturned.Name)
                    && result.Any(hubReturned => hubName2 == hubReturned.Name));
                // Delete the hub
                var deleteResult1 = aciClient.Hubs.DeleteWithHttpMessagesAsync(ResourceGroupName, hubName1).Result;
                Assert.Equal(HttpStatusCode.OK, deleteResult1.Response.StatusCode);

                // Delete the hub
                var deleteResult2 = aciClient.Hubs.DeleteWithHttpMessagesAsync(ResourceGroupName, hubName2).Result;
                Assert.Equal(HttpStatusCode.OK, deleteResult2.Response.StatusCode);
            }
        }
    }
}