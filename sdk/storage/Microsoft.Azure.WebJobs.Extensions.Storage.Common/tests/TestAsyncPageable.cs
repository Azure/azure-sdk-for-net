// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class TestAsyncPageable<T> : AsyncPageable<T>
    {
        private readonly Pageable<T> _enumerable;

        public TestAsyncPageable(Pageable<T> enumerable)
        {
            _enumerable = enumerable;
        }

        public TestAsyncPageable(IEnumerable<T> enumerable)
        {
            _enumerable = new TestPageable<T>(enumerable);
        }

#pragma warning disable 1998
        public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default)
#pragma warning restore 1998
        {
            foreach (Page<T> page in _enumerable.AsPages(continuationToken, pageSizeHint))
            {
                yield return page;
            }
        }
    }
}
