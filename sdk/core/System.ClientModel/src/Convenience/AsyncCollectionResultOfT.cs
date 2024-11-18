// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be delivered over one or more service responses.
/// </summary>
public abstract class AsyncCollectionResult<T> : AsyncCollectionResult, IAsyncEnumerable<T>
{
    /// <summary>
    /// Creates a new instance of <see cref="AsyncCollectionResult{T}"/>.
    /// </summary>
    protected internal AsyncCollectionResult()
    {
    }

    /// <inheritdoc/>
    public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        await foreach (ClientResult page in GetRawPagesAsync().ConfigureAwait(false).WithCancellation(cancellationToken))
        {
            await foreach (T value in GetValuesFromPageAsync(page).ConfigureAwait(false).WithCancellation(cancellationToken))
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
    /// <remarks>This method does not take a <see cref="CancellationToken"/>
    /// parameter.  <see cref="AsyncCollectionResult{T}"/> implementations must
    /// store the <see cref="CancellationToken"/> passed to the service method
    /// that creates them and pass that token to any <c>async</c> methods
    /// called from this method.</remarks>
    protected abstract IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page);
}
