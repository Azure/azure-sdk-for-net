// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;

namespace Azure.ResourceManager.ApplicationInsights.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Component
        public static ApplicationInsightsComponentData GetComponentData(AzureLocation location)
        {
            var data = new ApplicationInsightsComponentData(location, "device")
            {
                ApplicationType = ApplicationType.Web,
                FlowType = FlowType.Bluefield,
                RequestSource = new RequestSource(".NET SDK test")
            };
            return data;
        }

        public static void AssertComponment(ApplicationInsightsComponentData data1, ApplicationInsightsComponentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.ConnectionString, data2.ConnectionString);
            Assert.AreEqual(data1.ApplicationType, data2.ApplicationType);
            Assert.AreEqual(data1.FlowType, data2.FlowType);
        }
        #endregion

        #region WebTest
        public static WebTestData GetWebTestData(AzureLocation location, string resourcegroupName, string componentName, string webtestName)
        {
            var data = new WebTestData(location)
            {
                WebTestKind = WebTestKind.Ping,
                SyntheticMonitorId = "my-webtest-my-component",
                IsEnabled = true,
                WebTestName = webtestName,
                Locations =
                {
                    new WebTestGeolocation()
                    {
                        Location = "us-fl-mia-edge",
                    }
                },
                FrequencyInSeconds = 900,
                TimeoutInSeconds = 120,
                Kind = WebTestKind.Ping,
                IsRetryEnabled = true,
                Configuration = new WebTestPropertiesConfiguration()
                {
                    WebTest = "<WebTest Name=\"my-webtest\" Id=\"678ddf96-1ab8-44c8-9274-123456789abc\" Enabled=\"True\" CssProjectStructure=\"\" CssIteration=\"\" Timeout=\"120\" WorkItemIds=\"\" xmlns=\"http://microsoft.com/schemas/VisualStudio/TeamTest/2010\" Description=\"\" CredentialUserName=\"\" CredentialPassword=\"\" PreAuthenticate=\"True\" Proxy=\"default\" StopOnError=\"False\" RecordedResultFile=\"\" ResultsLocale=\"\" ><Items><Request Method=\"GET\" Guid=\"a4162485-9114-fcfc-e086-123456789abc\" Version=\"1.1\" Url=\"http://my-component.azurewebsites.net\" ThinkTime=\"0\" Timeout=\"120\" ParseDependentRequests=\"True\" FollowRedirects=\"True\" RecordResult=\"True\" Cache=\"False\" ResponseTimeGoal=\"0\" Encoding=\"utf-8\" ExpectedHttpStatusCode=\"200\" ExpectedResponseUrl=\"\" ReportingName=\"\" IgnoreHttpStatusCode=\"False\" /></Items></WebTest>"
                },
                Tags =
                {
                    {$"hidden-link:/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/{resourcegroupName}/providers/Microsoft.Insights/components/{componentName}", "Resource"},
                }
            };
            return data;
        }

        public static void AssertWebTestData(WebTestData data1, WebTestData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.FrequencyInSeconds, data2.FrequencyInSeconds);
            Assert.AreEqual(data1.TimeoutInSeconds, data2.TimeoutInSeconds);
            Assert.AreEqual(data1.IsEnabled, data2.IsEnabled);
        }
        #endregion
    }
}
