// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class FunctionTests : TestBase
    {
        [Fact(Skip = "ReRecord due to CR change")]
        public async Task FunctionOperationsTest_Scalar_AzureMLWebService()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string functionName = TestUtilities.GenerateName("function");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedFunctionType = TestHelper.GetFullRestOnlyResourceType(TestHelper.FunctionsResourceType);
                string expectedFunctionResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.FunctionsResourceType, functionName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                var expectedFunction = new Function()
                {
                    Properties = new ScalarFunctionProperties()
                    {
                        Inputs = new List<FunctionInput>()
                        {
                            new FunctionInput()
                            {
                                DataType = @"nvarchar(max)",
                                IsConfigurationParameter = null
                            }
                        },
                        Output = new FunctionOutput()
                        {
                            DataType = @"nvarchar(max)"
                        },
                        Binding = new AzureMachineLearningStudioFunctionBinding()
                        {
                            Endpoint = TestHelper.ExecuteEndpoint,
                            ApiKey = null,
                            Inputs = new AzureMachineLearningStudioInputs()
                            {
                                Name = "input1",
                                ColumnNames = new AzureMachineLearningStudioInputColumn[]
                                {
                                    new AzureMachineLearningStudioInputColumn()
                                    {
                                        Name = "tweet",
                                        DataType = "string",
                                        MapTo = 0
                                    }
                                }
                            },
                            Outputs = new List<AzureMachineLearningStudioOutputColumn>()
                            {
                                new AzureMachineLearningStudioOutputColumn()
                                {
                                    Name = "Sentiment",
                                    DataType = "string"
                                }
                            },
                            BatchSize = 1000
                        }
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // Retrieve default definition
                AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters retrieveDefaultDefinitionParameters = new AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters()
                {
                    UdfType = UdfType.Scalar,
                    ExecuteEndpoint = TestHelper.ExecuteEndpoint

                };
                var function = streamAnalyticsManagementClient.Functions.RetrieveDefaultDefinition(resourceGroupName, jobName, functionName, retrieveDefaultDefinitionParameters);
                Assert.Equal(functionName, function.Name);
                Assert.Null(function.Id);
                Assert.Null(function.Type);
                ValidationHelper.ValidateFunctionProperties(expectedFunction.Properties, function.Properties, false);

                // PUT function
                ((AzureMachineLearningStudioFunctionBinding)((ScalarFunctionProperties)function.Properties).Binding).ApiKey = TestHelper.ApiKey;
                var putResponse = await streamAnalyticsManagementClient.Functions.CreateOrReplaceWithHttpMessagesAsync(function, resourceGroupName, jobName, functionName);
                ((AzureMachineLearningStudioFunctionBinding)((ScalarFunctionProperties)function.Properties).Binding).ApiKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateFunction(function, putResponse.Body, false);
                Assert.Equal(expectedFunctionResourceId, putResponse.Body.Id);
                Assert.Equal(functionName, putResponse.Body.Name);
                Assert.Equal(expectedFunctionType, putResponse.Body.Type);

                // Verify GET request returns expected function
                var getResponse = await streamAnalyticsManagementClient.Functions.GetWithHttpMessagesAsync(resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Function
                var testResult = streamAnalyticsManagementClient.Functions.Test(resourceGroupName, jobName, functionName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH function
                var functionPatch = new Function()
                {
                    Properties = new ScalarFunctionProperties()
                    {
                        Binding = new AzureMachineLearningStudioFunctionBinding()
                        {
                            BatchSize = 5000
                        }
                    }
                };
                ((AzureMachineLearningStudioFunctionBinding)((ScalarFunctionProperties)putResponse.Body.Properties).Binding).BatchSize = ((AzureMachineLearningStudioFunctionBinding)((ScalarFunctionProperties)functionPatch.Properties).Binding).BatchSize;
                var patchResponse = await streamAnalyticsManagementClient.Functions.UpdateWithHttpMessagesAsync(functionPatch, resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET function to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Functions.GetWithHttpMessagesAsync(resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List function and verify that the function shows up in the list
                var listResult = streamAnalyticsManagementClient.Functions.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateFunction(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with function expanded and verify that the function shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "functions");
                Assert.Single(getJobResponse.Functions);
                ValidationHelper.ValidateFunction(putResponse.Body, getJobResponse.Functions.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Functions.Single().Properties.Etag);

                // Delete function
                streamAnalyticsManagementClient.Functions.Delete(resourceGroupName, jobName, functionName);

                // Verify that list operation returns an empty list after deleting the function
                listResult = streamAnalyticsManagementClient.Functions.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with function expanded and verify that there are no functions after deleting the function
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "functions");
                Assert.Empty(getJobResponse.Functions);
            }
        }

        [Fact]
        public async Task FunctionOperationsTest_Scalar_JavaScript()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string functionName = TestUtilities.GenerateName("function");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedFunctionType = TestHelper.GetFullRestOnlyResourceType(TestHelper.FunctionsResourceType);
                string expectedFunctionResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.FunctionsResourceType, functionName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                string javaScriptFunctionCode = @"function (x, y) { return x + y; }";

                var function = new Function()
                {
                    Properties = new ScalarFunctionProperties()
                    {
                        Inputs = new List<FunctionInput>()
                        {
                            new FunctionInput()
                            {
                                DataType = @"Any",
                                IsConfigurationParameter = null
                            }
                        },
                        Output = new FunctionOutput()
                        {
                            DataType = @"Any"
                        },
                        Binding = new JavaScriptFunctionBinding()
                        {
                            Script = javaScriptFunctionCode
                        }
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // Retrieve default definition
                JavaScriptFunctionRetrieveDefaultDefinitionParameters retrieveDefaultDefinitionParameters = new JavaScriptFunctionRetrieveDefaultDefinitionParameters()
                {
                    UdfType = UdfType.Scalar,
                    Script = javaScriptFunctionCode

                };
                CloudException cloudException = Assert.Throws<CloudException>(
                    () => streamAnalyticsManagementClient.Functions.RetrieveDefaultDefinition(resourceGroupName, jobName, functionName, retrieveDefaultDefinitionParameters));
                Assert.Equal(HttpStatusCode.InternalServerError, cloudException.Response.StatusCode);
                Assert.Contains(@"Retrieve default definition is not supported for function type: Microsoft.StreamAnalytics/JavascriptUdf", cloudException.Response.Content);

                // PUT function
                var putResponse = await streamAnalyticsManagementClient.Functions.CreateOrReplaceWithHttpMessagesAsync(function, resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(function, putResponse.Body, false);
                Assert.Equal(expectedFunctionResourceId, putResponse.Body.Id);
                Assert.Equal(functionName, putResponse.Body.Name);
                Assert.Equal(expectedFunctionType, putResponse.Body.Type);

                // Verify GET request returns expected function
                var getResponse = await streamAnalyticsManagementClient.Functions.GetWithHttpMessagesAsync(resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Function
                var testResult = streamAnalyticsManagementClient.Functions.Test(resourceGroupName, jobName, functionName);
                Assert.Equal("TestFailed", testResult.Status);
                Assert.NotNull(testResult.Error);
                Assert.Equal("BadRequest", testResult.Error.Code);
                Assert.Equal(@"Test operation is not supported for function type: Microsoft.StreamAnalytics/JavascriptUdf", testResult.Error.Message);

                // PATCH function
                var functionPatch = new Function()
                {
                    Properties = new ScalarFunctionProperties()
                    {
                        Binding = new JavaScriptFunctionBinding()
                        {
                            Script = @"function (a, b) { return a * b; }"
                        }
                    }
                };
                ((JavaScriptFunctionBinding)((ScalarFunctionProperties)putResponse.Body.Properties).Binding).Script = ((JavaScriptFunctionBinding)((ScalarFunctionProperties)functionPatch.Properties).Binding).Script;
                var patchResponse = await streamAnalyticsManagementClient.Functions.UpdateWithHttpMessagesAsync(functionPatch, resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET function to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Functions.GetWithHttpMessagesAsync(resourceGroupName, jobName, functionName);
                ValidationHelper.ValidateFunction(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List function and verify that the function shows up in the list
                var listResult = streamAnalyticsManagementClient.Functions.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateFunction(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with function expanded and verify that the function shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "functions");
                Assert.Single(getJobResponse.Functions);
                ValidationHelper.ValidateFunction(putResponse.Body, getJobResponse.Functions.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Functions.Single().Properties.Etag);

                // Delete function
                streamAnalyticsManagementClient.Functions.Delete(resourceGroupName, jobName, functionName);

                // Verify that list operation returns an empty list after deleting the function
                listResult = streamAnalyticsManagementClient.Functions.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with function expanded and verify that there are no functions after deleting the function
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "functions");
                Assert.Empty(getJobResponse.Functions);
            }
        }
    }
}
