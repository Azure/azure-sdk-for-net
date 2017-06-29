// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Dns.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class SourceControlTests
    {
        [Fact]
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
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName)
                    .WithNewWindowsPlan(PricingTier.StandardS1)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Create();
                Assert.NotNull(webApp);
                var response = await TestHelper.CheckAddress("http://" + WebAppName + "." + "azurewebsites.Net");
                Assert.Equal(HttpStatusCode.OK.ToString(), response.StatusCode.ToString());

                var body = await response.Content.ReadAsStringAsync();
                Assert.NotNull(body);
                Assert.True(body.Contains("Hello world from linux 4"));
            }
        }
    }
}