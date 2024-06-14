// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591

// This type is a client that defines a collection of elements and can
// make service requests to retrieve specific pages
public abstract class PageCollection<T> : ClientResult,
    IEnumerable<ClientPage<T>>,
    IEnumerable<ClientResult>
{
    // Note - assumes we don't make a request initially, so don't call
    // response constructor
    protected PageCollection() : base()
    {
    }

    public abstract PageToken FirstPageToken { get; }

    public abstract ClientPage<T> GetPage(PageToken pageToken, RequestOptions? options = default);

    public IEnumerable<T> GetValues()
    {
        foreach (ClientPage<T> page in (IEnumerable<ClientPage<T>>)this)
        {
            foreach (T value in page.Values)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<ClientPage<T>>)this).GetEnumerator();

    IEnumerator<ClientPage<T>> IEnumerable<ClientPage<T>>.GetEnumerator()
    {
        ClientPage<T> page = GetPage(FirstPageToken);
        SetRawResponse(page.GetRawResponse());
        yield return page;

        while (page.NextPageToken != null)
        {
            page = GetPage(page.NextPageToken);
            SetRawResponse(page.GetRawResponse());
            yield return page;
        }
    }

    // TODO: is this the best way to implement?
    IEnumerator<ClientResult> IEnumerable<ClientResult>.GetEnumerator()
    {
        foreach (ClientPage<T> page in (IEnumerable<ClientPage<T>>)this)
        {
            yield return page;
        }
    }
}
#pragma warning restore CS1591
