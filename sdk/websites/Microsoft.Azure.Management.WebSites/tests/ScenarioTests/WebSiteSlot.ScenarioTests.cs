// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            using (var context = MockContext.Start(this.GetType()))
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
                        Location = location,
                        Sku = new SkuDescription
                        {
                            Name = "S1",
                            Tier = "Standard"
                        }
                    });

                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site
                    {
                        Location = location,
                        Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                        ServerFarmId = serverFarmId
                    });

                string siteSlotResourceName = webSiteName + "/" + slotName;
                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, new Site()
                    {
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
            using (var context = MockContext.Start(this.GetType()))
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
                    Location = location,
                    ServerFarmId = serverFarmId
                });

                string siteSlotResourceName = webSiteName + "/" + slotName;
                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, slot: slotName, siteEnvelope:
                    new Site
                    {
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
            using (var context = MockContext.Start(this.GetType()))
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
                    Location = location,
                    ServerFarmId = serverFarmId
                });

                webSitesClient.WebApps.CreateOrUpdateSlot(resourceGroupName, webSiteName, slot: slotName, siteEnvelope:
                    new Site
                    {
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

