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

    public sealed class IndexerTests : SearchTestBase<IndexerFixture>
    {
        [Fact]
        public void CreateIndexerReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                Indexer expectedIndexer = Data.CreateTestIndexer();

                Indexer actualIndexer = searchClient.Indexers.Create(expectedIndexer);

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

                CloudException e = Assert.Throws<CloudException>(() => searchClient.Indexers.Create(indexer));
                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Equal("This indexer refers to a data source 'thisdatasourcedoesnotexist' that doesn't exist", e.Body.Message);
            });
        }

        [Fact]
        public void GetIndexerThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                CloudException e = Assert.Throws<CloudException>(() => searchClient.Indexers.Get("thisindexerdoesnotexist"));
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
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

                Assert.Equal("121713", oldestResult.Errors[1].Key);
                Assert.Equal("Item is too large", oldestResult.Errors[1].ErrorMessage);
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

        private static void AssertStartAndEndTimeValid(IndexerExecutionResult result)
        {
            Assert.True(result.StartTime.HasValue);
            Assert.NotEqual(new DateTimeOffset(), result.StartTime.Value);
            Assert.True(result.EndTime.HasValue);
            Assert.NotEqual(new DateTimeOffset(), result.EndTime.Value);
        }

        private void AssertIndexersEqual(Indexer expected, Indexer actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.DataSourceName, actual.DataSourceName);
            Assert.Equal(expected.TargetIndexName, actual.TargetIndexName);

            AssertSchedulesEqual(expected.Schedule, actual.Schedule);
            AssertParametersEqual(expected.Parameters, actual.Parameters);
        }

        private void AssertParametersEqual(IndexingParameters expected, IndexingParameters actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
            }
            else
            {
                Assert.NotNull(actual);
                Assert.Equal(expected.Base64EncodeKeys, actual.Base64EncodeKeys);
                Assert.Equal(expected.MaxFailedItems, actual.MaxFailedItems);
                Assert.Equal(expected.MaxFailedItemsPerBatch, actual.MaxFailedItemsPerBatch);
            }
        }

        private void AssertSchedulesEqual(IndexingSchedule expected, IndexingSchedule actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
            }
            else
            {
                Assert.NotNull(actual);
                Assert.Equal(expected.Interval, actual.Interval);

                if (expected.StartTime.HasValue)
                {
                    Assert.Equal(expected.StartTime, actual.StartTime);
                }
                else
                {
                    // There ought to be a start time in the response; We just can't know what it is because it would
                    // make the test timing-dependent.
                    Assert.True(actual.StartTime.HasValue);
                }
            }
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
