// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class InputTests : TestBase
    {
        [Fact(Skip = "ReRecord due to CR change")]
        public async Task InputOperationsTest_Stream_Blob()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string inputName = TestUtilities.GenerateName("input");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedInputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.InputsResourceType);
                string expectedInputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.InputsResourceType, inputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                StorageAccount storageAccount = new StorageAccount()
                {
                    AccountName = TestHelper.AccountName,
                    AccountKey = TestHelper.AccountKey
                };
                Input input = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            FieldDelimiter = ",",
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new BlobStreamInputDataSource()
                        {
                            StorageAccounts = new[] { storageAccount },
                            Container = TestHelper.Container,
                            PathPattern = "{date}/{time}",
                            DateFormat = "yyyy/MM/dd",
                            TimeFormat = "HH",
                            SourcePartitionCount = 16
                        }
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT input
                var putResponse = await streamAnalyticsManagementClient.Inputs.CreateOrReplaceWithHttpMessagesAsync(input, resourceGroupName, jobName, inputName);
                storageAccount.AccountKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateInput(input, putResponse.Body, false);
                Assert.Equal(expectedInputResourceId, putResponse.Body.Id);
                Assert.Equal(inputName, putResponse.Body.Name);
                Assert.Equal(expectedInputType, putResponse.Body.Type);

                // Verify GET request returns expected input
                var getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Input
                var testResult = streamAnalyticsManagementClient.Inputs.Test(resourceGroupName, jobName, inputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH input
                var inputPatch = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            FieldDelimiter = "|",
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new BlobStreamInputDataSource()
                        {
                            SourcePartitionCount = 32
                        }
                    }
                };
                ((CsvSerialization)putResponse.Body.Properties.Serialization).FieldDelimiter = ((CsvSerialization)inputPatch.Properties.Serialization).FieldDelimiter;
                ((BlobStreamInputDataSource)((StreamInputProperties)putResponse.Body.Properties).Datasource).SourcePartitionCount = ((BlobStreamInputDataSource)((StreamInputProperties)inputPatch.Properties).Datasource).SourcePartitionCount;
                var patchResponse = await streamAnalyticsManagementClient.Inputs.UpdateWithHttpMessagesAsync(inputPatch, resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET input to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List input and verify that the input shows up in the list
                var listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateInput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with input expanded and verify that the input shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Single(getJobResponse.Inputs);
                ValidationHelper.ValidateInput(putResponse.Body, getJobResponse.Inputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Inputs.Single().Properties.Etag);

                // Delete input
                streamAnalyticsManagementClient.Inputs.Delete(resourceGroupName, jobName, inputName);

                // Verify that list operation returns an empty list after deleting the input
                listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with input expanded and verify that there are no inputs after deleting the input
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Empty(getJobResponse.Inputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task InputOperationsTest_Stream_EventHub()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string inputName = TestUtilities.GenerateName("input");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedInputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.InputsResourceType);
                string expectedInputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.InputsResourceType, inputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                EventHubStreamInputDataSource eventHub = new EventHubStreamInputDataSource()
                {
                    ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                    SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                    SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                    EventHubName = TestHelper.EventHubName,
                    ConsumerGroupName = "sdkconsumergroup"
                };
                Input input = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new JsonSerialization()
                        {
                            Encoding = Encoding.UTF8
                        },
                        Datasource = eventHub
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT input
                var putResponse = await streamAnalyticsManagementClient.Inputs.CreateOrReplaceWithHttpMessagesAsync(input, resourceGroupName, jobName, inputName);
                eventHub.SharedAccessPolicyKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateInput(input, putResponse.Body, false);
                Assert.Equal(expectedInputResourceId, putResponse.Body.Id);
                Assert.Equal(inputName, putResponse.Body.Name);
                Assert.Equal(expectedInputType, putResponse.Body.Type);

                // Verify GET request returns expected input
                var getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Input
                var testResult = streamAnalyticsManagementClient.Inputs.Test(resourceGroupName, jobName, inputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH input
                var inputPatch = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new AvroSerialization(),
                        Datasource = new EventHubStreamInputDataSource()
                        {
                            ConsumerGroupName = "differentConsumerGroupName"
                        }
                    }
                };
                putResponse.Body.Properties.Serialization = inputPatch.Properties.Serialization;
                ((EventHubStreamInputDataSource)((StreamInputProperties)putResponse.Body.Properties).Datasource).ConsumerGroupName = ((EventHubStreamInputDataSource)((StreamInputProperties)inputPatch.Properties).Datasource).ConsumerGroupName;
                var patchResponse = await streamAnalyticsManagementClient.Inputs.UpdateWithHttpMessagesAsync(inputPatch, resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET input to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List input and verify that the input shows up in the list
                var listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateInput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with input expanded and verify that the input shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Single(getJobResponse.Inputs);
                ValidationHelper.ValidateInput(putResponse.Body, getJobResponse.Inputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Inputs.Single().Properties.Etag);

                // Delete input
                streamAnalyticsManagementClient.Inputs.Delete(resourceGroupName, jobName, inputName);

                // Verify that list operation returns an empty list after deleting the input
                listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with input expanded and verify that there are no inputs after deleting the input
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Empty(getJobResponse.Inputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task InputOperationsTest_Stream_IoTHub()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string inputName = TestUtilities.GenerateName("input");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedInputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.InputsResourceType);
                string expectedInputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.InputsResourceType, inputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                IoTHubStreamInputDataSource iotHub = new IoTHubStreamInputDataSource()
                {
                    IotHubNamespace = TestHelper.IoTHubNamespace,
                    SharedAccessPolicyName = TestHelper.IoTSharedAccessPolicyName,
                    SharedAccessPolicyKey = TestHelper.IoTHubSharedAccessPolicyKey,
                    Endpoint = "messages/events",
                    ConsumerGroupName = "sdkconsumergroup"
                };
                Input input = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new AvroSerialization(),
                        Datasource = iotHub
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT input
                var putResponse = await streamAnalyticsManagementClient.Inputs.CreateOrReplaceWithHttpMessagesAsync(input, resourceGroupName, jobName, inputName);
                iotHub.SharedAccessPolicyKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateInput(input, putResponse.Body, false);
                Assert.Equal(expectedInputResourceId, putResponse.Body.Id);
                Assert.Equal(inputName, putResponse.Body.Name);
                Assert.Equal(expectedInputType, putResponse.Body.Type);

                // Verify GET request returns expected input
                var getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Input
                var testResult = streamAnalyticsManagementClient.Inputs.Test(resourceGroupName, jobName, inputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH input
                var inputPatch = new Input()
                {
                    Properties = new StreamInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            FieldDelimiter = "|",
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new IoTHubStreamInputDataSource()
                        {
                            Endpoint = "messages/operationsMonitoringEvents"
                        }
                    }
                };
                putResponse.Body.Properties.Serialization = inputPatch.Properties.Serialization;
                ((IoTHubStreamInputDataSource)((StreamInputProperties)putResponse.Body.Properties).Datasource).Endpoint = ((IoTHubStreamInputDataSource)((StreamInputProperties)inputPatch.Properties).Datasource).Endpoint;
                var patchResponse = await streamAnalyticsManagementClient.Inputs.UpdateWithHttpMessagesAsync(inputPatch, resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET input to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List input and verify that the input shows up in the list
                var listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateInput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with input expanded and verify that the input shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Single(getJobResponse.Inputs);
                ValidationHelper.ValidateInput(putResponse.Body, getJobResponse.Inputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Inputs.Single().Properties.Etag);

                // Delete input
                streamAnalyticsManagementClient.Inputs.Delete(resourceGroupName, jobName, inputName);

                // Verify that list operation returns an empty list after deleting the input
                listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with input expanded and verify that there are no inputs after deleting the input
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Empty(getJobResponse.Inputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task InputOperationsTest_Reference_Blob()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string inputName = TestUtilities.GenerateName("input");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedInputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.InputsResourceType);
                string expectedInputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.InputsResourceType, inputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                StorageAccount storageAccount = new StorageAccount()
                {
                    AccountName = TestHelper.AccountName,
                    AccountKey = TestHelper.AccountKey
                };
                Input input = new Input()
                {
                    Properties = new ReferenceInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            FieldDelimiter = ",",
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new BlobReferenceInputDataSource()
                        {
                            StorageAccounts = new[] { storageAccount },
                            Container = TestHelper.Container,
                            PathPattern = "{date}/{time}",
                            DateFormat = "yyyy/MM/dd",
                            TimeFormat = "HH"
                        }
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT input
                var putResponse = await streamAnalyticsManagementClient.Inputs.CreateOrReplaceWithHttpMessagesAsync(input, resourceGroupName, jobName, inputName);
                storageAccount.AccountKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateInput(input, putResponse.Body, false);
                Assert.Equal(expectedInputResourceId, putResponse.Body.Id);
                Assert.Equal(inputName, putResponse.Body.Name);
                Assert.Equal(expectedInputType, putResponse.Body.Type);

                // Verify GET request returns expected input
                var getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Input
                var testResult = streamAnalyticsManagementClient.Inputs.Test(resourceGroupName, jobName, inputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH input
                var inputPatch = new Input()
                {
                    Properties = new ReferenceInputProperties()
                    {
                        Serialization = new CsvSerialization()
                        {
                            FieldDelimiter = "|",
                            Encoding = Encoding.UTF8
                        },
                        Datasource = new BlobReferenceInputDataSource()
                        {
                            Container = "differentContainer"
                        }
                    }
                };
                ((CsvSerialization)putResponse.Body.Properties.Serialization).FieldDelimiter = ((CsvSerialization)inputPatch.Properties.Serialization).FieldDelimiter;
                ((BlobReferenceInputDataSource)((ReferenceInputProperties)putResponse.Body.Properties).Datasource).Container = ((BlobReferenceInputDataSource)((ReferenceInputProperties)inputPatch.Properties).Datasource).Container;
                var patchResponse = await streamAnalyticsManagementClient.Inputs.UpdateWithHttpMessagesAsync(inputPatch, resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET input to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Inputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, inputName);
                ValidationHelper.ValidateInput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List input and verify that the input shows up in the list
                var listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateInput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Properties.Etag);

                // Get job with input expanded and verify that the input shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Single(getJobResponse.Inputs);
                ValidationHelper.ValidateInput(putResponse.Body, getJobResponse.Inputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Inputs.Single().Properties.Etag);

                // Delete input
                streamAnalyticsManagementClient.Inputs.Delete(resourceGroupName, jobName, inputName);

                // Verify that list operation returns an empty list after deleting the input
                listResult = streamAnalyticsManagementClient.Inputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with input expanded and verify that there are no inputs after deleting the input
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "inputs");
                Assert.Empty(getJobResponse.Inputs);
            }
        }
    }
}
