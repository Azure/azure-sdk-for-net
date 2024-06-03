// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation
/// sequentially over one or more calls to the service.
/// </summary>
public abstract class PageableResult<T> : CollectionResult<T>
{
    /// <summary>
    /// Create a new instance of <see cref="PageableResult{T}"/>.
    /// </summary>
    /// <remarks>This constructor does not take a <see cref="PipelineResponse"/>
    /// because derived types are expected to defer the first service call
    /// until the collection is enumerated using <c>foreach</c>.</remarks>
    protected PageableResult() : base()
    {
    }

    /// <summary>
    /// Return an enumerable of <see cref="PageResult{T}"/> that enumerates the
    /// collection's pages instead of the collection's individual values. This
    /// may make multiple service requests.
    /// </summary>
    /// <param name="pageToken">A token indicating the first page that
    /// will be requested when the returned collection is enumerated.
    /// Passing <c>null</c> cause the enumerable to make its first page request
    /// for the first page of collection values.</param>
    /// <returns>A sequence of <see cref="PageResult{T}"/> pages that each hold
    /// a subset of collection values, and that starts at the page indicated by
    /// <paramref name="pageToken"/>.
    /// </returns>
    public abstract IEnumerable<PageResult<T>> AsPages(string? pageToken = default);

    /// <summary>
    /// Return an enumerator that iterates through the collection values. This
    /// may make multiple service requests.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the
    /// collection values.</returns>
    public override IEnumerator<T> GetEnumerator()
    {
        foreach (PageResult<T> page in AsPages())
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }
}
