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
using System.Linq;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSiteSlotScenarioTests : TestBase
    {
        [Fact]
        public void CreateAndVerifyGetOnAWebsiteSlot()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("cswhp");
                var serverFarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, whpName);
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                        {
                            Location = location
                        });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName, new AppServicePlan()
                    {
                        Name = whpName,
                        Location = location,
                        Sku = new SkuDescription
                        {
                            Name = "S1",
                            Tier = "Standard"
                        }
                    });

                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site
                    {
                        Name = webSiteName,
                        Location = location,
                        Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                        ServerFarmId = serverFarmId
                    });

                string siteSlotResourceName = webSiteName + "/" + slotName;
                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, new Site()
                    {
                        Name = siteSlotResourceName,
                        Location = location,
                        ServerFarmId = serverFarmId
                    }, slotName);

                // TODO: Replace with GetSite with slotName API once its CSM related issue is resolved.
                var webSiteSlotCollection = webSitesClient.WebApps.ListSlots(resourceGroupName, webSiteName);
                Assert.Equal(1, webSiteSlotCollection.Count());
                Assert.Equal(siteSlotResourceName, webSiteSlotCollection.ToList()[0].Name);
            }
        }

        [Fact]
        public void CreateAndVerifyListOfSlots()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("csmwhp");
                var serverFarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, whpName);
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName, new AppServicePlan()
                    {
                        Name = whpName,
                        Location = location,
                        Sku = new SkuDescription
                        {
                            Name = "S1",
                            Tier = "Standard",
                            Capacity = 1
                        }
                    });

                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site
                {
                    Name = webSiteName,
                    Location = location,
                    ServerFarmId = serverFarmId
                });

                string siteSlotResourceName = webSiteName + "/" + slotName;
                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, slot: slotName, siteEnvelope:
                    new Site
                    {
                        Name = siteSlotResourceName,
                        Location = location,
                        ServerFarmId = serverFarmId
                    });

                var webSiteSlots = webSitesClient.WebApps.ListSlots(resourceGroupName, webSiteName);

                Assert.Equal(1, webSiteSlots.Count());
                Assert.Equal(siteSlotResourceName, webSiteSlots.ToList()[0].Name);
                Assert.Equal(serverFarmId, webSiteSlots.ToList()[0].ServerFarmId, StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void CreateAndDeleteWebSiteSlot()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("csmwhp");
                var serverFarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, whpName);
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName,
                    new AppServicePlan
                    {
                        Name = whpName,
                        Location = location,
                        Sku = new SkuDescription
                        {
                            Name = "S1",
                            Tier = "Standard",
                            Capacity = 1
                        }
                    });

                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site
                {
                    Name = webSiteName,
                    Location = location,
                    ServerFarmId = serverFarmId
                });

                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, slot: slotName, siteEnvelope:
                    new Site
                    {
                        Name = webSiteName + "/" + slotName,
                        Location = location,
                        ServerFarmId = serverFarmId
                    });

                webSitesClient.WebApps.DeleteSlot(resourceGroupName, webSiteName, slotName);

                var webSites = webSitesClient.WebApps.ListSlots(resourceGroupName, webSiteName);

                Assert.Equal(0, webSites.Count());
            }
        }
    }
}
