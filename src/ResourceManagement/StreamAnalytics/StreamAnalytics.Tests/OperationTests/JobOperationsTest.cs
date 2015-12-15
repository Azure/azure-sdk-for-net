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
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
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
    public class JobOperationsTest : TestBase
    {
        [Fact]
        public void Test_JobOperations_E2E()
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
                    ResourceGroup resourceGroup = new ResourceGroup() {Location = serviceLocation};
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroup);

                    Job job = new Job();
                    job.Name = resourceName;
                    job.Location = serviceLocation;

                    // Construct the general properties for JobProperties
                    JobProperties jobProperties = new JobProperties();
                    jobProperties.Sku = new Sku()
                    {
                        Name = "standard"
                    };
                    jobProperties.EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Drop;
                    jobProperties.EventsOutOfOrderMaxDelayInSeconds = 0;

                    // Construct the Input
                    StorageAccount storageAccount = new StorageAccount
                    {
                        AccountName = TestHelper.AccountName,
                        AccountKey = TestHelper.AccountKey
                    };
                    InputProperties inputProperties = new StreamInputProperties()
                    {
                        Serialization = new JsonSerialization()
                        {
                            Properties = new JsonSerializationProperties()
                            {
                                Encoding = "UTF8"
                            }
                        },
                        DataSource = new BlobStreamInputDataSource()
                        {
                            Properties = new BlobStreamInputDataSourceProperties()
                            {
                                StorageAccounts = new[] { storageAccount },
                                Container = "state",
                                PathPattern = ""
                            }
                        }
                    };
                    Input input1 = new Input("inputtest")
                    {
                        Properties = inputProperties
                    };
                    jobProperties.Inputs = new[] { input1 };

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    SqlAzureOutputDataSource sqlAzureOutputDataSource = new SqlAzureOutputDataSource()
                    {
                        Properties = new SqlAzureOutputDataSourceProperties()
                        {
                            Server = TestHelper.Server,
                            Database = TestHelper.Database,
                            User = TestHelper.User,
                            Password = TestHelper.Password,
                            Table = "StateInfo"
                        }
                    };
                    outputProperties.DataSource = sqlAzureOutputDataSource;
                    Output output1 = new Output("outputtest")
                    {
                        Properties = outputProperties
                    };
                    jobProperties.Outputs = new Output[] { output1 };

                    // Construct the transformation
                    Transformation transformation = new Transformation()
                    {
                        Name = "transformationtest",
                        Properties = new TransformationProperties()
                        {
                            Query = "Select Id, Name from inputtest",
                            StreamingUnits = 1
                        }
                    };
                    jobProperties.Transformation = transformation;

                    job.Properties = jobProperties;

                    // Construct the JobCreateProperties
                    JobCreateOrUpdateParameters jobCreateOrUpdateParameters = new JobCreateOrUpdateParameters();
                    jobCreateOrUpdateParameters.Job = job;

                    // Create a streaming job
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);
                    Assert.NotNull(jobCreateOrUpdateResponse.Job.Properties.Etag);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters("inputs,transformation,outputs");
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);
                    Assert.True(jobGetResponse.Job.Properties.Inputs[0].Properties is StreamInputProperties);
                    StreamInputProperties streamInputProperties = jobGetResponse.Job.Properties.Inputs[0].Properties as StreamInputProperties;
                    Assert.Equal("Stream", jobGetResponse.Job.Properties.Inputs[0].Properties.Type);
                    Assert.Equal("Microsoft.Storage/Blob", streamInputProperties.DataSource.Type);
                    Assert.Equal("Json", streamInputProperties.Serialization.Type);
                    Assert.Equal(EventsOutOfOrderPolicy.Drop, jobGetResponse.Job.Properties.EventsOutOfOrderPolicy);
                    Assert.NotNull(jobGetResponse.Job.Properties.Etag);
                    Assert.Equal(jobCreateOrUpdateResponse.Job.Properties.Etag, jobGetResponse.Job.Properties.Etag);

                    // Patch the streaming job
                    JobPatchParameters jobPatchParameters = new JobPatchParameters()
                    {
                        JobPatchRequest = new JobPatchRequest()
                        {
                            Properties = new JobProperties()
                            {
                                EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Adjust
                            }
                        }
                    };
                    var jobPatchResponse = client.StreamingJobs.Patch(resourceGroupName, resourceName, jobPatchParameters);
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobPatchResponse.StatusCode);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(EventsOutOfOrderPolicy.Adjust, jobPatchResponse.Job.Properties.EventsOutOfOrderPolicy);
                    Assert.Equal(EventsOutOfOrderPolicy.Adjust, jobGetResponse.Job.Properties.EventsOutOfOrderPolicy);

                    JobListParameters parameters = new JobListParameters(string.Empty);
                    JobListResponse response = client.StreamingJobs.ListJobsInResourceGroup(resourceGroupName, parameters);
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                    // Start a streaming job
                    JobStartParameters jobStartParameters = new JobStartParameters()
                    {
                        OutputStartMode = OutputStartMode.LastOutputEventTime
                    };
                    CloudException cloudException = Assert.Throws<CloudException>(() => client.StreamingJobs.Start(resourceGroupName, resourceName, jobStartParameters));
                    Assert.Equal("LastOutputEventTime must be available when OutputStartMode is set to LastOutputEventTime. Please make sure at least one output event has been processed. ", cloudException.Error.Message);

                    jobStartParameters.OutputStartMode = OutputStartMode.CustomTime;
                    jobStartParameters.OutputStartTime = new DateTime(2012, 12, 12, 12, 12, 12, DateTimeKind.Utc);
                    AzureOperationResponse jobStartOperationResponse = client.StreamingJobs.Start(resourceGroupName, resourceName, jobStartParameters);
                    Assert.Equal(HttpStatusCode.OK, jobStartOperationResponse.StatusCode);

                    // Get a streaming job to check
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.True(IsRunning(jobGetResponse.Job.Properties.JobState));

                    // Check diagnostics
                    InputListResponse inputListResponse = client.Inputs.ListInputInJob(resourceGroupName, resourceName,
                        new InputListParameters("*"));
                    Assert.Equal(HttpStatusCode.OK, inputListResponse.StatusCode);
                    Assert.NotEqual(0, inputListResponse.Value.Count);
                    Assert.NotNull(inputListResponse.Value[0].Properties.Diagnostics);
                    Assert.NotEqual(0, inputListResponse.Value[0].Properties.Diagnostics.Conditions.Count);
                    Assert.NotNull(inputListResponse.Value[0].Properties.Diagnostics.Conditions[0].Code);
                    Assert.NotNull(inputListResponse.Value[0].Properties.Diagnostics.Conditions[0].Message);

                    // Stop a streaming job
                    AzureOperationResponse jobStopOperationResponse = client.StreamingJobs.Stop(resourceGroupName, resourceName);
                    Assert.Equal(HttpStatusCode.OK, jobStopOperationResponse.StatusCode);

                    // Get a streaming job to check
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(JobRunningState.Stopped, jobGetResponse.Job.Properties.JobState);

                    // Delete a streaming job
                    AzureOperationResponse jobDeleteOperationResponse = client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    Assert.Equal(HttpStatusCode.OK, jobDeleteOperationResponse.StatusCode);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_JobOperationsWithJsonContent_E2E()
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

                    Job job = new Job();
                    job.Location = serviceLocation;

                    string inputName = TestUtilities.GenerateName("input");
                    string outputName = TestUtilities.GenerateName("output");
                    string transformationName = TestUtilities.GenerateName("transformation");

                    // Create a streaming job
                    string content = File.ReadAllText(@"Resources\JobDefinition.json");
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse =
                        client.StreamingJobs.CreateOrUpdateWithRawJsonContent(resourceGroupName, resourceName,
                            new JobCreateOrUpdateWithRawJsonContentParameters()
                            {
                                Content = content
                            });
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);
                    Assert.NotNull(jobCreateOrUpdateResponse.Job.Properties.Etag);

                    // Create an input for the streaming job
                    content = File.ReadAllText(@"Resources\InputDefinition.json");
                    InputCreateOrUpdateResponse inputCreateOrUpdateResponse =
                        client.Inputs.CreateOrUpdateWithRawJsonContent(resourceGroupName, resourceName, inputName,
                            new InputCreateOrUpdateWithRawJsonContentParameters()
                            {
                                Content = content
                            });
                    Assert.Equal(HttpStatusCode.OK, inputCreateOrUpdateResponse.StatusCode);
                    Assert.NotNull(inputCreateOrUpdateResponse.Input.Properties.Etag);

                    // Create an output for the streaming job
                    content = File.ReadAllText(@"Resources\OutputDefinition.json");
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse =
                        client.Outputs.CreateOrUpdateWithRawJsonContent(resourceGroupName, resourceName, outputName,
                            new OutputCreateOrUpdateWithRawJsonContentParameters()
                            {
                                Content = content
                            });
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Create a tranformation for the streaming job
                    content = File.ReadAllText(@"Resources\TransformationDefinition.json");
                    TransformationCreateOrUpdateResponse transformationCreateOrUpdateResponse =
                        client.Transformations.CreateOrUpdateWithRawJsonContent(resourceGroupName, resourceName,
                            transformationName, new TransformationCreateOrUpdateWithRawJsonContentParameters()
                            {
                                Content = content
                            });
                    Assert.Equal(HttpStatusCode.OK, transformationCreateOrUpdateResponse.StatusCode);
                    Assert.NotNull(transformationCreateOrUpdateResponse.Transformation.Properties.Etag);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters("inputs,transformation,outputs");
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);
                    Assert.Equal(inputName, jobGetResponse.Job.Properties.Inputs.SingleOrDefault().Name);
                    Assert.Equal(outputName, jobGetResponse.Job.Properties.Outputs.SingleOrDefault().Name);
                    Assert.Equal(transformationName, jobGetResponse.Job.Properties.Transformation.Name);
                    Assert.NotNull(jobGetResponse.Job.Properties.Etag);
                    Assert.NotEqual(jobCreateOrUpdateResponse.Job.Properties.Etag, jobGetResponse.Job.Properties.Etag);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        public static bool IsRunning(string jobStatus)
        {
            return jobStatus == JobRunningState.Running ||
                   jobStatus == JobRunningState.Degraded;
        }
    }
}
