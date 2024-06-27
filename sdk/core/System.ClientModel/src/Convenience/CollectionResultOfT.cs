// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be returned by one or more service responses.
/// </summary>
public abstract class CollectionResult<T> : ClientResult, IEnumerable<T>
{
    /// <summary>
    /// Create a new instance of <see cref="CollectionResult{T}"/>.
    /// </summary>
    /// <remarks>If no <see cref="PipelineResponse"/> is provided when the
    /// <see cref="ClientResult"/> instance is created, it is expected that
    /// a derived type will call <see cref="ClientResult.SetRawResponse(PipelineResponse)"/>
    /// prior to a user calling <see cref="ClientResult.GetRawResponse"/>.
    /// This constructor is indended for use by collection implementations that
    /// postpone sending a request until <see cref="GetEnumerator()"/>
    /// is called. Such implementations will typically be returned from client
    /// convenience methods so that callers of the methods don't need to
    /// dispose the return value. </remarks>
    protected internal CollectionResult() : base()
    {
    }

    /// <summary>
    /// Create a new instance of <see cref="CollectionResult{T}"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// items in the collection, or the first set of the items in the collection.
    /// </param>
    protected internal CollectionResult(PipelineResponse response) : base(response)
    {
    }

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="firstPage"></param>
    /// <returns></returns>
    public static CollectionResult<T> FromPage(PageResult<T> firstPage)
        => new PageableCollectionResult(firstPage);

    /// <inheritdoc/>
    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class PageableCollectionResult : CollectionResult<T>
    {
        private readonly PageResult<T> _firstPage;

        public PageableCollectionResult(PageResult<T> firstPage)
        {
            _firstPage = firstPage;
            SetRawResponse(firstPage.GetRawResponse());
        }

        public override IEnumerator<T> GetEnumerator()
        {
            PageResult<T> page = _firstPage;
            while (page.HasNext)
            {
                foreach (T value in page.Values)
                {
                    yield return value;
                }

                page = (PageResult<T>)page.GetNext();
            }
        }
    }
}
