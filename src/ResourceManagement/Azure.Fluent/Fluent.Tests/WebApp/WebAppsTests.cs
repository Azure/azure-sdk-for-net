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
    public class WebAppsTests
    {
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDWebApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string RG_NAME_1 = TestUtilities.GenerateName("javacsmrg");
                string RG_NAME_2 = TestUtilities.GenerateName("javacsmrg");
                string WEBAPP_NAME_1 = TestUtilities.GenerateName("java-webapp-");
                string WEBAPP_NAME_2 = TestUtilities.GenerateName("java-webapp-");
                string APP_SERVICE_PLAN_NAME_1 = TestUtilities.GenerateName("java-asp-");
                string APP_SERVICE_PLAN_NAME_2 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                var webApp1 = appServiceManager.WebApps.Define(WEBAPP_NAME_1)
                    .WithNewResourceGroup(RG_NAME_1)
                    .WithNewAppServicePlan(APP_SERVICE_PLAN_NAME_1)
                    .WithRegion(Region.US_WEST)
                    .WithPricingTier(AppServicePricingTier.Basic_B1)
                    .WithRemoteDebuggingEnabled(RemoteVisualStudioVersion.VS2013)
                    .Create();
                Assert.NotNull(webApp1);
                Assert.Equal(Region.US_WEST, webApp1.Region);
                var plan1 = appServiceManager.AppServicePlans.GetByGroup(RG_NAME_1, APP_SERVICE_PLAN_NAME_1);
                Assert.NotNull(plan1);
                Assert.Equal(Region.US_WEST, plan1.Region);
                Assert.Equal(AppServicePricingTier.Basic_B1, plan1.PricingTier);

                // Create in a new group with existing app service plan
                var webApp2 = appServiceManager.WebApps.Define(WEBAPP_NAME_2)
                    .WithNewResourceGroup(RG_NAME_2)
                    .WithExistingAppServicePlan(plan1)
                    .Create();
                Assert.NotNull(webApp2);
                Assert.Equal(Region.US_WEST, webApp1.Region);

                // Get
                var webApp = appServiceManager.WebApps.GetByGroup(RG_NAME_1, webApp1.Name);
                Assert.Equal(webApp1.Id, webApp.Id);
                webApp = appServiceManager.WebApps.GetById(webApp2.Id);
                Assert.Equal(webApp2.Name, webApp.Name);

                // List
                var webApps = appServiceManager.WebApps.ListByGroup(RG_NAME_1);
                Assert.Equal(1, webApps.Count);
                webApps = appServiceManager.WebApps.ListByGroup(RG_NAME_2);
                Assert.Equal(1, webApps.Count);

                // Update
                webApp1.Update()
                    .WithNewAppServicePlan(APP_SERVICE_PLAN_NAME_2)
                    .WithPricingTier(AppServicePricingTier.Standard_S2)
                    .Apply();
                var plan2 = appServiceManager.AppServicePlans.GetByGroup(RG_NAME_1, APP_SERVICE_PLAN_NAME_2);
                Assert.NotNull(plan2);
                Assert.Equal(Region.US_WEST, plan2.Region);
                Assert.Equal(AppServicePricingTier.Standard_S2, plan2.PricingTier);
            }
        }
    }
}