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
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using Newtonsoft.Json.Linq;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class WebSiteScenarioTests : TestBase
    {
        public WebSiteManagementClient GetWebSiteManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            var client = new WebSiteManagementClient(token).WithHandler(handler);
            client = client.WithHandler(handler);
            return client;
        }

        [Fact]
        public void GetWebSiteConfig()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetSiteConfig)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.GetConfiguration("space1", "site1");

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate response 
            Assert.Equal(2, result.AppSettings.Count);
            Assert.NotNull(result.AppSettings.ElementAt(0));
            Assert.Equal("prop1", result.AppSettings.ElementAt(0).Key);
            Assert.Equal("value1", result.AppSettings.ElementAt(0).Value);
            
            Assert.Equal(2, result.ConnectionStrings.Count);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(1, result.RoutingRules.Count);
            Assert.True(result.RoutingRules[0] is RampUpRule);
            
            var rule = (RampUpRule)result.RoutingRules[0];
            Assert.Equal(45, rule.ReroutePercentage);
            Assert.Equal("rule1", rule.Name);
            Assert.Equal("test-host.antares-int.windows-int.net", rule.ActionHostName);

            Assert.NotNull(result.ConnectionStrings);
            Assert.NotNull(result.ConnectionStrings[0]);
            Assert.Equal("connection1", result.ConnectionStrings[0].Name);
            Assert.Equal("mssql", result.ConnectionStrings[0].ConnectionString);
            Assert.Equal(ConnectionStringType.SqlAzure, result.ConnectionStrings[0].Type);

            var expectedSiteLimits = new WebSiteUpdateConfigurationParameters.SiteLimits()
            {
                MaxDiskSizeInMb = 1024,
                MaxMemoryInMb = 512,
                MaxPercentageCpu = 70.5
            };

            Assert.NotNull(result.Limits);
            Assert.Equal(expectedSiteLimits.MaxDiskSizeInMb, result.Limits.MaxDiskSizeInMb);
            Assert.Equal(expectedSiteLimits.MaxMemoryInMb, result.Limits.MaxMemoryInMb);
            Assert.Equal(expectedSiteLimits.MaxPercentageCpu, result.Limits.MaxPercentageCpu);

            bool siteAuthEnabled = result.SiteAuthEnabled.GetValueOrDefault();
            SiteAuthSettings siteAuthSettings = result.SiteAuthSettings;
            Assert.True(siteAuthEnabled);
            Assert.NotNull(siteAuthSettings);
            Assert.Equal("00000000-0000-0000-0000-7984e05b758c", siteAuthSettings.AADClientId);
            Assert.Equal("https://sts.windows.net/00000000-0000-0000-0000-19d76fef90d7/", siteAuthSettings.OpenIdIssuer);
            Assert.Equal(RemoteDebuggingVersion.VS2015, result.RemoteDebuggingVersion);
        }

        [Fact]
        public void UpdateSiteConfig()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetWebSiteManagementClient(handler);

            string expectedClientId = Guid.NewGuid().ToString();
            string expectedIssuer = "https://sts.microsoft.net/" + Guid.NewGuid() + "/";

            var expectedLimits = new WebSiteUpdateConfigurationParameters.SiteLimits()
            {
                MaxDiskSizeInMb = 1024,
                MaxMemoryInMb = 512,
                MaxPercentageCpu = 70.5
            };

            var parameters = new WebSiteUpdateConfigurationParameters
            {
                SiteAuthEnabled = true,
                SiteAuthSettings = new SiteAuthSettings
                {
                    AADClientId = expectedClientId,
                    OpenIdIssuer = expectedIssuer,
                },
                Limits = expectedLimits 
            };

            // Simulate a PUT request to update the config
            client.WebSites.UpdateConfiguration("webspace", "website", parameters);

            // Check the payload of the previous request to see if it matches our expectations
            Assert.Equal(handler.Method, HttpMethod.Put);
            Assert.NotEmpty(handler.Request);
            JObject requestJson = JObject.Parse(handler.Request);

            JToken token;
            Assert.True(requestJson.TryGetValue("SiteAuthEnabled", out token));
            Assert.Equal(JTokenType.Boolean, token.Type);
            Assert.True(token.Value<bool>());

            Assert.True(requestJson.TryGetValue("SiteAuthSettings", out token));
            Assert.Equal(JTokenType.Object, token.Type);

            JObject siteAuthSettingsJson = (JObject)token;
            Assert.True(siteAuthSettingsJson.TryGetValue("AADClientId", out token));
            Assert.Equal(JTokenType.String, token.Type);
            Assert.Equal(expectedClientId, token.Value<string>());

            Assert.True(siteAuthSettingsJson.TryGetValue("OpenIdIssuer", out token));
            Assert.Equal(JTokenType.String, token.Type);
            Assert.Equal(expectedIssuer, token.Value<string>());

            Assert.True(requestJson.TryGetValue("limits", out token));
            Assert.Equal(JTokenType.Object, token.Type);
            JObject limitsJson = (JObject)token;

            Assert.True(limitsJson.TryGetValue("maxDiskSizeInMb", out token));
            Assert.Equal(JTokenType.Integer, token.Type);
            Assert.Equal(expectedLimits.MaxDiskSizeInMb, token.Value<long>());

            Assert.True(limitsJson.TryGetValue("maxMemoryInMb", out token));
            Assert.Equal(JTokenType.Integer, token.Type);
            Assert.Equal(expectedLimits.MaxMemoryInMb, token.Value<long>());

            Assert.True(limitsJson.TryGetValue("maxPercentageCpu", out token));
            Assert.Equal(JTokenType.Float, token.Type);
            Assert.Equal(expectedLimits.MaxPercentageCpu, token.Value<double>());
        }

        [Fact]
        public void GetWebSiteMetrics()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetWebSiteMetricsPerInstancePerMinute)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.GetHistoricalUsageMetrics("space1", "site1", new WebSiteGetHistoricalUsageMetricsParameters()
            {
                TimeGrain = "PT1M",
                StartTime = DateTime.UtcNow.AddHours(-3),
                EndTime = DateTime.UtcNow,
                IncludeInstanceBreakdown = true,
            });

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);


            // Validate response 
            Assert.NotNull(result);
            Assert.NotNull(result.UsageMetrics);
            Assert.NotNull(result.UsageMetrics[0]);
            Assert.NotNull(result.UsageMetrics[0].Data);
            Assert.Equal("CpuTime", result.UsageMetrics[0].Data.Name);
            Assert.NotNull(result.UsageMetrics[0].Data.Values);
            Assert.Equal("PT1M", result.UsageMetrics[0].Data.TimeGrain);
            Assert.Equal("15", result.UsageMetrics[0].Data.Values[0].Total);
            Assert.Null(result.UsageMetrics[0].Data.Values[0].InstanceName);
            Assert.Equal("Total", result.UsageMetrics[0].Data.PrimaryAggregationType);

            // check instance
            Assert.NotNull(result.UsageMetrics[1]);
            Assert.NotNull(result.UsageMetrics[1].Data);
            Assert.Equal("CpuTime", result.UsageMetrics[1].Data.Name);
            Assert.NotNull(result.UsageMetrics[1].Data.Values);
            Assert.Equal("PT1M", result.UsageMetrics[1].Data.TimeGrain);
            Assert.Equal("15", result.UsageMetrics[1].Data.Values[0].Total);
            Assert.Equal("Instance", result.UsageMetrics[1].Data.PrimaryAggregationType);
            Assert.Equal("RD00155D4409B6", result.UsageMetrics[1].Data.Values[0].InstanceName);
        }

        [Fact]
        public void ApplySlotConfiguragion()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetWebSiteMetricsPerInstancePerMinute)
            };

            var handler = new RecordedDelegatingHandler(response) {StatusCodeToReturn = HttpStatusCode.OK};

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.ApplySlotConfiguration("space1", "site1(staging)", "production");

            // Validate headers 
            Assert.Equal(HttpMethod.Post, handler.Method);
        }

        public void ResetSlotConfiguragion()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetWebSiteMetricsPerInstancePerMinute)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.ResetSlotConfiguration("space1", "site1(staging)");

            // Validate headers 
            Assert.Equal(HttpMethod.Post, handler.Method);
        }
    }
}
