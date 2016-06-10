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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MachineLearning.Tests.Helpers;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;
using StorageAccount = Microsoft.Azure.Management.MachineLearning.WebServices.Models.StorageAccount;

namespace MachineLearning.Tests.ScenarioTests
{
    public class WebServiceTests : TestBase
    {
        private const string DefaultLocation = "South Central US";
        private const string TestServiceNamePrefix = "amlws";
        private const string TestCommitmentPlanNamePrefix = "amlcp";
        private const string TestResourceGroupNamePrefix = "amlrg";
        private const string TestStorageAccountPrefix = "amlstor";
        private const string MLResourceProviderNamespace = "Microsoft.MachineLearning";
        private const string CPResourceType = "commitmentPlans";

        private const string ResourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.MachineLearning/webServices/{2}";
        
        /// <summary>
        /// The tests are currently recorded against Azure Production, using the web service definition file specified by ServiceDefinitionJsonFileProduction.
        /// When testing new changes to the SDK, you can first record the test against dogfood using the ServiceDefinitionJsonFileDogfood file. Then once everything
        /// is working as expected, re-record the test against Prod before submitting an official pull request.
        /// </summary>
        private readonly string TestServiceDefinitionFile;

        private const int AsyncOperationPollingIntervalSeconds = 5;

        private delegate void AMLWebServiceTestDelegate(
            string webServiceName, 
            string resourceGroupName, 
            ResourceManagementClient resourcesClient, 
            AzureMLWebServicesManagementClient amlServicesClient, 
            string cpResourceId, 
            StorageAccount storageAccount);

        public WebServiceTests()
        {
            TestServiceDefinitionFile = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "GraphWebServiceDefinition_Prod.json");
        }

