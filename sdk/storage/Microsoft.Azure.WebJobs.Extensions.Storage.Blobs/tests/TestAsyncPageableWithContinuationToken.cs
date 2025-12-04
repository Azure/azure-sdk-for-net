// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Blobs.Models;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    /// <summary>
    /// This is based on the TestAsyncPageable in Common tests. It adds the ability to specify whether a continuation token is returned.
    /// This will allow the strategy to determine whether there are more pages and continue listing.
    /// It will NOT use the passed in continuation token to determine what to return; it always returns the page.
    /// </summary>
    public class TestAsyncPageableWithContinuationToken : AsyncPageable<BlobItem>
    {
        private readonly List<BlobItem> _page;
        private readonly bool _returnsContinuationToken;

        public TestAsyncPageableWithContinuationToken(List<BlobItem> page, bool returnsContinuationToken)
        {
            _page = page;
            _returnsContinuationToken = returnsContinuationToken;
        }

        public override async IAsyncEnumerable<Page<BlobItem>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            string mockContinuationToken = System.Guid.NewGuid().ToString();
            yield return Page<BlobItem>.FromValues(
                _page.AsReadOnly(),
                _returnsContinuationToken ? mockContinuationToken : null,
                Mock.Of<Response>());
            // Simulate async page boundary
            await Task.Yield();
        }
    }
}
