// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
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
    protected AsyncPageCollection(RequestOptions? options /* = default*/) : base()
    {
        RequestOptions = options;
    }

    // Note that this is abstract rather than providing the field in the base
    // type because it means the implementation can hold the field as a subtype
    // instance in the implementation and not have to cast it.
    public abstract ClientToken FirstPageToken { get; }

    protected RequestOptions? RequestOptions { get; }

    public abstract Task<PageResult<T>> GetPageAsync(ClientToken pageToken, RequestOptions? options = default);

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
        // TODO: join cancellation tokens

        RequestOptions? options = cancellationToken == default ?
            default :
            new RequestOptions() { CancellationToken = cancellationToken };

        PageResult<T> page = await GetPageAsync(FirstPageToken, options).ConfigureAwait(false);
        yield return page;

        while (page.NextPageToken != null)
        {
            page = await GetPageAsync(page.NextPageToken, options).ConfigureAwait(false);
            yield return page;
        }
    }
}

#pragma warning restore CS1591
