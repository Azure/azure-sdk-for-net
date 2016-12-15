// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Dns.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class SourceControlTests
    {
        private static readonly string RG_NAME = ResourceNamer.RandomResourceName("javacsmrg", 20);
        private static readonly string WEBAPP_NAME = ResourceNamer.RandomResourceName("java-webapp-", 20);
        private static readonly string APP_SERVICE_PLAN_NAME = ResourceNamer.RandomResourceName("java-asp-", 20);

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public async Task CanDeploySourceControl()
        {
            var appServiceManager = TestHelper.CreateAppServiceManager();

            // Create web app
            var webApp = appServiceManager.WebApps.Define(WEBAPP_NAME)
                .WithNewResourceGroup(RG_NAME)
                .WithNewAppServicePlan(APP_SERVICE_PLAN_NAME)
                .WithRegion(Region.US_WEST)
                .WithPricingTier(AppServicePricingTier.STANDARD_S1)
                .DefineSourceControl()
                    .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                    .WithBranch("master")
                    .Attach()
                .Create();
            Assert.NotNull(webApp);
            var response = await CheckAddress("http://" + WEBAPP_NAME + "." + "azurewebsites.Net");
            Assert.Equal(HttpStatusCode.OK.ToString(), response.StatusCode.ToString());

            var body = await response.Content.ReadAsStringAsync();
            Assert.NotNull(body);
            Assert.True(body.Contains("Hello world from linux 4"));
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