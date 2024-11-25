// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Adapters;

/// <summary>
/// Wraps an <see cref="IEnumerable{T}"/> as an <see cref="IAsyncEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The type of items being enumerated.</typeparam>
public class SyncToAsyncEnumerable<T> : IAsyncEnumerable<T>
{
    private IEnumerable<T> _enumerable;
    Exception? _ex;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="enumerable">The synchronous enumerable to wrap.</param>
    public SyncToAsyncEnumerable(IEnumerable<T> enumerable)
    {
        _enumerable = enumerable;
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="ex">The synchronous enumerable to wrap.</param>
    public SyncToAsyncEnumerable(Exception ex)
    {
        _ex = ex;
        _enumerable = Array.Empty<T>();
    }

    /// <inheritdoc />
    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        if (_ex != null)
        {
            return new SyncToAsyncEnumerator<T>(_ex);
        }
        else
        {
            return new SyncToAsyncEnumerator<T>(_enumerable.GetEnumerator(), cancellationToken);
        }
    }
}
