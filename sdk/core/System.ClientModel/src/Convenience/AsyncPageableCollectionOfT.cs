// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments

// TODO: should notnull constraint go on base result collection?
public abstract class AsyncPageableCollection<T> : AsyncResultCollection<T> where T : notnull
{
    protected internal AsyncPageableCollection() : base()
    {
    }

    // Note: we don't have a constructor that takes response because
    // pageables delay the first request so they don't need to be disposed.

    public abstract IAsyncEnumerable<ResultPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default);

    public override async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        await foreach (ResultPage<T> page in AsPages().ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page)
            {
                yield return value;
            }
        }
    }
}
#pragma warning restore CS1591 // public XML comments
