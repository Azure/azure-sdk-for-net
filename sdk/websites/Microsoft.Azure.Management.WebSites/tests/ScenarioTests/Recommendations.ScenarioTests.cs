// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
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
    public class RecommendationScenarioTests : TestBase
    {
        [Fact]
        public void ListRecommendationsRoundTrip()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string farmName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                string locationName = "West US";
                string siteName = TestUtilities.GenerateName("csmws");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = locationName
                    });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, farmName, new AppServicePlan
                {
                    Location = locationName,
                    Sku = new SkuDescription
                    {
                        Name = "S1",
                        Tier = "Standard",
                        Capacity = 1
                    }
                });

                var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, farmName);
                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, siteName, new Site
                {
                    Location = locationName,
                    ServerFarmId = serverfarmId
                });

                var recommendationResponse = webSitesClient.Recommendations.ListRecommendedRulesForWebApp(resourceGroupName, siteName);

                Assert.Equal("0", recommendationResponse.AsEnumerable().Count().ToString());
                Assert.Null(recommendationResponse.NextPageLink);

                var rec = recommendationResponse.FirstOrDefault();

                if (rec != null)
                {
                    Assert.Equal("PaidSiteSlots", rec.RuleName);
                    Assert.False(rec.IsDynamic);
                    Assert.True(rec.NextNotificationTime.HasValue);
                    Assert.True(rec.NotificationExpirationTime.HasValue);
                    Assert.True(rec.RecommendationId.HasValue);
                    Assert.Equal("WebSite", rec.ResourceScope);
                    Assert.Equal(1000, rec.Score);
                }

                webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);

                webSitesClient.AppServicePlans.Delete(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                Assert.Equal("0", serverFarmResponse.AsEnumerable().Count().ToString());
                Assert.Null(serverFarmResponse.NextPageLink);
            }
        }
    }
}
