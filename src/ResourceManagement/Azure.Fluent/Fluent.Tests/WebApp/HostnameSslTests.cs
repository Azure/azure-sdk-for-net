// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class HostnameSslTests
    {
        [Fact(Skip = "Test requires javacsmrg9b9912262 RG to be configured manually")]
        public async Task CanBindHostnameAndSsl()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string WebAppName = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();
                var domain = appServiceManager.AppServiceDomains.GetByResourceGroup("javacsmrg9b9912262", "graph-dm7720.com");
                var certificateOrder = appServiceManager.AppServiceCertificateOrders.GetByResourceGroup("javacsmrg9b9912262", "graphdmcert7720");

                // hostname binding
                appServiceManager.WebApps.Define(WebAppName)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName)
                    .WithNewWindowsPlan(PricingTier.BasicB1)
                    .DefineHostnameBinding()
                        .WithAzureManagedDomain(domain)
                        .WithSubDomain(WebAppName)
                        .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                        .Attach()
                    .Create();

                var webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                Assert.NotNull(webApp);

                var response = await TestHelper.CheckAddress("http://" + WebAppName + "." + domain.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(await response.Content.ReadAsStringAsync());

                // hostname binding shortcut
                webApp.Update()
                        .WithManagedHostnameBindings(domain, WebAppName + "-1", WebAppName + "-2")
                        .Apply();
                response = await TestHelper.CheckAddress("http://" + WebAppName + "-1." + domain.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(await response.Content.ReadAsStringAsync());
                response = await TestHelper.CheckAddress("http://" + WebAppName + "-2." + domain.Name);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(await response.Content.ReadAsStringAsync());

                // SSL binding
                webApp.Update()
                        .DefineSslBinding()
                            .ForHostname(WebAppName + "." + domain.Name)
                            .WithExistingAppServiceCertificateOrder(certificateOrder)
                            .WithSniBasedSsl()
                            .Attach()
                        .Apply();
                response = null;
                var retryCount = 3;
                while (response == null && retryCount > 0)
                {
                    try
                    {
                        response = await TestHelper.CheckAddress("https://" + WebAppName + "." + domain.Name);
                    }
                    catch (Exception)
                    {
                        retryCount--;
                        TestHelper.Delay(5000);
                    }
                }
                if (retryCount == 0)
                {
                    Assert.True(false);
                }
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(await response.Content.ReadAsStringAsync());
            }
        }
    }
}