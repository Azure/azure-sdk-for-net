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
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSiteScenarioTests
    {
        private delegate void WebsiteTestDelegate(string webSiteName, string resourceGroupName, string webHostingPlanName, string location, WebSiteManagementClient webSitesClient, ResourceManagementClient resourcesClient);

        [Fact]
        public void CreateAndVerifyGetOnAWebsite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var webSite = webSitesClient.WebSites.Get(resourceGroupName, webSiteName, null, new WebSiteGetParameters()
                    {
                        PropertiesToInclude = new List<string>() { "SiteConfig" }
                    });

                    Assert.Equal(webSiteName, webSite.WebSite.Name);
                    Assert.Equal(webSite.WebSite.Properties.ServerFarm, whpName);
                    Assert.Equal("value1", webSite.WebSite.Tags["tag1"]);
                    Assert.Equal("", webSite.WebSite.Tags["tag2"]);
                    Assert.NotNull(webSite.WebSite.Properties.SiteConfig);
                    Assert.NotNull(webSite.WebSite.Properties.HostNameSslStates);
                    Assert.NotEmpty(webSite.WebSite.Properties.HostNameSslStates);
                });
        }

        [Fact]
        public void CreateAndVerifyListOfWebsites()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var webSites = webSitesClient.WebSites.List(resourceGroupName, null, null);

                    Assert.Equal(1, webSites.WebSites.Count);
                    Assert.Equal(webSiteName, webSites.WebSites[0].Name);
                    Assert.Equal(whpName, webSites.WebSites[0].Properties.ServerFarm);
                });
        }

        [Fact]
        public void CreateAndDeleteWebsite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    #region Start/Stop website

                    AzureOperationResponse stopResponse = webSitesClient.WebSites.Stop(resourceGroupName, webSiteName, null);
                    Assert.Equal(HttpStatusCode.OK, stopResponse.StatusCode);

                    WebSiteGetParameters parameters = new WebSiteGetParameters()
                    {
                        PropertiesToInclude = null
                    };

                    WebSiteGetResponse getWebSiteResponse = webSitesClient.WebSites.Get(resourceGroupName, webSiteName, null, parameters);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.NotNull(getWebSiteResponse.WebSite);
                    Assert.NotNull(getWebSiteResponse.WebSite.Properties);
                    Assert.Equal(getWebSiteResponse.WebSite.Properties.State, WebSiteState.Stopped);

                    AzureOperationResponse startResponse = webSitesClient.WebSites.Start(resourceGroupName, webSiteName, null);
                    Assert.Equal(HttpStatusCode.OK, startResponse.StatusCode);
                    getWebSiteResponse = webSitesClient.WebSites.Get(resourceGroupName, webSiteName, null, null);
                    Assert.NotNull(getWebSiteResponse);
                    Assert.NotNull(getWebSiteResponse.WebSite);
                    Assert.NotNull(getWebSiteResponse.WebSite.Properties);
                    Assert.Equal(getWebSiteResponse.WebSite.Properties.State, WebSiteState.Running);

                    #endregion Start/Stop website

                    webSitesClient.WebSites.Delete(resourceGroupName, webSiteName, null, new WebSiteDeleteParameters
                    {
                        DeleteAllSlots = true
                    });

                    var webSites = webSitesClient.WebSites.List(resourceGroupName, null, null);

                    Assert.Equal(0, webSites.WebSites.Count);
                });
        }

        [Fact(Skip = "Microsoft.WindowsAzure.CloudExceptionInvalidFilterValueParameter: Argument Null; Parameter name: $filter")]
        public void GetSiteMetrics()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var endTime = new DateTime(2014, 8, 8, 1, 0, 0);

                    var result = webSitesClient.WebSites.GetHistoricalUsageMetrics(resourceGroupName, webSiteName, null, new WebSiteGetHistoricalUsageMetricsParameters()
                    {
                        MetricNames = new List<string>() { "Requests" },
                        TimeGrain = "PT1H",
                        StartTime = endTime.AddHours(-3),
                        EndTime = endTime,
                        IncludeInstanceBreakdown = true,
                    });

                    webSitesClient.WebSites.Delete(resourceGroupName, webSiteName, null, new WebSiteDeleteParameters
                    {
                        DeleteAllSlots = true
                    });

                    // Validate response
                    Assert.NotNull(result);
                    Assert.NotNull(result.UsageMetrics);
                    Assert.NotNull(result.UsageMetrics[0]);

                    // validate metrics only for replay since the metrics will not match
                    if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                    {
                        Assert.NotNull(result.UsageMetrics[0].Data);
                        Assert.Equal("Requests", result.UsageMetrics[0].Data.Name);
                        Assert.NotNull(result.UsageMetrics[0].Data.Values);
                        Assert.Equal("01:00:00", result.UsageMetrics[0].Data.TimeGrain);
                        Assert.Equal("400", result.UsageMetrics[0].Data.Values[0].Total);
                        Assert.Null(result.UsageMetrics[0].Data.Values[0].InstanceName);
                        Assert.Equal("Total", result.UsageMetrics[0].Data.PrimaryAggregationType);

                        // check instance
                        Assert.NotNull(result.UsageMetrics[1]);
                        Assert.NotNull(result.UsageMetrics[1].Data);
                        Assert.Equal("Requests", result.UsageMetrics[1].Data.Name);
                        Assert.NotNull(result.UsageMetrics[1].Data.Values);
                        Assert.Equal("01:00:00", result.UsageMetrics[1].Data.TimeGrain);
                        Assert.Equal("400", result.UsageMetrics[1].Data.Values[0].Total);
                        Assert.Equal("Instance", result.UsageMetrics[1].Data.PrimaryAggregationType);
                        Assert.Equal("RD00155D50A272", result.UsageMetrics[1].Data.Values[0].InstanceName);
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

                    var configurationResponse = webSitesClient.WebSites.GetConfiguration(resourceGroupName,
                        siteName, null, new WebSiteGetConfigurationParameters());

                    Assert.NotNull(configurationResponse.Resource);
                    Assert.NotNull(configurationResponse.Resource.Properties);
                    Assert.True(String.IsNullOrEmpty(configurationResponse.Resource.Properties.PythonVersion));

                    var configurationParameters = new WebSiteUpdateConfigurationParameters
                    {
                        Location = configurationResponse.Resource.Location,
                        Properties = new WebSiteUpdateConfigurationDetails
                        {
                            PythonVersion = "3.4"
                        }
                    };
                    var operationResponse = webSitesClient.WebSites.UpdateConfiguration(resourceGroupName,
                        siteName, null, configurationParameters);

                    Assert.Equal(HttpStatusCode.OK, operationResponse.StatusCode);

                    configurationResponse = webSitesClient.WebSites.GetConfiguration(resourceGroupName,
                        siteName, null, new WebSiteGetConfigurationParameters());

                    Assert.NotNull(configurationResponse.Resource);
                    Assert.NotNull(configurationResponse.Resource.Properties);
                    Assert.Equal(configurationResponse.Resource.Properties.PythonVersion, configurationParameters.Properties.PythonVersion);

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
                    var appSetting = new NameValuePair() { Name = settingName, Value = settingValue };
                    var appSettingsResponse = webSitesClient.WebSites.UpdateAppSettings(
                        resourceGroupName,
                        siteName,
                        null,
                        new WebSiteNameValueParameters(new List<NameValuePair>() { appSetting }, locationName));

                    Assert.NotNull(appSettingsResponse.Resource);
                    Assert.NotNull(appSettingsResponse.Resource.Properties);
                    var appSettings = appSettingsResponse.Resource.Properties;
                    Assert.Single(appSettings.Where(a => a.Name == settingName && a.Value == settingValue));

                    appSettingsResponse = webSitesClient.WebSites.GetAppSettings(resourceGroupName,
                        siteName, null);

                    Assert.NotNull(appSettingsResponse.Resource);
                    Assert.NotNull(appSettingsResponse.Resource.Properties);
                    appSettings = appSettingsResponse.Resource.Properties;
                    Assert.Single(appSettings.Where(a => a.Name == settingName && a.Value == settingValue));

                    #endregion Get/Set Application settings

                    #region Get/Set Metadata

                    const string metadataName = "Metadata 1", metadataValue = "Metadata Value 1";
                    var metadata = new NameValuePair() { Name = metadataName, Value = metadataValue };
                    var metadataResponse = webSitesClient.WebSites.UpdateMetadata(
                        resourceGroupName,
                        siteName,
                        null,
                        new WebSiteNameValueParameters()
                        {
                            Location = locationName,
                            Properties = new List<NameValuePair> { metadata }
                        });

                    Assert.NotNull(metadataResponse.Resource);
                    Assert.NotNull(metadataResponse.Resource.Properties);
                    var metadatas = metadataResponse.Resource.Properties;
                    Assert.Single(metadatas.Where(m => m.Name == metadataName && m.Value == metadataValue));

                    metadataResponse = webSitesClient.WebSites.GetMetadata(resourceGroupName,
                        siteName, null);

                    Assert.NotNull(metadataResponse.Resource);
                    Assert.NotNull(metadataResponse.Resource.Properties);
                    metadatas = metadataResponse.Resource.Properties;
                    Assert.Single(metadatas.Where(m => m.Name == metadataName && m.Value == metadataValue));

                    #endregion Get/Set Metadata

                    #region Get/Set Connection strings

                    const string connectionString = "ConnectionString 1", connectionStringValue = "ConnectionString Value 1";
                    var connectionStringInfo = new ConnectionStringInfo()
                    {
                        ConnectionString = connectionString,
                        Name = connectionStringValue,
                        Type = DatabaseServerType.MySql
                    };

                    var connectionStringResponse = webSitesClient.WebSites.UpdateConnectionStrings(
                        resourceGroupName,
                        siteName,
                        null,
                        new WebSiteUpdateConnectionStringsParameters()
                        {
                            Location = locationName,
                            Properties = new List<ConnectionStringInfo>() { { connectionStringInfo } }
                        });

                    Assert.NotNull(connectionStringResponse);
                    Assert.NotNull(connectionStringResponse.Resource.Properties);
                    var connectionStrings = connectionStringResponse.Resource.Properties;
                    Assert.Single(connectionStrings.Where(c => c.Name == connectionStringInfo.Name && c.ConnectionString == connectionStringInfo.ConnectionString && c.Type == connectionStringInfo.Type));

                    connectionStringResponse = webSitesClient.WebSites.GetConnectionStrings(resourceGroupName,
                        siteName, null);

                    Assert.NotNull(connectionStringResponse);
                    Assert.NotNull(connectionStringResponse.Resource.Properties);
                    connectionStrings = connectionStringResponse.Resource.Properties;
                    Assert.Single(connectionStrings.Where(c => c.Name == connectionStringInfo.Name && c.ConnectionString == connectionStringInfo.ConnectionString && c.Type == connectionStringInfo.Type));

                    #endregion Get/Set Connection strings

                    #region Get Publishing credentials

                    var credentialsResponse = webSitesClient.WebSites.GetPublishingCredentials(resourceGroupName, siteName, null);

                    Assert.NotNull(credentialsResponse.Resource);
                    Assert.NotNull(credentialsResponse.Resource.Properties);
                    Assert.Equal("$" + siteName, credentialsResponse.Resource.Properties.PublishingUserName);
                    Assert.NotNull(credentialsResponse.Resource.Properties.PublishingPassword);

                    #endregion Get Publishing credentials

                    #region Get Publishing profile XML

                    var publishingProfileResponse = webSitesClient.WebSites.GetPublishProfile(resourceGroupName, siteName, null);

                    Assert.NotEmpty(publishingProfileResponse.PublishProfiles);

                    #endregion Get Publishing profile XML

                    webSitesClient.WebSites.Delete(resourceGroupName, siteName, null, new WebSiteDeleteParameters()
                    {
                        DeleteAllSlots = true,
                        DeleteMetrics = true
                    });

                    webSitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);
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
                    webSitesClient.WebSites.UpdateSlotConfigNames(
                        resourceGroupName,
                        siteName,
                        new SlotConfigNamesUpdateParameters
                        {
                            Properties = new SlotConfigNames()
                            {
                                AppSettingNames = { setting1Name, setting2Name },
                                ConnectionStringNames = { connection1Name, connection2Name },
                            },
                            Location = locationName,
                        });

                    var response = webSitesClient.WebSites.GetSlotConfigNames(resourceGroupName, siteName);

                    Assert.NotNull(response.Resource);
                    Assert.NotNull(response.Resource.Properties);
                    Assert.NotNull(response.Resource.Properties.AppSettingNames);
                    var appSettingsNames = response.Resource.Properties.AppSettingNames;
                    Assert.Single(appSettingsNames.Where(a => a == setting1Name));
                    Assert.Single(appSettingsNames.Where(a => a == setting2Name));

                    Assert.NotNull(response.Resource.Properties.ConnectionStringNames);
                    var connectionStringNames = response.Resource.Properties.ConnectionStringNames;
                    Assert.Single(connectionStringNames.Where(a => a == connection1Name));
                    Assert.Single(connectionStringNames.Where(a => a == connection2Name));

                    #endregion Get/Set slot settings

                    webSitesClient.WebSites.Delete(resourceGroupName, siteName, null, new WebSiteDeleteParameters()
                    {
                        DeleteAllSlots = true,
                        DeleteMetrics = true
                    });

                    webSitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);
                });
        }

        [Fact]
        public void LinkAndUnlinkSourceControlToWebsiteShouldSucceed()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    var gitHubSourceControl = new SourceControl()
                    {
                        Name = "GitHub",
                        Properties = new SourceControlProperties()
                        {
                            Token = "36c7290f81fda5877d52d2fc3fbc7c31acd25051"
                        }
                    };

                    webSitesClient.SourceControls.Update(gitHubSourceControl.Name, new SourceControlUpdateParameters()
                    {
                        Properties = gitHubSourceControl.Properties
                    });

                    SiteSourceControlUpdateResponse siteSourceControlUpdateResponse =
                        webSitesClient.WebSites.UpdateSiteSourceControl(
                            resourceGroupName,
                            webSiteName,
                            null,
                            new SiteSourceControlUpdateParameters(
                                new SiteSourceControlProperties("https://github.com/amitaptest/HelloKudu")));

                    Assert.Equal(HttpStatusCode.OK, siteSourceControlUpdateResponse.StatusCode);
                    Assert.Equal("https://github.com/amitaptest/HelloKudu", siteSourceControlUpdateResponse.SiteSourceControl.Properties.RepoUrl);

                    AzureOperationResponse operationResponse =
                        webSitesClient.WebSites.DeleteSiteSourceControl(
                            resourceGroupName,
                            webSiteName,
                            null,
                            "https://github.com/amitaptest/HelloKudu");

                    Assert.Equal(HttpStatusCode.OK, operationResponse.StatusCode);
                });
        }

        private void RunWebsiteTestScenario(WebsiteTestDelegate testAction, SkuOptions sku = SkuOptions.Shared)
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(4);
                WebSiteManagementClient webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                ResourceManagementClient resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string webSiteName = TestUtilities.GenerateName("csmws");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                string webHostingPlanName = TestUtilities.GenerateName("csmwhp");
                string location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName,
                    new WebHostingPlanCreateOrUpdateParameters
                    {
                        WebHostingPlan = new WebHostingPlan
                        {
                            Name = webHostingPlanName,
                            Location = location,
                            Properties = new WebHostingPlanProperties()
                            {
                                Sku = sku
                            }
                        }
                    });

                var webSite = webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, webSiteName, null, new WebSiteCreateOrUpdateParameters
                {
                    WebSite = new WebSiteBase
                    {
                        Name = webSiteName,
                        Location = location,
                        Tags = new Dictionary<string, string> { { "tag1", "value1" }, { "tag2", "" } },
                        Properties = new WebSiteBaseProperties
                        {
                            ServerFarm = webHostingPlanName
                        }
                    }
                });

                Assert.Equal(webSiteName, webSite.WebSite.Name);
                Assert.Equal(webSite.WebSite.Properties.ServerFarm, webHostingPlanName);
                Assert.Equal("value1", webSite.WebSite.Tags["tag1"]);
                Assert.Equal("", webSite.WebSite.Tags["tag2"]);

                testAction(webSiteName, resourceGroupName, webHostingPlanName, location, webSitesClient, resourcesClient);
            }
        }

        [Fact]
        public void GetAndSetSiteLimits()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = ResourceGroupHelper.GetWebSitesClient(handler);
                var resourcesClient = ResourceGroupHelper.GetResourcesClient(handler);

                string whpName = TestUtilities.GenerateName("cswhp");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                var locationName = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");
                string siteName = TestUtilities.GenerateName("csmws");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = locationName
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = whpName,
                        Location = locationName,
                        Properties = new WebHostingPlanProperties
                        {
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small
                        }
                    }
                });

                var createResponse = webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, siteName, null, new WebSiteCreateOrUpdateParameters()
                {
                    WebSite = new WebSiteBase()
                    {
                        Name = siteName,
                        Location = locationName,
                        Properties = new WebSiteBaseProperties()
                        {
                            ServerFarm = whpName
                        }
                    }
                });

                #region Get/Set Site limits

                var expectedSitelimits = new SiteLimits()
                {
                    MaxDiskSizeInMb = 512,
                    MaxMemoryInMb = 1024,
                    MaxPercentageCpu = 70.5
                };
                var parameters = new WebSiteUpdateConfigurationParameters()
                {
                    Location = locationName,
                    Properties = new WebSiteUpdateConfigurationDetails()
                    {
                        Limits = expectedSitelimits
                    }
                };


                var siteUpdateConfigResponse = webSitesClient.WebSites.UpdateConfiguration(
                    resourceGroupName,
                    siteName,
                    null,
                    parameters);

                Assert.Equal(HttpStatusCode.OK, siteUpdateConfigResponse.StatusCode);

                var siteGetConfigResponse = webSitesClient.WebSites.GetConfiguration(resourceGroupName,
                    siteName, null, null);

                Assert.NotNull(siteGetConfigResponse);
                Assert.NotNull(siteGetConfigResponse.Resource);
                Assert.NotNull(siteGetConfigResponse.Resource.Properties);
                var limits = siteGetConfigResponse.Resource.Properties.Limits;
                Assert.NotNull(limits);
                Assert.Equal(expectedSitelimits.MaxDiskSizeInMb, limits.MaxDiskSizeInMb);
                Assert.Equal(expectedSitelimits.MaxMemoryInMb, limits.MaxMemoryInMb);
                Assert.Equal(expectedSitelimits.MaxPercentageCpu, limits.MaxPercentageCpu);

                #endregion Get/Set Site limits

                webSitesClient.WebSites.Delete(resourceGroupName, siteName, null, new WebSiteDeleteParameters()
                {
                    DeleteAllSlots = true,
                    DeleteMetrics = true
                });

                webSitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);
            }
        }

        [Fact(Skip = "Test needs to be re-recorded")]
        public void CloneSite()
        {
            RunWebsiteTestScenario(
                (webSiteName, resourceGroupName, whpName, locationName, webSitesClient, resourcesClient) =>
                {
                    string targetSiteName = TestUtilities.GenerateName("csmws");
                    string location = ResourceGroupHelper.GetResourceLocation(resourcesClient, "Microsoft.Web/sites");
                    WebSiteCloneParameters parameters = new WebSiteCloneParameters()
                    {
                        WebSiteClone = new WebSiteCloneBase()
                        {
                            Location = location,
                            Properties = new WebSiteCloneBaseProperties()
                            {
                                CloningInfo = new CloningInfo()
                                {
                                    Source = new SourceWebSite()
                                    {
                                        Location = location,
                                        Name = webSiteName,
                                        ResourceGroupName = resourceGroupName,
                                        SubscriptionId = resourcesClient.Credentials.SubscriptionId
                                    }
                                }
                            }
                        }
                    };

                    var operationResponse = webSitesClient.WebSites.Clone(resourceGroupName, targetSiteName, null,
                        parameters);
                    Assert.NotNull(operationResponse);
                    Assert.NotNull(operationResponse.Location);

                    Guid operationId = ParseOperationIdFromLocation(operationResponse.Location);

                    WaitForOperationCompletion(360, 1000, "WebSites.GetOperation", () =>
                    {
                        operationResponse = webSitesClient.WebSites.GetOperation(resourceGroupName, targetSiteName, null, operationId);
                        return operationResponse.StatusCode;
                    });
                }, SkuOptions.Standard);
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
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep((int)interval);
                }
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
}
