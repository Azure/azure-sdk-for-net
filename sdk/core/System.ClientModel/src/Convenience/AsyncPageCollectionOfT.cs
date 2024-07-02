// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        if (enumerator.Current == null)
        {
            await enumerator.MoveNextAsync().ConfigureAwait(false);
        }

        return enumerator.Current!;
    }

    public async IAsyncEnumerable<T> GetAllValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        IAsyncEnumerator<PageResult<T>> enumerator = GetAsyncEnumeratorCore(cancellationToken);

        do
        {
            if (enumerator.Current is not null)
            {
                foreach (T value in enumerator.Current.Values)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    yield return value;
                }
            }
        }
        while (await enumerator.MoveNextAsync().ConfigureAwait(false));
    }

    protected abstract IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default);

    IAsyncEnumerator<PageResult<T>> IAsyncEnumerable<PageResult<T>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => GetAsyncEnumeratorCore(cancellationToken);
}

#pragma warning restore CS1591
