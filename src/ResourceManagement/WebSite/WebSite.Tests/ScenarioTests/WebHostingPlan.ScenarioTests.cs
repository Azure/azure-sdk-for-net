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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebHostingPlanScenarioTests : TestBase
    {
        [Fact]
        public void CreateAndVerifyWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string webHostingPlanName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                        {
                            Location = location
                        });

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, webHostingPlanName, new ServerFarmWithRichSku()
                    {
                        ServerFarmWithRichSkuName = webHostingPlanName,
                        Location = location,
                        Sku = new SkuDescription()
                        {
                            Name = "B1",
                            Tier = "Basic",
                            Capacity = 1
                        }
                    });

                var webHostingPlanResponse = webSitesClient.ServerFarms.GetServerFarm(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.Name);
                Assert.Equal(1, webHostingPlanResponse.Sku.Capacity);
                Assert.Equal("B1", webHostingPlanResponse.Sku.Name);
                Assert.Equal("Basic", webHostingPlanResponse.Sku.Tier);
            }
        }

        [Fact]
        public void CreateAndVerifyListOfWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string whpName1 = TestUtilities.GenerateName("csmwhp");
                string whpName2 = TestUtilities.GenerateName("csmwhp");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, whpName1, serverFarmEnvelope: new ServerFarmWithRichSku()
                {
                    ServerFarmWithRichSkuName = whpName1,
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Tier = "Shared"
                    }
                });

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, whpName2, serverFarmEnvelope: new ServerFarmWithRichSku()
                {
                    ServerFarmWithRichSkuName = whpName2,
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "B1",
                        Capacity = 1,
                        Tier = "Basic"
                    }
                });

                var webHostingPlanResponse = webSitesClient.ServerFarms.GetServerFarms(resourceGroupName);

                var whp1 = webHostingPlanResponse.Value.First(f => f.Name == whpName1);
                var whp2 = webHostingPlanResponse.Value.First(f => f.Name == whpName2);
                Assert.Equal(whp1.Sku.Tier, "Shared");
                Assert.Equal(whp2.Sku.Tier, "Basic");
            }
        }

        [Fact]
        public void CreateAndDeleteWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string whpName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.Sites.GetSites(resourceGroupName);

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, whpName, new ServerFarmWithRichSku() 
                {
                    ServerFarmWithRichSkuName = whpName,
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Capacity = 1,
                        Tier = "Shared"
                    }
                });

                webSitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, whpName);

                var webHostingPlanResponse = webSitesClient.ServerFarms.GetServerFarms(resourceGroupName);

                Assert.Equal(0, webHostingPlanResponse.Value.Count);
            }
        }

        [Fact]
        public void GetAndSetAdminSiteWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string webHostingPlanName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                var serverFarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName,
                    webHostingPlanName);
                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                var serverFarm = webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, webHostingPlanName, new ServerFarmWithRichSku()
                {
                    ServerFarmWithRichSkuName = webHostingPlanName,
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "S1",
                        Capacity = 1,
                        Tier = "Standard"
                    }
                });

                webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, webSiteName, new Site()
                {
                    SiteName = webSiteName,
                    Location = location,
                    Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                    ServerFarmId = serverFarmId
                });

                serverFarm.AdminSiteName = webSiteName;
                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, webHostingPlanName, serverFarm);

                var webHostingPlanResponse = webSitesClient.ServerFarms.GetServerFarm(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.Name);
                Assert.Equal(1, webHostingPlanResponse.Sku.Capacity);
                Assert.Equal("S1", webHostingPlanResponse.Sku.Name);
                Assert.Equal("Standard", webHostingPlanResponse.Sku.Tier);
                Assert.Equal(webSiteName, webHostingPlanResponse.AdminSiteName);
            }
        }

        //[Fact(Skip = "Test does not work in playback mode due to key matching issue in test framework")]
        [Fact(Skip="TODO: Fix datetime parsing in test to correctly handle UTC times and rerecord.")]
        public void GetWebHostingPlanMetrics()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string whpName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                var webSiteName = TestUtilities.GenerateName("csmws");
                var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, whpName,
                    new ServerFarmWithRichSku()
                    {
                        ServerFarmWithRichSkuName = whpName,
                        Location = location,
                        Sku = new SkuDescription
                        {
                            Name = "S1",
                            Capacity = 1,
                            Tier = "Standard"
                        }
                    });

                var webSite = webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, webSiteName, new Site
                {
                    SiteName = webSiteName,
                    Location = location,
                    Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                    ServerFarmId = serverfarmId
                });

                var endTime = DateTime.Parse("2015-12-11T09:52:42Z");
                var metricNames = new List<string> { "MemoryPercentage", "CpuPercentage", "DiskQueueLength", "HttpQueueLength", "BytesReceived", "BytesSent" };
                metricNames.Sort();
                var result = webSitesClient.ServerFarms.GetServerFarmMetrics(resourceGroupName: resourceGroupName,
                    name: whpName,
                    filter:
                        WebSitesHelper.BuildMetricFilter(startTime: endTime.AddDays(-1), endTime: endTime,
                            timeGrain: "PT1H", metricNames: metricNames), details: true);

                webSitesClient.Sites.DeleteSite(resourceGroupName, webSiteName, deleteAllSlots: true.ToString(), deleteEmptyServerFarm: true.ToString());

                var webHostingPlanResponse = webSitesClient.ServerFarms.GetServerFarms(resourceGroupName);

                Assert.Equal(0, webHostingPlanResponse.Value.Count);

                // Validate response
                Assert.NotNull(result);
                var actualmetricNames =
                    result.Value.Select(r => r.Name.Value).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
                actualmetricNames.Sort();
                Assert.Equal(metricNames, actualmetricNames, StringComparer.OrdinalIgnoreCase);

                // validate metrics only for replay since the metrics will not match
                if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    // TODO: Add playback mode assertions. 
                }
            }
        }
    }
}
