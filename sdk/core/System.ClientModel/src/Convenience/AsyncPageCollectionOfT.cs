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
        IAsyncEnumerator<PageResult<T>> enumerator = GetAsyncEnumerator();
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

    public abstract IAsyncEnumerator<PageResult<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default);
}

#pragma warning restore CS1591
