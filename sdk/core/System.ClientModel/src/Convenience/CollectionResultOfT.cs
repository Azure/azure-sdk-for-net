// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be delivered over one or more service responses.
/// </summary>
public abstract class CollectionResult<T> : CollectionResult, IEnumerable<T>
{
    /// <summary>
    /// Creates a new instance of <see cref="CollectionResult{T}"/>.
    /// </summary>
    protected internal CollectionResult()
    {
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (ClientResult page in GetRawPages())
        {
            foreach (T value in GetValuesFromPage(page))
            {
                yield return value;
            }
        }
    }

    /// <summary>
    /// Gets a collection of the values returned in a page response.
    /// </summary>
    /// <param name="page">The service response to obtain the values from.
    /// </param>
    /// <returns>A collection of <typeparamref name="T"/> values read from the
    ///response content in <paramref name="page"/>.</returns>
    /// <remarks><see cref="CollectionResult{T}"/> implementations are expected
    /// to store the <see cref="CancellationToken"/> passed to the service
    /// method that creates them and pass that token to any methods making
    /// service calls that are called from this method.</remarks>
    protected abstract IEnumerable<T> GetValuesFromPage(ClientResult page);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
