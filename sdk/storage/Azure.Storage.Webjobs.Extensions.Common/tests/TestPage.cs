// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class TestPage<T> : Page<T>
    {
        private IEnumerable<T> enumerable;
        private string continuationToken;

        public TestPage(IEnumerable<T> enumerable, string continuationToken = null)
        {
            this.enumerable = enumerable;
            this.continuationToken = continuationToken;
        }

        public override IReadOnlyList<T> Values => this.enumerable.ToList();

        public override string ContinuationToken => continuationToken;

        public override Response GetRawResponse()
        {
            throw new System.NotImplementedException();
        }
    }
}
