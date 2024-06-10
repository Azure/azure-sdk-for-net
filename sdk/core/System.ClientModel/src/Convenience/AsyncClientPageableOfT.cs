// Copyright (c) Microsoft Corporation. All rights reserved.
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
public abstract class AsyncClientPageable<T> : AsyncCollectionResult<T>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncClientPageable{T}"/>.
    /// </summary>
    /// <remarks>This constructor does not take a <see cref="PipelineResponse"/>
    /// because derived types are expected to defer the first service call
    /// until the collection is enumerated using <c>await foreach</c>.
    /// </remarks>
    protected AsyncClientPageable() : base()
    {
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public async Task<ClientPage<T>> GetPageAsync(string pageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        return await GetPageCoreAsync(pageToken).ConfigureAwait(false);
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="pageToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">If no page can be retrieved
    /// from <paramref name="pageToken"/>.</exception>
    protected abstract Task<ClientPage<T>> GetPageCoreAsync(string pageToken);

    /// <summary>
    /// Convert this <see cref="ClientPageable{T}"/> to a collection of pages
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
    public IAsyncEnumerable<ClientPage<T>> AsPages(string fromPage = ClientPage<T>.DefaultFirstPageToken)
    {
        Argument.AssertNotNull(fromPage, nameof(fromPage));

        return new AsyncPageCollection(this, fromPage);
    }

    // TODO: Qn - AsPagesAsync?  Why or why not?  What is the "correct" .NET pattern
    // here?
    private class AsyncPageCollection : IAsyncEnumerable<ClientPage<T>>
    {
        private readonly AsyncClientPageable<T> _pageable;
        private readonly string _fromPage;

        public AsyncPageCollection(AsyncClientPageable<T> pageable, string fromPage)
        {
            _pageable = pageable;
            _fromPage = fromPage;
        }

        public async IAsyncEnumerator<ClientPage<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            string? pageToken = _fromPage;
            while (pageToken != null)
            {
                ClientPage<T> page = await _pageable.GetPageAsync(pageToken).ConfigureAwait(false);
                _pageable.SetRawResponse(page.GetRawResponse());
                yield return page;
                pageToken = page.NextPageToken;
            }
        }
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
        await foreach (ClientPage<T> page in AsPages().ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }
}
