// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using ApplicationInsights.Tests.Helpers;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace ApplicationInsights.Tests.Scenarios
{
    public class WebtestsTest : TestBase
    {
        private const string ResourceGroupName = "swaggertest";
        private RecordedDelegatingHandler handler;


        public WebtestsTest()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteWebtests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = this.GetAppInsightsManagementClient(context, handler);

                //prepare a component
                var createdComponentResponse = this.CreateAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteWebtests));

                //add a new web test
                WebTest createWebTestProperties = GetCreateWebTestProperties(createdComponentResponse.Body.Id);

                var createWebTestResponse = insightsClient
                                                .WebTests
                                                .CreateOrUpdateWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    createWebTestProperties.SyntheticMonitorId,
                                                    createWebTestProperties)
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Equal(createWebTestProperties.WebTestName, createWebTestResponse.Body.WebTestName);
                Assert.Equal(createWebTestProperties.Kind, createWebTestResponse.Body.Kind);
                Assert.Equal(createWebTestProperties.SyntheticMonitorId, createWebTestResponse.Body.SyntheticMonitorId);
                Assert.Equal(createWebTestProperties.Enabled, createWebTestResponse.Body.Enabled);

                //list web test
                var listWebTestsResponse = insightsClient
                                                .WebTests
                                                .ListWithHttpMessagesAsync()
                                                .GetAwaiter()
                                                .GetResult();

                Assert.True(listWebTestsResponse.Body.Count() > 0);

                //get back web test
                var getWebTestResponse = insightsClient
                                                .WebTests
                                                .GetWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    createWebTestProperties.SyntheticMonitorId)
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Equal(createWebTestProperties.WebTestName, getWebTestResponse.Body.WebTestName);
                Assert.Equal(createWebTestProperties.Kind, getWebTestResponse.Body.Kind);
                Assert.Equal(createWebTestProperties.SyntheticMonitorId, getWebTestResponse.Body.SyntheticMonitorId);
                Assert.Equal(createWebTestProperties.Enabled, getWebTestResponse.Body.Enabled);

                //update web test                
                createWebTestProperties.Enabled = false;
                var updateWebTestResponse = insightsClient
                                                .WebTests
                                                .CreateOrUpdateWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    createWebTestProperties.SyntheticMonitorId,
                                                    createWebTestProperties)
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Equal(createWebTestProperties.WebTestName, updateWebTestResponse.Body.WebTestName);
                Assert.Equal(createWebTestProperties.Kind, updateWebTestResponse.Body.Kind);
                Assert.Equal(createWebTestProperties.SyntheticMonitorId, updateWebTestResponse.Body.SyntheticMonitorId);
                Assert.Equal(createWebTestProperties.Enabled, updateWebTestResponse.Body.Enabled);

                //delete web test
                var deleteWebTestResponse = insightsClient
                                                .WebTests
                                                .DeleteWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    createWebTestProperties.SyntheticMonitorId)
                                                .GetAwaiter()
                                                .GetResult();

                //get webtest again, should get an exception
                Assert.Throws<CloudException>(() =>
                {
                    getWebTestResponse = insightsClient
                                                .WebTests
                                                .GetWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    createWebTestProperties.SyntheticMonitorId)
                                                .GetAwaiter()
                                                .GetResult();
                });

                this.DeleteAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteWebtests));
            }
        }

        private static WebTest GetCreateWebTestProperties(string componentId)
        {
            if (string.IsNullOrEmpty(componentId))
            {
                throw new ArgumentNullException(nameof(componentId));
            }

            var location = new WebTestGeolocation()
            {
                Location = "us-fl-mia-edge",
            };

            var configuration = new WebTestPropertiesConfiguration()
            {
                WebTest = "<WebTest Name=\"my-webtest\" Id=\"678ddf96-1ab8-44c8-9274-123456789abc\" Enabled=\"True\" CssProjectStructure=\"\" CssIteration=\"\" Timeout=\"120\" WorkItemIds=\"\" xmlns=\"http://microsoft.com/schemas/VisualStudio/TeamTest/2010\" Description=\"\" CredentialUserName=\"\" CredentialPassword=\"\" PreAuthenticate=\"True\" Proxy=\"default\" StopOnError=\"False\" RecordedResultFile=\"\" ResultsLocale=\"\" ><Items><Request Method=\"GET\" Guid=\"a4162485-9114-fcfc-e086-123456789abc\" Version=\"1.1\" Url=\"http://my-component.azurewebsites.net\" ThinkTime=\"0\" Timeout=\"120\" ParseDependentRequests=\"True\" FollowRedirects=\"True\" RecordResult=\"True\" Cache=\"False\" ResponseTimeGoal=\"0\" Encoding=\"utf-8\" ExpectedHttpStatusCode=\"200\" ExpectedResponseUrl=\"\" ReportingName=\"\" IgnoreHttpStatusCode=\"False\" /></Items></WebTest>",
            };

            var tags = new Dictionary<string, string>();
            tags.Add("hidden-link:" + componentId, "Resource");

            return new WebTest()
            {
                Location = "South Central US",
                WebTestKind = WebTestKind.Ping,
                WebTestName = "my-webtest-my-component",
                SyntheticMonitorId = "my-webtest-my-component",
                Enabled = true,
                Frequency = 900,
                Timeout = 120,
                Kind = WebTestKind.Ping,
                RetryEnabled = true,
                Locations = new WebTestGeolocation[] { location },
                Configuration = configuration,
                Tags = tags,
            };
        }
    }
}