// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;

namespace ClientModel.Tests.Paging;

internal abstract class PageEnumerator<T> : PageResultEnumerator,
    IAsyncEnumerator<PageResult<T>>,
    IEnumerator<PageResult<T>>
{
    public abstract PageResult<T> GetPageFromResult(ClientResult result);

    PageResult<T> IEnumerator<PageResult<T>>.Current
    {
        get
        {
            if (Current is null)
            {
                return default!;
            }

            return GetPageFromResult(Current);
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

            return GetPageFromResult(Current);
        }
    }
}
