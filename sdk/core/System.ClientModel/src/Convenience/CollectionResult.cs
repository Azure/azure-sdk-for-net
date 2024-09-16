// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class CollectionResult
{
    protected CollectionResult()
    {
    }

    public abstract IEnumerable<ClientResult> GetRawPages();

    /// <summary>
    /// Get a <see cref="ContinuationToken"/> that can be passed to a client
    /// method to obtain a collection holding the remaining items in this
    /// <see cref="CollectionResult"/>.
    /// </summary>
    /// <param name="page">The raw page to obtain a continuation token for.
    /// </param>
    /// <returns>A <see cref="ContinuationToken"/> that a client can use to
    /// obtain a <see cref="CollectionResult"/> whose items start at the first
    /// item after the ones in <paramref name="page"/>, or null if
    /// <paramref name="page"/> is the last page in the sequence of pages
    /// containing the items in the collection.</returns>
    public abstract ContinuationToken? GetContinuationToken(ClientResult page);
}
#pragma warning restore CS1591 // public XML comments
