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
using System.Net;
using System.Text;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StreamAnalytics.Tests.OperationTests
{
    public class OutputOperationsTest : TestBase
    {
        [Fact]
        public void Test_OutputOperations_E2E()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string tableName = "StateInfo";
                    SqlAzureOutputDataSource sqlAzureOutputDataSource = new SqlAzureOutputDataSource()
                    {
                        Properties = new SqlAzureOutputDataSourceProperties()
                        {
                            Server = TestHelper.Server,
                            Database = TestHelper.Database,
                            User = TestHelper.User,
                            Password = TestHelper.Password,
                            Table = tableName
                        }
                    };
                    outputProperties.DataSource = sqlAzureOutputDataSource;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is SqlAzureOutputDataSource);
                    SqlAzureOutputDataSource sqlAzureOutputDataSourceInResponse1 = (SqlAzureOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(tableName, sqlAzureOutputDataSourceInResponse1.Properties.Table);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is SqlAzureOutputDataSource);
                    SqlAzureOutputDataSource sqlAzureOutputDataSourceInResponse2 = (SqlAzureOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(tableName, sqlAzureOutputDataSourceInResponse2.Properties.Table);

                    // List outputs
                    OutputListResponse outputListResponse = client.Outputs.ListOutputInJob(resourceGroupName, resourceName, new OutputListParameters());
                    Assert.Equal(HttpStatusCode.OK, outputListResponse.StatusCode);
                    Assert.Equal(1, outputListResponse.Value.Count);

                    // Check that there is 1 output in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(1, jobGetResponse.Job.Properties.Outputs.Count);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    string newTableName = TestUtilities.GenerateName("NewTableName");
                    sqlAzureOutputDataSource.Properties.Table = newTableName;
                    outputProperties.DataSource = sqlAzureOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is SqlAzureOutputDataSource);
                    SqlAzureOutputDataSource sqlAzureOutputDataSourceInResponse3 = (SqlAzureOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newTableName, sqlAzureOutputDataSourceInResponse3.Properties.Table);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Add second output
                    string outputName2 = TestUtilities.GenerateName("outputtest");
                    Output output2 = new Output(outputName2)
                    {
                        Properties = outputProperties
                    };
                    outputCreateOrUpdateParameters.Output = output2;
                    outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);

                    // List outputs
                    outputListResponse = client.Outputs.ListOutputInJob(resourceGroupName, resourceName, new OutputListParameters());
                    Assert.Equal(HttpStatusCode.OK, outputListResponse.StatusCode);
                    Assert.Equal(2, outputListResponse.Value.Count);

                    // Check that there are 2 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(2, jobGetResponse.Job.Properties.Outputs.Count);

                    // Delete the outputs
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName2);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check that there are 0 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_Blob()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    StorageAccount storageAccount = new StorageAccount();
                    storageAccount.AccountName = TestHelper.AccountName;
                    storageAccount.AccountKey = TestHelper.AccountKey;
                    BlobOutputDataSource blobOutputDataSource = new BlobOutputDataSource()
                    {
                        Properties = new BlobOutputDataSourceProperties()
                        {
                            StorageAccounts = new[] { storageAccount },
                            Container = "state",
                            PathPattern = "{date}",
                            DateFormat = "yyyy/MM/dd"
                        }
                    };
                    JsonSerialization jsonSerialization = new JsonSerialization()
                    {
                        Properties = new JsonSerializationProperties()
                        {
                            Encoding = "UTF8",
                            Format = Format.LineSeparated
                        }
                    };
                    outputProperties.DataSource = blobOutputDataSource;
                    outputProperties.Serialization = jsonSerialization;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is BlobOutputDataSource);
                    BlobOutputDataSource blobOutputDataSourceInResponse1 = (BlobOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal("{date}", blobOutputDataSourceInResponse1.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobOutputDataSourceInResponse1.Properties.DateFormat);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is BlobOutputDataSource);
                    BlobOutputDataSource blobOutputDataSourceInResponse2 = (BlobOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal("{date}", blobOutputDataSourceInResponse2.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobOutputDataSourceInResponse2.Properties.DateFormat);
                    Assert.Equal(outputCreateOrUpdateResponse.Output.Properties.Etag, outputGetResponse.Output.Properties.Etag);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    blobOutputDataSource.Properties.PathPattern = "test.csv";
                    outputProperties.DataSource = blobOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is BlobOutputDataSource);
                    BlobOutputDataSource blobOutputDataSourceInResponse3 = (BlobOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal("test.csv", blobOutputDataSourceInResponse3.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobOutputDataSourceInResponse3.Properties.DateFormat);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check that there are 0 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_AzureTable()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string tableName = "samples";
                    AzureTableOutputDataSource azureTableOutputDataSource = new AzureTableOutputDataSource()
                    {
                        Properties = new AzureTableOutputDataSourceProperties()
                        {
                            AccountName = TestHelper.AccountName,
                            AccountKey = TestHelper.AccountKey,
                            PartitionKey = "partitionKey",
                            RowKey = "rowKey",
                            Table = tableName
                        }
                    };
                    outputProperties.DataSource = azureTableOutputDataSource;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is AzureTableOutputDataSource);
                    AzureTableOutputDataSource azureTableOutputDataSourceInResponse1 = (AzureTableOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(tableName, azureTableOutputDataSourceInResponse1.Properties.Table);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is AzureTableOutputDataSource);
                    AzureTableOutputDataSource azureTableOutputDataSourceInResponse2 = (AzureTableOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(tableName, azureTableOutputDataSourceInResponse2.Properties.Table);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    string newTableName = TestUtilities.GenerateName("NewTableName");
                    azureTableOutputDataSource.Properties.Table = newTableName;
                    outputProperties.DataSource = azureTableOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is AzureTableOutputDataSource);
                    AzureTableOutputDataSource azureTableOutputDataSourceInResponse3 = (AzureTableOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newTableName, azureTableOutputDataSourceInResponse3.Properties.Table);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check that there are 0 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_EventHub()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string partitionKey = "partitionKey";
                    EventHubOutputDataSource eventHubOutputDataSource = new EventHubOutputDataSource()
                    {
                        Properties = new EventHubOutputDataSourceProperties()
                        {
                            ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                            EventHubName = TestHelper.EventHubName,
                            SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                            SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                            PartitionKey = partitionKey
                        }
                    };
                    JsonSerialization jsonSerialization = new JsonSerialization()
                    {
                        Properties = new JsonSerializationProperties()
                        {
                            Encoding = "UTF8",
                            Format = Format.LineSeparated
                        }
                    };
                    outputProperties.DataSource = eventHubOutputDataSource;
                    outputProperties.Serialization = jsonSerialization;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.Serialization is JsonSerialization);
                    JsonSerialization jsonSerializationInResponse1 = (JsonSerialization)outputCreateOrUpdateResponse.Output.Properties.Serialization;
                    Assert.Equal(Format.LineSeparated, jsonSerializationInResponse1.Properties.Format);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is EventHubOutputDataSource);
                    EventHubOutputDataSource eventHubOutputDataSourceInResponse1 = (EventHubOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(partitionKey, eventHubOutputDataSourceInResponse1.Properties.PartitionKey);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.Serialization is JsonSerialization);
                    JsonSerialization jsonSerializationInResponse2 = (JsonSerialization)outputGetResponse.Output.Properties.Serialization;
                    Assert.Equal(Format.LineSeparated, jsonSerializationInResponse2.Properties.Format);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is EventHubOutputDataSource);
                    EventHubOutputDataSource eventHubOutputDataSourceInResponse2 = (EventHubOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(partitionKey, eventHubOutputDataSourceInResponse2.Properties.PartitionKey);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    jsonSerialization = new JsonSerialization()
                    {
                        Properties = new JsonSerializationProperties()
                        {
                            Encoding = "UTF8",
                            Format = Format.Array
                        }
                    };
                    string newPartitionKey = TestUtilities.GenerateName("NewPartitionKey");
                    eventHubOutputDataSource.Properties.PartitionKey = newPartitionKey;
                    outputProperties.DataSource = eventHubOutputDataSource;
                    outputProperties.Serialization = jsonSerialization;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.Serialization is JsonSerialization);
                    JsonSerialization jsonSerializationInResponse3 = (JsonSerialization)outputPatchResponse.Properties.Serialization;
                    // TODO : Re-enable check once service bug is fixed
                    //Assert.Equal(Format.Array, jsonSerializationInResponse3.Properties.Format);
                    Assert.True(outputPatchResponse.Properties.DataSource is EventHubOutputDataSource);
                    EventHubOutputDataSource eventHubOutputDataSourceInResponse3 = (EventHubOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newPartitionKey, eventHubOutputDataSourceInResponse3.Properties.PartitionKey);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check that there are 0 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_ServiceBusQueue()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string queueName = "sdkqueue";
                    ServiceBusQueueOutputDataSource serviceBusQueueOutputDataSource = new ServiceBusQueueOutputDataSource()
                    {
                        Properties = new ServiceBusQueueOutputDataSourceProperties()
                        {
                            ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                            QueueName = queueName,
                            SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                            SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                        }
                    };
                    JsonSerialization jsonSerialization = new JsonSerialization()
                    {
                        Properties = new JsonSerializationProperties()
                        {
                            Encoding = "UTF8",
                            Format = Format.LineSeparated
                        }
                    };
                    outputProperties.DataSource = serviceBusQueueOutputDataSource;
                    outputProperties.Serialization = jsonSerialization;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is ServiceBusQueueOutputDataSource);
                    ServiceBusQueueOutputDataSource serviceBusQueueOutputDataSourceInResponse1 = (ServiceBusQueueOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(queueName, serviceBusQueueOutputDataSourceInResponse1.Properties.QueueName);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is ServiceBusQueueOutputDataSource);
                    ServiceBusQueueOutputDataSource serviceBusQueueOutputDataSourceInResponse2 = (ServiceBusQueueOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(queueName, serviceBusQueueOutputDataSourceInResponse2.Properties.QueueName);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    string newQueueName = TestUtilities.GenerateName("NewQueueName");
                    serviceBusQueueOutputDataSource.Properties.QueueName = newQueueName;
                    outputProperties.DataSource = serviceBusQueueOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is ServiceBusQueueOutputDataSource);
                    ServiceBusQueueOutputDataSource serviceBusQueueOutputDataSourceInResponse3 = (ServiceBusQueueOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newQueueName, serviceBusQueueOutputDataSourceInResponse3.Properties.QueueName);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check there is no output any more
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_ServiceBusTopic()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string topicName = "sdktopic";
                    ServiceBusTopicOutputDataSource serviceBusTopicOutputDataSource = new ServiceBusTopicOutputDataSource()
                    {
                        Properties = new ServiceBusTopicOutputDataSourceProperties()
                        {
                            ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                            TopicName = topicName,
                            SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                            SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                        }
                    };
                    JsonSerialization jsonSerialization = new JsonSerialization()
                    {
                        Properties = new JsonSerializationProperties()
                        {
                            Encoding = "UTF8",
                            Format = Format.LineSeparated
                        }
                    };
                    outputProperties.DataSource = serviceBusTopicOutputDataSource;
                    outputProperties.Serialization = jsonSerialization;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is ServiceBusTopicOutputDataSource);
                    ServiceBusTopicOutputDataSource serviceBusTopicOutputDataSourceInResponse1 = (ServiceBusTopicOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(topicName, serviceBusTopicOutputDataSourceInResponse1.Properties.TopicName);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is ServiceBusTopicOutputDataSource);
                    ServiceBusTopicOutputDataSource serviceBusTopicOutputDataSourceInResponse2 = (ServiceBusTopicOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(topicName, serviceBusTopicOutputDataSourceInResponse2.Properties.TopicName);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    string newTopicName = TestUtilities.GenerateName("NewTopicName");
                    serviceBusTopicOutputDataSource.Properties.TopicName = newTopicName;
                    outputProperties.DataSource = serviceBusTopicOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is ServiceBusTopicOutputDataSource);
                    ServiceBusTopicOutputDataSource serviceBusTopicOutputDataSourceInResponse3 = (ServiceBusTopicOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newTopicName, serviceBusTopicOutputDataSourceInResponse3.Properties.TopicName);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check there is no output any more
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_OutputOperations_DocumentDB()
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
                    JobCreateOrUpdateResponse jobCreateOrUpdateResponse = client.StreamingJobs.CreateOrUpdate(resourceGroupName, jobCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, jobCreateOrUpdateResponse.StatusCode);

                    // Get a streaming job to check
                    JobGetParameters jobGetParameters = new JobGetParameters(string.Empty);
                    JobGetResponse jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(serviceLocation, jobGetResponse.Job.Location);
                    Assert.Equal(resourceName, jobGetResponse.Job.Name);

                    // Construct the Output
                    OutputProperties outputProperties = new OutputProperties();
                    string outputName = TestUtilities.GenerateName("outputtest");
                    string database = "db01";
                    DocumentDbOutputDataSource documentDbOutputDataSource = new DocumentDbOutputDataSource()
                    {
                        Properties = new DocumentDbOutputDataSourceProperties()
                        {
                            AccountId = TestHelper.DocDbAccountId,
                            AccountKey = TestHelper.DocDbAccountKey,
                            Database = database,
                            PartitionKey = "key",
                            CollectionNamePattern = "collection"
                        }
                    };
                    outputProperties.DataSource = documentDbOutputDataSource;
                    Output output1 = new Output(outputName)
                    {
                        Properties = outputProperties
                    };

                    // Add an output
                    OutputCreateOrUpdateParameters outputCreateOrUpdateParameters = new OutputCreateOrUpdateParameters();
                    outputCreateOrUpdateParameters.Output = output1;
                    OutputCreateOrUpdateResponse outputCreateOrUpdateResponse = client.Outputs.CreateOrUpdate(resourceGroupName, resourceName, outputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, outputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(outputName, outputCreateOrUpdateResponse.Output.Name);
                    Assert.True(outputCreateOrUpdateResponse.Output.Properties.DataSource is DocumentDbOutputDataSource);
                    DocumentDbOutputDataSource documentDbOutputDataSourceInResponse1 = (DocumentDbOutputDataSource)outputCreateOrUpdateResponse.Output.Properties.DataSource;
                    Assert.Equal(database, documentDbOutputDataSourceInResponse1.Properties.Database);
                    Assert.NotNull(outputCreateOrUpdateResponse.Output.Properties.Etag);

                    // Get the output
                    OutputGetResponse outputGetResponse = client.Outputs.Get(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, outputGetResponse.StatusCode);
                    Assert.Equal(outputName, outputGetResponse.Output.Name);
                    Assert.True(outputGetResponse.Output.Properties.DataSource is DocumentDbOutputDataSource);
                    DocumentDbOutputDataSource documentDbOutputDataSourceInResponse2 = (DocumentDbOutputDataSource)outputGetResponse.Output.Properties.DataSource;
                    Assert.Equal(database, documentDbOutputDataSourceInResponse2.Properties.Database);

                    // Test output connectivity
                    ResourceTestConnectionResponse response = client.Outputs.TestConnection(resourceGroupName, resourceName, outputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(ResourceTestStatus.TestSucceeded, response.ResourceTestStatus);

                    // Update the output
                    string newDatabase = TestUtilities.GenerateName("NewDatabase");
                    documentDbOutputDataSource.Properties.Database = newDatabase;
                    outputProperties.DataSource = documentDbOutputDataSource;
                    outputProperties.Etag = outputCreateOrUpdateResponse.Output.Properties.Etag;
                    OutputPatchParameters outputPatchParameters = new OutputPatchParameters(outputProperties);
                    OutputPatchResponse outputPatchResponse = client.Outputs.Patch(resourceGroupName, resourceName, outputName, outputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, outputPatchResponse.StatusCode);
                    Assert.True(outputPatchResponse.Properties.DataSource is DocumentDbOutputDataSource);
                    DocumentDbOutputDataSource documentDbOutputDataSourceInResponse3 = (DocumentDbOutputDataSource)outputPatchResponse.Properties.DataSource;
                    Assert.Equal(newDatabase, documentDbOutputDataSourceInResponse3.Properties.Database);
                    Assert.NotNull(outputPatchResponse.Properties.Etag);
                    Assert.NotEqual(outputCreateOrUpdateResponse.Output.Properties.Etag, outputPatchResponse.Properties.Etag);

                    // Delete the output
                    AzureOperationResponse deleteOutputOperationResponse = client.Outputs.Delete(resourceGroupName, resourceName, outputName);
                    Assert.Equal(HttpStatusCode.OK, deleteOutputOperationResponse.StatusCode);

                    // Check that there are 0 outputs in the job
                    jobGetParameters = new JobGetParameters("outputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Outputs.Count);
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