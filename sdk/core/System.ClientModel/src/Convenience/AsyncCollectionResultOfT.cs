// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be returned by one or more service responses.
/// </summary>
public abstract class AsyncCollectionResult<T> : AsyncCollectionResult, IAsyncEnumerable<T>
{
    /// <summary>
    /// Create a new instance of <see cref="AsyncCollectionResult{T}"/>.
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
    protected internal AsyncCollectionResult() : base()
    {
    }

    /// <inheritdoc/>
    public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
}
