// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using ApplicationInsights.Tests.Helpers;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace ApplicationInsights.Tests.Scenarios
{
    public class APIKeysTests : TestBase
    {
        private const string ResourceGroupName = "swaggertest";
        private RecordedDelegatingHandler handler;


        public APIKeysTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteAPIKeys()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = this.GetAppInsightsManagementClient(context, handler);

                //prepare a component
                this.CreateAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteAPIKeys));

                //create an API key
                var apiKeyProperties = GetCreateAPIKeyProperties(ResourceGroupName, nameof(CreateGetListUpdateDeleteAPIKeys));
                var createAPIKeyResponse = insightsClient
                                                        .APIKeys
                                                        .CreateWithHttpMessagesAsync(
                                                            ResourceGroupName,
                                                            nameof(CreateGetListUpdateDeleteAPIKeys),
                                                            apiKeyProperties)
                                                        .GetAwaiter()
                                                        .GetResult();
                AreEqual(apiKeyProperties, createAPIKeyResponse.Body);

                //get all API keys
                var getAllAPIKeys = insightsClient
                                                .APIKeys
                                                .ListWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    nameof(CreateGetListUpdateDeleteAPIKeys))
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Single(getAllAPIKeys.Body);
                AreEqual(apiKeyProperties, getAllAPIKeys.Body.ElementAt(0));

                string fullkeyId = getAllAPIKeys.Body.ElementAt(0).Id;
                string keyId = fullkeyId.Split('/')[10];

                //get specif API key
                var getAPIKey = insightsClient
                                            .APIKeys
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(CreateGetListUpdateDeleteAPIKeys),
                                                keyId)
                                            .GetAwaiter()
                                            .GetResult();

                AreEqual(apiKeyProperties, getAPIKey.Body);

                //delete the API key
                var deleteAPIKeyResponse = insightsClient
                                                        .APIKeys
                                                        .DeleteWithHttpMessagesAsync(
                                                            ResourceGroupName,
                                                            nameof(CreateGetListUpdateDeleteAPIKeys),
                                                            keyId)
                                                        .GetAwaiter()
                                                        .GetResult();

                //get API again, should get an NOT found exception
                Assert.Throws<CloudException>(() =>
                {
                    getAPIKey = insightsClient
                                            .APIKeys
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(CreateGetListUpdateDeleteAPIKeys),
                                                keyId)
                                            .GetAwaiter()
                                            .GetResult();
                });                               

                //clean up component
                this.DeleteAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteAPIKeys));
            }
        }

        private static void AreEqual(APIKeyRequest request, ApplicationInsightsComponentAPIKey response)
        {
            Assert.Equal(request.Name, response.Name, ignoreCase: true);
            Assert.True(response.LinkedReadProperties.Count >= request.LinkedReadProperties.Count);
            Assert.True(response.LinkedWriteProperties.Count >= request.LinkedWriteProperties.Count);
            foreach (var readaccess in request.LinkedReadProperties)
            {
                Assert.Contains(response.LinkedReadProperties, r => r == readaccess);

            }

            foreach (var writeaccess in request.LinkedWriteProperties)
            {
                Assert.Contains(response.LinkedWriteProperties, w => w == writeaccess);
            }
        }

        private APIKeyRequest GetCreateAPIKeyProperties(string resourceGroupName, string componentName)
        {
            return new APIKeyRequest()
            {
                Name = "test",
                LinkedReadProperties = new string[] {
                    $"/subscriptions/{this.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.insights/components/{componentName}/api",
                    $"/subscriptions/{this.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.insights/components/{componentName}/agentconfig"
                },
                LinkedWriteProperties = new string[]
                {
                    $"/subscriptions/{this.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.insights/components/{componentName}/annotations"
                }
            };
        }

        private static ApplicationInsightsComponent GetCreateComponentProperties()
        {
            return new ApplicationInsightsComponent(
                name: nameof(CreateGetListUpdateDeleteAPIKeys),
                location: "South Central US",
                kind: "web",
                applicationType: "web",
                applicationId: nameof(CreateGetListUpdateDeleteAPIKeys),
                flowType: "Bluefield",
                requestSource: "rest"
            );
        }

    }
}