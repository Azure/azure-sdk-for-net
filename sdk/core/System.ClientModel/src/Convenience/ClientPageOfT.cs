// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591

/// <summary>
/// Represents the subset (or page) of values contained in a single response
/// from a cloud service returning a collection of values sequentially over
/// one or more calls to the service (i.e. a paged collection).
/// </summary>
public abstract class ClientPage<T> : ClientResult
{
    protected ClientPage(IReadOnlyList<T> values, bool hasNext, PipelineResponse response)
        : base(response)
    {
        Values = values;
        HasNext = hasNext;
    }

    /// <summary>
    /// Gets the values in this <see cref="ClientPage{T}"/>.
    /// </summary>
    public IReadOnlyList<T> Values { get; }

    public bool HasNext { get; }

    protected abstract ClientPage<T> GetNext(RequestOptions? options = default);

    protected abstract Task<ClientPage<T>> GetNextAsync(RequestOptions? options = default);

    public IEnumerable<T> ToItemCollection()
    {
        foreach (ClientPage<T> page in ToPageCollection())
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }

    public async IAsyncEnumerable<T> ToItemCollectionAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (ClientPage<T> page in ToPageCollectionAsync(cancellationToken).ConfigureAwait(false))
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }

    public IEnumerable<ClientPage<T>> ToPageCollection()
    {
        ClientPage<T> page = this;
        while (page.HasNext)
        {
            page = GetNext();
            yield return page;
        }
    }

    public async IAsyncEnumerable<ClientPage<T>> ToPageCollectionAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ClientPage<T> page = this;
        while (page.HasNext)
        {
            page = await GetNextAsync().ConfigureAwait(false);
            yield return page;
        }
    }
}
#pragma warning restore CS1591
