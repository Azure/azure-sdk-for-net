// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591
internal class PageEnumerator : IAsyncEnumerator<ClientResult>, IEnumerator<ClientResult>
{
    private readonly PageableResult _subclient;

    public PageEnumerator(PageableResult subclient)
    {
        _subclient = subclient;
    }

    private ClientResult? _current;
    private bool _hasNext = true;

    public ClientResult Current => _current!;

    public IEnumerable<ClientResult> ToResultCollection()
    {
        while (MoveNext())
        {
            yield return Current;
        }
    }

    public async IAsyncEnumerable<ClientResult> ToAsyncResultCollection()
    {
        while (await MoveNextAsync().ConfigureAwait(false))
        {
            yield return Current;
        }
    }

    object IEnumerator.Current => ((IEnumerator<ClientResult>)this).Current;

    public bool MoveNext()
    {
        if (!_hasNext)
        {
            return false;
        }

        if (_current == null)
        {
            // TODO: figure out RequestOptions
            _current = _subclient.GetNextPage(null, null!);
        }
        else
        {
            _current = _subclient.GetNextPage(_current, null!);
        }

        _hasNext = _subclient.HasNext(_current);
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
            _current = await _subclient.GetNextPageAsync(null, null!).ConfigureAwait(false);
        }
        else
        {
            _current = await _subclient.GetNextPageAsync(_current, null!).ConfigureAwait(false);
        }

        _hasNext = _subclient.HasNext(_current);
        return true;
    }

    ValueTask IAsyncDisposable.DisposeAsync() => default;
}
#pragma warning restore CS1591
