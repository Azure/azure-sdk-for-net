// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
/// <summary>
/// Represents a collection of values returned from a cloud service operation.
/// The collection values may be returned by one or more service responses.
/// </summary>
public abstract class AsyncCollectionResult<T> : AsyncCollectionResult, IAsyncEnumerable<T>
{
    protected internal AsyncCollectionResult(CancellationToken cancellationToken)
        : base(cancellationToken)
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
    /// Get a collection of the values returned in a page response.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected abstract IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page);
}
#pragma warning restore CS1591 // public XML comments
