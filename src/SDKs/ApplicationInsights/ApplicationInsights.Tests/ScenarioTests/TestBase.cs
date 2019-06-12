// Copyright (c) Microsoft Corporation. All rights reserved.

// Licensed under the MIT License. See License.txt in the project root for license information.

using ApplicationInsights.Tests.Helpers;
using Microsoft.Azure.Management.ApplicationInsights.Management;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using Xunit;

namespace ApplicationInsights.Tests.Scenarios
{
    public class TestBase
    {
        protected string SubscriptionId { get; set; }

        public TestBase()
        {
        }


        protected ApplicationInsightsManagementClient GetAppInsightsManagementClient(MockContext context,  RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            ApplicationInsightsManagementClient client;
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

            if (string.Equals(testMode, "record", StringComparison.OrdinalIgnoreCase))
            {
                string subId = Environment.GetEnvironmentVariable("AZURE_TEST_SUBSCRIPTIONID");
                subId = string.IsNullOrWhiteSpace(subId) ? "b90b0dec-9b9a-4778-a84e-4ffb73bb17f6" : subId;
                this.SubscriptionId = subId;

                TestEnvironment env = new TestEnvironment(connectionString: "SubscriptionId=" + subId); 
                client = context.GetServiceClient<ApplicationInsightsManagementClient>(
                    currentEnvironment: env,
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
            else
            {
                this.SubscriptionId = "b90b0dec-9b9a-4778-a84e-4ffb73bb17f6";
                client = context.GetServiceClient<ApplicationInsightsManagementClient>(
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }

            return client;
        }

        protected AzureOperationResponse<ApplicationInsightsComponent> CreateAComponent(ApplicationInsightsManagementClient insightsClient, string resourceGroupName, string componentName)
        {
            ApplicationInsightsComponent bodyParameter = GetCreateComponentProperties(componentName);
            //"create new component";
            var createdComponentResponse = insightsClient
                                                .Components
                                                .CreateOrUpdateWithHttpMessagesAsync(
                                                    resourceGroupName,
                                                    componentName,
                                                    insightProperties: bodyParameter)
                                                .GetAwaiter()
                                                .GetResult();
            //verify
            Assert.Equal(bodyParameter.Name, createdComponentResponse.Body.Name);
            Assert.Equal(bodyParameter.RequestSource, createdComponentResponse.Body.RequestSource);
            Assert.Equal(bodyParameter.FlowType, createdComponentResponse.Body.FlowType);
            Assert.Equal(bodyParameter.Kind, createdComponentResponse.Body.Kind);

            return createdComponentResponse;
        }

        protected void DeleteAComponent(ApplicationInsightsManagementClient insightsClient, string resourceGroupName, string componentName)
        {
            var deleteComponentResponse = insightsClient
                                                .Components
                                                .DeleteWithHttpMessagesAsync(
                                                    resourceGroupName,
                                                    componentName)
                                                .GetAwaiter()
                                                .GetResult();

            //get component again, should get an exception
            Assert.Throws<CloudException>(() =>
            {
                var getComponentResponse = insightsClient
                                                    .Components
                                                    .GetWithHttpMessagesAsync(
                                                        resourceGroupName,
                                                        componentName)
                                                    .GetAwaiter()
                                                    .GetResult();
            });
        }

        protected static ApplicationInsightsComponent GetCreateComponentProperties(string componentName)
        {
            if (string.IsNullOrEmpty(componentName))
            {
                throw new ArgumentNullException(nameof(componentName));
            }

            return new ApplicationInsightsComponent(
                name: componentName,
                location: "South Central US",
                kind: "web",
                applicationType: "web",
                applicationId: componentName,
                flowType: "Bluefield",
                requestSource: ".NET SDK test"
            );
        }
    }
}