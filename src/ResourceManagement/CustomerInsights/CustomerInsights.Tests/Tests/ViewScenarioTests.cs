// --------------------------------------------------------------------------------------------------------------------
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
// --------------------------------------------------------------------------------------------------------------------

namespace CustomerInsights.Tests.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class ViewScenarioTests
    {
        static ViewScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CrdViewFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var userId = "testUser";

                var viewName = "testView";
                var viewResourceFormat = new ViewResourceFormat
                                             {
                                                 DisplayName = new Dictionary<string, string> { { "en", "some name" } },
                                                 Definition =
                                                     @"{""isProfileType"":false,""profileTypes"":[],""widgets"":[],""style"":[]}",
                                                 UserId = userId
                                             };

                var createdView = aciClient.Views.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    viewName,
                    viewResourceFormat);
                Assert.Equal(viewName, createdView.ViewName);

                var getView = aciClient.Views.Get(ResourceGroupName, HubName, viewName, userId);
                Assert.Equal(viewName, getView.ViewName);

                var deleteConnectorResponse =
                    aciClient.Views.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, viewName, userId).Result;
                Assert.Equal(HttpStatusCode.OK, deleteConnectorResponse.Response.StatusCode);
            }
        }

        [Fact]
        public void ListViewsInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var userId = "testUser";

                var viewName1 = "testView1";
                var viewName2 = "testView2";

                var viewResourceFormat1 = new ViewResourceFormat
                                              {
                                                  DisplayName = new Dictionary<string, string> { { "en", "some name" } },
                                                  Definition =
                                                      @"{""isProfileType"":false,""profileTypes"":[],""widgets"":[],""style"":[]}",
                                                  UserId = userId
                                              };
                var viewResourceFormat2 = new ViewResourceFormat
                                              {
                                                  DisplayName = new Dictionary<string, string> { { "en", "some name" } },
                                                  Definition =
                                                      @"{""isProfileType"":false,""profileTypes"":[],""widgets"":[],""style"":[]}",
                                                  UserId = userId
                                              };

                aciClient.Views.CreateOrUpdate(ResourceGroupName, HubName, viewName1, viewResourceFormat1);
                aciClient.Views.CreateOrUpdate(ResourceGroupName, HubName, viewName2, viewResourceFormat2);

                var result = aciClient.Views.ListByHub(ResourceGroupName, HubName, userId);
                Assert.True(result.ToList().Count >= 2);
                Assert.True(
                    result.ToList().Any(viewReturned => viewName1 == viewReturned.ViewName)
                    && result.ToList().Any(viewReturned => viewName2 == viewReturned.ViewName));
            }
        }
    }
}