// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
    /// TBD.
    /// </summary>
    public ClientPage<T> GetPage(string pageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        return GetPageCore(pageToken);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="pageToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">If no page can be retrieved
    /// from <paramref name="pageToken"/>.</exception>
    protected abstract ClientPage<T> GetPageCore(string pageToken);

    /// <summary>
    /// Convert this <see cref="PageableResult{T}"/> to a collection of pages
    /// instead of a collection of the individual values of type
    /// <typeparamref name="T"/>. Enumerating this collection will typically
    /// make one service request for each page item.
    /// </summary>
    /// <param name="fromPage">A token indicating the first page that will be
    /// requested when the returned collection is enumerated. If no
    /// <paramref name="fromPage"/> value is specified, the first page in the
    /// returned collection will be the first page of values returned from the
    /// service.</param>
    /// <returns>An enumerable of <see cref="ClientPage{T}"/> that enumerates the
    /// collection's pages instead of the collection's individual values,
    /// starting at the page indicated by <paramref name="fromPage"/>.
    /// </returns>
    public IEnumerable<ClientPage<T>> AsPages(string fromPage = ClientPage<T>.DefaultFirstPageToken)
    {
        Argument.AssertNotNull(fromPage, nameof(fromPage));

        string? pageToken = fromPage;
        while (pageToken != null)
        {
            ClientPage<T> page = GetPageCore(pageToken);
            SetRawResponse(page.GetRawResponse());
            yield return page;
            pageToken = page.NextPageToken;
        }
    }

    /// <summary>
    /// Return an enumerator that iterates through the collection values. This
    /// may make multiple service requests.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the
    /// collection values.</returns>
    public override IEnumerator<T> GetEnumerator()
    {
        foreach (ClientPage<T> page in AsPages())
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }
}
