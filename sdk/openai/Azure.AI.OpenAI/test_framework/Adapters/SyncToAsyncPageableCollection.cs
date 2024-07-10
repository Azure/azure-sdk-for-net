// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.ExceptionServices;

namespace System.ClientModel.TestFramework.Adapters;

/// <summary>
/// An adapter to make a <see cref="PageableCollection{T}"/> look and work like a <see cref="AsyncPageableCollection{T}"/>. This
/// simplifies writing test cases.
/// </summary>
/// <typeparam name="T">The type of the items the enumerator returns.</typeparam>
public class SyncToAsyncPageableCollection<T> : AsyncPageableCollection<T>
{
    private bool _responseSet;
    private PageableCollection<T> _syncCollection;
    private Exception? _ex;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="syncCollection">The synchronous collection to wrap.</param>
    /// <exception cref="ArgumentNullException">If the collection was null.</exception>
    public SyncToAsyncPageableCollection(PageableCollection<T> syncCollection)
    {
        _syncCollection = syncCollection ?? throw new ArgumentNullException(nameof(syncCollection));
        TrySetRawResponse();
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="ex">The exception to throw.</param>
    /// <exception cref="ArgumentNullException">If the exception was null.</exception>
    public SyncToAsyncPageableCollection(Exception ex)
    {
        _ex = ex ?? throw new ArgumentNullException(nameof(ex));
        _syncCollection = null!;
    }

    /// <inheritdoc />
    public override async IAsyncEnumerable<ResultPage<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        IEnumerable<ResultPage<T>> syncEnumerable = _syncCollection.AsPages(continuationToken, pageSizeHint);
        var asyncWrapper = new SyncToAsyncEnumerator<ResultPage<T>>(syncEnumerable.GetEnumerator());
        while (await asyncWrapper.MoveNextAsync().ConfigureAwait(false))
        {
            TrySetRawResponse();
            yield return asyncWrapper.Current;
        }
    }

    private void TrySetRawResponse()
    {
        if (_responseSet)
        {
            return;
        }

        // Client result doesn't provide virtual methods so we have to manually set it ourselves here
        try
        {
            var raw = _syncCollection.GetRawResponse();
            if (raw != null)
            {
                SetRawResponse(raw);
                _responseSet = true;
            }
        }
        catch (Exception) { /* dont' care */ }
    }
}
