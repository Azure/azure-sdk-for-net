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
using Microsoft.Azure.Test;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebHostingPlanScenarioTests
    {
        [Fact]
        public void CreateAndVerifyWebHostingPlan()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webHostingPlanName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                        {
                            Location = location
                        });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                    {
                        WebHostingPlan = new WebHostingPlan
                            {
                                Name = webHostingPlanName,
                                Location = location,
                                Properties = new WebHostingPlanProperties
                                {
                                    NumberOfWorkers = 1,
                                    WorkerSize = WorkerSizeOptions.Small,
                                    Sku = SkuOptions.Basic
                                }
                            }
                    });

                var webHostingPlanResponse = webSitesClient.WebHostingPlans.Get(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.WebHostingPlan.Name);
                Assert.Equal(1, webHostingPlanResponse.WebHostingPlan.Properties.NumberOfWorkers);
                Assert.Equal(WorkerSizeOptions.Small, webHostingPlanResponse.WebHostingPlan.Properties.WorkerSize);
                Assert.Equal(SkuOptions.Basic, webHostingPlanResponse.WebHostingPlan.Properties.Sku);
            }
        }

        [Fact]
        public void CreateAndVerifyListOfWebHostingPlan()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string whpName1 = TestUtilities.GenerateName("csmwhp");
                string whpName2 = TestUtilities.GenerateName("csmwhp");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = whpName1,
                        Location = location,
                        Properties = new WebHostingPlanProperties
                        {
                            Sku = SkuOptions.Shared
                        }
                    }
                });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = whpName2,
                        Location = location,
                        Properties = new WebHostingPlanProperties
                        {
                            Sku = SkuOptions.Basic,
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small
                        }
                    }
                });

                var webHostingPlanResponse = webSitesClient.WebHostingPlans.List(resourceGroupName);

                var whp1 = webHostingPlanResponse.WebHostingPlans.First(f => f.Name == whpName1);
                var whp2 = webHostingPlanResponse.WebHostingPlans.First(f => f.Name == whpName2);
                Assert.Equal(whp1.Properties.Sku, SkuOptions.Shared);
                Assert.Equal(whp2.Properties.Sku, SkuOptions.Basic);
            }
        }

        [Fact]
        public void CreateAndDeleteWebHostingPlan()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string whpName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebSites.List(resourceGroupName, null, new WebSiteListParameters());

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = whpName,
                        Location = location,
                        Properties = new WebHostingPlanProperties
                        {
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small
                        }
                    }
                });

                webSitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);

                var webHostingPlanResponse = webSitesClient.WebHostingPlans.List(resourceGroupName);

                Assert.Equal(0, webHostingPlanResponse.WebHostingPlans.Count);
            }
        }

        [Fact]
        public void GetAndSetAdminSiteWebHostingPlan()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string webHostingPlanName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = webHostingPlanName,
                        Location = location,
                        Properties = new WebHostingPlanProperties
                        {
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small,
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
                            ServerFarm = webHostingPlanName
                        }
                    }
                });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = webHostingPlanName,
                        Location = location,
                        Properties = new WebHostingPlanProperties
                        {
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small,
                            Sku = SkuOptions.Standard,
                            AdminSiteName = webSiteName
                        }
                    }
                });

                var webHostingPlanResponse = webSitesClient.WebHostingPlans.Get(resourceGroupName, webHostingPlanName);

                Assert.Equal(webHostingPlanName, webHostingPlanResponse.WebHostingPlan.Name);
                Assert.Equal(1, webHostingPlanResponse.WebHostingPlan.Properties.NumberOfWorkers);
                Assert.Equal(WorkerSizeOptions.Small, webHostingPlanResponse.WebHostingPlan.Properties.WorkerSize);
                Assert.Equal(SkuOptions.Standard, webHostingPlanResponse.WebHostingPlan.Properties.Sku);
                Assert.Equal(webSiteName, webHostingPlanResponse.WebHostingPlan.Properties.AdminSiteName);
            }
        }
    }
}
