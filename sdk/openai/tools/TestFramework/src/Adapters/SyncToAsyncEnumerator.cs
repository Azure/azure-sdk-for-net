// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.ExceptionServices;

namespace OpenAI.TestFramework.Adapters;

/// <summary>
/// Wraps an <see cref="IEnumerator{T}"/> as an <see cref="IAsyncEnumerator{T}"/>
/// </summary>
/// <typeparam name="T">The type of items being enumerated.</typeparam>
public class SyncToAsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private IEnumerator<T> _sync;
    private CancellationToken _token;
    private Exception? _ex;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="sync">The synchronous enumerator to wrap.</param>
    /// <param name="token">(Optional) The cancellation token to use.</param>
    /// <exception cref="ArgumentNullException">If the enumerator was null.</exception>
    public SyncToAsyncEnumerator(IEnumerator<T> sync, CancellationToken token = default)
    {
        _sync = sync ?? throw new ArgumentNullException(nameof(sync));
        _token = token;
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="ex">The exception to throw.</param>
    /// <exception cref="ArgumentNullException">If the exception was null.</exception>
    public SyncToAsyncEnumerator(Exception ex)
    {
        _sync = Enumerable.Empty<T>().GetEnumerator();
        _token = default;
        _ex = ex ?? throw new ArgumentNullException(nameof(ex));
    }

    /// <inheritdoc />
    public T Current => _sync.Current;

    /// <inheritdoc />
    public ValueTask DisposeAsync()
    {
        _sync.Dispose();
        return default;
    }

    /// <inheritdoc />
    public ValueTask<bool> MoveNextAsync()
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        _token.ThrowIfCancellationRequested();
        bool ret = _sync.MoveNext();
        return new ValueTask<bool>(ret);
    }
}
