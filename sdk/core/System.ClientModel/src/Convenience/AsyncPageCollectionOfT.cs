// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591

public abstract class AsyncPageCollection<TPage, TValue, TPageToken> : ClientResult, IAsyncEnumerable<TPage>
    where TPage : ClientPage<TValue, TPageToken>
    where TPageToken : IPersistableModel<TPageToken>
{
    protected AsyncPageCollection(TPageToken firstPageToken) : base()
    {
        FirstPageToken = firstPageToken;
    }

    public TPageToken FirstPageToken { get; }

    // TODO: take RequestOptions instead?
    public abstract Task<TPage> GetPageAsync(TPageToken pageToken, CancellationToken cancellationToken = default);

    public async IAsyncEnumerable<TValue> GetAllValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (TPage page in this.ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (TValue value in page.Values)
            {
                yield return value;
            }
        }
    }

    public async IAsyncEnumerator<TPage> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        TPage page = await GetPageAsync(FirstPageToken, cancellationToken).ConfigureAwait(false);
        SetRawResponse(page.GetRawResponse());
        yield return page;

        while (page.NextPageToken != null)
        {
            page = await GetPageAsync(page.NextPageToken, cancellationToken).ConfigureAwait(false);
            SetRawResponse(page.GetRawResponse());
            yield return page;
        }
    }
}

#pragma warning restore CS1591
