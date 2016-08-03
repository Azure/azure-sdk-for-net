// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Xunit;

    public class IndexBatchExceptionTests
    {
        private const string KeyFieldName = "key";

        private DocumentIndexResult _results = new DocumentIndexResult(new List<IndexingResult>());

        [Fact]
        public void ClientShouldNotRetrySuccessfulBatch()
        {
            _results.Results.Add(SucceededResult("1"));
            _results.Results.Add(CreatedResult("2"));

            AssertRetryBatchEmpty();
        }

        [Fact]
        public void ClientShouldNotRetryBatchWithAllNonRetriableFailures()
        {
            _results.Results.Add(FailedResult("1", 500));
            _results.Results.Add(FailedResult("2", 404));
            _results.Results.Add(FailedResult("3", 400));

            AssertRetryBatchEmpty();
        }

        [Fact]
        public void ClientShouldNotRetryBatchWithSuccessesAndNonRetriableFailures()
        {
            _results.Results.Add(SucceededResult("1"));
            _results.Results.Add(FailedResult("2", 500));
            _results.Results.Add(FailedResult("3", 404));
            _results.Results.Add(CreatedResult("4"));
            _results.Results.Add(FailedResult("5", 400));

            AssertRetryBatchEmpty();
        }

        [Fact]
        public void ClientShouldRetryBatchWithAllRetriableFailures()
        {
            _results.Results.Add(FailedResult("1", 422));
            _results.Results.Add(FailedResult("2", 409));
            _results.Results.Add(FailedResult("3", 503));

            AssertRetryBatchContains("1", "2", "3");
        }

        [Fact]
        public void ClientShouldRetryBatchWithSomeRetriableFailures()
        {
            _results.Results.Add(SucceededResult("1"));
            _results.Results.Add(FailedResult("2", 500));
            _results.Results.Add(FailedResult("3", 422));
            _results.Results.Add(FailedResult("4", 404));
            _results.Results.Add(FailedResult("5", 409));
            _results.Results.Add(FailedResult("6", 400));
            _results.Results.Add(CreatedResult("7"));
            _results.Results.Add(FailedResult("8", 503));

            AssertRetryBatchContains("3", "5", "8");
        }

        [Fact]
        public void ClientShouldNotRetryResultWithUnexpectedStatusCode()
        {
            _results.Results.Add(SucceededResult("1"));
            _results.Results.Add(FailedResult("2", 502));
            _results.Results.Add(FailedResult("3", 503));

            AssertRetryBatchContains("3");
        }

        private static IndexingResult SucceededResult(string key)
        {
            return new IndexingResult(key, errorMessage: null, succeeded: true, statusCode: 200);
        }

        private static IndexingResult CreatedResult(string key)
        {
            return new IndexingResult(key, errorMessage: null, succeeded: true, statusCode: 201);
        }

        private static IndexingResult FailedResult(string key, int statusCode)
        {
            return new IndexingResult(
                key, 
                errorMessage: "Something went wrong", 
                succeeded: false, 
                statusCode: statusCode);
        }

        private void AssertRetryBatchContains(params string[] expectedKeys)
        {
            Assert.Equal(
                expectedKeys, 
                GetRetryBatch().Actions.Select(a => a.Document[KeyFieldName]).Cast<string>());

            Assert.Equal(expectedKeys, GetTypedRetryBatch().Actions.Select(a => a.Document.HotelId));
        }

        private void AssertRetryBatchEmpty()
        {
            Assert.Empty(GetRetryBatch().Actions);
            Assert.Empty(GetTypedRetryBatch().Actions);
        }

        private IndexBatch GetRetryBatch()
        {
            IEnumerable<string> allKeys = _results.Results.Select(r => r.Key);

            var exception = new IndexBatchException(_results);
            IndexBatch originalBatch = IndexBatch.Upload(allKeys.Select(k => new Document() { { KeyFieldName, k } }));
            return exception.FindFailedActionsToRetry(originalBatch, KeyFieldName);
        }

        private IndexBatch<Hotel> GetTypedRetryBatch()
        {
            IEnumerable<string> allKeys = _results.Results.Select(r => r.Key);

            var exception = new IndexBatchException(_results);
            IndexBatch<Hotel> originalBatch = IndexBatch.Upload(allKeys.Select(k => new Hotel() { HotelId = k }));
            return exception.FindFailedActionsToRetry(originalBatch, h => h.HotelId);
        }
    }
}
