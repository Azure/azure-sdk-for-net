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

    // Note that this is abstract rather than providing the field in the base
    // type because it means the implementation can hold the field as a subtype
    // instance in the implementation and not have to cast it.
    public abstract ClientToken FirstPageToken { get; }

    public async Task<PageResult<T>> GetPageAsync()
    => await GetPageAsyncCore(FirstPageToken).ConfigureAwait(false);

    public async Task<PageResult<T>> GetPageAsync(ClientToken pageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));
        return await GetPageAsyncCore(FirstPageToken).ConfigureAwait(false);
    }

    // Doesn't take RequestOptions because RequestOptions cannot be rehydrated.
    public abstract Task<PageResult<T>> GetPageAsyncCore(ClientToken pageToken);

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

    async IAsyncEnumerator<PageResult<T>> IAsyncEnumerable<PageResult<T>>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        PageResult<T> page = await GetPageAsync(FirstPageToken).ConfigureAwait(false);
        yield return page;

        while (page.NextPageToken != null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            page = await GetPageAsync(page.NextPageToken).ConfigureAwait(false);
            yield return page;
        }
    }
}

#pragma warning restore CS1591
