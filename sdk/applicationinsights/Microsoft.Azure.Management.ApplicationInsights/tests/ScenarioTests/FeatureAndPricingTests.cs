// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ApplicationInsights.Tests.Helpers;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Management.ApplicationInsights.Management;

namespace ApplicationInsights.Tests.Scenarios
{
    public class FeatureAndPricingTests : TestBase
    {
        private const string ResourceGroupName = "swaggertest";
        private RecordedDelegatingHandler handler;


        public FeatureAndPricingTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetAndUpdateFeatures()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var insightsClient = this.GetAppInsightsManagementClient(context, handler);

                //prepare a component
                this.CreateAComponent(insightsClient, ResourceGroupName, nameof(GetAndUpdateFeatures));

                //Get features
                var getFeaturesResponse = insightsClient
                                            .ComponentCurrentBillingFeatures
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(GetAndUpdateFeatures))
                                            .GetAwaiter()
                                            .GetResult();

                Assert.Equal(1, getFeaturesResponse.Body.CurrentBillingFeatures.Count);
                Assert.Equal("Basic", getFeaturesResponse.Body.CurrentBillingFeatures[0]);
                Assert.Equal(500, getFeaturesResponse.Body.DataVolumeCap.Cap);

                //Update features
                var featuresProperties = GetUpdateFeatureProperties();

                var updatedFeaturesResponse = insightsClient
                                                .ComponentCurrentBillingFeatures
                                                .UpdateWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    nameof(GetAndUpdateFeatures),
                                                    featuresProperties)
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Equal(featuresProperties.CurrentBillingFeatures.Count, updatedFeaturesResponse.Body.CurrentBillingFeatures.Count);
                Assert.Equal(featuresProperties.CurrentBillingFeatures[0], updatedFeaturesResponse.Body.CurrentBillingFeatures[0]);
                Assert.Equal(featuresProperties.CurrentBillingFeatures[1], updatedFeaturesResponse.Body.CurrentBillingFeatures[1]);
                Assert.Equal(featuresProperties.DataVolumeCap.Cap, updatedFeaturesResponse.Body.DataVolumeCap.Cap);
                Assert.Equal(featuresProperties.DataVolumeCap.StopSendNotificationWhenHitCap, updatedFeaturesResponse.Body.DataVolumeCap.StopSendNotificationWhenHitCap);

                //Get Again
                getFeaturesResponse = insightsClient
                                            .ComponentCurrentBillingFeatures
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(GetAndUpdateFeatures))
                                            .GetAwaiter()
                                            .GetResult();

                Assert.Equal(featuresProperties.CurrentBillingFeatures.Count, getFeaturesResponse.Body.CurrentBillingFeatures.Count);
                Assert.Equal(featuresProperties.CurrentBillingFeatures[0], getFeaturesResponse.Body.CurrentBillingFeatures[0]);
                Assert.Equal(featuresProperties.CurrentBillingFeatures[1], getFeaturesResponse.Body.CurrentBillingFeatures[1]);
                Assert.Equal(featuresProperties.DataVolumeCap.Cap, getFeaturesResponse.Body.DataVolumeCap.Cap);
                Assert.Equal(featuresProperties.DataVolumeCap.StopSendNotificationWhenHitCap, getFeaturesResponse.Body.DataVolumeCap.StopSendNotificationWhenHitCap);

                //clean up component
                this.DeleteAComponent(insightsClient, ResourceGroupName, nameof(GetAndUpdateFeatures));
            }
        }

        private static ApplicationInsightsComponentBillingFeatures GetUpdateFeatureProperties()
        {
            string[] currentBillingFeatures = new string[] { "Basic", "Application Insights Enterprise" };

            return new ApplicationInsightsComponentBillingFeatures()
            {
                CurrentBillingFeatures = currentBillingFeatures,
                DataVolumeCap = new ApplicationInsightsComponentDataVolumeCap()
                {
                    Cap = 300,
                    StopSendNotificationWhenHitCap = true,
                }
            };
        }
    }
}