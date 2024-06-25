// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591

public abstract class AsyncPageCollection<T> : IAsyncEnumerable<ClientPage<T>>
{
    protected AsyncPageCollection() : base()
    {
    }

    // I like this being abstract rather than providing the field in the base
    // type because it means the implementation can hold the field as a subtype
    // instance in the implementation and not have to cast it.
    public abstract BinaryData FirstPageToken { get; }

    public abstract Task<ClientPage<T>> GetPageAsync(BinaryData pageToken, RequestOptions? options = default);

    public async IAsyncEnumerable<T> GetAllValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (ClientPage<T> page in this.ConfigureAwait(false).WithCancellation(cancellationToken))
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
            new RequestOptions() { CancellationToken = cancellationToken };

        ClientPage<T> page = await GetPageAsync(FirstPageToken, options).ConfigureAwait(false);
        yield return page;

        while (page.NextPageToken != null)
        {
            page = await GetPageAsync(page.NextPageToken, options).ConfigureAwait(false);
            yield return page;
        }
    }
}

#pragma warning restore CS1591
