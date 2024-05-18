// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of results returned from a cloud service operation.
/// </summary>
public abstract class ResultCollection<T> : ClientResult, IEnumerable<T>
{
    /// <summary>
    /// Create a new instance of <see cref="ResultCollection{T}"/>.
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
    protected internal ResultCollection() : base()
    {
    }

    /// <summary>
    /// Create a new instance of <see cref="ResultCollection{T}"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> holding the
    /// items in the collection, or the first set of the items in the collection.
    /// </param>
    protected internal ResultCollection(PipelineResponse response) : base(response)
    {
    }

    /// <inheritdoc/>
    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
