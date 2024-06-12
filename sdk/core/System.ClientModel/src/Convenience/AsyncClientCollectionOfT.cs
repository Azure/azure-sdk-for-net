// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// </summary>
public abstract class AsyncClientCollection<T> : ClientResult, IAsyncEnumerable<T>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncClientCollection{T}"/>.
    /// </summary>
    /// <remarks>If no <see cref="PipelineResponse"/> is provided when the
    /// <see cref="ClientResult"/> instance is created, it is expected that
    /// a derived type will call <see cref="ClientResult.SetRawResponse(PipelineResponse)"/>
    /// prior to a user calling <see cref="ClientResult.GetRawResponse"/>.
    /// This constructor is indended for use by collection implementations that
    /// postpone sending a request until <see cref="GetAsyncEnumerator(CancellationToken)"/>
    /// is called. Such implementations will typically be returned from client
    /// convenience methods so that callers of the methods don't need to
    /// dispose the return value. </remarks>
    protected internal AsyncClientCollection() : base()
    {
    }

    /// <summary>
    /// Create a new instance of <see cref="AsyncClientCollection{T}"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// items in the collection, or the first set of the items in the collection.
    /// </param>
    protected internal AsyncClientCollection(PipelineResponse response) : base(response)
    {
    }

    /// <inheritdoc/>
    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static AsyncClientCollection<T> FromPageAsync(ClientPage<T> page)
    {
        return new AsyncClientPageable(page);
    }

    internal class AsyncClientPageable : AsyncClientCollection<T>
    {
        private readonly ClientPage<T> _page;

        public AsyncClientPageable(ClientPage<T> page) : base(page.GetRawResponse())
        {
            _page = page;
        }

        // TODO: plumb through request options
        public override async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await foreach (ClientPage<T> page in _page.ToPageCollectionAsync().ConfigureAwait(false).WithCancellation(cancellationToken))
            {
                foreach (T value in page.Values)
                {
                    yield return value;
                }
            }
        }
    }
}
