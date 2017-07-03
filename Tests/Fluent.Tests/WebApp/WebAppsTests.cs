// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class WebApps
    {
        [Fact]
        public void CanCRUDWebApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string GroupName2 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName2 = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName1 = TestUtilities.GenerateName("java-asp-");
                string AppServicePlanName2 = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                var webApp1 = appServiceManager.WebApps.Define(WebAppName1)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName1)
                    .WithNewWindowsPlan(PricingTier.BasicB1)
                    .WithRemoteDebuggingEnabled(RemoteVisualStudioVersion.VS2013)
                    .Create();
                Assert.NotNull(webApp1);
                Assert.Equal(Region.USWest, webApp1.Region);
                var plan1 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                Assert.NotNull(plan1);
                Assert.Equal(Region.USWest, plan1.Region);
                Assert.Equal(PricingTier.BasicB1, plan1.PricingTier);

                // Create in a new group with existing app service plan
                var webApp2 = appServiceManager.WebApps.Define(WebAppName2)
                    .WithExistingWindowsPlan(plan1)
                    .WithNewResourceGroup(GroupName2)
                    .Create();
                Assert.NotNull(webApp2);
                Assert.Equal(Region.USWest, webApp1.Region);

                // Get
                var webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName1, webApp1.Name);
                Assert.Equal(webApp1.Id, webApp.Id);
                webApp = appServiceManager.WebApps.GetById(webApp2.Id);
                Assert.Equal(webApp2.Name, webApp.Name);

                // List
                var webApps = appServiceManager.WebApps.ListByResourceGroup(GroupName1);
                Assert.Equal(1, webApps.Count());
                webApps = appServiceManager.WebApps.ListByResourceGroup(GroupName2);
                Assert.Equal(1, webApps.Count());

                // Update
                webApp1.Update()
                    .WithNewAppServicePlan(PricingTier.StandardS2)
                    .Apply();
                var plan2 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                Assert.NotNull(plan2);
                Assert.NotEqual(plan1.Id, plan2.Id);
                Assert.Equal(Region.USWest, plan2.Region);
                Assert.Equal(PricingTier.StandardS2, plan2.PricingTier);
            }
        }
    }
}