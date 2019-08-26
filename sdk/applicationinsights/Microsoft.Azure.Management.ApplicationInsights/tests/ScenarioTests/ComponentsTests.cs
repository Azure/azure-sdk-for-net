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
    public class ComponentsTests : TestBase
    {
        private const string ResourceGroupName = "swaggertest";
        private RecordedDelegatingHandler handler;


        public ComponentsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteComponents()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ApplicationInsightsComponent bodyParameter = GetCreateComponentProperties(nameof(CreateGetListUpdateDeleteComponents));

                var insightsClient = GetAppInsightsManagementClient(context, handler);

                //"create new component";
                var createdComponentResponse = insightsClient
                                                    .Components
                                                    .CreateOrUpdateWithHttpMessagesAsync(
                                                        ResourceGroupName,
                                                        nameof(CreateGetListUpdateDeleteComponents),
                                                        insightProperties: bodyParameter)
                                                    .GetAwaiter()
                                                    .GetResult();
                //verify
                Assert.Equal(bodyParameter.Name, createdComponentResponse.Body.Name);
                Assert.Equal(bodyParameter.RequestSource, createdComponentResponse.Body.RequestSource);
                Assert.Equal(bodyParameter.FlowType, createdComponentResponse.Body.FlowType);
                Assert.Equal(bodyParameter.Kind, createdComponentResponse.Body.Kind);

                //list all components
                var listAllComponentsResponse = insightsClient
                                                    .Components
                                                    .ListWithHttpMessagesAsync()
                                                    .GetAwaiter()
                                                    .GetResult();

                //verify
                Assert.True(listAllComponentsResponse.Body.Count() > 0);

                //list components inside inside a group
                var listComponentsResponse = insightsClient
                                                    .Components
                                                    .ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName)
                                                    .GetAwaiter()
                                                    .GetResult();

                //verify
                Assert.True(listComponentsResponse.Body.Count() > 0);
                var component = listComponentsResponse.Body.FirstOrDefault(c => c.Name == bodyParameter.Name);
                Assert.True(component != null);

                //get back component
                var getComponentResponse = insightsClient
                                                    .Components
                                                    .GetWithHttpMessagesAsync(ResourceGroupName,
                                                        nameof(CreateGetListUpdateDeleteComponents))
                                                    .GetAwaiter()
                                                    .GetResult();
                //verify
                Assert.True(getComponentResponse.Body != null);
                Assert.Equal(getComponentResponse.Body.Name, bodyParameter.Name);

                //update component
                bodyParameter = GetUpdateComponentProperties();

                var updateComponentResponse = insightsClient
                                                    .Components
                                                    .CreateOrUpdateWithHttpMessagesAsync(
                                                        ResourceGroupName,
                                                        nameof(CreateGetListUpdateDeleteComponents),
                                                        bodyParameter)
                                                    .GetAwaiter()
                                                    .GetResult();

                //verify
                Assert.Equal(bodyParameter.Name, updateComponentResponse.Body.Name);
                Assert.Equal(bodyParameter.RequestSource, updateComponentResponse.Body.RequestSource);
                Assert.Equal(bodyParameter.FlowType, updateComponentResponse.Body.FlowType);
                Assert.Equal(bodyParameter.Kind, updateComponentResponse.Body.Kind);


                //delete component
                var deleteComponentResponse = insightsClient
                                                    .Components
                                                    .DeleteWithHttpMessagesAsync(
                                                        ResourceGroupName,
                                                        nameof(CreateGetListUpdateDeleteComponents))
                                                    .GetAwaiter()
                                                    .GetResult();

                //get component again, should get an exception
                Assert.Throws<CloudException>(() =>
                {
                    getComponentResponse = insightsClient
                                                        .Components
                                                        .GetWithHttpMessagesAsync(ResourceGroupName,
                                                            nameof(CreateGetListUpdateDeleteComponents))
                                                        .GetAwaiter()
                                                        .GetResult();
                });
            }
        }

        private static ApplicationInsightsComponent GetUpdateComponentProperties()
        {
            return new ApplicationInsightsComponent(
                name: nameof(CreateGetListUpdateDeleteComponents),
                location: "South Central US",
                kind: "device",
                applicationType: "web",
                applicationId: nameof(CreateGetListUpdateDeleteComponents),
                flowType: "Bluefield",
                requestSource: ".NET SDK test"
            );
        }
    }
}