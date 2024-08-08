// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Runtime.ExceptionServices;

namespace OpenAI.TestFramework.Adapters;

/// <summary>
/// An adapter to make a <see cref="PageableCollection{T}"/> look and work like a <see cref="AsyncPageableCollection{T}"/>. This
/// simplifies writing test cases.
/// </summary>
/// <typeparam name="T">The type of the items the enumerator returns.</typeparam>
public class SyncToAsyncPageCollection<T> : AsyncPageCollection<T>
{
    private PageCollection<T>? _syncCollection;
    private Exception? _ex;
    private PageResult<T>? _currentPage;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="syncCollection">The synchronous collection to wrap.</param>
    /// <exception cref="ArgumentNullException">If the collection was null.</exception>
    public SyncToAsyncPageCollection(PageCollection<T> syncCollection)
    {
        _syncCollection = syncCollection ?? throw new ArgumentNullException(nameof(syncCollection));
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="ex">The exception to throw.</param>
    /// <exception cref="ArgumentNullException">If the exception was null.</exception>
    public SyncToAsyncPageCollection(Exception ex)
    {
        _ex = ex ?? throw new ArgumentNullException(nameof(ex));
        _syncCollection = null;
    }

    /// <inheritdoc />
    protected override Task<PageResult<T>> GetCurrentPageAsyncCore()
        => Task.FromResult(_currentPage ?? throw new InvalidOperationException("Please call MoveNextAsync first."));

    /// <inheritdoc />
    protected override async IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default)
    {
        await Task.Delay(0).ConfigureAwait(false);

        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        foreach (PageResult<T> page in _syncCollection!)
        {
            _currentPage = page;
            yield return page;
        }
    }
}
