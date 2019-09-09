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
    public class ResourceHealthMetadataTests : TestBase
    {
        [Fact]
        public void ListResourceHealthMetadata()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                var resourceHealthMetadataResponse = webSitesClient.ResourceHealthMetadata.ListBySite(resourceGroupName, siteName);

                Assert.NotEmpty(resourceHealthMetadataResponse);
                if (resourceHealthMetadataResponse != null) {
                    Assert.Single(resourceHealthMetadataResponse);
                }

                var metadata = resourceHealthMetadataResponse.FirstOrDefault();

                if (metadata != null)
                {
                    Assert.Equal("default", metadata.Name);
                    Assert.Equal("Microsoft.Web/sites/resourceHealthMetadata", metadata.Type);
                }

                webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);

                webSitesClient.AppServicePlans.Delete(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                Assert.Empty(serverFarmResponse);
            }
        }

        [Fact]
        public void GetResourceHealthMetadata()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                var resourceHealthMetadataResponse = webSitesClient.ResourceHealthMetadata.GetBySite(resourceGroupName, siteName);

                if (resourceHealthMetadataResponse != null)
                {
                    Assert.Equal("default", resourceHealthMetadataResponse.Name);
                    Assert.Equal("Microsoft.Web/sites/resourceHealthMetadata", resourceHealthMetadataResponse.Type);
                }

                webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);

                webSitesClient.AppServicePlans.Delete(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                Assert.Empty(serverFarmResponse);
            }
        }
    }
}

