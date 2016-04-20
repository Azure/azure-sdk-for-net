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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace WebServices.Tests.ScenarioTests
{
    public class WebServiceTests : TestBase
    {
        private const string DefaultLocation = "South Central US";
        private const string TestServiceNamePrefix = "amlws";
        private const string TestResourceGroupNamePrefix = "amlrg";
        private const string ResourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.MachineLearning/webServices/{2}";
        private const string ServiceDefinitionJsonFileDogfood = @".\TestData\GraphWebServiceDefinition_Dogfood.json";
        private const string TestServiceDefinitionFile = WebServiceTests.ServiceDefinitionJsonFileDogfood;

        private const int AsyncOperationPollingIntervalSeconds = 5;

        private delegate void AMLWebServiceTestDelegate(string webServiceName, string resourceGroupName, ResourceManagementClient resourcesClient, AzureMLWebServicesManagementClient amlServicesClient);

        [Fact]
        public void CreateGetRemoveGraphWebService()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient) =>
            {
                //Validate expected NO-OP behavior on deleting a non existing service
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, webServiceName);

                // Create and validate the AML service resource
                var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(WebServiceTests.TestServiceDefinitionFile);
                var webService = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, webServiceName);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, webService, serviceDefinition);

                // Retrieve the AML web service after creation
                var retrievedService = amlServicesClient.WebServices.GetWebService(resourceGroupName, webServiceName);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, retrievedService);

                // Retrieve the AML web service's keys
                WebServiceKeys serviceKeys = amlServicesClient.WebServices.GetWebServiceKeys(resourceGroupName, webServiceName);
                Assert.NotNull(serviceKeys);
                Assert.Equal(serviceKeys.Primary, serviceDefinition.Properties.Keys.Primary);
                Assert.Equal(serviceKeys.Secondary, serviceDefinition.Properties.Keys.Secondary);

                // Remove the web service
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, webServiceName);

                //Validate that the expected not found exception is thrown after deletion when trying to access the service
                var expectedCloudException = Assert.Throws<CloudException>(() => amlServicesClient.WebServices.GetWebService(resourceGroupName, webServiceName));
                Assert.NotNull(expectedCloudException.Body);
                Assert.True(string.Equals(expectedCloudException.Body.Code, "NotFound"));
            });
        }

        [Fact]
        public void CreateAndUpdateOnGraphWebService()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient) =>
            {
                // Create and validate the AML service resource
                var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(WebServiceTests.TestServiceDefinitionFile);
                var webService = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, webServiceName);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, webService, serviceDefinition);

                // Submit some updates to this resource
                var serviceUpdates = new WebService
                {
                    Properties = new WebServicePropertiesForGraph
                    {
                        Description = "description was updated!",
                        Keys = new WebServiceKeys("f6ae3d003c63457ab4c5997effb5e4dc"),
                        Diagnostics = new DiagnosticsConfiguration(DiagnosticsLevel.All)
                    }
                };
                var updatedWebService = amlServicesClient.WebServices.PatchWebService(serviceUpdates, resourceGroupName, webServiceName);

                // Validate the updated resource
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, updatedWebService);
                Assert.Equal(serviceUpdates.Properties.Description, updatedWebService.Properties.Description);
                Assert.NotNull(updatedWebService.Properties.Diagnostics);
                Assert.Equal(serviceUpdates.Properties.Diagnostics.Level, updatedWebService.Properties.Diagnostics.Level);
                Assert.True(updatedWebService.Properties.ModifiedOn.Value.CompareTo(webService.Properties.ModifiedOn.Value) > 0);

                // Also fetch the service keys and validate the update there
                WebServiceKeys serviceKeys = amlServicesClient.WebServices.GetWebServiceKeys(resourceGroupName, webServiceName);
                Assert.NotNull(serviceKeys);
                Assert.Equal(serviceKeys.Primary, serviceUpdates.Properties.Keys.Primary);
                Assert.Equal(serviceKeys.Secondary, serviceDefinition.Properties.Keys.Secondary);

                // Remove the web service
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, webServiceName);
            });
        }

        [Fact]
        public void CreateAndListWebServices()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient) =>
            {
                // Create a few webservices in the same resource group
                var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(WebServiceTests.TestServiceDefinitionFile);
                var webService1 = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, webServiceName);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, webService1, serviceDefinition);

                string service2Name = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                var webService2 = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, service2Name);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, service2Name, webService2, serviceDefinition);

                string service3Name = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                var webService3 = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, service3Name);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, service3Name, webService3, serviceDefinition);

                // Create a new web service in a different resource group
                var otherResourceGroupName = TestUtilities.GenerateName(WebServiceTests.TestResourceGroupNamePrefix);
                resourcesClient.ResourceGroups.CreateOrUpdate(otherResourceGroupName, new ResourceGroup { Location = WebServiceTests.DefaultLocation });
                var otherServiceName = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                var otherService = amlServicesClient.WebServices.CreateOrUpdateWebService(serviceDefinition, otherResourceGroupName, otherServiceName);
                WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, otherResourceGroupName, otherServiceName, otherService, serviceDefinition);

                // Validate that only the first 3 services are returned on the get call for web services in a subscription & resource group
                var servicesInGroup = amlServicesClient.WebServices.GetWebServicesInResourceGroup(resourceGroupName);
                Assert.NotNull(servicesInGroup);
                IList<WebService> servicesList = servicesInGroup.Value;
                Assert.NotNull(servicesList);
                Assert.Equal(3, servicesList.Count);
                string service1ExpectedId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, amlServicesClient.SubscriptionId, resourceGroupName, webServiceName);
                string service2ExpectedId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, amlServicesClient.SubscriptionId, resourceGroupName, service2Name);
                string service3ExpectedId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, amlServicesClient.SubscriptionId, resourceGroupName, service3Name);
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service1ExpectedId, StringComparison.OrdinalIgnoreCase)));
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service2ExpectedId, StringComparison.OrdinalIgnoreCase)));
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service3ExpectedId, StringComparison.OrdinalIgnoreCase)));

                // Validate that all services are called when getting the AML service resource list for the subscription
                var servicesInSubscription = amlServicesClient.WebServices.GetWebServicesInSubscription();
                Assert.NotNull(servicesInSubscription);
                servicesList = servicesInSubscription.Value;
                Assert.NotNull(servicesList);
                Assert.Equal(4, servicesList.Count);
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service1ExpectedId, StringComparison.OrdinalIgnoreCase)));
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service2ExpectedId, StringComparison.OrdinalIgnoreCase)));
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service3ExpectedId, StringComparison.OrdinalIgnoreCase)));
                string otherServiceExpectedId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, amlServicesClient.SubscriptionId, otherResourceGroupName, otherServiceName);
                Assert.True(servicesList.Any(svc => string.Equals(svc.Id, otherServiceExpectedId, StringComparison.OrdinalIgnoreCase)));

                // Remove the web services created by the test
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, webServiceName);
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, service2Name);
                amlServicesClient.WebServices.RemoveWebService(resourceGroupName, service3Name);
                amlServicesClient.WebServices.RemoveWebService(otherResourceGroupName, otherServiceName);
            });
        }

        private void RunAMLWebServiceTestScenario(AMLWebServiceTestDelegate actualTest,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            using (var context = MockContext.Start(this.GetType().FullName, methodName))
            {
                bool testIsSuccessfull = true;
                try
                {
                    var amlServiceName = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                    var resourceGroupName = TestUtilities.GenerateName(WebServiceTests.TestResourceGroupNamePrefix);

                    // Create a resource group for the AML service
                    var resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                    var resourceGroupDefinition = new ResourceGroup
                    {
                        Location = WebServiceTests.DefaultLocation
                    };
                    resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroupDefinition);

                    // Create a client for the AML RP and run the actual test
                    var webServicesClient = context.GetServiceClient<AzureMLWebServicesManagementClient>();
                    webServicesClient.LongRunningOperationRetryTimeout = WebServiceTests.AsyncOperationPollingIntervalSeconds;

                    actualTest(amlServiceName, resourceGroupName, resourcesClient, webServicesClient);
                }
                catch (CloudException cloudEx)
                {
                    Console.WriteLine("Caught unexpected exception: ");
                    Console.WriteLine(WebServiceTests.GenerateCloudExceptionReport(cloudEx));
                    testIsSuccessfull = false;
                }

                Assert.True(testIsSuccessfull);
            }
        }

        private static WebService GetServiceDefinitionFromTestData(string testDataFile)
        {
            string serviceAsJson = File.ReadAllText(testDataFile);
            var serviceDefinition = ModelsSerializationUtil.GetAzureMLWebServiceFromJsonDefinition(serviceAsJson);
            serviceDefinition.Location = WebServiceTests.DefaultLocation;
            return serviceDefinition;
        }

        private static void ValidateWebServiceResource(string subscriptionId, string resourceGroupName, string webServiceName, WebService webService, WebService requestPayload = null)
        {
            // Validate basic ARM resource fields
            Assert.NotNull(webService);
            string expectedResourceId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, subscriptionId, resourceGroupName, webServiceName);
            Assert.Equal(expectedResourceId, webService.Id);
            Assert.Equal(WebServiceTests.DefaultLocation, webService.Location);
            Assert.Equal("Microsoft.MachineLearning/webServices", webService.Type);

            // Validate specific AML web service properties
            var serviceProperties = webService.Properties;
            Assert.NotNull(serviceProperties);
            Assert.NotNull(serviceProperties.CreatedOn);
            Assert.NotNull(serviceProperties.ModifiedOn);
            Assert.True(serviceProperties.ModifiedOn.Value.CompareTo(serviceProperties.CreatedOn.Value) >= 0);
            Assert.Null(serviceProperties.Keys);
            Assert.NotNull(serviceProperties.StorageAccount);
            Assert.Null(serviceProperties.StorageAccount.Key);
            Assert.NotNull(serviceProperties.Assets);
            Assert.False(string.IsNullOrWhiteSpace(serviceProperties.SwaggerLocation));

            // Validate specific AML web service properties againts the request payload, if applicable
            if (requestPayload != null)
            {
                var definitionProperties = requestPayload.Properties;

                Assert.Equal(definitionProperties.Description, serviceProperties.Description);
                Assert.Equal(definitionProperties.ReadOnlyProperty, serviceProperties.ReadOnlyProperty);
                Assert.Equal(definitionProperties.StorageAccount.Name, serviceProperties.StorageAccount.Name);
                Assert.True((serviceProperties.Input != null && definitionProperties.Input != null) || (serviceProperties.Input == null && definitionProperties.Input == null));
                Assert.True((serviceProperties.Output != null && definitionProperties.Output != null) || (serviceProperties.Output == null && definitionProperties.Output == null));
                Assert.Equal(definitionProperties.Assets.Count, serviceProperties.Assets.Count);
            }
        }

        private static string GenerateCloudExceptionReport(CloudException cloudException)
        {
            var errorReport = new StringBuilder();
            
            string requestId = cloudException.RequestId;
            if (string.IsNullOrWhiteSpace(requestId) && cloudException.Response != null)
            {
                // Try to obtain the request id from the HTTP response associated with the exception
                IEnumerable<string> headerValues = Enumerable.Empty<string>();
                if (cloudException.Response.Headers != null &&
                    cloudException.Response.Headers.TryGetValue("x-ms-request-id", out headerValues))
                {
                    requestId = headerValues.First();
                }
            }

            errorReport.AppendLine($"Request Id: {requestId}");
            if (cloudException.Body != null)
            {
                errorReport.AppendLine($"Error Code: {cloudException.Body.Code}");
                errorReport.AppendLine($"Error Message: {cloudException.Body.Message}");
                if (cloudException.Body.Details.Any())
                {
                    errorReport.AppendLine("Error Details:");
                    foreach (var errorDetail in cloudException.Body.Details)
                    {
                        errorReport.AppendLine($"\t[Code={errorDetail.Code}, Message={errorDetail.Message}]");
                    }
                }
            }

            return errorReport.ToString();
        }
    }
}
