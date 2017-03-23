// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
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
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // CREATE
                var appServicePlan = appServiceManager.AppServicePlans
                    .Define(AppServicePlanName)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName)
                    .WithPricingTier(AppServicePricingTier.PremiumP1)
                    .WithPerSiteScaling(false)
                    .WithCapacity(2)
                    .Create();
                Assert.NotNull(appServicePlan);
                Assert.Equal(AppServicePricingTier.PremiumP1, appServicePlan.PricingTier);
                Assert.Equal(false, appServicePlan.PerSiteScaling);
                Assert.Equal(2, appServicePlan.Capacity);
                Assert.Equal(0, appServicePlan.NumberOfWebApps);
                Assert.Equal(20, appServicePlan.MaxInstances);
                // GET
                Assert.NotNull(appServiceManager.AppServicePlans.GetByGroup(GroupName, AppServicePlanName));
                // LIST
                var appServicePlans = appServiceManager.AppServicePlans.ListByGroup(GroupName);
                var found = false;
                foreach (var asp in appServicePlans)
                {
                    if (AppServicePlanName.Equals(asp.Name))
                    {
                        found = true;
                        break;
                    }
                }
                Assert.True(found);
                // UPDATE
                appServicePlan = appServicePlan.Update()
                    .WithPricingTier(AppServicePricingTier.StandardS1)
                    .WithPerSiteScaling(true)
                    .WithCapacity(3)
                    .Apply();
                Assert.NotNull(appServicePlan);
                Assert.Equal(AppServicePricingTier.StandardS1, appServicePlan.PricingTier);
                Assert.Equal(true, appServicePlan.PerSiteScaling);
                Assert.Equal(3, appServicePlan.Capacity);
            }
        }
    }
}