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
    public class LinuxWebApps
    {
        [Fact]
        public void CanCRUDLinuxWebApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string GroupName2 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName2 = TestUtilities.GenerateName("java-webapp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                var webApp1 = appServiceManager.WebApps.Define(WebAppName1)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName1)
                    .WithNewLinuxPlan(PricingTier.BasicB1)
                    .WithPublicDockerHubImage("wordpress")
                    .Create();
                Assert.NotNull(webApp1);
                Assert.Equal(Region.USWest, webApp1.Region);
                var plan1 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                Assert.NotNull(plan1);
                Assert.Equal(Region.USWest, plan1.Region);
                Assert.Equal(PricingTier.BasicB1, plan1.PricingTier);
                Assert.Equal(OperatingSystem.Linux, plan1.OperatingSystem);
                Assert.Equal(OperatingSystem.Linux, webApp1.OperatingSystem);

                // Create in a new group with existing app service plan
                var webApp2 = appServiceManager.WebApps.Define(WebAppName2)
                    .WithExistingWindowsPlan(plan1)
                    .WithNewResourceGroup(GroupName2)
                    .Create();
                Assert.NotNull(webApp2);
                Assert.Equal(Region.USWest, webApp2.Region);
                Assert.Equal(OperatingSystem.Linux, webApp2.OperatingSystem);

                // Get
                var webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName1, webApp1.Name);
                Assert.Equal(webApp1.Id, webApp.Id);
                Assert.Equal(OperatingSystem.Linux, webApp.OperatingSystem);
                webApp = appServiceManager.WebApps.GetById(webApp2.Id);
                Assert.Equal(webApp2.Name, webApp.Name);
                Assert.Equal(OperatingSystem.Linux, webApp.OperatingSystem);

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
                Assert.Equal(OperatingSystem.Linux, plan2.OperatingSystem);

                // Update 2
                webApp1.Update()
                    .WithBuiltInImage(RuntimeStack.NodeJS_6_6)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Apply();
                Assert.NotNull(webApp1);
            }
        }
    }
}