// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

internal abstract class PageEnumerator :
    IAsyncEnumerator<ClientResult>,
    IEnumerator<ClientResult>
{
    private ClientResult? _current;
    private bool _hasNext = true;

    public ClientResult Current => _current!;

    public abstract Task<ClientResult> GetFirstAsync();

    public abstract ClientResult GetFirst();

    public abstract Task<ClientResult> GetNextAsync(ClientResult result);

    public abstract ClientResult GetNext(ClientResult result);

    public abstract bool HasNext(ClientResult result);

    object IEnumerator.Current => ((IEnumerator<ClientResult>)this).Current;

    public bool MoveNext()
    {
        if (!_hasNext)
        {
            return false;
        }

        if (_current == null)
        {
            _current = GetFirst();
        }
        else
        {
            _current = GetNext(_current);
        }

        _hasNext = HasNext(_current);
        return true;
    }

    void IEnumerator.Reset() => _current = null;

    void IDisposable.Dispose() { }

    public async ValueTask<bool> MoveNextAsync()
    {
        if (!_hasNext)
        {
            return false;
        }

        if (_current == null)
        {
            _current = await GetFirstAsync().ConfigureAwait(false);
        }
        else
        {
            _current = await GetNextAsync(_current).ConfigureAwait(false);
        }

        _hasNext = HasNext(_current);
        return true;
    }

    ValueTask IAsyncDisposable.DisposeAsync() => default;
}
