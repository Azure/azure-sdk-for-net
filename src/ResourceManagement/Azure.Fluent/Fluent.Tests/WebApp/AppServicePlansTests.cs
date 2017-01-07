// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class AppServicePlansTests
    {
        [Fact]
        public void CanCRUDAppServicePlan()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string RG_NAME = TestUtilities.GenerateName("javacsmrg");
                string APP_SERVICE_PLAN_NAME = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // CREATE
                var appServicePlan = appServiceManager.AppServicePlans
                    .Define(APP_SERVICE_PLAN_NAME)
                    .WithRegion(Region.US_WEST)
                    .WithNewResourceGroup(RG_NAME)
                    .WithPricingTier(AppServicePricingTier.Premium_P1)
                    .WithPerSiteScaling(false)
                    .WithCapacity(2)
                    .Create();
                Assert.NotNull(appServicePlan);
                Assert.Equal(AppServicePricingTier.Premium_P1, appServicePlan.PricingTier);
                Assert.Equal(false, appServicePlan.PerSiteScaling);
                Assert.Equal(2, appServicePlan.Capacity);
                Assert.Equal(0, appServicePlan.NumberOfWebApps);
                Assert.Equal(20, appServicePlan.MaxInstances);
                // GET
                Assert.NotNull(appServiceManager.AppServicePlans.GetByGroup(RG_NAME, APP_SERVICE_PLAN_NAME));
                // LIST
                var appServicePlans = appServiceManager.AppServicePlans.ListByGroup(RG_NAME);
                var found = false;
                foreach (var asp in appServicePlans)
                {
                    if (APP_SERVICE_PLAN_NAME.Equals(asp.Name))
                    {
                        found = true;
                        break;
                    }
                }
                Assert.True(found);
                // UPDATE
                appServicePlan = appServicePlan.Update()
                    .WithPricingTier(AppServicePricingTier.Standard_S1)
                    .WithPerSiteScaling(true)
                    .WithCapacity(3)
                    .Apply();
                Assert.NotNull(appServicePlan);
                Assert.Equal(AppServicePricingTier.Standard_S1, appServicePlan.PricingTier);
                Assert.Equal(true, appServicePlan.PerSiteScaling);
                Assert.Equal(3, appServicePlan.Capacity);
            }
        }
    }
}