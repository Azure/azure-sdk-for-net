// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSiteScenarioTests : TestBase
    {
        private delegate void WebsiteTestDelegate(string webSiteName, string resourceGroupName, string webHostingPlanName, string location, WebSiteManagementClient webSitesClient, ResourceManagementClient resourcesClient);

        [Fact]
        public void CreateAndVerifyGetOnAWebsite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var webSite = webSitesClient.WebApps.Get(resourceGroupName, webSiteName);

                    Assert.Equal(webSiteName, webSite.Name);
                    var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                    Assert.Equal(serverfarmId, webSite.ServerFarmId, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal("value1", webSite.Tags["tag1"]);
                    Assert.Equal("", webSite.Tags["tag2"]);
                    Assert.NotNull(webSite.HostNameSslStates);
                    Assert.NotEmpty(webSite.HostNameSslStates);
                });
        }

        [Fact]
        public void CreateAndVerifyListOfWebsites()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var webSites = webSitesClient.WebApps.ListByResourceGroup(resourceGroupName, null);

                    Assert.Equal(1, webSites.Count());
                    Assert.Equal(webSiteName, webSites.ToList()[0].Name);
                    var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                    Assert.Equal(serverfarmId, webSites.ToList()[0].ServerFarmId, StringComparer.OrdinalIgnoreCase);
                });
        }

        [Fact]
        public void CreateAndDeleteWebsite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Start/Stop website

                    webSitesClient.WebApps.Stop(resourceGroupName, webSiteName);

                    var getWebSiteResponse = webSitesClient.WebApps.Get(resourceGroupName, webSiteName);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.Equal(getWebSiteResponse.State, "Stopped");

                    webSitesClient.WebApps.Start(resourceGroupName, webSiteName);
                    getWebSiteResponse = webSitesClient.WebApps.Get(resourceGroupName, webSiteName);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.Equal(getWebSiteResponse.State, "Running");

                    #endregion Start/Stop website

                    webSitesClient.WebApps.Delete(resourceGroupName, webSiteName, null);

                    var webSites = webSitesClient.WebApps.ListByResourceGroup(resourceGroupName);

                    Assert.Equal(0, webSites.Count());
                });
        }

        [Fact(Skip = "Deptecated API")]
        //[Fact(Skip="TODO: Fix datetime parsing in test to properly handle universal time and rerecord.")]
        public void GetSiteMetrics()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var endTime = DateTime.Parse("2018-01-28T00:23:02Z").ToUniversalTime();
                    var metricNames = new List<string> {"Requests", "CPU", "MemoryWorkingSet"};
                    metricNames.Sort();
                    var result = webSitesClient.WebApps.ListMetrics(resourceGroupName: resourceGroupName,
                        name: webSiteName, filter: WebSitesHelper.BuildMetricFilter(startTime: endTime.AddDays(-1), endTime: endTime, timeGrain: "PT1H", metricNames: metricNames), details: true);
                    
                    webSitesClient.WebApps.Delete(resourceGroupName, webSiteName);

                    // Validate response
                    Assert.NotNull(result);
                    var actualmetricNames =
                        result.Select(r => r.Name.Value).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
                    actualmetricNames.Sort();
                    Assert.Equal(metricNames, actualmetricNames, StringComparer.OrdinalIgnoreCase);

                    // validate metrics only for replay since the metrics will not match
                    if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                    {
                        // TODO: Add playback mode assertions. 
                    }
                });
        }

        [Fact]
        public void GetAndSetNonSensitiveSiteConfigs()
        {
            RunWebsiteTestScenario(
                (siteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Get/Set PythonVersion

                    var configurationResponse = webSitesClient.WebApps.GetConfiguration(resourceGroupName,
                        siteName);

                    Assert.NotNull(configurationResponse);
                    Assert.True(string.IsNullOrEmpty(configurationResponse.PythonVersion));

                    var configurationParameters = new SiteConfigResource
                    {
                        PythonVersion = "3.4"
                    };

                    var operationResponse = webSitesClient.WebApps.UpdateConfiguration(resourceGroupName,
                        siteName, configurationParameters);

                    configurationResponse = webSitesClient.WebApps.GetConfiguration(resourceGroupName, siteName);

                    Assert.NotNull(configurationResponse);
                    Assert.Equal(configurationResponse.PythonVersion, configurationParameters.PythonVersion);

                    #endregion Get/Set PythonVersion
                });
        }

        [Fact]
        public void GetAndSetSensitiveSiteConfigs()
        {
            RunWebsiteTestScenario(
                (siteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Get/Set Application settings

                    const string settingName = "Application Setting1", settingValue = "Setting Value 1";
                    var appSetting = new StringDictionary { Properties = new Dictionary<string, string> { { settingName, settingValue} } };
                    var appSettingsResponse = webSitesClient.WebApps.UpdateApplicationSettings(
                        resourceGroupName,
                        siteName,
                        appSetting);

                    Assert.NotNull(appSettingsResponse);
                    Assert.True(appSettingsResponse.Properties.Contains(new KeyValuePair<string, string>(settingName, settingValue)));

                    appSettingsResponse = webSitesClient.WebApps.ListApplicationSettings(resourceGroupName, siteName);

                    Assert.NotNull(appSettingsResponse);
                    Assert.True(appSettingsResponse.Properties.Contains(new KeyValuePair<string, string>(settingName, settingValue)));

                    #endregion Get/Set Application settings

                    #region Get/Set Metadata

                    const string metadataName = "Metadata 1", metadataValue = "Metadata Value 1";
                    var metadata = new StringDictionary { Properties = new Dictionary<string, string> { { metadataName, metadataValue } } };
                    var metadataResponse = webSitesClient.WebApps.UpdateMetadata(
                        resourceGroupName,
                        siteName,
                        metadata);

                    Assert.NotNull(metadataResponse);
                    Assert.True(metadataResponse.Properties.Contains(new KeyValuePair<string, string>(metadataName, metadataValue)));

                    metadataResponse = webSitesClient.WebApps.ListMetadata(resourceGroupName, siteName);

                    Assert.NotNull(metadataResponse);
                    Assert.True(metadataResponse.Properties.Contains(new KeyValuePair<string, string>(metadataName, metadataValue)));

                    #endregion Get/Set Metadata

                    #region Get/Set Connection strings

                    const string connectionStringName = "ConnectionString 1",
                        connectionStringValue = "ConnectionString Value 1";
                    var connStringValueTypePair = new ConnStringValueTypePair
                    {
                        Value = connectionStringValue,
                        Type = ConnectionStringType.MySql
                    };

                    var connectionStringResponse = webSitesClient.WebApps.UpdateConnectionStrings(
                        resourceGroupName,
                        siteName,
                        new ConnectionStringDictionary { Properties = new Dictionary<string, ConnStringValueTypePair> { { connectionStringName, connStringValueTypePair } } });

                    Assert.NotNull(connectionStringResponse);
                    Assert.True(connectionStringResponse.Properties.Contains(new KeyValuePair<string, ConnStringValueTypePair>(connectionStringName, connStringValueTypePair), new ConnectionStringComparer()));

                    connectionStringResponse = webSitesClient.WebApps.ListConnectionStrings(resourceGroupName, siteName);

                    Assert.NotNull(connectionStringResponse);
                    Assert.True(connectionStringResponse.Properties.Contains(new KeyValuePair<string, ConnStringValueTypePair>(connectionStringName, connStringValueTypePair), new ConnectionStringComparer()));

                    #endregion Get/Set Connection strings

                    #region Get Publishing credentials

                    var credentialsResponse = webSitesClient.WebApps.ListPublishingCredentials(resourceGroupName, siteName);

                    Assert.NotNull(credentialsResponse);
                    Assert.Equal("$" + siteName, credentialsResponse.PublishingUserName);
                    Assert.NotNull(credentialsResponse.PublishingPassword);

                    #endregion Get Publishing credentials

                    #region Get Publishing profile XML

                    var publishingProfileResponse = webSitesClient.WebApps.ListPublishingProfileXmlWithSecrets(resourceGroupName, siteName, new CsmPublishingProfileOptions() { Format = "WebDeploy" });

                    Assert.NotNull(publishingProfileResponse);
                    var doc = XDocument.Load(publishingProfileResponse, LoadOptions.None);
                    Assert.NotNull(doc);

                    #endregion Get Publishing profile XML

                    webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);

                    webSitesClient.AppServicePlans.Delete(resourceGroupName, whpName);
                });
        }

        [Fact]
        public void GetAndSetSlotSettingsConfigs()
        {
            RunWebsiteTestScenario(
                (siteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Get/Set slot settings

                    const string setting1Name = "AppSetting1", setting2Name = "AppSetting2";
                    const string connection1Name = "ConnString1", connection2Name = "ConnString2";
                    webSitesClient.WebApps.UpdateSlotConfigurationNames(
                        resourceGroupName,
                        siteName,
                        new SlotConfigNamesResource()
                        {
                            AppSettingNames = new List<string> { setting1Name, setting2Name },
                            ConnectionStringNames = new List<string> { connection1Name, connection2Name },
                        });

                    var response = webSitesClient.WebApps.ListSlotConfigurationNames(resourceGroupName, siteName);

                    Assert.NotNull(response);
                    Assert.NotNull(response.AppSettingNames);
                    var appSettingsNames = response.AppSettingNames;
                    Assert.Single(appSettingsNames.Where(a => a == setting1Name));
                    Assert.Single(appSettingsNames.Where(a => a == setting2Name));

                    Assert.NotNull(response.ConnectionStringNames);
                    var connectionStringNames = response.ConnectionStringNames;
                    Assert.Single(connectionStringNames.Where(a => a == connection1Name));
                    Assert.Single(connectionStringNames.Where(a => a == connection2Name));

                    #endregion Get/Set slot settings

                    webSitesClient.WebApps.Delete(resourceGroupName, siteName,  deleteMetrics: true);
                    webSitesClient.AppServicePlans.Delete(resourceGroupName, whpName);
                });
        }

        [Fact(Skip = "Failing on GitHubProxy GetWebHookInfo")]
        public void LinkAndUnlinkSourceControlToWebsiteShouldSucceed()
        {
            /*
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var gitHubSourceControl = new SourceControl()
                    {
                        SourceControlName = "GitHub",
                        Token = "36c7290f81fda5877d52d2fc3fbc7c31acd25051",
                        Location = locationName
                    };

                    webSitesClient.Provider.UpdateSourceControl(gitHubSourceControl.SourceControlName, gitHubSourceControl);

                    var siteSourceControlUpdateResponse =
                        webSitesClient.WebApps.UpdateSiteSourceControl(
                            resourceGroupName,
                            webSiteName,
                            new SiteSourceControl() { RepoUrl = "https://github.com/amitaptest/HelloKudu"});

                    Assert.Equal("https://github.com/amitaptest/HelloKudu", siteSourceControlUpdateResponse.RepoUrl);

                    var operationResponse =
                        webSitesClient.WebApps.DeleteSiteSourceControl(
                            resourceGroupName,
                            webSiteName);
                });
            */
        }

        private void RunWebsiteTestScenario(WebsiteTestDelegate testAction, string skuTier = "Shared", string skuName = "D1",
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName= "testframework_failed")
        {
            using (var context = MockContext.Start(this.GetType().FullName, methodName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                var webSiteName = TestUtilities.GenerateName("csmws");
                var resourceGroupName = TestUtilities.GenerateName("csmrg");
                var webHostingPlanName = TestUtilities.GenerateName("csmwhp");
                var location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                var serverFarm = webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, webHostingPlanName, 
                    new AppServicePlan()
                    {
                        Location = location,
                        Sku = new SkuDescription()
                        {
                            Name = skuName,
                            Tier = skuTier
                        }
                    });

                var webSite = webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, webSiteName, new Site
                {
                    Location = location,
                    Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                    ServerFarmId = serverFarm.Id
                });

                Assert.Equal(webSiteName, webSite.Name);
                Assert.Equal(serverFarm.Id, webSite.ServerFarmId, StringComparer.OrdinalIgnoreCase);
                Assert.Equal("value1", webSite.Tags["tag1"]);
                Assert.Equal("", webSite.Tags["tag2"]);

                testAction(webSiteName, resourceGroupName, webHostingPlanName, location, webSitesClient, resourcesClient);
            }
        }

        [Fact]
        public void GetAndSetSiteLimits()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                var whpName = TestUtilities.GenerateName("cswhp");
                var resourceGroupName = TestUtilities.GenerateName("csmrg");

                var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                var locationName = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");
                var siteName = TestUtilities.GenerateName("csmws");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = locationName
                    });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, whpName, new AppServicePlan()
                {
                    Location = locationName,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Tier = "Shared",
                        Capacity = 1
                    }
                });

                var createResponse = webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, siteName, new Site
                {
                    Location = locationName,
                    ServerFarmId = serverfarmId
                });

                #region Get/Set Site limits

                var expectedSitelimits = new SiteLimits()
                {
                    MaxDiskSizeInMb = 512,
                    MaxMemoryInMb = 1024,
                    MaxPercentageCpu = 70.5
                };
                var siteConfig = new SiteConfigResource
                {
                    Limits = expectedSitelimits
                };

                webSitesClient.WebApps.UpdateConfiguration(
                    resourceGroupName,
                    siteName,
                    siteConfig);

                var siteGetConfigResponse = webSitesClient.WebApps.GetConfiguration(resourceGroupName, siteName);

                Assert.NotNull(siteGetConfigResponse);
                var limits = siteGetConfigResponse.Limits;
                Assert.NotNull(limits);
                Assert.Equal(expectedSitelimits.MaxDiskSizeInMb, limits.MaxDiskSizeInMb);
                Assert.Equal(expectedSitelimits.MaxMemoryInMb, limits.MaxMemoryInMb);
                Assert.Equal(expectedSitelimits.MaxPercentageCpu, limits.MaxPercentageCpu);

                #endregion Get/Set Site limits

                webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);
                webSitesClient.AppServicePlans.Delete(resourceGroupName, whpName);
            }
        }

        //[Fact(Skip = "Test failing due to test issue. Needs further investigation")]
        [Fact]
        public void CloneSite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    string targetSiteName = TestUtilities.GenerateName("csmws");
                    string location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");
                    var webAppIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.Web/sites/{2}";
                    var serverFarmIdFormat = "/subscriptions/{0}/resourcegroups/{1}/providers/Microsoft.Web/serverfarms/{2}";
                    var site = new Site()
                    {
                        Location = "West US",
                        ServerFarmId = string.Format(serverFarmIdFormat, webSitesClient.SubscriptionId, resourceGroupName, whpName),
                        CloningInfo = new CloningInfo()
                        {
                            SourceWebAppId = string.Format(webAppIdFormat, webSitesClient.SubscriptionId, resourceGroupName, webSiteName),
                        }
                    };

                    ServiceClientTracing.IsEnabled = true;
                    var operationResponse = webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, targetSiteName, site);
                    ServiceClientTracing.IsEnabled = false;
                }, "Premium", "P1");
        }

        private Guid ParseOperationIdFromLocation(string location)
        {
            var locationSplit = location.Split('/');
            Assert.NotEmpty(locationSplit);
            Guid operationId;
            Assert.True(Guid.TryParse(locationSplit.Last(), out operationId));
            return operationId;
        }

        private void WaitForOperationCompletion(double timeOutInSeconds, double timeIntervalInMilliSeconds, string operationName, Func<HttpStatusCode> operationToCall)
        {
            DateTime endTime = DateTime.Now.AddSeconds(timeOutInSeconds);
            double interval = timeIntervalInMilliSeconds;
            HttpStatusCode status = HttpStatusCode.Accepted;
            while (status == HttpStatusCode.Accepted && DateTime.Now < endTime)
            {
                status = operationToCall();
                if (DateTime.Now.AddMilliseconds(interval) > endTime)
                {
                    interval = (endTime - DateTime.Now).TotalMilliseconds;
                }

                Thread.Sleep((int)interval);
            }

            switch (status)
            {
                case HttpStatusCode.Accepted:
                    throw new Exception(string.Format("Timed out waiting on operation {0} after {1} s", operationName, timeIntervalInMilliSeconds));
                case HttpStatusCode.OK:
                    return;
                default:
                    throw new Exception(string.Format("Operation {0} was not successful. Status {1}", operationName, status.ToString()));
            }
        }
    }

    class ConnectionStringComparer : IEqualityComparer<KeyValuePair<string, ConnStringValueTypePair>>
    {
        public bool Equals(KeyValuePair<string, ConnStringValueTypePair> x, KeyValuePair<string, ConnStringValueTypePair> y)
        {
            return string.Equals(x.Key, y.Key, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(x.Value.Value, y.Value.Value, StringComparison.OrdinalIgnoreCase) && x.Value.Type == y.Value.Type;
        }

        public int GetHashCode(KeyValuePair<string, ConnStringValueTypePair> obj)
        {
            return obj.Key.GetHashCode() ^ obj.Value.Type.GetHashCode() ^ obj.Value.Value.GetHashCode();
        }
    }
}
