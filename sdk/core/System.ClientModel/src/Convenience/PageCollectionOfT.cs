// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591

// This type is a client that defines a collection of elements and can
// make service requests to retrieve specific pages
public abstract class PageCollection<T> : IEnumerable<PageResult<T>>
{
    // Note - assumes we don't make a request initially, so don't call
    // response constructor
    protected PageCollection() : base()
    {
    }

    public abstract ClientToken FirstPageToken { get; }

    public abstract PageResult<T> GetPage(ClientToken pageToken, RequestOptions? options = default);

    public IEnumerable<T> GetAllValues()
    {
        foreach (PageResult<T> page in this)
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<PageResult<T>>)this).GetEnumerator();

    IEnumerator<PageResult<T>> IEnumerable<PageResult<T>>.GetEnumerator()
    {
        PageResult<T> page = GetPage(FirstPageToken);
        yield return page;

        while (page.NextPageToken != null)
        {
            page = GetPage(page.NextPageToken);
            yield return page;
        }
    }
}

#pragma warning restore CS1591
