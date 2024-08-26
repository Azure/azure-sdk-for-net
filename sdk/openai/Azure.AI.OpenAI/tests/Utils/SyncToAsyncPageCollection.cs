// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.AI.OpenAI.Tests.Utils;

/// <summary>
/// An adapter to make a <see cref="PageableCollection{T}"/> look and work like a <see cref="AsyncPageableCollection{T}"/>. This
/// simplifies writing test cases.
/// </summary>
/// <typeparam name="T">The type of the items the enumerator returns.</typeparam>
public class SyncToAsyncPageCollection<T> : AsyncPageCollection<T>
{
    private PageCollection<T>? _syncCollection;
    private Exception? _ex;

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
    {
        if (_ex != null)
        {
            return Task.FromException<PageResult<T>>(_ex);
        }
        else
        {
            return Task.FromResult(_syncCollection!.GetCurrentPage());
        }
    }

    /// <inheritdoc />
    protected override async IAsyncEnumerator<PageResult<T>> GetAsyncEnumeratorCore(CancellationToken cancellationToken = default)
    {
        if (_ex != null)
        {
            ExceptionDispatchInfo.Capture(_ex).Throw();
        }

        foreach (PageResult<T> page in _syncCollection!)
        {
            await Task.Delay(0).ConfigureAwait(false);
            yield return page;
        }
    }
}
