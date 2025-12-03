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
