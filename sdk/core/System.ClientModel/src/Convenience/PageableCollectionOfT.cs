// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of results returned from a cloud service operation
/// sequentially over one or more calls to the service.
/// </summary>
public abstract class PageableCollection<T> : ResultCollection<T>
{
    /// <summary>
    /// Create a new instance of <see cref="PageableCollection{T}"/>.
    /// </summary>
    /// <remarks>This constructor does not take a <see cref="PipelineResponse"/>
    /// because derived types are expected to defer the first service call
    /// until the collection is enumerated using <c>foreach</c>.</remarks>
    protected PageableCollection() : base()
    {
    }

    /// <summary>
    /// Return an enumerable of <see cref="ResultPage{T}"/> that enumerates the
    /// collection's pages instead of the collection's individual values. This
    /// may make multiple service requests.
    /// </summary>
    /// <param name="continuationToken">A token indicating where the collection
    /// of results returned from the service should begin. Passing <c>null</c>
    /// will start the collection at the first page of values.</param>
    /// <param name="pageSizeHint">The number of items to request that the
    /// service return in a <see cref="ResultPage{T}"/>, if the service supports
    /// such requests.</param>
    /// <returns>A sequence of <see cref="ResultPage{T}"/>, each holding the
    /// subset of collection values contained in a given service response.
    /// </returns>
    public abstract IEnumerable<ResultPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default);

    /// <summary>
    /// Return an enumerator that iterates through the collection values. This
    /// may make multiple service requests.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the
    /// collection values.</returns>
    public override IEnumerator<T> GetEnumerator()
    {
        foreach (ResultPage<T> page in AsPages())
        {
            foreach (T value in page)
            {
                yield return value;
            }
        }
    }
}
