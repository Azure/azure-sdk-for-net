// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Runtime.ExceptionServices;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Adapters;

/// <summary>
/// An adapter to make a <see cref="CollectionResult{T}"/> look and work like a <see cref="AsyncCollectionResult{T}"/>. This
/// simplifies writing test cases
/// </summary>
/// <typeparam name="T">The type of the items the enumerator returns</typeparam>
public class SyncToAsyncCollectionResult<T> : AsyncCollectionResult<T>
{
    private CollectionResult<T>? _syncCollection;
    private Exception? _ex;

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <param name="syncCollection">The synchronous collection to wrap</param>
    /// <exception cref="ArgumentNullException">If the collection was null</exception>
    public SyncToAsyncCollectionResult(CollectionResult<T> syncCollection)
    {
        _syncCollection = syncCollection ?? throw new ArgumentNullException(nameof(syncCollection));
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="ex">The exception to throw.</param>
    /// <exception cref="ArgumentNullException">If the exception was null.</exception>
    public SyncToAsyncCollectionResult(Exception ex)
    {
        _ex = ex ?? throw new ArgumentNullException(nameof(ex));
    }

    /// <inheritdoc />
    public override ContinuationToken? GetContinuationToken(ClientResult page)
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        return _syncCollection!.GetContinuationToken(page);
    }

    /// <inheritdoc />
    public override IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        return new SyncToAsyncEnumerable<ClientResult>(_syncCollection!.GetRawPages());
    }

    /// <inheritdoc />
    protected override IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        var items = NonPublic.FromMethod<CollectionResult<T>, ClientResult, IEnumerable<T>>("GetValuesFromPage")(_syncCollection!, page);
        return new SyncToAsyncEnumerable<T>(items);
    }
}
