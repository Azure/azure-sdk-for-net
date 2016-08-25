//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
                    var webSite = webSitesClient.Sites.GetSite(resourceGroupName, webSiteName, "SiteConfig");

                    Assert.Equal(webSiteName, webSite.SiteName);
                    var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                    Assert.Equal(serverfarmId, webSite.ServerFarmId, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal("value1", webSite.Tags["tag1"]);
                    Assert.Equal("", webSite.Tags["tag2"]);
                    Assert.NotNull(webSite.SiteConfig);
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
                    var webSites = webSitesClient.Sites.GetSites(resourceGroupName, null, null);

                    Assert.Equal(1, webSites.Value.Count);
                    Assert.Equal(webSiteName, webSites.Value[0].Name);
                    var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId,
                    resourceGroupName, whpName);
                    Assert.Equal(serverfarmId, webSites.Value[0].ServerFarmId, StringComparer.OrdinalIgnoreCase);
                });
        }

        [Fact]
        public void CreateAndDeleteWebsite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Start/Stop website

                    webSitesClient.Sites.StopSite(resourceGroupName, webSiteName);

                    var getWebSiteResponse = webSitesClient.Sites.GetSite(resourceGroupName, webSiteName);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.Equal(getWebSiteResponse.State, "Stopped");

                    webSitesClient.Sites.StartSite(resourceGroupName, webSiteName);
                    getWebSiteResponse = webSitesClient.Sites.GetSite(resourceGroupName, webSiteName);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.Equal(getWebSiteResponse.State, "Running");

                    #endregion Start/Stop website

                    webSitesClient.Sites.DeleteSite(resourceGroupName, webSiteName, null,
                        deleteAllSlots: true.ToString());

                    var webSites = webSitesClient.Sites.GetSites(resourceGroupName);

                    Assert.Equal(0, webSites.Value.Count);
                });
        }

        //Fact(Skip = "Test does not work in playback mode due to key matching issue in test framework")]
        [Fact(Skip="TODO: Fix datetime parsing in test to properly handle universal time and rerecord.")]
        public void GetSiteMetrics()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var endTime = DateTime.Parse("2015-10-05T23:49:31Z");
                    var metricNames = new List<string> {"Requests", "CPU", "MemoryWorkingSet"};
                    metricNames.Sort();
                    var result = webSitesClient.Sites.GetSiteMetrics(resourceGroupName: resourceGroupName,
                        name: webSiteName, filter: WebSitesHelper.BuildMetricFilter(startTime: endTime.AddDays(-1), endTime: endTime, timeGrain: "PT1H", metricNames: metricNames), details: true);
                    
                    webSitesClient.Sites.DeleteSite(resourceGroupName, webSiteName, deleteAllSlots: true.ToString());

                    // Validate response
                    Assert.NotNull(result);
                    var actualmetricNames =
                        result.Value.Select(r => r.Name.Value).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
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

                    var configurationResponse = webSitesClient.Sites.GetSiteConfig(resourceGroupName,
                        siteName);

                    Assert.NotNull(configurationResponse);
                    Assert.True(string.IsNullOrEmpty(configurationResponse.PythonVersion));

                    var configurationParameters = new SiteConfig
                    {
                        Location = configurationResponse.Location,
                        PythonVersion = "3.4"
                    };

                    var operationResponse = webSitesClient.Sites.UpdateSiteConfig(resourceGroupName,
                        siteName, configurationParameters);

                    configurationResponse = webSitesClient.Sites.GetSiteConfig(resourceGroupName, siteName);

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
                    var appSetting = new StringDictionary { Location = locationName, Properties = new Dictionary<string, string> { { settingName, settingValue} } };
                    var appSettingsResponse = webSitesClient.Sites.UpdateSiteAppSettings(
                        resourceGroupName,
                        siteName,
                        appSetting);

                    Assert.NotNull(appSettingsResponse);
                    Assert.True(appSettingsResponse.Properties.Contains(new KeyValuePair<string, string>(settingName, settingValue)));

                    appSettingsResponse = webSitesClient.Sites.ListSiteAppSettings(resourceGroupName, siteName);

                    Assert.NotNull(appSettingsResponse);
                    Assert.True(appSettingsResponse.Properties.Contains(new KeyValuePair<string, string>(settingName, settingValue)));

                    #endregion Get/Set Application settings

                    #region Get/Set Metadata

                    const string metadataName = "Metadata 1", metadataValue = "Metadata Value 1";
                    var metadata = new StringDictionary { Location = locationName, Properties = new Dictionary<string, string> { { metadataName, metadataValue } } };
                    var metadataResponse = webSitesClient.Sites.UpdateSiteMetadata(
                        resourceGroupName,
                        siteName,
                        metadata);

                    Assert.NotNull(metadataResponse);
                    Assert.True(metadataResponse.Properties.Contains(new KeyValuePair<string, string>(metadataName, metadataValue)));

                    metadataResponse = webSitesClient.Sites.ListSiteMetadata(resourceGroupName, siteName);

                    Assert.NotNull(metadataResponse);
                    Assert.True(metadataResponse.Properties.Contains(new KeyValuePair<string, string>(metadataName, metadataValue)));

                    #endregion Get/Set Metadata

                    #region Get/Set Connection strings

                    const string connectionStringName = "ConnectionString 1",
                        connectionStringValue = "ConnectionString Value 1";
                    var connStringValueTypePair = new ConnStringValueTypePair
                    {
                        Value = connectionStringValue,
                        Type = DatabaseServerType.MySql
                    };

                    var connectionStringResponse = webSitesClient.Sites.UpdateSiteConnectionStrings(
                        resourceGroupName,
                        siteName,
                        new ConnectionStringDictionary { Location = locationName, Properties = new Dictionary<string, ConnStringValueTypePair> { { connectionStringName, connStringValueTypePair } } });

                    Assert.NotNull(connectionStringResponse);
                    Assert.True(connectionStringResponse.Properties.Contains(new KeyValuePair<string, ConnStringValueTypePair>(connectionStringName, connStringValueTypePair), new ConnectionStringComparer()));

                    connectionStringResponse = webSitesClient.Sites.ListSiteConnectionStrings(resourceGroupName, siteName);

                    Assert.NotNull(connectionStringResponse);
                    Assert.True(connectionStringResponse.Properties.Contains(new KeyValuePair<string, ConnStringValueTypePair>(connectionStringName, connStringValueTypePair), new ConnectionStringComparer()));

                    #endregion Get/Set Connection strings

                    #region Get Publishing credentials

                    var credentialsResponse = webSitesClient.Sites.ListSitePublishingCredentials(resourceGroupName, siteName);

                    Assert.NotNull(credentialsResponse);
                    Assert.Equal("$" + siteName, credentialsResponse.PublishingUserName);
                    Assert.NotNull(credentialsResponse.PublishingPassword);

                    #endregion Get Publishing credentials

                    #region Get Publishing profile XML

                    var publishingProfileResponse = webSitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, siteName, new CsmPublishingProfileOptions() { Format = "WebDeploy" });

                    Assert.NotNull(publishingProfileResponse);
                    var doc = XDocument.Load(publishingProfileResponse, LoadOptions.None);
                    Assert.NotNull(doc);

                    #endregion Get Publishing profile XML

                    webSitesClient.Sites.DeleteSite(resourceGroupName, siteName, deleteAllSlots: true.ToString(), deleteMetrics: true.ToString());

                    webSitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, whpName);
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
                    webSitesClient.Sites.UpdateSlotConfigNames(
                        resourceGroupName,
                        siteName,
                        new SlotConfigNamesResource()
                        {
                            Location = locationName,
                            AppSettingNames = new List<string> { setting1Name, setting2Name },
                            ConnectionStringNames = new List<string> { connection1Name, connection2Name },
                        });

                    var response = webSitesClient.Sites.GetSlotConfigNames(resourceGroupName, siteName);

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

                    webSitesClient.Sites.DeleteSite(resourceGroupName, siteName, deleteAllSlots: true.ToString(), deleteMetrics: true.ToString());
                    webSitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, whpName);
                });
        }

        [Fact(Skip = "Failing on GitHubProxy GetWebHookInfo")]
        public void LinkAndUnlinkSourceControlToWebsiteShouldSucceed()
        {
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
                        webSitesClient.Sites.UpdateSiteSourceControl(
                            resourceGroupName,
                            webSiteName,
                            new SiteSourceControl() { RepoUrl = "https://github.com/amitaptest/HelloKudu"});

                    Assert.Equal("https://github.com/amitaptest/HelloKudu", siteSourceControlUpdateResponse.RepoUrl);

                    var operationResponse =
                        webSitesClient.Sites.DeleteSiteSourceControl(
                            resourceGroupName,
                            webSiteName);
                });
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

                var serverFarm = webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, webHostingPlanName, 
                    new ServerFarmWithRichSku()
                    {
                        ServerFarmWithRichSkuName = webHostingPlanName,
                        Location = location,
                        Sku = new SkuDescription()
                        {
                            Name = skuName,
                            Tier = skuTier
                        }
                    });

                var webSite = webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, webSiteName, new Site
                {
                    SiteName = webSiteName,
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

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, whpName, new ServerFarmWithRichSku()
                {
                    ServerFarmWithRichSkuName = whpName,
                    Location = locationName,
                    Sku = new SkuDescription
                    {
                        Name = "D1",
                        Tier = "Shared",
                        Capacity = 1
                    }
                });

                var createResponse = webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, siteName, new Site
                {
                    SiteName = siteName,
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
                var siteConfig = new SiteConfig
                {
                    Location = locationName,
                    Limits = expectedSitelimits
                };

                webSitesClient.Sites.UpdateSiteConfig(
                    resourceGroupName,
                    siteName,
                    siteConfig);

                var siteGetConfigResponse = webSitesClient.Sites.GetSiteConfig(resourceGroupName, siteName);

                Assert.NotNull(siteGetConfigResponse);
                var limits = siteGetConfigResponse.Limits;
                Assert.NotNull(limits);
                Assert.Equal(expectedSitelimits.MaxDiskSizeInMb, limits.MaxDiskSizeInMb);
                Assert.Equal(expectedSitelimits.MaxMemoryInMb, limits.MaxMemoryInMb);
                Assert.Equal(expectedSitelimits.MaxPercentageCpu, limits.MaxPercentageCpu);

                #endregion Get/Set Site limits

                webSitesClient.Sites.DeleteSite(resourceGroupName, siteName, deleteAllSlots: true.ToString(), deleteMetrics: true.ToString());
                webSitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, whpName);
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
                    var site = new Site()
                    {
                        Location = "West US",
                        CloningInfo = new CloningInfo()
                        {
                            SourceWebAppId = string.Format(webAppIdFormat, webSitesClient.SubscriptionId, resourceGroupName, webSiteName)
                        }
                    };

                    ServiceClientTracing.IsEnabled = true;
                    var operationResponse = webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, targetSiteName, site);
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
