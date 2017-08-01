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
    public class FunctionApps
    {
        [Fact]
        public void CanCRUDFunctionApp()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName1 = TestUtilities.GenerateName("javacsmrg");
                string GroupName2 = TestUtilities.GenerateName("javacsmrg");
                string WebAppName1 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName2 = TestUtilities.GenerateName("java-webapp-");
                string WebAppName3 = TestUtilities.GenerateName("java-webapp-");
                string StorageName1 = TestUtilities.GenerateName("javast");
                if (StorageName1.Length >= 23)
                {
                    StorageName1 = StorageName1.Substring(0, 20);
                }
                StorageName1 = StorageName1.Replace("-", string.Empty);

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with consumption plan
                var functionApp1 = appServiceManager.FunctionApps.Define(WebAppName1)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName1)
                    .Create();
                Assert.NotNull(functionApp1);
                Assert.Equal(Region.USWest, functionApp1.Region);
                var plan1 = appServiceManager.AppServicePlans.GetById(functionApp1.AppServicePlanId);
                Assert.NotNull(plan1);
                Assert.Equal(Region.USWest, plan1.Region);
                Assert.Equal(new PricingTier("Dynamic", "Y1"), plan1.PricingTier);

                // Create in a new group with existing consumption plan
                var functionApp2 = appServiceManager.FunctionApps.Define(WebAppName2)
                    .WithExistingAppServicePlan(plan1)
                    .WithNewResourceGroup(GroupName2)
                    .WithExistingStorageAccount(functionApp1.StorageAccount)
                    .Create();
                Assert.NotNull(functionApp2);
                Assert.Equal(Region.USWest, functionApp2.Region);

                // Create with app service plan
                var functionApp3 = appServiceManager.FunctionApps.Define(WebAppName3)
                    .WithRegion(Region.USWest)
                    .WithExistingResourceGroup(GroupName2)
                    .WithNewAppServicePlan(PricingTier.BasicB1)
                    .WithExistingStorageAccount(functionApp1.StorageAccount)
                    .Create();
                Assert.NotNull(functionApp3);
                Assert.Equal(Region.USWest, functionApp3.Region);

                // Get
                var functionApp = appServiceManager.FunctionApps.GetByResourceGroup(GroupName1, functionApp1.Name);
                Assert.Equal(functionApp1.Id, functionApp.Id);
                functionApp = appServiceManager.FunctionApps.GetById(functionApp2.Id);
                Assert.Equal(functionApp2.Name, functionApp.Name);

                // List
                var functionApps = appServiceManager.FunctionApps.ListByResourceGroup(GroupName1);
                Assert.Equal(1, functionApps.Count());
                functionApps = appServiceManager.FunctionApps.ListByResourceGroup(GroupName2);
                Assert.Equal(2, functionApps.Count());

                // Update
                functionApp2.Update()
                    .WithNewStorageAccount(StorageName1, Microsoft.Azure.Management.Storage.Fluent.Models.SkuName.StandardGRS)
                    .Apply();
                Assert.Equal(StorageName1, functionApp2.StorageAccount.Name);

                // Scale
                functionApp3.Update()
                    .WithNewAppServicePlan(PricingTier.StandardS2)
                    .Apply();
                var plan2 = appServiceManager.AppServicePlans.GetById(functionApp3.AppServicePlanId);
                Assert.NotNull(plan2);
                Assert.NotEqual(plan1.Id, plan2.Id);
                Assert.Equal(Region.USWest, plan2.Region);
                Assert.Equal(PricingTier.StandardS2, plan2.PricingTier);
            }
        }
    }
}