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
    public class ContinuousExportsTests : TestBase
    {
        private const string ResourceGroupName = "swaggertest";
        private RecordedDelegatingHandler handler;


        public ContinuousExportsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteExports()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = this.GetAppInsightsManagementClient(context, handler);

                //prepare a component
                this.CreateAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteExports));

                //create a continuous export
                var createContinuousExportProperties = GetCreateContinuousExportProperties();
                var createContinuousExportResponse = insightsClient
                                                        .ExportConfigurations
                                                        .CreateWithHttpMessagesAsync(
                                                            ResourceGroupName,
                                                            nameof(CreateGetListUpdateDeleteExports),
                                                            createContinuousExportProperties)
                                                        .GetAwaiter()
                                                        .GetResult();
                Assert.Single(createContinuousExportResponse.Body);
                AreEqual(createContinuousExportProperties, createContinuousExportResponse.Body.FirstOrDefault());

                //get all continuous exports
                var getAllContinuousExports = insightsClient
                                                .ExportConfigurations
                                                .ListWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    nameof(CreateGetListUpdateDeleteExports))
                                                .GetAwaiter()
                                                .GetResult();

                Assert.Single(getAllContinuousExports.Body);
                AreEqual(createContinuousExportProperties, getAllContinuousExports.Body.FirstOrDefault());

                string exportId = getAllContinuousExports.Body.FirstOrDefault().ExportId;

                //get specif continuous export
                var getContinuousExport = insightsClient
                                            .ExportConfigurations
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(CreateGetListUpdateDeleteExports),
                                                exportId)
                                            .GetAwaiter()
                                            .GetResult();

                AreEqual(createContinuousExportProperties, getContinuousExport.Body);

                //update the continuous export
                createContinuousExportProperties.IsEnabled = "false";
                createContinuousExportProperties.RecordTypes = "Requests, Event, Exceptions";

                var updateContinuousExport = insightsClient
                                                .ExportConfigurations
                                                .UpdateWithHttpMessagesAsync(
                                                    ResourceGroupName,
                                                    nameof(CreateGetListUpdateDeleteExports),
                                                    exportId,
                                                    createContinuousExportProperties)
                                                .GetAwaiter()
                                                .GetResult();

                AreEqual(createContinuousExportProperties, updateContinuousExport.Body);

                //get again
                getContinuousExport = insightsClient
                                            .ExportConfigurations
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(CreateGetListUpdateDeleteExports),
                                                exportId)
                                            .GetAwaiter()
                                            .GetResult();

                AreEqual(createContinuousExportProperties, getContinuousExport.Body);

                //delete the continuous export
                var deleteContinuousExportResponse = insightsClient
                                                        .ExportConfigurations
                                                        .DeleteWithHttpMessagesAsync(
                                                            ResourceGroupName,
                                                            nameof(CreateGetListUpdateDeleteExports),
                                                            exportId)
                                                        .GetAwaiter()
                                                        .GetResult();
                getContinuousExport = insightsClient
                                            .ExportConfigurations
                                            .GetWithHttpMessagesAsync(
                                                ResourceGroupName,
                                                nameof(CreateGetListUpdateDeleteExports),
                                                exportId)
                                            .GetAwaiter()
                                            .GetResult();

                Assert.True(getContinuousExport.Body == null);

                //clean up component
                this.DeleteAComponent(insightsClient, ResourceGroupName, nameof(CreateGetListUpdateDeleteExports));
            }
        }

        private static void AreEqual(ApplicationInsightsComponentExportRequest request, ApplicationInsightsComponentExportConfiguration response)
        {
            Assert.Equal(request.IsEnabled, response.IsUserEnabled, ignoreCase: true);
            Assert.Equal(request.RecordTypes, response.RecordTypes);
            Assert.Equal(request.DestinationStorageSubscriptionId, response.DestinationStorageSubscriptionId);
            Assert.Equal(request.DestinationStorageLocationId, response.DestinationStorageLocationId);
            Assert.Equal(request.DestinationAccountId, response.DestinationAccountId);
        }

        private ApplicationInsightsComponentExportRequest GetCreateContinuousExportProperties()
        {
            return new ApplicationInsightsComponentExportRequest()
            {
                RecordTypes = "Requests, Event, Exceptions, Metrics, PageViews, PageViewPerformance, Rdd, PerformanceCounters, Availability",
                DestinationType = "Blob",
                DestinationAddress = "https://mystorageblob.blob.core.windows.net/testexport?sv=2015-04-05&sr=c&sig=token",
                IsEnabled = "true",
                DestinationStorageSubscriptionId = "8330b4a4-0b8e-40cf-a643-bbaf60d375c9",
                DestinationAccountId = "/subscriptions/8330b4a4-0b8e-40cf-a643-bbaf60d375c9/resourceGroups/my-resource-group/providers/Microsoft.ClassicStorage/storageAccounts/mystorageblob",
                DestinationStorageLocationId = "eastus",
            };
        }

        private static ApplicationInsightsComponent GetCreateComponentProperties()
        {
            return new ApplicationInsightsComponent(
                name: nameof(CreateGetListUpdateDeleteExports),
                location: "South Central US",
                kind: "web",
                applicationType: "web",
                applicationId: nameof(CreateGetListUpdateDeleteExports),
                flowType: "Bluefield",
                requestSource: "rest"
            );
        }

    }
}