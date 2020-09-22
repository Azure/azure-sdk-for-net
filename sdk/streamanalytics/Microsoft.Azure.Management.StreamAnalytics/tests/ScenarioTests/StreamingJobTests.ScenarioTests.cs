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
    public class StreamingJobTests : TestBase
    {
        [Fact]
        public async Task StreamingJobOperationsTest_JobShell()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedJobResourceId = TestHelper.GetJobResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                StreamingJob streamingJob = new StreamingJob()
                {
                    Tags = new Dictionary<string, string>()
                    {
                        { "key1", "value1" },
                        { "randomKey", "randomValue" },
                        { "key3", "value3" }
                    },
                    Location = TestHelper.DefaultLocation,
                    EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Drop,
                    EventsOutOfOrderMaxDelayInSeconds = 5,
                    EventsLateArrivalMaxDelayInSeconds = 16,
                    OutputErrorPolicy = OutputErrorPolicy.Drop,
                    DataLocale = "en-US",
                    CompatibilityLevel = CompatibilityLevel.OneFullStopZero,
                    Sku = new Microsoft.Azure.Management.StreamAnalytics.Models.StreamingJobSku()
                    {
                        Name = StreamingJobSkuName.Standard
                    },
                    Inputs = new List<Input>(),
                    Outputs = new List<Output>(),
                    Functions = new List<Function>()
                };

                // PUT job
                var putResponse = await streamAnalyticsManagementClient.StreamingJobs.CreateOrReplaceWithHttpMessagesAsync(streamingJob, resourceGroupName, jobName);
                ValidationHelper.ValidateStreamingJob(streamingJob, putResponse.Body, false);
                Assert.Equal(expectedJobResourceId, putResponse.Body.Id);
                Assert.Equal(jobName, putResponse.Body.Name);
                Assert.Equal(TestHelper.StreamingJobFullResourceType, putResponse.Body.Type);

                Assert.Equal("Succeeded", putResponse.Body.ProvisioningState);
                Assert.Equal("Created", putResponse.Body.JobState);

                // Verify GET request returns expected job
                var getResponse = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName, "inputs,outputs,transformation,functions");
                ValidationHelper.ValidateStreamingJob(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // PATCH job
                var streamingJobPatch = new StreamingJob()
                {
                    EventsOutOfOrderMaxDelayInSeconds = 21,
                    EventsLateArrivalMaxDelayInSeconds = 13                    
                };
                putResponse.Body.EventsOutOfOrderMaxDelayInSeconds = streamingJobPatch.EventsOutOfOrderMaxDelayInSeconds;
                putResponse.Body.EventsLateArrivalMaxDelayInSeconds = streamingJobPatch.EventsLateArrivalMaxDelayInSeconds;
                putResponse.Body.Inputs = null;
                putResponse.Body.Outputs = null;
                putResponse.Body.Functions = null;
                var patchResponse = await streamAnalyticsManagementClient.StreamingJobs.UpdateWithHttpMessagesAsync(streamingJobPatch, resourceGroupName, jobName);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                putResponse.Body.Inputs = new List<Input>();
                putResponse.Body.Outputs = new List<Output>();
                putResponse.Body.Functions = new List<Function>();
                // Run another GET job to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName, "inputs,outputs,transformation,functions");
                ValidationHelper.ValidateStreamingJob(putResponse.Body, getResponse.Body, true);
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List job and verify that the job shows up in the list
                var listByRgResponse = streamAnalyticsManagementClient.StreamingJobs.ListByResourceGroup(resourceGroupName, "inputs,outputs,transformation,functions");
                Assert.Single(listByRgResponse);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, listByRgResponse.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listByRgResponse.Single().Etag);

                var listReponse = streamAnalyticsManagementClient.StreamingJobs.List("inputs, outputs, transformation, functions");
                Assert.Single(listReponse);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, listReponse.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listReponse.Single().Etag);

                // Delete job
                streamAnalyticsManagementClient.StreamingJobs.Delete(resourceGroupName, jobName);

                // Verify that list operation returns an empty list after deleting the job
                listByRgResponse = streamAnalyticsManagementClient.StreamingJobs.ListByResourceGroup(resourceGroupName, "inputs,outputs,transformation,functions");
                Assert.Empty(listByRgResponse);

                listReponse = streamAnalyticsManagementClient.StreamingJobs.List("inputs, outputs, transformation, functions");
                Assert.Empty(listReponse);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task StreamingJobOperationsTest_FullJob()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string inputName = "inputtest";
                string transformationName = "transformationtest";
                string outputName = "outputtest";

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedJobResourceId = TestHelper.GetJobResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName);
                string expectedInputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.InputsResourceType, inputName);
                string expectedTransformationResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.TransformationResourceType, transformationName);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                StorageAccount storageAccount = new StorageAccount()
                {
                    AccountName = TestHelper.AccountName,
                    AccountKey = TestHelper.AccountKey
                };
                Input input = new Input(id: expectedInputResourceId)
                {
                    Name = inputName,
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new JsonSerialization()
                        {
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new BlobStreamInputDataSource()
                        {
                            StorageAccounts = new[] { storageAccount },
                            Container = TestHelper.Container,
                            PathPattern = "",
                        }
                    }
                };

                AzureSqlDatabaseOutputDataSource azureSqlDatabase = new AzureSqlDatabaseOutputDataSource()
                {
                    Server = TestHelper.Server,
                    Database = TestHelper.Database,
                    User = TestHelper.User,
                    Password = TestHelper.Password,
                    Table = TestHelper.SqlTableName
                };
                Output output = new Output(id: expectedOutputResourceId)
                {
                    Name = outputName,
                    Datasource = azureSqlDatabase
                };

                StreamingJob streamingJob = new StreamingJob()
                {
                    Tags = new Dictionary<string, string>()
                    {
                        { "key1", "value1" },
                        { "randomKey", "randomValue" },
                        { "key3", "value3" }
                    },
                    Location = TestHelper.DefaultLocation,
                    EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Drop,
                    EventsOutOfOrderMaxDelayInSeconds = 0,
                    EventsLateArrivalMaxDelayInSeconds = 5,
                    OutputErrorPolicy = OutputErrorPolicy.Drop,
                    DataLocale = "en-US",
                    CompatibilityLevel = "1.0",
                    Sku = new Microsoft.Azure.Management.StreamAnalytics.Models.StreamingJobSku()
                    {
                        Name = StreamingJobSkuName.Standard
                    },
                    Inputs = new List<Input>() { input },
                    Transformation = new Transformation(id: expectedTransformationResourceId)
                    {
                        Name = transformationName,
                        Query = "Select Id, Name from inputtest",
                        StreamingUnits = 1
                    },
                    Outputs = new List<Output>() { output },
                    Functions = new List<Function>()
                };

                // PUT job
                var putResponse = await streamAnalyticsManagementClient.StreamingJobs.CreateOrReplaceWithHttpMessagesAsync(streamingJob, resourceGroupName, jobName);
                // Null out because secrets are not returned in responses
                storageAccount.AccountKey = null;
                azureSqlDatabase.Password = null;
                ValidationHelper.ValidateStreamingJob(streamingJob, putResponse.Body, false);
                Assert.Equal(expectedJobResourceId, putResponse.Body.Id);
                Assert.Equal(jobName, putResponse.Body.Name);
                Assert.Equal(TestHelper.StreamingJobFullResourceType, putResponse.Body.Type);
                //Assert.True(putResponse.Body.CreatedDate > DateTime.UtcNow.AddMinutes(-1));

                Assert.Equal("Succeeded", putResponse.Body.ProvisioningState);
                Assert.Equal("Created", putResponse.Body.JobState);

                // Verify GET request returns expected job
                var getResponse = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName, "inputs,outputs,transformation,functions");
                ValidationHelper.ValidateStreamingJob(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // PATCH job
                var streamingJobPatch = new StreamingJob()
                {
                    EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Adjust,
                    OutputErrorPolicy = OutputErrorPolicy.Stop
                };
                putResponse.Body.EventsOutOfOrderPolicy = streamingJobPatch.EventsOutOfOrderPolicy;
                putResponse.Body.OutputErrorPolicy = streamingJobPatch.OutputErrorPolicy;
                putResponse.Body.Functions = null;
                streamingJob.EventsOutOfOrderPolicy = streamingJobPatch.EventsOutOfOrderPolicy;
                streamingJob.OutputErrorPolicy = streamingJobPatch.OutputErrorPolicy;
                streamingJob.Inputs = null;
                streamingJob.Transformation = null;
                streamingJob.Outputs = null;
                streamingJob.Functions = null;
                var patchResponse = await streamAnalyticsManagementClient.StreamingJobs.UpdateWithHttpMessagesAsync(streamingJobPatch, resourceGroupName, jobName);
                ValidationHelper.ValidateStreamingJob(streamingJob, patchResponse.Body, false);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                putResponse.Body.Functions = new List<Function>();
                // Run another GET job to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName, "inputs,outputs,transformation,functions");
                ValidationHelper.ValidateStreamingJob(putResponse.Body, getResponse.Body, true);
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List job and verify that the job shows up in the list
                var listByRgResponse = streamAnalyticsManagementClient.StreamingJobs.ListByResourceGroup(resourceGroupName, "inputs,outputs,transformation,functions");
                Assert.Single(listByRgResponse);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, listByRgResponse.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listByRgResponse.Single().Etag);

                var listReponse = streamAnalyticsManagementClient.StreamingJobs.List("inputs, outputs, transformation, functions");
                Assert.Single(listReponse);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, listReponse.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listReponse.Single().Etag);

                // Start job
                StartStreamingJobParameters startStreamingJobParameters = new StartStreamingJobParameters()
                {
                    OutputStartMode = OutputStartMode.LastOutputEventTime
                };
                CloudException cloudException = Assert.Throws<CloudException>(() => streamAnalyticsManagementClient.StreamingJobs.Start(resourceGroupName, jobName, startStreamingJobParameters));
                Assert.Equal((HttpStatusCode)422, cloudException.Response.StatusCode);
                Assert.Contains("LastOutputEventTime must be available when OutputStartMode is set to LastOutputEventTime. Please make sure at least one output event has been processed.", cloudException.Response.Content);

                startStreamingJobParameters.OutputStartMode = OutputStartMode.CustomTime;
                startStreamingJobParameters.OutputStartTime = new DateTime(2012, 12, 12, 12, 12, 12, DateTimeKind.Utc);
                putResponse.Body.OutputStartMode = startStreamingJobParameters.OutputStartMode;
                putResponse.Body.OutputStartTime = startStreamingJobParameters.OutputStartTime;
                streamingJob.OutputStartMode = startStreamingJobParameters.OutputStartMode;
                streamingJob.OutputStartTime = startStreamingJobParameters.OutputStartTime;
                streamAnalyticsManagementClient.StreamingJobs.Start(resourceGroupName, jobName, startStreamingJobParameters);

                // Check that job started
                var getResponseAfterStart = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName);
                Assert.Equal("Succeeded", getResponseAfterStart.Body.ProvisioningState);
                Assert.True(getResponseAfterStart.Body.JobState == "Running" || getResponseAfterStart.Body.JobState == "Degraded"); 
                Assert.Null(getResponseAfterStart.Body.Inputs);
                Assert.Null(getResponseAfterStart.Body.Transformation);
                Assert.Null(getResponseAfterStart.Body.Outputs);
                Assert.Null(getResponseAfterStart.Body.Functions);
                ValidationHelper.ValidateStreamingJob(streamingJob, getResponseAfterStart.Body, false);
                Assert.NotEqual(putResponse.Headers.ETag, getResponseAfterStart.Headers.ETag);
                Assert.NotEqual(patchResponse.Headers.ETag, getResponseAfterStart.Headers.ETag);

                // Check diagnostics
                var inputListResponse = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName, "*");
                Assert.NotNull(inputListResponse);
                Assert.Single(inputListResponse);
                var inputFromList = inputListResponse.Single();
                Assert.NotNull(inputFromList.Properties.Diagnostics);
                Assert.Equal(2, inputFromList.Properties.Diagnostics.Conditions.Count());
                Assert.NotNull(inputFromList.Properties.Diagnostics.Conditions[0].Since);
                DateTime.Parse(inputFromList.Properties.Diagnostics.Conditions[0].Since);
                Assert.Equal(@"INP-3", inputFromList.Properties.Diagnostics.Conditions[0].Code);
                Assert.Equal(@"Could not deserialize the input event(s) from resource 'https://$testAccountName$.blob.core.windows.net/state/states1.csv' as Json. Some possible reasons: 1) Malformed events 2) Input source configured with incorrect serialization format", inputFromList.Properties.Diagnostics.Conditions[0].Message);

                // Stop job
                streamAnalyticsManagementClient.StreamingJobs.Stop(resourceGroupName, jobName);

                // Check that job stopped
                var getResponseAfterStop = await streamAnalyticsManagementClient.StreamingJobs.GetWithHttpMessagesAsync(resourceGroupName, jobName, "inputs,outputs,transformation,functions");
                Assert.Equal("Succeeded", getResponseAfterStop.Body.ProvisioningState);
                Assert.Equal("Stopped", getResponseAfterStop.Body.JobState);
                ValidationHelper.ValidateStreamingJob(putResponse.Body, getResponseAfterStop.Body, false);
                Assert.NotEqual(putResponse.Headers.ETag, getResponseAfterStop.Headers.ETag);
                Assert.NotEqual(patchResponse.Headers.ETag, getResponseAfterStop.Headers.ETag);
                Assert.NotEqual(getResponseAfterStart.Headers.ETag, getResponseAfterStop.Headers.ETag);

                // Delete job
                streamAnalyticsManagementClient.StreamingJobs.Delete(resourceGroupName, jobName);

                // Verify that list operation returns an empty list after deleting the job
                listByRgResponse = streamAnalyticsManagementClient.StreamingJobs.ListByResourceGroup(resourceGroupName, "inputs,outputs,transformation,functions");
                Assert.Empty(listByRgResponse);

                listReponse = streamAnalyticsManagementClient.StreamingJobs.List("inputs, outputs, transformation, functions");
                Assert.Empty(listReponse);
            }
        }
    }
}
