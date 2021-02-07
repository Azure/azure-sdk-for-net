// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Index = Microsoft.Azure.Search.Models.Index;

    public sealed class IndexerTests : SearchTestBase<IndexerFixture>
    {
        [Fact]
        public void CreateIndexerReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                Indexer expectedIndexer = Data.CreateTestIndexer();
                expectedIndexer.IsDisabled = true;
                expectedIndexer.Parameters =
                    new IndexingParameters()
                    {
                        BatchSize = 50,
                        MaxFailedItems = 10,
                        MaxFailedItemsPerBatch = 10
                    };

                Indexer actualIndexer = searchClient.Indexers.Create(expectedIndexer);

                expectedIndexer.Parameters.Configuration = new Dictionary<string, object>();    // Get returns empty dictionary.
                ExpectSameStartTime(expectedIndexer, actualIndexer);

                AssertIndexersEqual(expectedIndexer, actualIndexer);
            });
        }

        [Fact]
        public void CreateIndexerFailsWithUsefulMessageOnUserError()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();
                indexer.DataSourceName = "thisdatasourcedoesnotexist";

                SearchAssert.ThrowsCloudException(
                    () => searchClient.Indexers.Create(indexer),
                    HttpStatusCode.BadRequest,
                    "This indexer refers to a data source 'thisdatasourcedoesnotexist' that doesn't exist");
            });
        }

        [Fact]
        public void GetIndexerThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                SearchAssert.ThrowsCloudException(() => searchClient.Indexers.Get("thisindexerdoesnotexist"), HttpStatusCode.NotFound);
            });
        }

        [Fact]
        public void CanUpdateIndexer()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer initial = Data.CreateTestIndexer();
                searchClient.Indexers.Create(initial);

                Indexer updatedExpected = Data.CreateTestIndexer();
                updatedExpected.Name = initial.Name;
                updatedExpected.Description = "somethingdifferent";

                Indexer updateResponse = searchClient.Indexers.CreateOrUpdate(updatedExpected);
                ExpectSameStartTime(updatedExpected, updateResponse);

                AssertIndexersEqual(updatedExpected, updateResponse);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenIndexerDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                AzureOperationResponse<Indexer> response =
                    searchClient.Indexers.CreateOrUpdateWithHttpMessagesAsync(indexer).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenIndexerWithSkillsetDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Skillset skillset = SkillsetsTests.CreateTestSkillsetOcrEntity(null, null);

                AzureOperationResponse<Skillset> response =
                        searchClient.Skillsets.CreateOrUpdateWithHttpMessagesAsync(skillset.Name, skillset).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);

                Indexer indexer = Data.CreateTestIndexerWithSkillset(skillset.Name, new[]
                {
                    new FieldMapping(sourceFieldName: "/document/myEntities", targetFieldName: "myEntities"),
                    new FieldMapping(sourceFieldName: "/document/myText", targetFieldName: "myText")
                });

                AzureOperationResponse<Indexer> response1 =
                    searchClient.Indexers.CreateOrUpdateWithHttpMessagesAsync(indexer).Result;
                Assert.Equal(HttpStatusCode.Created, response1.Response.StatusCode);
            });
        }

        [Fact]
        public void CreateOrUpdateIndexerIfNotExistsFailsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsFailsOnExistingResource(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer,
                    Data.MutateIndexer);
            });
        }

        [Fact]
        public void CreateOrUpdateIndexerIfNotExistsSucceedsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsSucceedsOnNoResource(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer);
            });
        }

        [Fact]
        public void UpdateIndexerIfExistsSucceedsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsSucceedsOnExistingResource(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer,
                    Data.MutateIndexer);
            });
        }

        [Fact]
        public void UpdateIndexerIfExistsFailsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsFailsOnNoResource(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer);
            });
        }

        [Fact]
        public void UpdateIndexerIfNotChangedSucceedsWhenResourceUnchanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedSucceedsWhenResourceUnchanged(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer,
                    Data.MutateIndexer);
            });
        }

        [Fact]
        public void UpdateIndexerIfNotChangedFailsWhenResourceChanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedFailsWhenResourceChanged(
                    Data.GetSearchServiceClient().Indexers.CreateOrUpdate,
                    Data.CreateTestIndexer,
                    Data.MutateIndexer);
            });
        }

        [Fact]
        public void DeleteIndexerIfNotChangedWorksOnlyOnCurrentResource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                AccessConditionTests.DeleteIfNotChangedWorksOnlyOnCurrentResource(
                    searchClient.Indexers.Delete,
                    () => searchClient.Indexers.CreateOrUpdate(indexer),
                    x => searchClient.Indexers.CreateOrUpdate(Data.MutateIndexer(x)),
                    indexer.Name);
            });
        }

        [Fact]
        public void DeleteIndexerIfExistsWorksOnlyWhenResourceExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                AccessConditionTests.DeleteIfExistsWorksOnlyWhenResourceExists(
                    searchClient.Indexers.Delete,
                    () => searchClient.Indexers.CreateOrUpdate(indexer),
                    indexer.Name);
            });
        }

        [Fact]
        public void DeleteIndexerIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                // Try delete before the indexer even exists.
                AzureOperationResponse deleteResponse =
                    searchClient.Indexers.DeleteWithHttpMessagesAsync(indexer.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);

                searchClient.Indexers.Create(indexer);

                // Now delete twice.
                deleteResponse = searchClient.Indexers.DeleteWithHttpMessagesAsync(indexer.Name).Result;
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                deleteResponse = searchClient.Indexers.DeleteWithHttpMessagesAsync(indexer.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);
            });
        }

        [Fact]
        public void CanCreateAndListIndexers()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer1 = Data.CreateTestIndexer();
                Indexer indexer2 = Data.CreateTestIndexer();

                searchClient.Indexers.Create(indexer1);
                searchClient.Indexers.Create(indexer2);

                IndexerListResult listResponse = searchClient.Indexers.List();
                Assert.Equal(2, listResponse.Indexers.Count);

                IEnumerable<string> indexerNames = listResponse.Indexers.Select(i => i.Name);
                Assert.Contains(indexer1.Name, indexerNames);
                Assert.Contains(indexer2.Name, indexerNames);
            });
        }

        [Fact]
        public void CanRunIndexerAndGetIndexerStatus()
        {
            Run(() =>
            {
                // Set handler that injects mock_status query string, which results in service
                // returning a well-known mock response
                SearchServiceClient searchClient = Data.GetSearchServiceClient(new MockStatusDelegatingHandler());

                Indexer indexer = Data.CreateTestIndexer();

                searchClient.Indexers.Create(indexer);

                IndexerExecutionInfo info = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(IndexerStatus.Running, info.Status);

                AzureOperationResponse runResponse =
                    searchClient.Indexers.RunWithHttpMessagesAsync(indexer.Name).Result;
                Assert.Equal(HttpStatusCode.Accepted, runResponse.Response.StatusCode);

                info = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(IndexerStatus.Running, info.Status);

                Assert.Equal(IndexerExecutionStatus.InProgress, info.LastResult.Status);
                Assert.Equal(3, info.ExecutionHistory.Count);

                Assert.NotNull(info.Limits);
                Assert.Equal(100000, info.Limits.MaxDocumentContentCharactersToExtract);
                Assert.Equal(1000, info.Limits.MaxDocumentExtractionSize);
                Assert.Equal(TimeSpan.FromDays(1), info.Limits.MaxRunTime);

                IndexerExecutionResult newestResult = info.ExecutionHistory[0];
                IndexerExecutionResult middleResult = info.ExecutionHistory[1];
                IndexerExecutionResult oldestResult = info.ExecutionHistory[2];

                Assert.Equal(IndexerExecutionStatus.TransientFailure, newestResult.Status);
                Assert.Equal("The indexer could not connect to the data source", newestResult.ErrorMessage);
                AssertStartAndEndTimeValid(newestResult);

                Assert.Equal(IndexerExecutionStatus.Reset, middleResult.Status);
                AssertStartAndEndTimeValid(middleResult);

                Assert.Equal(IndexerExecutionStatus.Success, oldestResult.Status);
                Assert.Equal(124876, oldestResult.ItemCount);
                Assert.Equal(2, oldestResult.FailedItemCount);
                Assert.Equal("100", oldestResult.InitialTrackingState);
                Assert.Equal("200", oldestResult.FinalTrackingState);
                AssertStartAndEndTimeValid(oldestResult);

                Assert.Equal(2, oldestResult.Errors.Count);

                Assert.Equal("1", oldestResult.Errors[0].Key);
                Assert.Equal("Key field contains unsafe characters", oldestResult.Errors[0].ErrorMessage);
                Assert.Equal("DocumentExtraction.AzureBlob.MyDataSource", oldestResult.Errors[0].Name);
                Assert.Equal("The file could not be parsed.", oldestResult.Errors[0].Details);
                Assert.Equal("https://go.microsoft.com/fwlink/?linkid=2049388", oldestResult.Errors[0].DocumentationLink);

                Assert.Equal("121713", oldestResult.Errors[1].Key);
                Assert.Equal("Item is too large", oldestResult.Errors[1].ErrorMessage);
                Assert.Equal("DocumentExtraction.AzureBlob.DataReader", oldestResult.Errors[1].Name);
                Assert.Equal("Blob size cannot exceed 256 MB.", oldestResult.Errors[1].Details);
                Assert.Equal("https://go.microsoft.com/fwlink/?linkid=2049388", oldestResult.Errors[1].DocumentationLink);

                Assert.Equal(1, oldestResult.Warnings.Count);
                Assert.Equal("2", oldestResult.Warnings[0].Key);
                Assert.Equal("Document was truncated to 50000 characters.", oldestResult.Warnings[0].Message);
                Assert.Equal("Enrichment.LanguageDetectionSkill.#4", oldestResult.Warnings[0].Name);
                Assert.Equal("Try to split the input into smaller chunks using Split skill.", oldestResult.Warnings[0].Details);
                Assert.Equal("https://go.microsoft.com/fwlink/?linkid=2099692", oldestResult.Warnings[0].DocumentationLink);
            });
        }

        [Fact]
        public void CanResetIndexerAndGetIndexerStatus()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                searchClient.Indexers.Create(indexer);
                searchClient.Indexers.Reset(indexer.Name);

                IndexerExecutionInfo info = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(IndexerStatus.Running, info.Status);
                Assert.Equal(IndexerExecutionStatus.Reset, info.LastResult.Status);
            });
        }

        [Fact]
        public void ExistsReturnsTrueForExistingIndexer()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Indexer indexer = Data.CreateTestIndexer();
                client.Indexers.Create(indexer);

                Assert.True(client.Indexers.Exists(indexer.Name));
            });
        }

        [Fact]
        public void ExistsReturnsFalseForNonExistingIndexer()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Assert.False(client.Indexers.Exists("invalidindexer"));
            });
        }

        [Fact]
        public void CanCreateBlobIndexerWithConfigurationParameters()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                Indexer expectedIndexer = Data.CreateTestIndexer();
                DataSource blobDataSource =
                    DataSource.AzureBlobStorage(
                        SearchTestUtilities.GenerateName(),
                        storageConnectionString: "fake",
                        containerName: "fake");

                expectedIndexer.DataSourceName = blobDataSource.Name;
                expectedIndexer.IsDisabled = true;
                expectedIndexer.Parameters = new IndexingParameters();
                expectedIndexer.Parameters
                    .ExcludeFileNameExtensions(".pdf")
                    .IndexFileNameExtensions(".docx")
                    .SetBlobExtractionMode(BlobExtractionMode.StorageMetadata);

                Indexer actualIndexer = searchClient.Indexers.Create(expectedIndexer);
                ExpectSameStartTime(expectedIndexer, actualIndexer);

                AssertIndexersEqual(expectedIndexer, actualIndexer);
            });
        }

        [Fact]
        public void CanRoundtripIndexerWithFieldMappingFunctions() =>
            Run(() =>
            {
                Indexer expectedIndexer = new Indexer(SearchTestUtilities.GenerateName(), Data.DataSourceName, Data.TargetIndexName)
                {
                    FieldMappings = new[]
                    {
                        // Try all the field mapping functions and parameters (even if they don't make sense in the context of the test DB).
                        new FieldMapping("feature_id", "a", FieldMappingFunction.Base64Encode()),
                        new FieldMapping("feature_id", "b", FieldMappingFunction.Base64Encode(useHttpServerUtilityUrlTokenEncode: true)),
                        new FieldMapping("feature_id", "c", FieldMappingFunction.ExtractTokenAtPosition(delimiter: " ", position: 0)),
                        new FieldMapping("feature_id", "d", FieldMappingFunction.Base64Decode()),
                        new FieldMapping("feature_id", "e", FieldMappingFunction.Base64Decode(useHttpServerUtilityUrlTokenDecode: false)),
                        new FieldMapping("feature_id", "f", FieldMappingFunction.JsonArrayToStringCollection()),
                        new FieldMapping("feature_id", "g", FieldMappingFunction.UrlEncode()),
                        new FieldMapping("feature_id", "h", FieldMappingFunction.UrlDecode()),
                    }
                };

                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                // We need to add desired fields to the index before those fields can be referenced by the field mappings
                Index index = searchClient.Indexes.Get(Data.TargetIndexName);
                string[] fieldNames = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
                index.Fields = index.Fields.Concat(fieldNames.Select(name => new Field(name, DataType.String))).ToList();
                searchClient.Indexes.CreateOrUpdate(index);

                searchClient.Indexers.Create(expectedIndexer);

                Indexer actualIndexer = searchClient.Indexers.Get(expectedIndexer.Name);
                AssertIndexersEqual(expectedIndexer, actualIndexer);
            });

        private static void AssertStartAndEndTimeValid(IndexerExecutionResult result)
        {
            Assert.True(result.StartTime.HasValue);
            Assert.NotEqual(new DateTimeOffset(), result.StartTime.Value);
            Assert.True(result.EndTime.HasValue);
            Assert.NotEqual(new DateTimeOffset(), result.EndTime.Value);
        }

        private static void AssertIndexersEqual(Indexer expected, Indexer actual)
        {
            Assert.Equal(expected, actual, new DataPlaneModelComparer<Indexer>());
        }

        private static void ExpectSameStartTime(Indexer expected, Indexer actual)
        {
            // There ought to be a start time in the response; We just can't know what it is because it would
            // make the test timing-dependent.
            expected.Schedule.StartTime = actual.Schedule.StartTime;
        }

        private class MockStatusDelegatingHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                string uriWithMockStatusQuery = request.RequestUri.AbsoluteUri + "&mock_status=inProgress";
                request.RequestUri = new Uri(uriWithMockStatusQuery);
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
