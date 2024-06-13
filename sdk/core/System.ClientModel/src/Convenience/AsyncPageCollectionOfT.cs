// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

    // TODO: take RequestOptions instead?
    public abstract Task<ClientPage<T>> GetPageAsync(PageToken pageToken, CancellationToken cancellationToken = default);

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
        ClientPage<T> page = await GetPageAsync(FirstPageToken, cancellationToken).ConfigureAwait(false);
        SetRawResponse(page.GetRawResponse());
        yield return page;

        while (page.NextPageToken != null)
        {
            page = await GetPageAsync(page.NextPageToken, cancellationToken).ConfigureAwait(false);
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
