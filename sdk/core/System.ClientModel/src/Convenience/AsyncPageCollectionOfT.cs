// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591

public abstract class AsyncPageCollection<T> : ClientResult,
    IAsyncEnumerable<ClientPage<T>>,
    IAsyncEnumerable<ClientResult>
{
    protected AsyncPageCollection(PageToken firstPageToken) : base()
    {
        FirstPageToken = firstPageToken;
    }

    public PageToken FirstPageToken { get; }

    public abstract Task<ClientPage<T>> GetPageAsync(PageToken pageToken, RequestOptions? options = default);

    public async IAsyncEnumerable<T> GetValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (ClientPage<T> page in ((IAsyncEnumerable<ClientPage<T>>)this).ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }

    async IAsyncEnumerator<ClientPage<T>> IAsyncEnumerable<ClientPage<T>>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        RequestOptions? options = cancellationToken == default ?
            default :
            new RequestOptions() {  CancellationToken = cancellationToken };

        ClientPage<T> page = await GetPageAsync(FirstPageToken, options).ConfigureAwait(false);
        SetRawResponse(page.GetRawResponse());
        yield return page;

        while (page.NextPageToken != null)
        {
            page = await GetPageAsync(page.NextPageToken, options).ConfigureAwait(false);
            SetRawResponse(page.GetRawResponse());
            yield return page;
        }
    }

    // TODO: is this the best way to implement?
    async IAsyncEnumerator<ClientResult> IAsyncEnumerable<ClientResult>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        await foreach (ClientPage<T> page in ((IAsyncEnumerable<ClientPage<T>>)this).ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            yield return page;
        }
    }
}

#pragma warning restore CS1591
