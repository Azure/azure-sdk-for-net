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
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSiteSlotScenarioTests
    {
        [Fact]
        public void CreateAndVerifyGetOnAWebsiteSlot()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("cswhp");
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                        {
                            Location = location
                        });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName,
                    new WebHostingPlanCreateOrUpdateParameters
                    {
                        WebHostingPlan = new WebHostingPlan
                        {
                            Name = whpName,
                            Location = location,
                            Properties = new WebHostingPlanProperties
                            {
                                Sku = SkuOptions.Standard
                            }
                        }
                    });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, null, new WebSiteCreateOrUpdateParameters
                    {
                        WebSite = new WebSiteBase
                            {
                                Name = webSiteName,
                                Location = location,
                                Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                                Properties = new WebSiteBaseProperties
                                {
                                    ServerFarm = whpName
                                }
                            }
                    });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, slotName,
                    new WebSiteCreateOrUpdateParameters
                    {
                        WebSite = new WebSiteBase
                        {
                            Location = location,
                            Properties = new WebSiteBaseProperties
                            {
                                ServerFarm = whpName
                            }
                        }
                    });

                // TODO: Replace with GetSite with slotName API once its CSM related issue is resolved.
                var webSiteSlotCollection = webSitesClient.WebSites.List(resourceGroupName, webSiteName, null);
                Assert.Equal(1, webSiteSlotCollection.WebSites.Count);
                Assert.Equal(siteWithSlotName, webSiteSlotCollection.WebSites[0].Name);
            }
        }

        [Fact]
        public void CreateAndVerifyListOfSlots()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("csmwhp");
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName,
                    new WebHostingPlanCreateOrUpdateParameters
                    {
                        WebHostingPlan = new WebHostingPlan
                        {
                            Name = whpName,
                            Location = location,
                            Properties = new WebHostingPlanProperties()
                            {
                                Sku = SkuOptions.Standard
                            }
                        }
                    });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, null, new WebSiteCreateOrUpdateParameters
                {
                    WebSite = new WebSiteBase
                    {
                        Name = webSiteName,
                        Location = location,
                        Properties = new WebSiteBaseProperties
                        {
                            ServerFarm = whpName
                        }
                    }
                });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, slotName,
                    new WebSiteCreateOrUpdateParameters
                    {
                        WebSite = new WebSiteBase
                        {
                            Location = location,
                            Properties = new WebSiteBaseProperties
                            {
                                ServerFarm = whpName
                            }
                        }
                    });

                var webSiteSlots = webSitesClient.WebSites.List(resourceGroupName, webSiteName, null);

                Assert.Equal(1, webSiteSlots.WebSites.Count);
                Assert.Equal(siteWithSlotName, webSiteSlots.WebSites[0].Name);
                Assert.Equal(whpName, webSiteSlots.WebSites[0].Properties.ServerFarm);
            }
        }

        [Fact]
        public void CreateAndDeleteWebSiteSlot()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string whpName = TestUtilities.GenerateName("csmwhp");
                const string slotName = "staging";
                string siteWithSlotName = string.Format("{0}({1})", webSiteName, slotName);

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName,
                    new WebHostingPlanCreateOrUpdateParameters
                    {
                        WebHostingPlan = new WebHostingPlan
                        {
                            Name = whpName,
                            Location = location,
                            Properties = new WebHostingPlanProperties()
                            {
                                Sku = SkuOptions.Standard
                            }
                        }
                    });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, null, new WebSiteCreateOrUpdateParameters
                {
                    WebSite = new WebSiteBase
                    {
                        Name = webSiteName,
                        Location = location,
                        Properties = new WebSiteBaseProperties
                        {
                            ServerFarm = whpName
                        }
                    }
                });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, slotName,
                    new WebSiteCreateOrUpdateParameters
                    {
                        WebSite = new WebSiteBase
                        {
                            Location = location,
                            Properties = new WebSiteBaseProperties
                            {
                                ServerFarm = whpName
                            }
                        }
                    });

                webSitesClient.WebSites.Delete(resourceGroupName, webSiteName, slotName, new WebSiteDeleteParameters
                {
                    DeleteAllSlots = false
                });

                var webSites = webSitesClient.WebSites.List(resourceGroupName, webSiteName, null);

                Assert.Equal(0, webSites.WebSites.Count);
            }
        }
    }
}
