// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Fluent.Tests.WebApp
{
    public class WebAppConfigTests
    {
        [Fact]
        public void CanCRUDWebAppConfig()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                string GroupName = TestUtilities.GenerateName("javacsmrg");
                string WebAppName = TestUtilities.GenerateName("java-webapp-");
                string AppServicePlanName = TestUtilities.GenerateName("java-asp-");

                var appServiceManager = TestHelper.CreateAppServiceManager();

                // Create with new app service plan
                appServiceManager.WebApps.Define(WebAppName)
                    .WithRegion(Region.USWest)
                    .WithNewResourceGroup(GroupName)
                    .WithNewWindowsPlan(PricingTier.BasicB1)
                    .WithNetFrameworkVersion(NetFrameworkVersion.V3_0)
                    .Create();

                var webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                Assert.NotNull(webApp);
                Assert.Equal(Region.USWest, webApp.Region);
                Assert.Equal(NetFrameworkVersion.V3_0, webApp.NetFrameworkVersion);

                // Java version
                webApp.Update()
                    .WithJavaVersion(JavaVersion.V7_51)
                    .WithWebContainer(WebContainer.Tomcat7_0_50)
                    .Apply();
                webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                Assert.Equal(JavaVersion.V7_51, webApp.JavaVersion);

                // Python version
                webApp.Update()
                    .WithPythonVersion(PythonVersion.V34)
                    .Apply();
                webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                Assert.Equal(PythonVersion.V34, webApp.PythonVersion);

                // Default documents
                var documentSize = webApp.DefaultDocuments.Count;
                webApp.Update()
                        .WithDefaultDocument("somedocument.Html")
                        .Apply();
                webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                Assert.Equal(documentSize + 1, webApp.DefaultDocuments.Count);
                Assert.True(webApp.DefaultDocuments.Contains("somedocument.Html"));

                // App settings
                webApp.Update()
                        .WithAppSetting("appkey", "appvalue")
                        .WithStickyAppSetting("stickykey", "stickyvalue")
                        .Apply();
                webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
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
                webApp = appServiceManager.WebApps.GetByResourceGroup(GroupName, WebAppName);
                var connectionStringMap = webApp.ConnectionStrings;
                Assert.Equal("connectionValue", connectionStringMap["connectionName"].Value);
                Assert.Equal(false, connectionStringMap["connectionName"].Sticky);
                Assert.Equal("stickyValue", connectionStringMap["stickyName"].Value);
                Assert.Equal(true, connectionStringMap["stickyName"].Sticky);
            }
        }
    }
}