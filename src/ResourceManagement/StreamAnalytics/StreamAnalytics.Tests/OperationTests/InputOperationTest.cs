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
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace StreamAnalytics.Tests.OperationTests
{
    public class InputOperationsTest : TestBase
    {
        [Fact]
        public void Test_InputOperations_E2E()
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

                    // Construct the Input
                    StorageAccount storageAccount = new StorageAccount();
                    storageAccount.AccountName = TestHelper.AccountName;
                    storageAccount.AccountKey = TestHelper.AccountKey;
                    InputProperties inputProperties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            Properties = new CsvSerializationProperties()
                            {
                                FieldDelimiter = ",",
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
                    string inputName = TestUtilities.GenerateName("inputtest");
                    Input input1 = new Input(inputName)
                    {
                        Properties = inputProperties
                    };

                    // Add an input
                    InputCreateOrUpdateParameters inputCreateOrUpdateParameters = new InputCreateOrUpdateParameters();
                    inputCreateOrUpdateParameters.Input = input1;
                    InputCreateOrUpdateResponse inputCreateOrUpdateResponse = client.Inputs.CreateOrUpdate(resourceGroupName, resourceName, inputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, inputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(inputName, inputCreateOrUpdateResponse.Input.Name);
                    Assert.Equal("Stream", inputCreateOrUpdateResponse.Input.Properties.Type);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse1 = (CsvSerialization)inputCreateOrUpdateResponse.Input.Properties.Serialization;
                    Assert.Equal(",", csvSerializationInResponse1.Properties.FieldDelimiter);
                    Assert.NotNull(inputCreateOrUpdateResponse.Input.Properties.Etag);

                    // Get the input
                    InputGetResponse inputGetResponse = client.Inputs.Get(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, inputGetResponse.StatusCode);
                    Assert.Equal(inputName, inputGetResponse.Input.Name);
                    Assert.True(inputGetResponse.Input.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse2 = (CsvSerialization)inputGetResponse.Input.Properties.Serialization;
                    Assert.Equal(",", csvSerializationInResponse2.Properties.FieldDelimiter);
                    Assert.Equal(inputCreateOrUpdateResponse.Input.Properties.Etag, inputGetResponse.Input.Properties.Etag);

                    // List inputs
                    InputListResponse inputListResponse = client.Inputs.ListInputInJob(resourceGroupName, resourceName, new InputListParameters());
                    Assert.Equal(HttpStatusCode.OK, inputListResponse.StatusCode);
                    Assert.Equal(1, inputListResponse.Value.Count);

                    // Check that there is 1 input in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(1, jobGetResponse.Job.Properties.Inputs.Count);

                    // Test input connectivity
                    DataSourceTestConnectionResponse response = client.Inputs.TestConnection(resourceGroupName, resourceName, inputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(DataSourceTestStatus.TestSucceeded, response.DataSourceTestStatus);

                    // Update the input
                    Serialization csvSerialization = new CsvSerialization()
                    {
                        Properties = new CsvSerializationProperties()
                        {
                            FieldDelimiter = "|",
                            Encoding = "UTF8"
                        }
                    };
                    inputProperties.Serialization = csvSerialization;
                    inputProperties.Etag = inputCreateOrUpdateResponse.Input.Properties.Etag;
                    InputPatchParameters inputPatchParameters = new InputPatchParameters(inputProperties);
                    InputPatchResponse inputPatchResponse = client.Inputs.Patch(resourceGroupName, resourceName, inputName, inputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, inputPatchResponse.StatusCode);
                    Assert.True(inputPatchResponse.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse3 = (CsvSerialization)inputPatchResponse.Properties.Serialization;
                    Assert.Equal("|", csvSerializationInResponse3.Properties.FieldDelimiter);
                    Assert.NotNull(inputPatchResponse.Properties.Etag);
                    Assert.NotEqual(inputCreateOrUpdateResponse.Input.Properties.Etag, inputPatchResponse.Properties.Etag);
                    
                    // Add second input
                    string inputName2 = TestUtilities.GenerateName("inputtest");
                    Input input2 = new Input(inputName2)
                    {
                        Properties = inputProperties
                    };
                    inputCreateOrUpdateParameters.Input = input2;
                    inputCreateOrUpdateResponse = client.Inputs.CreateOrUpdate(resourceGroupName, resourceName, inputCreateOrUpdateParameters);

                    // List inputs
                    inputListResponse = client.Inputs.ListInputInJob(resourceGroupName, resourceName, new InputListParameters());
                    Assert.Equal(HttpStatusCode.OK, inputListResponse.StatusCode);
                    Assert.Equal(2, inputListResponse.Value.Count);

                    // Check that there are 2 inputs in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(2, jobGetResponse.Job.Properties.Inputs.Count);

                    // Delete the inputs
                    AzureOperationResponse deleteInputOperationResponse = client.Inputs.Delete(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, deleteInputOperationResponse.StatusCode);

                    deleteInputOperationResponse = client.Inputs.Delete(resourceGroupName, resourceName, inputName2);
                    Assert.Equal(HttpStatusCode.OK, deleteInputOperationResponse.StatusCode);

                    // Check that there are 0 inputs in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Inputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_InputOperations_EventHub()
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

                    // Construct the Input
                    
                    InputProperties inputProperties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            Properties = new CsvSerializationProperties()
                            {
                                FieldDelimiter = ",",
                                Encoding = "UTF8"
                            }
                        },
                        DataSource = new EventHubStreamInputDataSource()
                        {
                            Properties = new EventHubStreamInputDataSourceProperties()
                            {
                                ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                                EventHubName = TestHelper.EventHubName,
                                SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                                SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                                ConsumerGroupName = "sdkconsumergroup"
                            }
                        }
                    };
                    string inputName = TestUtilities.GenerateName("inputtest");
                    Input input1 = new Input(inputName)
                    {
                        Properties = inputProperties
                    };

                    // Add an input
                    InputCreateOrUpdateParameters inputCreateOrUpdateParameters = new InputCreateOrUpdateParameters();
                    inputCreateOrUpdateParameters.Input = input1;
                    InputCreateOrUpdateResponse inputCreateOrUpdateResponse = client.Inputs.CreateOrUpdate(resourceGroupName, resourceName, inputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, inputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(inputName, inputCreateOrUpdateResponse.Input.Name);
                    Assert.Equal("Stream", inputCreateOrUpdateResponse.Input.Properties.Type);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse1 = (CsvSerialization)inputCreateOrUpdateResponse.Input.Properties.Serialization;
                    Assert.Equal(",", csvSerializationInResponse1.Properties.FieldDelimiter);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties is StreamInputProperties);
                    StreamInputProperties streamInputPropertiesInResponse = (StreamInputProperties) inputCreateOrUpdateResponse.Input.Properties;
                    Assert.True(streamInputPropertiesInResponse.DataSource is EventHubStreamInputDataSource);
                    EventHubStreamInputDataSource eventHubInputDataSourceInResponse1 = (EventHubStreamInputDataSource)streamInputPropertiesInResponse.DataSource;
                    Assert.Equal("sdktest", eventHubInputDataSourceInResponse1.Properties.ServiceBusNamespace);
                    Assert.NotNull(streamInputPropertiesInResponse.Etag);

                    // Test input connectivity
                    DataSourceTestConnectionResponse response = client.Inputs.TestConnection(resourceGroupName, resourceName, inputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(DataSourceTestStatus.TestSucceeded, response.DataSourceTestStatus);

                    // Update the input
                    Serialization csvSerialization = new CsvSerialization()
                    {
                        Properties = new CsvSerializationProperties()
                        {
                            FieldDelimiter = "|",
                            Encoding = "UTF8"
                        }
                    };
                    inputProperties.Serialization = csvSerialization;
                    inputProperties.Etag = inputCreateOrUpdateResponse.Input.Properties.Etag;
                    InputPatchParameters inputPatchParameters = new InputPatchParameters(inputProperties);
                    InputPatchResponse inputPatchResponse = client.Inputs.Patch(resourceGroupName, resourceName, inputName, inputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, inputPatchResponse.StatusCode);
                    Assert.True(inputPatchResponse.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse2 = (CsvSerialization)inputPatchResponse.Properties.Serialization;
                    Assert.Equal("|", csvSerializationInResponse2.Properties.FieldDelimiter);
                    Assert.True(inputPatchResponse.Properties is StreamInputProperties);
                    StreamInputProperties streamInputPropertiesInResponse2 = (StreamInputProperties)inputPatchResponse.Properties;
                    Assert.True(streamInputPropertiesInResponse2.DataSource is EventHubStreamInputDataSource);
                    EventHubStreamInputDataSource eventHubInputDataSourceInResponse2 = (EventHubStreamInputDataSource)streamInputPropertiesInResponse2.DataSource;
                    Assert.Equal("sdktest", eventHubInputDataSourceInResponse2.Properties.ServiceBusNamespace);
                    Assert.NotNull(inputPatchResponse.Properties.Etag);
                    Assert.NotEqual(streamInputPropertiesInResponse.Etag, inputPatchResponse.Properties.Etag);

                    // Delete the input
                    AzureOperationResponse deleteInputOperationResponse = client.Inputs.Delete(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, deleteInputOperationResponse.StatusCode);

                    // Check that there are 0 inputs in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Inputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_InputOperations_ReferenceBlob()
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

                    // Construct the Input
                    StorageAccount storageAccount = new StorageAccount();
                    storageAccount.AccountName = TestHelper.AccountName;
                    storageAccount.AccountKey = TestHelper.AccountKey;
                    InputProperties inputProperties = new ReferenceInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            Properties = new CsvSerializationProperties()
                            {
                                FieldDelimiter = ",",
                                Encoding = "UTF8"
                            }
                        },
                        DataSource = new BlobReferenceInputDataSource()
                        {
                            Properties = new BlobReferenceInputDataSourceProperties()
                            {
                                StorageAccounts = new[] { storageAccount },
                                Container = "state",
                                PathPattern = "{date}",
                                DateFormat = "yyyy/MM/dd"
                            }
                        }
                    };
                    string inputName = TestUtilities.GenerateName("inputtest");
                    Input input1 = new Input(inputName)
                    {
                        Properties = inputProperties
                    };

                    // Add an input
                    InputCreateOrUpdateParameters inputCreateOrUpdateParameters = new InputCreateOrUpdateParameters();
                    inputCreateOrUpdateParameters.Input = input1;
                    InputCreateOrUpdateResponse inputCreateOrUpdateResponse = client.Inputs.CreateOrUpdate(resourceGroupName, resourceName, inputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, inputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(inputName, inputCreateOrUpdateResponse.Input.Name);
                    Assert.Equal("Reference", inputCreateOrUpdateResponse.Input.Properties.Type);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties is ReferenceInputProperties);
                    ReferenceInputProperties referenceInputPropertiesInResponse1 = (ReferenceInputProperties) inputCreateOrUpdateResponse.Input.Properties;
                    Assert.True(referenceInputPropertiesInResponse1.DataSource is BlobReferenceInputDataSource);
                    BlobReferenceInputDataSource blobReferenceInputDataSourceInResponse1 = (BlobReferenceInputDataSource)referenceInputPropertiesInResponse1.DataSource;
                    Assert.Equal("{date}", blobReferenceInputDataSourceInResponse1.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobReferenceInputDataSourceInResponse1.Properties.DateFormat);
                    Assert.NotNull(inputCreateOrUpdateResponse.Input.Properties.Etag);

                    // Get the input
                    InputGetResponse inputGetResponse = client.Inputs.Get(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, inputGetResponse.StatusCode);
                    Assert.Equal(inputName, inputGetResponse.Input.Name);
                    Assert.True(inputGetResponse.Input.Properties is ReferenceInputProperties);
                    ReferenceInputProperties referenceInputPropertiesInResponse2 = (ReferenceInputProperties)inputGetResponse.Input.Properties;
                    Assert.True(referenceInputPropertiesInResponse2.DataSource is BlobReferenceInputDataSource);
                    BlobReferenceInputDataSource blobReferenceInputDataSourceInResponse2 = (BlobReferenceInputDataSource)referenceInputPropertiesInResponse2.DataSource;
                    Assert.Equal("{date}", blobReferenceInputDataSourceInResponse2.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobReferenceInputDataSourceInResponse2.Properties.DateFormat);
                    Assert.Equal(inputCreateOrUpdateResponse.Input.Properties.Etag, inputGetResponse.Input.Properties.Etag);

                    // List inputs
                    InputListResponse inputListResponse = client.Inputs.ListInputInJob(resourceGroupName, resourceName, new InputListParameters());
                    Assert.Equal(HttpStatusCode.OK, inputListResponse.StatusCode);
                    Assert.Equal(1, inputListResponse.Value.Count);

                    // Test input connectivity
                    DataSourceTestConnectionResponse response = client.Inputs.TestConnection(resourceGroupName, resourceName, inputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(DataSourceTestStatus.TestSucceeded, response.DataSourceTestStatus);

                    // Update the input
                    BlobReferenceInputDataSource blobReferenceInputDataSource = new BlobReferenceInputDataSource()
                    {
                        Properties = new BlobReferenceInputDataSourceProperties()
                        {
                            StorageAccounts = new[] { storageAccount },
                            Container = "state",
                            PathPattern = "test.csv",
                            DateFormat = "yyyy/MM/dd"
                        }
                    };
                    ((ReferenceInputProperties)inputProperties).DataSource = blobReferenceInputDataSource;
                    inputProperties.Etag = inputCreateOrUpdateResponse.Input.Properties.Etag;
                    InputPatchParameters inputPatchParameters = new InputPatchParameters(inputProperties);
                    InputPatchResponse inputPatchResponse = client.Inputs.Patch(resourceGroupName, resourceName, inputName, inputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, inputPatchResponse.StatusCode);
                    Assert.True(inputPatchResponse.Properties is ReferenceInputProperties);
                    ReferenceInputProperties referenceInputPropertiesInResponse3 = (ReferenceInputProperties)inputPatchResponse.Properties;
                    Assert.True(referenceInputPropertiesInResponse3.DataSource is BlobReferenceInputDataSource);
                    BlobReferenceInputDataSource blobReferenceInputDataSourceInResponse3 = (BlobReferenceInputDataSource)referenceInputPropertiesInResponse3.DataSource;
                    Assert.Equal("test.csv", blobReferenceInputDataSourceInResponse3.Properties.PathPattern);
                    Assert.Equal("yyyy/MM/dd", blobReferenceInputDataSourceInResponse3.Properties.DateFormat);
                    Assert.NotNull(inputPatchResponse.Properties.Etag);
                    Assert.NotEqual(inputCreateOrUpdateResponse.Input.Properties.Etag, inputPatchResponse.Properties.Etag);

                    // Delete the inputs
                    AzureOperationResponse deleteInputOperationResponse = client.Inputs.Delete(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, deleteInputOperationResponse.StatusCode);

                    // Check that there are 0 inputs in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Inputs.Count);
                }
                finally
                {
                    client.StreamingJobs.Delete(resourceGroupName, resourceName);
                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        public void Test_InputOperations_IoTHub()
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

                    // Construct the Input
                    string sharedAccessPolicyName = "owner";
                    InputProperties inputProperties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            Properties = new CsvSerializationProperties()
                            {
                                FieldDelimiter = ",",
                                Encoding = "UTF8"
                            }
                        },
                        DataSource = new IoTHubStreamInputDataSource()
                        {
                            Properties = new IoTHubStreamInputDataSourceProperties()
                            {
                                IotHubNamespace = TestHelper.IoTHubNamespace,
                                SharedAccessPolicyName = sharedAccessPolicyName,
                                SharedAccessPolicyKey = TestHelper.IotHubSharedAccessPolicyKey
                            }
                        }
                    };
                    string inputName = TestUtilities.GenerateName("inputtest");
                    Input input1 = new Input(inputName)
                    {
                        Properties = inputProperties
                    };

                    // Add an input
                    InputCreateOrUpdateParameters inputCreateOrUpdateParameters = new InputCreateOrUpdateParameters();
                    inputCreateOrUpdateParameters.Input = input1;
                    InputCreateOrUpdateResponse inputCreateOrUpdateResponse = client.Inputs.CreateOrUpdate(resourceGroupName, resourceName, inputCreateOrUpdateParameters);
                    Assert.Equal(HttpStatusCode.OK, inputCreateOrUpdateResponse.StatusCode);
                    Assert.Equal(inputName, inputCreateOrUpdateResponse.Input.Name);
                    Assert.Equal("Stream", inputCreateOrUpdateResponse.Input.Properties.Type);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse1 = (CsvSerialization)inputCreateOrUpdateResponse.Input.Properties.Serialization;
                    Assert.Equal(",", csvSerializationInResponse1.Properties.FieldDelimiter);
                    Assert.True(inputCreateOrUpdateResponse.Input.Properties is StreamInputProperties);
                    StreamInputProperties streamInputPropertiesInResponse = (StreamInputProperties)inputCreateOrUpdateResponse.Input.Properties;
                    Assert.True(streamInputPropertiesInResponse.DataSource is IoTHubStreamInputDataSource);
                    IoTHubStreamInputDataSource iotHubInputDataSourceInResponse1 = (IoTHubStreamInputDataSource)streamInputPropertiesInResponse.DataSource;
                    Assert.Equal(sharedAccessPolicyName, iotHubInputDataSourceInResponse1.Properties.SharedAccessPolicyName);
                    Assert.NotNull(streamInputPropertiesInResponse.Etag);

                    // Get the input
                    InputGetResponse inputGetResponse = client.Inputs.Get(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, inputGetResponse.StatusCode);
                    Assert.Equal(inputName, inputGetResponse.Input.Name);
                    Assert.True(inputGetResponse.Input.Properties is StreamInputProperties);
                    StreamInputProperties streamInputPropertiesInResponse2 = (StreamInputProperties)inputGetResponse.Input.Properties;
                    Assert.True(streamInputPropertiesInResponse2.DataSource is IoTHubStreamInputDataSource);
                    IoTHubStreamInputDataSource iotHubInputDataSourceInResponse2 = (IoTHubStreamInputDataSource)streamInputPropertiesInResponse2.DataSource;
                    Assert.Equal(sharedAccessPolicyName, iotHubInputDataSourceInResponse2.Properties.SharedAccessPolicyName);
                    Assert.Equal(inputCreateOrUpdateResponse.Input.Properties.Etag, inputGetResponse.Input.Properties.Etag);

                    // Test input connectivity
                    DataSourceTestConnectionResponse response = client.Inputs.TestConnection(resourceGroupName, resourceName, inputName);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                    Assert.Equal(DataSourceTestStatus.TestSucceeded, response.DataSourceTestStatus);

                    // Update the input
                    string newSharedPolicyName = TestUtilities.GenerateName("owner");
                    inputProperties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            Properties = new CsvSerializationProperties()
                            {
                                FieldDelimiter = "|",
                                Encoding = "UTF8"
                            }
                        },
                        DataSource = new IoTHubStreamInputDataSource()
                        {
                            Properties = new IoTHubStreamInputDataSourceProperties()
                            {
                                IotHubNamespace = TestHelper.IoTHubNamespace,
                                SharedAccessPolicyName = newSharedPolicyName,
                                SharedAccessPolicyKey = TestHelper.IotHubSharedAccessPolicyKey
                            }
                        }
                    };
                    inputProperties.Etag = inputCreateOrUpdateResponse.Input.Properties.Etag;
                    InputPatchParameters inputPatchParameters = new InputPatchParameters(inputProperties);
                    InputPatchResponse inputPatchResponse = client.Inputs.Patch(resourceGroupName, resourceName, inputName, inputPatchParameters);
                    Assert.Equal(HttpStatusCode.OK, inputPatchResponse.StatusCode);
                    Assert.True(inputPatchResponse.Properties.Serialization is CsvSerialization);
                    CsvSerialization csvSerializationInResponse2 = (CsvSerialization)inputPatchResponse.Properties.Serialization;
                    Assert.Equal("|", csvSerializationInResponse2.Properties.FieldDelimiter);
                    Assert.True(inputPatchResponse.Properties is StreamInputProperties);
                    StreamInputProperties streamInputPropertiesInResponse3 = (StreamInputProperties)inputPatchResponse.Properties;
                    Assert.True(streamInputPropertiesInResponse3.DataSource is IoTHubStreamInputDataSource);
                    IoTHubStreamInputDataSource iotHubInputDataSourceInResponse3 = (IoTHubStreamInputDataSource)streamInputPropertiesInResponse3.DataSource;
                    Assert.Equal(newSharedPolicyName, iotHubInputDataSourceInResponse3.Properties.SharedAccessPolicyName);
                    Assert.NotNull(inputPatchResponse.Properties.Etag);
                    Assert.NotEqual(streamInputPropertiesInResponse.Etag, inputPatchResponse.Properties.Etag);

                    // Delete the input
                    AzureOperationResponse deleteInputOperationResponse = client.Inputs.Delete(resourceGroupName, resourceName, inputName);
                    Assert.Equal(HttpStatusCode.OK, deleteInputOperationResponse.StatusCode);

                    // Check that there are 0 inputs in the job
                    jobGetParameters = new JobGetParameters("inputs");
                    jobGetResponse = client.StreamingJobs.Get(resourceGroupName, resourceName, jobGetParameters);
                    Assert.Equal(HttpStatusCode.OK, jobGetResponse.StatusCode);
                    Assert.Equal(0, jobGetResponse.Job.Properties.Inputs.Count);
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