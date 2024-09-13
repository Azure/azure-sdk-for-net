// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

internal abstract class PageEnumerator<T> : PageEnumerator,
    IAsyncEnumerator<IEnumerable<T>>,
    IEnumerator<IEnumerable<T>>
{
    public abstract IEnumerable<T> GetPageValuesFromResult(ClientResult result);

    public IEnumerable<T> GetCurrentPage()
    {
        if (Current is null)
        {
            return GetPageValuesFromResult(GetFirst());
        }

        return ((IEnumerator<IEnumerable<T>>)this).Current;
    }

    public async Task<IEnumerable<T>> GetCurrentPageAsync()
    {
        if (Current is null)
        {
            return GetPageValuesFromResult(await GetFirstAsync().ConfigureAwait(false));
        }

        return ((IEnumerator<IEnumerable<T>>)this).Current;
    }

    IEnumerable<T> IEnumerator<IEnumerable<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return GetPageValuesFromResult(Current);
        }
    }

    IEnumerable<T> IAsyncEnumerator<IEnumerable<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return GetPageValuesFromResult(Current);
        }
    }
}
