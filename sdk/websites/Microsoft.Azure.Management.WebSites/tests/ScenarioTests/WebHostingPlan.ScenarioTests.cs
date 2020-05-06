// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            using (var context = MockContext.Start(this.GetType()))
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

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, webHostingPlanName, new AppServicePlan()
                    {
                        Location = location,
                        Sku = new SkuDescription()
                        {
                            Name = "B1",
                            Tier = "Basic",
                            Capacity = 1
                        }
                    });

                var webHostingPlanResponse = webSitesClient.AppServicePlans.Get(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.Name);
                Assert.Equal(1, webHostingPlanResponse.Sku.Capacity);
                Assert.Equal("B1", webHostingPlanResponse.Sku.Name);
                Assert.Equal("Basic", webHostingPlanResponse.Sku.Tier);
            }
        }

        [Fact]
        public void CreateAndVerifyListOfWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName1, new AppServicePlan()
                {
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Tier = "Shared"
                    }
                });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName2, new AppServicePlan()
                {
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "B1",
                        Capacity = 1,
                        Tier = "Basic"
                    }
                });

                var webHostingPlanResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                var whp1 = webHostingPlanResponse.First(f => f.Name == whpName1);
                var whp2 = webHostingPlanResponse.First(f => f.Name == whpName2);
                Assert.Equal(whp1.Sku.Tier, "Shared");
                Assert.Equal(whp2.Sku.Tier, "Basic");
            }
        }

        [Fact]
        public void CreateAndDeleteWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                webSitesClient.WebApps.ListByResourceGroup(resourceGroupName);

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName, new AppServicePlan() 
                {
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Capacity = 1,
                        Tier = "Shared"
                    }
                });

                webSitesClient.AppServicePlans.Delete(resourceGroupName, whpName);

                var webHostingPlanResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                Assert.Equal(0, webHostingPlanResponse.Count());
            }
        }

        [Fact]
        public void GetAndSetAdminSiteWebHostingPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                var serverFarm = webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, webHostingPlanName, new AppServicePlan()
                {
                    Location = location,
                    Sku = new SkuDescription
                    {
                        Name = "S1",
                        Capacity = 1,
                        Tier = "Standard"
                    }
                });

                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site()
                {
                    Location = location,
                    Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                    ServerFarmId = serverFarmId
                });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, webHostingPlanName, serverFarm);

                var webHostingPlanResponse = webSitesClient.AppServicePlans.Get(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.Name);
                Assert.Equal(1, webHostingPlanResponse.Sku.Capacity);
                Assert.Equal("S1", webHostingPlanResponse.Sku.Name);
                Assert.Equal("Standard", webHostingPlanResponse.Sku.Tier);
            }
        }
    }
}

