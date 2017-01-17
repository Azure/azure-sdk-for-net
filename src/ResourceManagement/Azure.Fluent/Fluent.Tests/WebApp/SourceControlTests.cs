﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Dns.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class SourceControlTests
    {
        [Fact(Skip = "Failing at 31")]
        public async Task CanDeploySourceControl()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var GroupName = TestUtilities.GenerateName("javacsmrg");
                var WebAppName = TestUtilities.GenerateName("java-webapp-");
                var AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create web app
                var webApp = appServiceManager.WebApps.Define(WebAppName)
                    .WithNewResourceGroup(GroupName)
                    .WithNewAppServicePlan(AppServicePlanName)
                    .WithRegion(Region.US_WEST)
                    .WithPricingTier(AppServicePricingTier.Standard_S1)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Create();
                Assert.NotNull(webApp);
                var response = await CheckAddress("http://" + WebAppName + "." + "azurewebsites.Net");
                Assert.Equal(HttpStatusCode.OK.ToString(), response.StatusCode.ToString());

                var body = await response.Content.ReadAsStringAsync();
                Assert.NotNull(body);
                Assert.True(body.Contains("Hello world from linux 4"));
            }
        }

        private static async Task<HttpResponseMessage> CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }
    }
}