// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.WorkloadManager
{
    // Remove after https://github.com/Azure/azure-sdk-for-net/issues/63508 is fixed in the pinned generator.
    [CodeGenType("AsyncPageableWrapper")]
    [CodeGenSuppress("AsPages", typeof(string), typeof(int?))]
    internal partial class AsyncPageableWrapper<T, U>
    {
        public override IAsyncEnumerable<Page<U>> AsPages(string continuationToken, int? pageSizeHint)
            => GetPagesAsync(continuationToken, pageSizeHint);

        private async IAsyncEnumerable<Page<U>> GetPagesAsync(
            string continuationToken,
            int? pageSizeHint,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (Page<T> page in _source.AsPages(continuationToken, pageSizeHint).WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                List<U> convertedItems = new List<U>();
                foreach (T item in page.Values)
                    convertedItems.Add(_converter(item));
                yield return Page<U>.FromValues(convertedItems, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
