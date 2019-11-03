// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    internal class ResultBatch<T>
    {
        internal ResultBatch(T[] values, string link)
        {
            Values = values;
            NextBatchLink = link;
        }

        public string NextBatchLink { get; }

        public T[] Values { get; }
    }
}
