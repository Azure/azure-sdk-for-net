// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be delivered over one or more service responses.
/// </summary>
public abstract class CollectionResult
{    /// <summary>
     /// Creates a new instance of <see cref="CollectionResult"/>.
     /// </summary>
    protected CollectionResult()
    {
    }

    /// <summary>
    /// Gets the collection of page responses that contain the items in this
    /// collection.
    /// </summary>
    /// <returns>A collection of service responses where each
    /// <see cref="ClientResult"/> holds a subset of items in the full
    /// collection.
    /// </returns>
    /// <remarks><see cref="CollectionResult"/> implementations are expected
    /// to store the <see cref="CancellationToken"/> passed to the service
    /// method that creates them and pass that token to any methods making
    /// service calls that are called from this method.  For protocol methods,
    /// this <see cref="CancellationToken"/> will come from the
    /// <see cref="RequestOptions.CancellationToken"/> property.</remarks>
    public abstract IEnumerable<ClientResult> GetRawPages();

    /// <summary>
    /// Gets a <see cref="ContinuationToken"/> that can be passed to a client
    /// method to obtain a collection holding the remaining items in this
    /// <see cref="CollectionResult"/>.
    /// </summary>
    /// <param name="page">The raw page to obtain a continuation token for.
    /// </param>
    /// <returns>A <see cref="ContinuationToken"/> that a client can use to
    /// obtain an <see cref="CollectionResult"/> whose items start at the
    /// first item after the last item in <paramref name="page"/>, or
    /// <c>null</c> if <paramref name="page"/> is the last page in the sequence
    /// of page responses delivering the items in the collection.</returns>
    public abstract ContinuationToken? GetContinuationToken(ClientResult page);
}
