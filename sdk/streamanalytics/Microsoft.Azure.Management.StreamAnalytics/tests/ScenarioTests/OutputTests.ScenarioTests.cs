// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StreamAnalytics.Tests
{
    public class OutputTests : TestBase
    {
        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_Blob()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                StorageAccount storageAcount = new StorageAccount()
                {
                    AccountName = TestHelper.AccountName,
                    AccountKey = TestHelper.AccountKey
                };
                Output output = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = ",",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = new BlobOutputDataSource()
                    {
                        StorageAccounts = new[] { storageAcount },
                        Container = TestHelper.Container,
                        PathPattern = "{date}/{time}",
                        DateFormat = "yyyy/MM/dd",
                        TimeFormat = "HH"
                    }
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                storageAcount.AccountKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = "|",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = new BlobOutputDataSource()
                    {
                        Container = "differentContainer"
                    }
                };
                ((CsvSerialization)putResponse.Body.Serialization).FieldDelimiter = ((CsvSerialization)outputPatch.Serialization).FieldDelimiter;
                ((BlobOutputDataSource)putResponse.Body.Datasource).Container = ((BlobOutputDataSource)outputPatch.Datasource).Container;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_AzureTable()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                AzureTableOutputDataSource azureTable = new AzureTableOutputDataSource()
                {
                    AccountName = TestHelper.AccountName,
                    AccountKey = TestHelper.AccountKey,
                    Table = TestHelper.AzureTableName,
                    PartitionKey = "partitionKey",
                    RowKey = "rowKey",
                    ColumnsToRemove = new[] { "column1", "column2" },
                    BatchSize = 25
                };
                Output output = new Output()
                {
                    Datasource = azureTable
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                azureTable.AccountKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Datasource = new AzureTableOutputDataSource()
                    {
                        PartitionKey = "differentPartitionKey"
                    }
                };
                ((AzureTableOutputDataSource)putResponse.Body.Datasource).PartitionKey = ((AzureTableOutputDataSource)outputPatch.Datasource).PartitionKey;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_EventHub()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                EventHubOutputDataSource eventHub = new EventHubOutputDataSource()
                {
                    ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                    SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                    SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                    EventHubName = TestHelper.EventHubName,
                    PartitionKey = "partitionKey"
                };
                Output output = new Output()
                {
                    Serialization = new JsonSerialization()
                    {
                        Encoding = Encoding.UTF8,
                        Format = JsonOutputSerializationFormat.Array
                    },
                    Datasource = eventHub
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                eventHub.SharedAccessPolicyKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Serialization = new JsonSerialization()
                    {
                        Encoding = Encoding.UTF8,
                        Format = JsonOutputSerializationFormat.LineSeparated
                    },
                    Datasource = new EventHubOutputDataSource()
                    {
                        PartitionKey = "differentPartitionKey"
                    }
                };
                ((JsonSerialization)putResponse.Body.Serialization).Format = ((JsonSerialization)outputPatch.Serialization).Format;
                ((EventHubOutputDataSource)putResponse.Body.Datasource).PartitionKey = ((EventHubOutputDataSource)outputPatch.Datasource).PartitionKey;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_AzureSqlDatabase()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                AzureSqlDatabaseOutputDataSource azureSqlDatabase = new AzureSqlDatabaseOutputDataSource()
                {
                    Server = TestHelper.Server,
                    Database = TestHelper.Database,
                    User = TestHelper.User,
                    Password = TestHelper.Password,
                    Table = TestHelper.SqlTableName
                };
                Output output = new Output()
                {
                    Datasource = azureSqlDatabase
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                azureSqlDatabase.Password = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Datasource = new AzureSqlDatabaseOutputDataSource()
                    {
                        Table = "differentTable"
                    }
                };
                ((AzureSqlDatabaseOutputDataSource)putResponse.Body.Datasource).Table = ((AzureSqlDatabaseOutputDataSource)outputPatch.Datasource).Table;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_DocumentDb()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                DocumentDbOutputDataSource documentDb = new DocumentDbOutputDataSource()
                {
                    AccountId = TestHelper.DocDbAccountId,
                    AccountKey = TestHelper.DocDbAccountKey,
                    Database = TestHelper.DocDbDatabase,
                    PartitionKey = "key",
                    CollectionNamePattern = "collection",
                    DocumentId = "documentId"
                };
                Output output = new Output()
                {
                    Datasource = documentDb
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                documentDb.AccountKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Datasource = new DocumentDbOutputDataSource()
                    {
                        PartitionKey = "differentPartitionKey"
                    }
                };
                ((DocumentDbOutputDataSource)putResponse.Body.Datasource).PartitionKey = ((DocumentDbOutputDataSource)outputPatch.Datasource).PartitionKey;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_ServiceBusQueue()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                ServiceBusQueueOutputDataSource serviceBusQueue = new ServiceBusQueueOutputDataSource()
                {
                    ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                    SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                    SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                    QueueName = TestHelper.QueueName,
                    PropertyColumns = new[] { "column1", "column2" }
                };
                Output output = new Output()
                {
                    Serialization = new AvroSerialization(),
                    Datasource = serviceBusQueue
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                serviceBusQueue.SharedAccessPolicyKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Serialization = new JsonSerialization()
                    {
                        Encoding = Encoding.UTF8,
                        Format = JsonOutputSerializationFormat.LineSeparated
                    },
                    Datasource = new ServiceBusQueueOutputDataSource()
                    {
                        QueueName = "differentQueueName"
                    }
                };
                putResponse.Body.Serialization = outputPatch.Serialization;
                ((ServiceBusQueueOutputDataSource)putResponse.Body.Datasource).QueueName = ((ServiceBusQueueOutputDataSource)outputPatch.Datasource).QueueName;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public async Task OutputOperationsTest_ServiceBusTopic()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                ServiceBusTopicOutputDataSource serviceBusTopic = new ServiceBusTopicOutputDataSource()
                {
                    ServiceBusNamespace = TestHelper.ServiceBusNamespace,
                    SharedAccessPolicyName = TestHelper.SharedAccessPolicyName,
                    SharedAccessPolicyKey = TestHelper.SharedAccessPolicyKey,
                    TopicName = TestHelper.TopicName,
                    PropertyColumns = new[] { "column1", "column2" }
                };
                Output output = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = ",",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = serviceBusTopic
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                serviceBusTopic.SharedAccessPolicyKey = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestSucceeded", testResult.Status);
                Assert.Null(testResult.Error);

                // PATCH output
                var outputPatch = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = "|",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = new ServiceBusTopicOutputDataSource()
                    {
                        TopicName = "differentTopicName"
                    }
                };
                ((CsvSerialization)putResponse.Body.Serialization).FieldDelimiter = ((CsvSerialization)outputPatch.Serialization).FieldDelimiter;
                ((ServiceBusTopicOutputDataSource)putResponse.Body.Datasource).TopicName = ((ServiceBusTopicOutputDataSource)outputPatch.Datasource).TopicName;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact]
        public async Task OutputOperationsTest_PowerBI()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                PowerBIOutputDataSource powerBI = new PowerBIOutputDataSource()
                {
                    RefreshToken = "someRefreshToken==",
                    TokenUserPrincipalName = "bobsmith@contoso.com",
                    TokenUserDisplayName = "Bob Smith",
                    Dataset = "someDataset",
                    Table = "someTable",
                    GroupId = "ac40305e-3e8d-43ac-8161-c33799f43e95",
                    GroupName = "MyPowerBIGroup"
                };
                Output output = new Output()
                {
                    Datasource = powerBI
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                powerBI.RefreshToken = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestFailed", testResult.Status);
                Assert.NotNull(testResult.Error);
                Assert.Contains("either expired or is invalid", testResult.Error.Message);

                // PATCH output
                var outputPatch = new Output()
                {
                    Datasource = new PowerBIOutputDataSource()
                    {
                        Dataset = "differentDataset"
                    }
                };
                ((PowerBIOutputDataSource)putResponse.Body.Datasource).Dataset = ((PowerBIOutputDataSource)outputPatch.Datasource).Dataset;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }

        [Fact]
        public async Task OutputOperationsTest_AzureDataLakeStore()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName("sjrg");
                string jobName = TestUtilities.GenerateName("sj");
                string outputName = TestUtilities.GenerateName("output");

                var resourceManagementClient = this.GetResourceManagementClient(context);
                var streamAnalyticsManagementClient = this.GetStreamAnalyticsManagementClient(context);

                string expectedOutputType = TestHelper.GetFullRestOnlyResourceType(TestHelper.OutputsResourceType);
                string expectedOutputResourceId = TestHelper.GetRestOnlyResourceId(streamAnalyticsManagementClient.SubscriptionId, resourceGroupName, jobName, TestHelper.OutputsResourceType, outputName);

                resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = TestHelper.DefaultLocation });

                AzureDataLakeStoreOutputDataSource azureDataLakeStore = new AzureDataLakeStoreOutputDataSource()
                {
                    RefreshToken = "someRefreshToken==",
                    TokenUserPrincipalName = "bobsmith@contoso.com",
                    TokenUserDisplayName = "Bob Smith",
                    AccountName = "someaccount",
                    TenantId = "cea4e98b-c798-49e7-8c40-4a2b3beb47dd",
                    FilePathPrefix = "{date}/{time}",
                    DateFormat = "yyyy/MM/dd",
                    TimeFormat = "HH"
                };
                Output output = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = ",",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = azureDataLakeStore
                };

                // PUT job
                streamAnalyticsManagementClient.StreamingJobs.CreateOrReplace(TestHelper.GetDefaultStreamingJob(), resourceGroupName, jobName);

                // PUT output
                var putResponse = await streamAnalyticsManagementClient.Outputs.CreateOrReplaceWithHttpMessagesAsync(output, resourceGroupName, jobName, outputName);
                azureDataLakeStore.RefreshToken = null; // Null out because secrets are not returned in responses
                ValidationHelper.ValidateOutput(output, putResponse.Body, false);
                Assert.Equal(expectedOutputResourceId, putResponse.Body.Id);
                Assert.Equal(outputName, putResponse.Body.Name);
                Assert.Equal(expectedOutputType, putResponse.Body.Type);

                // Verify GET request returns expected output
                var getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be the same
                Assert.Equal(putResponse.Headers.ETag, getResponse.Headers.ETag);

                // Test Output
                var testResult = streamAnalyticsManagementClient.Outputs.Test(resourceGroupName, jobName, outputName);
                Assert.Equal("TestFailed", testResult.Status);
                Assert.NotNull(testResult.Error);
                Assert.Contains("either expired or is invalid", testResult.Error.Message);

                // PATCH output
                var outputPatch = new Output()
                {
                    Serialization = new CsvSerialization()
                    {
                        FieldDelimiter = "|",
                        Encoding = Encoding.UTF8
                    },
                    Datasource = new AzureDataLakeStoreOutputDataSource()
                    {
                        AccountName = "differentaccount"
                    }
                };
                ((CsvSerialization)putResponse.Body.Serialization).FieldDelimiter = ((CsvSerialization)outputPatch.Serialization).FieldDelimiter;
                ((AzureDataLakeStoreOutputDataSource)putResponse.Body.Datasource).AccountName = ((AzureDataLakeStoreOutputDataSource)outputPatch.Datasource).AccountName;
                var patchResponse = await streamAnalyticsManagementClient.Outputs.UpdateWithHttpMessagesAsync(outputPatch, resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, patchResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, patchResponse.Headers.ETag);

                // Run another GET output to verify that it returns the newly updated properties as well
                getResponse = await streamAnalyticsManagementClient.Outputs.GetWithHttpMessagesAsync(resourceGroupName, jobName, outputName);
                ValidationHelper.ValidateOutput(putResponse.Body, getResponse.Body, true);
                // ETag should be different after a PATCH operation
                Assert.NotEqual(putResponse.Headers.ETag, getResponse.Headers.ETag);
                Assert.Equal(patchResponse.Headers.ETag, getResponse.Headers.ETag);

                // List output and verify that the output shows up in the list
                var listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Single(listResult);
                ValidationHelper.ValidateOutput(putResponse.Body, listResult.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, listResult.Single().Etag);

                // Get job with output expanded and verify that the output shows up
                var getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Single(getJobResponse.Outputs);
                ValidationHelper.ValidateOutput(putResponse.Body, getJobResponse.Outputs.Single(), true);
                Assert.Equal(getResponse.Headers.ETag, getJobResponse.Outputs.Single().Etag);

                // Delete output
                streamAnalyticsManagementClient.Outputs.Delete(resourceGroupName, jobName, outputName);

                // Verify that list operation returns an empty list after deleting the output
                listResult = streamAnalyticsManagementClient.Outputs.ListByStreamingJob(resourceGroupName, jobName);
                Assert.Empty(listResult);

                // Get job with output expanded and verify that there are no outputs after deleting the output
                getJobResponse = streamAnalyticsManagementClient.StreamingJobs.Get(resourceGroupName, jobName, "outputs");
                Assert.Empty(getJobResponse.Outputs);
            }
        }
    }
}
