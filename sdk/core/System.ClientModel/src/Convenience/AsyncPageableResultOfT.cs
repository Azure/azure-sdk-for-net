﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
    /// TBD.
    /// </summary>
    public virtual async Task<PageResult<T>> GetPageAsync(string pageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        await foreach (PageResult<T> page in AsPages(pageToken).ConfigureAwait(false))
        {
            return page;
        }

        throw new ArgumentOutOfRangeException(nameof(pageToken), $"No pages returned for pageToken '{pageToken}'.");
    }

    /// <summary>
    /// Convert this <see cref="PageableResult{T}"/> to a collection of pages
    /// instead of a collection of the individual values of type
    /// <typeparamref name="T"/>. Enumerating this collection will typically
    /// make one service request for each page item.
    /// </summary>
    /// <param name="pageToken">A token indicating the first page that will be
    /// requested when the returned collection is enumerated. If no
    /// <paramref name="pageToken"/> value is specified, the first page in the
    /// returned collection will be the first page of values returned from the
    /// service.</param>
    /// <returns>An enumerable of <see cref="PageResult{T}"/> that enumerates the
    /// collection's pages instead of the collection's individual values,
    /// starting at the page indicated by <paramref name="pageToken"/>.
    /// </returns>
    public IAsyncEnumerable<PageResult<T>> AsPages(string pageToken = PageResult<T>.FirstPageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        return AsPagesCore(pageToken);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    protected abstract IAsyncEnumerable<PageResult<T>> AsPagesCore(string pageToken);

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
        await foreach (PageResult<T> page in AsPages(PageResult<T>.FirstPageToken).ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }
}
