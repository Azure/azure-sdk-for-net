// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591

public abstract class AsyncPageCollection<T> : IAsyncEnumerable<PageResult<T>>
{
    // Note page collections delay making a first request until either
    // GetPage is called or the collection is enumerated, so the constructor
    // calls the base class constructor that does not take a response.
    protected AsyncPageCollection() : base()
    {
    }

    public async Task<PageResult<T>> GetCurrentPageAsync()
    {
        IAsyncEnumerator<PageResult<T>> enumerator = GetAsyncEnumeratorCore();
        PageResult<T> current = enumerator.Current;

        // Relies on generated enumerator contract
        if (current == null)
        {
            await enumerator.MoveNextAsync().ConfigureAwait(false);
            current = enumerator.Current;
        }

        return current;
    }

    public async IAsyncEnumerable<T> GetAllValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (PageResult<T> page in this.ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page.Values)
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return value;
            }
        }
    }

    protected abstract IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default);

    IAsyncEnumerator<PageResult<T>> IAsyncEnumerable<PageResult<T>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => GetAsyncEnumeratorCore(cancellationToken);
}

#pragma warning restore CS1591
