// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Azure.Tests.WebApp
{
    public class WebAppConfigTests
    {
        [Fact]
        public void CanCRUDWebAppConfig()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string RG_NAME = TestUtilities.GenerateName("javacsmrg");
                string WEBAPP_NAME = TestUtilities.GenerateName("java-webapp-");
                string APP_SERVICE_PLAN_NAME = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                appServiceManager.WebApps.Define(WEBAPP_NAME)
                    .WithNewResourceGroup(RG_NAME)
                    .WithNewAppServicePlan(APP_SERVICE_PLAN_NAME)
                    .WithRegion(Region.US_WEST)
                    .WithPricingTier(AppServicePricingTier.Basic_B1)
                    .WithNetFrameworkVersion(NetFrameworkVersion.V3_0)
                    .Create();

                var webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                Assert.NotNull(webApp);
                Assert.Equal(Region.US_WEST, webApp.Region);
                Assert.Equal(NetFrameworkVersion.V3_0, webApp.NetFrameworkVersion);

                // Java version
                webApp.Update()
                    .WithJavaVersion(JavaVersion.Java_1_7_0_51)
                    .WithWebContainer(WebContainer.Tomcat_7_0_50)
                    .Apply();
                webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                Assert.Equal(JavaVersion.Java_1_7_0_51, webApp.JavaVersion);

                // Python version
                webApp.Update()
                    .WithPythonVersion(PythonVersion.Python_34)
                    .Apply();
                webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                Assert.Equal(PythonVersion.Python_34, webApp.PythonVersion);

                // Default documents
                var documentSize = webApp.DefaultDocuments.Count;
                webApp.Update()
                        .WithDefaultDocument("somedocument.Html")
                        .Apply();
                webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                Assert.Equal(documentSize + 1, webApp.DefaultDocuments.Count);
                Assert.True(webApp.DefaultDocuments.Contains("somedocument.Html"));

                // App settings
                webApp.Update()
                        .WithAppSetting("appkey", "appvalue")
                        .WithStickyAppSetting("stickykey", "stickyvalue")
                        .Apply();
                webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                var appSettingMap = webApp.AppSettings;
                Assert.Equal("appvalue", appSettingMap["appkey"].Value);
                Assert.Equal(false, appSettingMap["appkey"].Sticky);
                Assert.Equal("stickyvalue", appSettingMap["stickykey"].Value);
                Assert.Equal(true, appSettingMap["stickykey"].Sticky);

                // Connection strings
                webApp.Update()
                        .WithConnectionString("connectionName", "connectionValue", ConnectionStringType.Custom)
                        .WithStickyConnectionString("stickyName", "stickyValue", ConnectionStringType.Custom)
                        .Apply();
                webApp = appServiceManager.WebApps.GetByGroup(RG_NAME, WEBAPP_NAME);
                var connectionStringMap = webApp.ConnectionStrings;
                Assert.Equal("connectionValue", connectionStringMap["connectionName"].Value);
                Assert.Equal(false, connectionStringMap["connectionName"].Sticky);
                Assert.Equal("stickyValue", connectionStringMap["stickyName"].Value);
                Assert.Equal(true, connectionStringMap["stickyName"].Sticky);
            }
        }
    }
}