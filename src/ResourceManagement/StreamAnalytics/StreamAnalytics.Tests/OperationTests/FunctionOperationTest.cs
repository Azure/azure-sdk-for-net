// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StreamAnalytics.Tests.OperationTests
{
    public class FunctionOperationTest : TestBase
    {
        [Fact]
        public void Test_FunctionOperations_Full_Scalar_AzureMLWebService()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("StreamAnalytics");
                string resourceName = TestUtilities.GenerateName("MyStreamingJobSubmittedBySDK");

                string serviceLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetStreamAnalyticsManagementClient(handler);

                try
                {
                    ResourceGroup resourceGroup = new ResourceGroup() { Location = serviceLocation };
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    // Construct the JobCreateProperties
                    JobCreateOrUpdateParameters jobCreateOrUpdateParameters =
                        new JobCreateOrUpdateParameters(TestHelper.GetDefaultJob(resourceName, serviceLocation));

                    // Create a streaming job
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse =
                        client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Retrieve default definition of the function
                    string functionName = TestUtilities.GenerateName("functiontest");
                    var retrieveDefaultDefinitionParameters = new 
                        AzureMachineLearningWebServiceFunctionRetrieveDefaultDefinitionParameters ()
                    {
                        BindingRetrievalProperties = new AzureMachineLearningWebServiceFunctionBindingRetrievalProperties()
                        {
                            ExecuteEndpoint = TestHelper.ExecuteEndpoint,
                            UdfType = "Scalar"
                        }
                    };
                    FunctionRetrieveDefaultDefinitionResponse retrieveDefaultDefinitionResponse =
                        client.Functions.RetrieveDefaultDefinition(resourceGroupName, resourceName, functionName,
                            retrieveDefaultDefinitionParameters);
                    Assert.Equal(functionName, retrieveDefaultDefinitionResponse.Function.Name);

                    // Add the function
                    ScalarFunctionProperties scalarFunctionProperties =
                        (ScalarFunctionProperties) retrieveDefaultDefinitionResponse.Function.Properties;
                    AzureMachineLearningWebServiceFunctionBinding azureMachineLearningWebServiceFunctionBinding =
                        (AzureMachineLearningWebServiceFunctionBinding) scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(TestHelper.ExecuteEndpoint, azureMachineLearningWebServiceFunctionBinding.Properties.Endpoint);
                    Assert.Equal(1000, azureMachineLearningWebServiceFunctionBinding.Properties.BatchSize);
                    Assert.Null(azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey);
                    azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey = TestHelper.ApiKey;
                    FunctionCreateOrUpdateParameters functionCreateOrUpdateParameters =
                        new FunctionCreateOrUpdateParameters {Function = retrieveDefaultDefinitionResponse.Function};
                    FunctionCreateOrUpdateResponse functionCreateOrUpdateResponse =
                        client.Functions.CreateOrUpdate(resourceGroupName, resourceName,
                            functionCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, functionCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(functionName, functionCreateOrUpdateResponse.Function.Name);
                    scalarFunctionProperties =
                        (ScalarFunctionProperties)functionCreateOrUpdateResponse.Function.Properties;
                    azureMachineLearningWebServiceFunctionBinding =
                        (AzureMachineLearningWebServiceFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(TestHelper.ExecuteEndpoint, azureMachineLearningWebServiceFunctionBinding.Properties.Endpoint);
                    Assert.Equal(1000, azureMachineLearningWebServiceFunctionBinding.Properties.BatchSize);
                    Assert.Null(azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey);
                    Assert.NotNull(functionCreateOrUpdateResponse.Function.Properties.Etag);

                    // Get the function
                    FunctionGetResponse functionGetResponse = client.Functions.Get(resourceGroupName, resourceName, functionName);
                    Assert.Equal(HttpStatusCode.OK, functionGetResponse.StatusCode);
                    Assert.Equal(functionName, functionGetResponse.Function.Name);
                    scalarFunctionProperties =
                        (ScalarFunctionProperties)functionGetResponse.Function.Properties;
                    azureMachineLearningWebServiceFunctionBinding =
                        (AzureMachineLearningWebServiceFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(TestHelper.ExecuteEndpoint, azureMachineLearningWebServiceFunctionBinding.Properties.Endpoint);
                    Assert.Equal(1000, azureMachineLearningWebServiceFunctionBinding.Properties.BatchSize);
                    Assert.Null(azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey);
                    Assert.Equal(functionCreateOrUpdateResponse.Function.Properties.Etag, functionGetResponse.Function.Properties.Etag);

                    // List functions
                    FunctionListResponse functionListResponse = client.Functions.ListFunctionsInJob(resourceGroupName, resourceName);
                    Assert.Equal(HttpStatusCode.OK, functionListResponse.StatusCode);
                    Assert.Equal(1, functionListResponse.Value.Count);

                    // Check that there is 1 function in the job
                    jobGetParameters = new JobGetParameters("functions");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(1, jobGetResponse.Job.Properties.Functions.Count);

                    // Test function connectivity
                    ResourceTestConnectionResponse response = client.Functions.TestConnection(resourceGroupName,
                        resourceName, functionName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the function
                    ScalarFunctionProperties scalarFunctionPropertiesForPatch = new ScalarFunctionProperties()
                    {
                        Properties = new ScalarFunctionConfiguration()
                        {
                            Binding = new AzureMachineLearningWebServiceFunctionBinding()
                            {
                                Properties = new AzureMachineLearningWebServiceFunctionBindingProperties()
                                {
                                    BatchSize = 256
                                }
                            }
                        }
                    };
                    FunctionPatchParameters functionPatchParameters = new FunctionPatchParameters(scalarFunctionPropertiesForPatch);
                    FunctionPatchResponse functionPatchResponse = client.Functions.Patch(resourceGroupName, resourceName,
                        functionName, functionPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, functionPatchResponse.StatusCode);
                    scalarFunctionProperties =
                        (ScalarFunctionProperties)functionPatchResponse.Properties;
                    azureMachineLearningWebServiceFunctionBinding =
                        (AzureMachineLearningWebServiceFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(TestHelper.ExecuteEndpoint, azureMachineLearningWebServiceFunctionBinding.Properties.Endpoint);
                    Assert.Equal(256, azureMachineLearningWebServiceFunctionBinding.Properties.BatchSize);
                    Assert.Null(azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey);
                    Assert.NotNull(functionPatchResponse.Properties.Etag);
                    Assert.NotEqual(functionCreateOrUpdateResponse.Function.Properties.Etag, functionPatchResponse.Properties.Etag);

                    // Add second function
                    string functionName2 = TestUtilities.GenerateName("functiontest");
                    Function function2 = new Function(functionName2)
                    {
                        Properties = retrieveDefaultDefinitionResponse.Function.Properties
                    };
                    functionCreateOrUpdateParameters.Function = function2;
                    functionCreateOrUpdateResponse = client.Functions.CreateOrUpdate(resourceGroupName, resourceName,
                        functionCreateOrUpdateParameters);

                    // List functions
                    functionListResponse = client.Functions.ListFunctionsInJob(resourceGroupName, resourceName);
                    Assert.Equal(HttpStatusCode.OK, functionListResponse.StatusCode);
                    Assert.Equal(2, functionListResponse.Value.Count);

                    // Check that there are 2 functions in the job
                    jobGetParameters = new JobGetParameters("functions");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(2, jobGetResponse.Job.Properties.Functions.Count);

                    // Delete the functions
                    AzureOperationResponse deleteFunctionOperationResponse = client.Functions.Delete(resourceGroupName,
                        resourceName, functionName);
                    Assert.Equal(HttpStatusCode.OK, deleteFunctionOperationResponse.StatusCode);

                    deleteFunctionOperationResponse = client.Functions.Delete(resourceGroupName, resourceName, functionName2);
                    Assert.Equal(HttpStatusCode.OK, deleteFunctionOperationResponse.StatusCode);

                    // Check that there are 0 functions in the job
                    jobGetParameters = new JobGetParameters("functions");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Functions.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_FunctionOperations_Scalar_JavaScript()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("StreamAnalytics");
                string resourceName = TestUtilities.GenerateName("MyStreamingJobSubmittedBySDK");

                string serviceLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetStreamAnalyticsManagementClient(handler);

                try
                {
                    ResourceGroup resourceGroup = new ResourceGroup() { Location = serviceLocation };
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    // Construct the JobCreateProperties
                    JobCreateOrUpdateParameters jobCreateOrUpdateParameters =
                        new JobCreateOrUpdateParameters(TestHelper.GetDefaultJob(resourceName, serviceLocation));

                    // Create a streaming job
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse =
                        client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Retrieve default definition of the function
                    string functionName = TestUtilities.GenerateName("functiontest");
                    string javaScriptFunctionCode = @"function (x, y) { return x + y; }";
                    var retrieveDefaultDefinitionParameters = new JavaScriptFunctionRetrieveDefaultDefinitionParameters
                        ()
                    {
                        BindingRetrievalProperties = new JavaScriptFunctionBindingRetrievalProperties()
                        {
                            Script = javaScriptFunctionCode,
                            UdfType = "Scalar"
                        }
                    };

                    CloudException cloudException =
                        Assert.Throws<CloudException>(
                            () =>
                                client.Functions.RetrieveDefaultDefinition(resourceGroupName, resourceName, functionName,
                                    retrieveDefaultDefinitionParameters));
                    Assert.Equal(HttpStatusCode.InternalServerError, cloudException.Response.StatusCode);
                    Assert.Contains("not supported", cloudException.Error.Message, StringComparison.InvariantCulture);

                    // Add the function
                    Function javaScriptFunction = new Function(functionName)
                    {
                        Properties = new ScalarFunctionProperties()
                        {
                            Properties = new ScalarFunctionConfiguration()
                            {
                                Inputs = new List<FunctionInput>(){ new FunctionInput() { DataType = "Any"} },
                                Output = new FunctionOutput()
                                {
                                    DataType = "Any"
                                },
                                Binding = new JavaScriptFunctionBinding()
                                {
                                    Properties = new JavaScriptFunctionBindingProperties()
                                    {
                                        Script = javaScriptFunctionCode
                                    }
                                }
                            }
                        }
                    };
                    FunctionCreateOrUpdateParameters functionCreateOrUpdateParameters =
                        new FunctionCreateOrUpdateParameters { Function = javaScriptFunction };
                    FunctionCreateOrUpdateResponse functionCreateOrUpdateResponse =
                        client.Functions.CreateOrUpdate(resourceGroupName, resourceName,
                            functionCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, functionCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(functionName, functionCreateOrUpdateResponse.Function.Name);
                    var scalarFunctionProperties =
                        (ScalarFunctionProperties)functionCreateOrUpdateResponse.Function.Properties;
                    var javaScriptFunctionBinding =
                        (JavaScriptFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(javaScriptFunctionCode, javaScriptFunctionBinding.Properties.Script);
                    Assert.NotNull(functionCreateOrUpdateResponse.Function.Properties.Etag);

                    // Get the function
                    FunctionGetResponse functionGetResponse = client.Functions.Get(resourceGroupName, resourceName, functionName);
                    Assert.Equal(HttpStatusCode.OK, functionGetResponse.StatusCode);
                    Assert.Equal(functionName, functionGetResponse.Function.Name);
                    scalarFunctionProperties =
                        (ScalarFunctionProperties)functionGetResponse.Function.Properties;
                    javaScriptFunctionBinding =
                        (JavaScriptFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(javaScriptFunctionCode, javaScriptFunctionBinding.Properties.Script);
                    Assert.Equal(functionCreateOrUpdateResponse.Function.Properties.Etag, functionGetResponse.Function.Properties.Etag);

                    // List functions
                    FunctionListResponse functionListResponse = client.Functions.ListFunctionsInJob(resourceGroupName, resourceName);
                    Assert.Equal(HttpStatusCode.OK, functionListResponse.StatusCode);
                    Assert.Equal(1, functionListResponse.Value.Count);

                    // Check that there is 1 function in the job
                    jobGetParameters = new JobGetParameters("functions");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(1, jobGetResponse.Job.Properties.Functions.Count);

                    // Test function connectivity
                    ResourceTestConnectionResponse response = client.Functions.TestConnection(resourceGroupName,
                        resourceName, functionName);
                    Assert.Equal(OperationStatus.Failed, response.Status);
                    Assert.Equal(ResourceTestStatus.TestFailed, response.ResourceTestStatus);
                    Assert.NotNull(response.Error);
                    Assert.Contains("not supported", response.Error.Message, StringComparison.InvariantCulture);

                    // Update the function
                    string newJavaScriptFunctionCode = @"function (x, y) { return x * y; }";
                    ScalarFunctionProperties scalarFunctionPropertiesForPatch = new ScalarFunctionProperties()
                    {
                        Properties = new ScalarFunctionConfiguration()
                        {
                            Binding = new JavaScriptFunctionBinding()
                            {
                                Properties = new JavaScriptFunctionBindingProperties()
                                {
                                    Script = newJavaScriptFunctionCode
                                }
                            }
                        }
                    };
                    FunctionPatchParameters functionPatchParameters = new FunctionPatchParameters(scalarFunctionPropertiesForPatch);
                    FunctionPatchResponse functionPatchResponse = client.Functions.Patch(resourceGroupName, resourceName,
                        functionName, functionPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, functionPatchResponse.StatusCode);
                    scalarFunctionProperties =
                        (ScalarFunctionProperties)functionPatchResponse.Properties;
                    javaScriptFunctionBinding =
                        (JavaScriptFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(newJavaScriptFunctionCode, javaScriptFunctionBinding.Properties.Script);
                    Assert.NotEqual(javaScriptFunctionCode, javaScriptFunctionBinding.Properties.Script);
                    Assert.NotNull(functionPatchResponse.Properties.Etag);
                    Assert.NotEqual(functionCreateOrUpdateResponse.Function.Properties.Etag, functionPatchResponse.Properties.Etag);

                    // Delete the functions
                    AzureOperationResponse deleteFunctionOperationResponse = client.Functions.Delete(resourceGroupName,
                        resourceName, functionName);
                    Assert.Equal(HttpStatusCode.OK, deleteFunctionOperationResponse.StatusCode);

                    // Check that there are 0 functions in the job
                    jobGetParameters = new JobGetParameters("functions");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Functions.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_FunctionOperations_RetrieveDefaultDefinitionWithRawJsonContent()
        {
            BasicDelegatingHandler handler = new BasicDelegatingHandler();

            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string resourceGroupName = TestUtilities.GenerateName("StreamAnalytics");
                string resourceName = TestUtilities.GenerateName("MyStreamingJobSubmittedBySDK");

                string serviceLocation = TestHelper.GetDefaultLocation();

                var resourceClient = TestHelper.GetResourceClient(handler);
                var client = TestHelper.GetStreamAnalyticsManagementClient(handler);

                try
                {
                    ResourceGroup resourceGroup = new ResourceGroup() { Location = serviceLocation };
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    // Construct the JobCreateProperties
                    JobCreateOrUpdateParameters jobCreateOrUpdateParameters =
                        new JobCreateOrUpdateParameters(TestHelper.GetDefaultJob(resourceName, serviceLocation));

                    // Create a streaming job
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse =
                        client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName,
                        jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Retrieve default definition of the function
                    string functionName = TestUtilities.GenerateName("functiontest");
                    string content = File.ReadAllText(@"Resources\RetrieveDefaultFunctionDefinitionRequest.json");
                    var retrieveDefaultDefinitionParameters = new FunctionRetrieveDefaultDefinitionWithRawJsonContentParameters
                        ()
                    {
                        Content = content
                    };
                    FunctionRetrieveDefaultDefinitionResponse retrieveDefaultDefinitionResponse =
                        client.Functions.RetrieveDefaultDefinitionWithRawJsonContent(resourceGroupName, resourceName,
                            functionName,
                            retrieveDefaultDefinitionParameters);
                    Assert.Equal(functionName, retrieveDefaultDefinitionResponse.Function.Name);
                    ScalarFunctionProperties scalarFunctionProperties =
                        (ScalarFunctionProperties)retrieveDefaultDefinitionResponse.Function.Properties;
                    AzureMachineLearningWebServiceFunctionBinding azureMachineLearningWebServiceFunctionBinding =
                        (AzureMachineLearningWebServiceFunctionBinding)scalarFunctionProperties.Properties.Binding;
                    Assert.Equal(TestHelper.ExecuteEndpoint,
                        azureMachineLearningWebServiceFunctionBinding.Properties.Endpoint);
                    Assert.Equal(1000, azureMachineLearningWebServiceFunctionBinding.Properties.BatchSize);
                    Assert.Null(azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey);
                    azureMachineLearningWebServiceFunctionBinding.Properties.ApiKey = TestHelper.ApiKey;
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}
