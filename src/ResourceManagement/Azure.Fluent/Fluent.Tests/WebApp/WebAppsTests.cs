// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class WebAppsTests
    {
        private static readonly string GroupName1 = ResourceNamer.RandomResourceName("javacsmrg", 20);
        private static readonly string GroupName2 = ResourceNamer.RandomResourceName("javacsmrg", 20);
        private static readonly string WebAppName1 = ResourceNamer.RandomResourceName("java-webapp-", 20);
        private static readonly string WebAppName2 = ResourceNamer.RandomResourceName("java-webapp-", 20);
        private static readonly string AppServicePlanName1 = ResourceNamer.RandomResourceName("java-asp-", 20);
        private static readonly string AppServicePlanName2 = ResourceNamer.RandomResourceName("java-asp-", 20);

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDWebApp()
        {
            var appServiceManager = TestHelper.CreateAppServiceManager();

            // Create with new app service plan
            var webApp1 = appServiceManager.WebApps.Define(WebAppName1)
                .WithNewResourceGroup(GroupName1)
                .WithNewAppServicePlan(AppServicePlanName1)
                .WithRegion(Region.US_WEST)
                .WithPricingTier(AppServicePricingTier.Basic_B1)
                .WithRemoteDebuggingEnabled(RemoteVisualStudioVersion.VS2013)
                .Create();
            Assert.NotNull(webApp1);
            Assert.Equal(Region.US_WEST, webApp1.Region);
            var plan1 = appServiceManager.AppServicePlans.GetByGroup(GroupName1, AppServicePlanName1);
            Assert.NotNull(plan1);
            Assert.Equal(Region.US_WEST, plan1.Region);
            Assert.Equal(AppServicePricingTier.Basic_B1, plan1.PricingTier);

            // Create in a new group with existing app service plan
            var webApp2 = appServiceManager.WebApps.Define(WebAppName2)
                .WithNewResourceGroup(GroupName2)
                .WithExistingAppServicePlan(plan1)
                .Create();
            Assert.NotNull(webApp2);
            Assert.Equal(Region.US_WEST, webApp1.Region);

            // Get
            var webApp = appServiceManager.WebApps.GetByGroup(GroupName1, webApp1.Name);
            Assert.Equal(webApp1.Id, webApp.Id);
            webApp = appServiceManager.WebApps.GetById(webApp2.Id);
            Assert.Equal(webApp2.Name, webApp.Name);

            // List
            var webApps = appServiceManager.WebApps.ListByGroup(GroupName1);
            Assert.Equal(1, webApps.Count);
            webApps = appServiceManager.WebApps.ListByGroup(GroupName2);
            Assert.Equal(1, webApps.Count);

            // Update
            webApp1.Update()
                .WithNewAppServicePlan(AppServicePlanName2)
                .WithPricingTier(AppServicePricingTier.Standard_S2)
                .Apply();
            var plan2 = appServiceManager.AppServicePlans.GetByGroup(GroupName1, AppServicePlanName2);
            Assert.NotNull(plan2);
            Assert.Equal(Region.US_WEST, plan2.Region);
            Assert.Equal(AppServicePricingTier.Standard_S2, plan2.PricingTier);
        }
    }
}