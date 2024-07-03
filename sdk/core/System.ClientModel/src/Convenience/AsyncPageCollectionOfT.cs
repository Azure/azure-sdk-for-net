// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// An asynchronous collection of page results returned by a cloud service.
/// Cloud services use pagination to return a collection of items over multiple
/// responses.  Each response from the service returns a page of items in the
/// collection, as well as the information needed to obtain the next page of
/// items, until all the items in the requested collection have been returned.
/// To enumerate the items in the collection, instead of the pages in the
/// collection, call <see cref="GetAllValuesAsync"/>.  To get the current
/// collection page, call <see cref="GetCurrentPageAsync"/>.
/// </summary>
public abstract class AsyncPageCollection<T> : IAsyncEnumerable<PageResult<T>>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncPageCollection{T}"/>.
    /// </summary>
    protected AsyncPageCollection() : base()
    {
        // Note that page collections delay making a first request until either
        // GetCurrentPageAsync is called or the collection returned by
        // GetAllValuesAsync is enumerated, so this constructor calls the base
        // class constructor that does not take a PipelineResponse.
    }

    /// <summary>
    /// Get the current page of the collection.
    /// </summary>
    /// <returns>The current page in the collection.</returns>
    public async Task<PageResult<T>> GetCurrentPageAsync()
        => await GetCurrentPageAsyncCore().ConfigureAwait(false);

    /// <summary>
    /// Get a collection of all the values in the collection requested from the
    /// cloud service, rather than the pages of values.
    /// </summary>
    /// <returns>The values requested from the cloud service.</returns>
    public async IAsyncEnumerable<T> GetAllValuesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (PageResult<T> page in this.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            foreach (T value in page.Values)
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return value;
            }
        }
    }

    /// <summary>
    /// Get the current page of the collection.
    /// </summary>
    /// <returns>The current page in the collection.</returns>
    protected abstract Task<PageResult<T>> GetCurrentPageAsyncCore();

    /// <summary>
    /// Get an async enumerator that can enumerate the pages of values returned
    /// by the cloud service.
    /// </summary>
    /// <returns>An async enumerator of pages holding the items in the value
    /// collection.</returns>
    protected abstract IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default);

    IAsyncEnumerator<PageResult<T>> IAsyncEnumerable<PageResult<T>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => GetAsyncEnumeratorCore(cancellationToken);
}
