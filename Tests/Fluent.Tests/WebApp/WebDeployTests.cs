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
    public class WebDeploy
    {
        [Fact]
        public void CanDeployBakeryWebApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                var webApp1 = appServiceManager.WebApps.Define(WebAppName1)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName1)
                    .WithNewWindowsPlan(PricingTier.BasicB1)
                    .WithNetFrameworkVersion(NetFrameworkVersion.V4_6)
                    .Create();
                Assert.NotNull(webApp1);
                Assert.Equal(Region.USWest, webApp1.Region);
                var plan1 = appServiceManager.AppServicePlans.GetById(webApp1.AppServicePlanId);
                Assert.NotNull(plan1);
                Assert.Equal(Region.USWest, plan1.Region);
                Assert.Equal(PricingTier.BasicB1, plan1.PricingTier);

                IWebDeployment deployment = webApp1.Deploy()
                    .WithPackageUri("https://github.com/Azure/azure-sdk-for-net/raw/Fluent/Tests/Fluent.Tests/Assets/bakery-webapp.zip")
                    .WithExistingDeploymentsDeleted(true)
                    .Execute();

                Assert.NotNull(deployment);
                Assert.True(deployment.Complete);
            }
        }
    }
}