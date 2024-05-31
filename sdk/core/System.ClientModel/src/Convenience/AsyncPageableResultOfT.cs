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
public abstract class AsyncPageableResult<T> : AsyncCollectionResult<T>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncPageableResult{T}"/>.
    /// </summary>
    /// <remarks>This constructor does not take a <see cref="PipelineResponse"/>
    /// because derived types are expected to defer the first service call
    /// until the collection is enumerated using <c>await foreach</c>.
    /// </remarks>
    protected AsyncPageableResult() : base()
    {
    }

    /// <summary>
    /// Return an enumerable of <see cref="PageResult{T}"/> that aynchronously
    /// enumerates the collection's pages instead of the collection's individual
    /// values. This may make multiple service requests.
    /// </summary>
    /// <param name="pageToken">A token indicating which page should be the
    /// first page in the collection of pages returned form this method.
    /// Passing <c>null</c> will start the collection at the first page of
    /// values.</param>
    /// <returns>A sequence of <see cref="PageResult{T}"/> holding a subset of
    /// collection values, starting at the page indicated by
    /// <paramref name="pageToken"/>.
    /// </returns>
    public abstract IAsyncEnumerable<PageResult<T>> AsPages(string? pageToken = default);

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
