// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591
internal class PageEnumerator<T> : PageEnumerator, IAsyncEnumerator<PageResult<T>>, IEnumerator<PageResult<T>>
{
    private readonly PageableResult _subclient;

    public PageEnumerator(PageableResult subclient)
    {
        _subclient = subclient;
    }

    public PageResult<T> GetCurrentPage()
    {
        if (Current is null)
        {
            return _toPage(_subclient.GetNextPage(null, null!));
        }

        return ((IEnumerator<PageResult<T>>)this).Current;
    }

    public async Task<PageResult<T>> GetCurrentPageAsync()
    {
        if (Current is null)
        {
            return _toPage(await _subclient.GetNextPageAsync(null, null!).ConfigureAwait(false));
        }

        return ((IEnumerator<PageResult<T>>)this).Current;
    }

    PageResult<T> IEnumerator<PageResult<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return _toPage(Current);
        }
    }

    PageResult<T> IAsyncEnumerator<PageResult<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return _toPage(Current);
        }
    }
}
#pragma warning restore CS1591
