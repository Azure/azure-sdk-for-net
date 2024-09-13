// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

/// <summary>
/// Abstract type defining methods that service clients must provide in order
/// to implement an enumerator over collections of strongly typed models (T's)
/// that represent the subsets of items delivered by the pages of results found
/// in services responses that together provide the full set of items in a
/// paginated collection.
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class PageEnumerator<T> : PageEnumerator,
    IAsyncEnumerator<IEnumerable<T>>,
    IEnumerator<IEnumerable<T>>
{
    public abstract IEnumerable<T> GetValuesFromPage(ClientResult pageResult);

    public async Task<IEnumerable<T>> GetCurrentPageAsync()
    {
        if (Current is null)
        {
            return GetValuesFromPage(await GetFirstAsync().ConfigureAwait(false));
        }

        return ((IEnumerator<IEnumerable<T>>)this).Current;
    }

    public IEnumerable<T> GetCurrentPage()
    {
        if (Current is null)
        {
            return GetValuesFromPage(GetFirst());
        }

        return ((IEnumerator<IEnumerable<T>>)this).Current;
    }

    IEnumerable<T> IAsyncEnumerator<IEnumerable<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return GetValuesFromPage(Current);
        }
    }

    IEnumerable<T> IEnumerator<IEnumerable<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return GetValuesFromPage(Current);
        }
    }
}
