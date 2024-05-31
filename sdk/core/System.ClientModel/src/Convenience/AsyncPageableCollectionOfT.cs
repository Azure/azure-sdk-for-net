// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation
/// sequentially over one or more calls to the service.
/// </summary>
public abstract class AsyncPageableCollection<T> : AsyncCollectionResult<T>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncPageableCollection{T}"/>.
    /// </summary>
    /// <remarks>This constructor does not take a <see cref="PipelineResponse"/>
    /// because derived types are expected to defer the first service call
    /// until the collection is enumerated using <c>await foreach</c>.
    /// </remarks>
    protected AsyncPageableCollection() : base()
    {
    }

    /// <summary>
    /// Return an enumerable of <see cref="PageResult{T}"/> that aynchronously
    /// enumerates the collection's pages instead of the collection's individual
    /// values. This may make multiple service requests.
    /// </summary>
    /// <param name="pageToken">A token indicating where the collection
    /// of results returned from the service should begin. Passing <c>null</c>
    /// will start the collection at the first page of values.</param>
    /// <returns>An async sequence of <see cref="PageResult{T}"/>, each holding
    /// the subset of collection values contained in a given service response.
    /// </returns>
    public abstract IAsyncEnumerable<PageResult<T>> AsPages(string? pageToken = default);

    /// <summary>
    /// Return the <see cref="PageResult{T}"/> corresponding to the provided
    /// <paramref name="pageToken"/>, or the first page of collection values if
    /// <paramref name="pageToken"/> is <c>null</c>.
    /// </summary>
    /// <param name="pageToken">The page token indicating which page of
    /// collection values to return.</param>
    /// <param name="cancellationToken">TBD.</param>
    /// <returns>The <see cref="PageResult{T}"/> corresponding to the provided
    /// <paramref name="pageToken"/>, or the first page of collection values if
    /// <paramref name="pageToken"/> is <c>null</c>.</returns>
    public virtual async Task<PageResult<T>> GetPageAsync(string? pageToken = default, CancellationToken cancellationToken = default)
    {
        IAsyncEnumerable<PageResult<T>> pages = AsPages(pageToken);
        await foreach (PageResult<T> page in pages.ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            return page;
        }

        return PageResult<T>.Create(new List<T>().AsReadOnly(), null, GetRawResponse());
    }

    /// <summary>
    /// Return an enumerator that iterates asynchronously through the collection
    /// values. This may make multiple service requests.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used
    /// with requests made while enumerating asynchronously.</param>
    /// <returns>An <see cref="IAsyncEnumerator{T}"/> that can iterate
    /// asynchronously through the collection values.</returns>
    public override async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        await foreach (PageResult<T> page in AsPages().ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }
}
