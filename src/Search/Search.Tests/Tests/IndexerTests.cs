// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class IndexerTests : SearchTestBase<IndexerFixture>
    {
        [Fact]
        public void CreateIndexerReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(indexer);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                AssertIndexersEqual(indexer, createResponse.Indexer);
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
                Assert.Equal("This indexer refers to a data source 'thisdatasourcedoesnotexist' that doesn't exist", e.Error.Message);
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

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(initial);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                Indexer updated = Data.CreateTestIndexer();
                updated.Name = initial.Name;
                updated.Description = "somethingdifferent";

                IndexerDefinitionResponse updateResponse = searchClient.Indexers.CreateOrUpdate(updated);
                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

                AssertIndexersEqual(updated, updateResponse.Indexer);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenIndexerDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                IndexerDefinitionResponse response = searchClient.Indexers.CreateOrUpdate(indexer);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
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
                AzureOperationResponse deleteResponse = searchClient.Indexers.Delete(indexer.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(indexer);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Now delete twice.
                deleteResponse = searchClient.Indexers.Delete(indexer.Name);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                deleteResponse = searchClient.Indexers.Delete(indexer.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
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

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(indexer1);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                createResponse = searchClient.Indexers.Create(indexer2);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                IndexerListResponse listResponse = searchClient.Indexers.List();
                Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
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
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                Indexer indexer = Data.CreateTestIndexer();

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(indexer);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                IndexerGetStatusResponse statusResponse = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(HttpStatusCode.OK, statusResponse.StatusCode);

                IndexerExecutionInfo info = statusResponse.ExecutionInfo;
                Assert.Equal(IndexerStatus.Running, info.Status);

                AzureOperationResponse runResponse = searchClient.Indexers.Run(indexer.Name);
                Assert.Equal(HttpStatusCode.Accepted, runResponse.StatusCode);

                // Set handler that injects mock_status query string, which results in service 
                // returning a well-known mock response
                searchClient.AddHandlerToPipeline(new MockStatusDelegatingHandler());

                statusResponse = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(HttpStatusCode.OK, statusResponse.StatusCode);

                info = statusResponse.ExecutionInfo;
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

                IndexerDefinitionResponse createResponse = searchClient.Indexers.Create(indexer);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                AzureOperationResponse resetResponse = searchClient.Indexers.Reset(indexer.Name);
                Assert.Equal(HttpStatusCode.NoContent, resetResponse.StatusCode);

                IndexerGetStatusResponse statusResponse = searchClient.Indexers.GetStatus(indexer.Name);
                Assert.Equal(HttpStatusCode.OK, statusResponse.StatusCode);

                IndexerExecutionInfo info = statusResponse.ExecutionInfo;
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
                Assert.Equal(expected.StartTime, actual.StartTime);
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