        [Fact]
        public void CreateGetRemoveGraphWebService()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient, cpResourceId, storageAccount) =>
            {
                bool serviceWasRemoved = false;
                try
                {
                    //Validate expected NO-OP behavior on deleting a non existing service
                    amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName);

                    // Create and validate the AML service resource
                    var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(this.TestServiceDefinitionFile, cpResourceId, storageAccount);
                    var webService = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, resourceGroupName, webServiceName);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, webService, serviceDefinition);

                    // Retrieve the AML web service after creation
                    var retrievedService = amlServicesClient.WebServices.Get(resourceGroupName, webServiceName);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, retrievedService);

                    // Retrieve the AML web service's keys
                    WebServiceKeys serviceKeys = amlServicesClient.WebServices.ListKeys(resourceGroupName, webServiceName);
                    Assert.NotNull(serviceKeys);
                    Assert.Equal(serviceKeys.Primary, serviceDefinition.Properties.Keys.Primary);
                    Assert.Equal(serviceKeys.Secondary, serviceDefinition.Properties.Keys.Secondary);

                    // Remove the web service
                    amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName);
                    serviceWasRemoved = true;

                    //Validate that the expected not found exception is thrown after deletion when trying to access the service
                    var expectedCloudException = Assert.Throws<CloudException>(() => amlServicesClient.WebServices.Get(resourceGroupName, webServiceName));
                    Assert.NotNull(expectedCloudException.Body);
                    Assert.True(string.Equals(expectedCloudException.Body.Code, "NotFound"));
                }
                finally
                {
                    // Remove the web service
                    if (!serviceWasRemoved)
                    {
                        WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName));
                    }
                }
            });
        }

        [Fact]
        public void CreateAndUpdateOnGraphWebService()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient, cpResourceId, storageAccount) =>
            {
                try
                {
                    // Create and validate the AML service resource
                    var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(this.TestServiceDefinitionFile, cpResourceId, storageAccount);
                    var webService = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, resourceGroupName, webServiceName);
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
                    var updatedWebService = amlServicesClient.WebServices.PatchWithRequestId(serviceUpdates, resourceGroupName, webServiceName);

                    // Validate the updated resource
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, updatedWebService);
                    Assert.Equal(serviceUpdates.Properties.Description, updatedWebService.Properties.Description);
                    Assert.NotNull(updatedWebService.Properties.Diagnostics);
                    Assert.Equal(serviceUpdates.Properties.Diagnostics.Level, updatedWebService.Properties.Diagnostics.Level);
                    Assert.True(updatedWebService.Properties.ModifiedOn.Value.CompareTo(webService.Properties.ModifiedOn.Value) > 0);

                    // Also fetch the service keys and validate the update there
                    WebServiceKeys serviceKeys = amlServicesClient.WebServices.ListKeys(resourceGroupName, webServiceName);
                    Assert.NotNull(serviceKeys);
                    Assert.Equal(serviceKeys.Primary, serviceUpdates.Properties.Keys.Primary);
                    Assert.Equal(serviceKeys.Secondary, serviceDefinition.Properties.Keys.Secondary);
                }
                finally
                {
                    // Remove the web service
                    WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName));
                }
            });
        }

        [Fact]
        public void CreateAndListWebServices()
        {
            this.RunAMLWebServiceTestScenario((webServiceName, resourceGroupName, resourcesClient, amlServicesClient, cpResourceId, storageAccount) =>
            {
                string service2Name = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                string service3Name = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                var otherResourceGroupName = TestUtilities.GenerateName(WebServiceTests.TestResourceGroupNamePrefix);
                var otherServiceName = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);

                try
                {
                    // Create a few webservices in the same resource group
                    var serviceDefinition = WebServiceTests.GetServiceDefinitionFromTestData(this.TestServiceDefinitionFile, cpResourceId, storageAccount);
                    var webService1 = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, resourceGroupName, webServiceName);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, webServiceName, webService1, serviceDefinition);
                    var webService2 = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, resourceGroupName, service2Name);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, service2Name, webService2, serviceDefinition);
                    var webService3 = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, resourceGroupName, service3Name);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, resourceGroupName, service3Name, webService3, serviceDefinition);

                    // Create a new web service in a different resource group
                    resourcesClient.ResourceGroups.CreateOrUpdate(otherResourceGroupName, new ResourceGroup { Location = WebServiceTests.DefaultLocation });
                    var otherService = amlServicesClient.WebServices.CreateOrUpdateWithRequestId(serviceDefinition, otherResourceGroupName, otherServiceName);
                    WebServiceTests.ValidateWebServiceResource(amlServicesClient.SubscriptionId, otherResourceGroupName, otherServiceName, otherService, serviceDefinition);

                    // Validate that only the first 3 services are returned on the get call for web services in a subscription & resource group
                    var servicesInGroup = amlServicesClient.WebServices.ListInResourceGroup(resourceGroupName);
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
                    var servicesInSubscription = amlServicesClient.WebServices.List();
                    Assert.NotNull(servicesInSubscription);
                    servicesList = servicesInSubscription.Value;
                    Assert.NotNull(servicesList);
                    Assert.True(servicesList.Count >= 4);
                    Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service1ExpectedId, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service2ExpectedId, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(servicesList.Any(svc => string.Equals(svc.Id, service3ExpectedId, StringComparison.OrdinalIgnoreCase)));
                    string otherServiceExpectedId = string.Format(CultureInfo.InvariantCulture, WebServiceTests.ResourceIdFormat, amlServicesClient.SubscriptionId, otherResourceGroupName, otherServiceName);
                    Assert.True(servicesList.Any(svc => string.Equals(svc.Id, otherServiceExpectedId, StringComparison.OrdinalIgnoreCase)));
                }
                finally
                {
                    // Remove the resources created by the test
                    WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName));
                    WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, service2Name));
                    WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(resourceGroupName, service3Name));
                    WebServiceTests.DisposeOfTestResource(() => amlServicesClient.WebServices.RemoveWithRequestId(otherResourceGroupName, otherServiceName));
                    WebServiceTests.DisposeOfTestResource(() => resourcesClient.ResourceGroups.Delete(otherResourceGroupName));
                }
            });
        }

        private void RunAMLWebServiceTestScenario(AMLWebServiceTestDelegate actualTest,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            using (var context = MockContext.Start(this.GetType().FullName, methodName))
            {
                bool testIsSuccessfull = true;
                string cpRpApiVersion = string.Empty;
                ResourceManagementClient resourcesClient = null;
                StorageManagementClient storageManagementClient = null;

                var amlServiceName = TestUtilities.GenerateName(WebServiceTests.TestServiceNamePrefix);
                var resourceGroupName = TestUtilities.GenerateName(WebServiceTests.TestResourceGroupNamePrefix);
                var commitmentPlanName = TestUtilities.GenerateName(WebServiceTests.TestCommitmentPlanNamePrefix);
                var cpDeploymentName = "depl" + commitmentPlanName;
                var storageAccountName = TestUtilities.GenerateName(WebServiceTests.TestStorageAccountPrefix);

                try
                {
                    // Create a resource group for the AML service
                    resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                    var resourceGroupDefinition = new ResourceGroup
                    {
                        Location = WebServiceTests.DefaultLocation
                    };
                    resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroupDefinition);

                    // Create a support storage account for the service in this resource group
                    storageManagementClient = context.GetServiceClient<StorageManagementClient>();
                    var accountParameters = new StorageAccountCreateParameters
                    {
                        AccountType = AccountType.StandardLRS,
                        Location = WebServiceTests.DefaultLocation
                    };
                    storageManagementClient.StorageAccounts.Create(resourceGroupName, storageAccountName, accountParameters);
                    StorageAccountKeys accountKeys = storageManagementClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
                    var storageAccountInfo = new StorageAccount(storageAccountName, accountKeys.Key1);

                    // Create an AML commitment plan resource to associate with the services
                    cpRpApiVersion = ResourceProvidersHelper.GetRPApiVersion(resourcesClient, WebServiceTests.MLResourceProviderNamespace, WebServiceTests.CPResourceType);
                    var cpDeploymentItems = WebServiceTests.CreateCommitmentPlanResource(resourceGroupName, commitmentPlanName, cpDeploymentName, resourcesClient, cpRpApiVersion);
                    var cpResource = cpDeploymentItems.Item2;

                    // Create a client for the AML RP and run the actual test
                    var webServicesClient = context.GetServiceClient<AzureMLWebServicesManagementClient>();
                    webServicesClient.LongRunningOperationRetryTimeout = WebServiceTests.AsyncOperationPollingIntervalSeconds;

                    // Run the actual test
                    actualTest(amlServiceName, resourceGroupName, resourcesClient, webServicesClient, cpResource.Id, storageAccountInfo);
                }
                catch (CloudException cloudEx)
                {
                    Trace.TraceError("Caught unexpected exception: ");
                    Trace.TraceError(WebServiceTests.GenerateCloudExceptionReport(cloudEx));
                    testIsSuccessfull = false;
                }
                finally
                {
                    if (resourcesClient != null)
                    {
                        // Delete the deployment with the commitment plan
                        if (cpRpApiVersion != string.Empty)
                        {
                            WebServiceTests.DisposeOfTestResource(() => resourcesClient.Resources.Delete(resourceGroupName, WebServiceTests.MLResourceProviderNamespace, string.Empty, WebServiceTests.CPResourceType, commitmentPlanName, cpRpApiVersion));
                            WebServiceTests.DisposeOfTestResource(() => resourcesClient.Deployments.Delete(resourceGroupName, cpDeploymentName));
                        }

                        // Delete the created storage account
                        WebServiceTests.DisposeOfTestResource(() => storageManagementClient.StorageAccounts.Delete(resourceGroupName, storageAccountName));

                        // Delete the created resource group
                        WebServiceTests.DisposeOfTestResource(() => resourcesClient.ResourceGroups.Delete(resourceGroupName));
                    }
                }
                Assert.True(testIsSuccessfull);
            }
        }

        private static WebService GetServiceDefinitionFromTestData(string testDataFile, string commitmentPlanId, StorageAccount storageAccount)
        {
            string serviceAsJson = File.ReadAllText(testDataFile);
            var serviceDefinition = ModelsSerializationUtil.GetAzureMLWebServiceFromJsonDefinition(serviceAsJson);
            serviceDefinition.Location = WebServiceTests.DefaultLocation;
            serviceDefinition.Properties.CommitmentPlan.Id = commitmentPlanId;
            serviceDefinition.Properties.StorageAccount = storageAccount;
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
                Assert.Equal(definitionProperties.ExposeSampleData, serviceProperties.ExposeSampleData);

                Assert.NotNull(serviceProperties.ExampleRequest);
                Assert.NotNull(serviceProperties.ExampleRequest.Inputs);
                Assert.Equal(definitionProperties.ExampleRequest.Inputs.Count, serviceProperties.ExampleRequest.Inputs.Count);
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

        private static Tuple<DeploymentExtended, GenericResource> CreateCommitmentPlanResource(string resourceGroupName, string commitmentPlanName, string deploymentName, ResourceManagementClient resourcesClient, string cpApiVersion)
        {
            string deploymentParams = @"{'planName': {'value': '" + commitmentPlanName + "'}, 'planSkuName': {'value': 'PLAN_SKU_NAME'}, 'planSkuTier': {'value': 'PLAN_SKU_TIER'}, 'apiVersion': {'value': '" + cpApiVersion + "'}}";
            var deploymentProperties = new DeploymentProperties
            {
                Template = JObject.Parse(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestData", "DeployCommitmentPlanTemplate.json"))),
                Parameters = JObject.Parse(deploymentParams),
                Mode = DeploymentMode.Incremental
            };

            var deployment = resourcesClient.Deployments.CreateOrUpdate(resourceGroupName, deploymentName, new Deployment(deploymentProperties));
            var cpResource = resourcesClient.Resources.Get(resourceGroupName, WebServiceTests.MLResourceProviderNamespace, string.Empty, WebServiceTests.CPResourceType, commitmentPlanName, cpApiVersion);

            return Tuple.Create(deployment, cpResource);
        }

        private static void DisposeOfTestResource(Action disposalCall)
        {
            try
            {
                disposalCall();
            }
            catch (CloudException cloudEx)
            {
                Trace.TraceWarning("Caught unexpected exception during resource cleanup: ");
                Trace.TraceWarning(WebServiceTests.GenerateCloudExceptionReport(cloudEx));
            }
            catch (Exception ex)
            {
                Trace.TraceWarning("Caught unexpected exception during resource cleanup: {0}", ex.Message);
            }
        }
    }
}
