// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

// Lives in .Primitives because it's intended to be inherited from to create
// a service-specific instance.
namespace System.ClientModel.Primitives;

#pragma warning disable CS1591

// This type is a client that defines a collection of elements and can
// make service requests to retrieve specific pages
public abstract class PageCollection<TPage, TValue, TPageToken> : ClientResult, IEnumerable<TPage>
    where TPage : ClientPage<TValue, TPageToken>
    where TPageToken : IPersistableModel<TPageToken>
{
    // Note - assumes we don't make a request initially
    protected PageCollection(TPageToken firstPageToken) : base()
    {
        FirstPageToken = firstPageToken;
    }

    public TPageToken FirstPageToken { get; }

    public abstract TPage GetPage(TPageToken pageToken);

    public IEnumerable<TValue> GetAllValues()
    {
        foreach (TPage page in this)
        {
            foreach (TValue value in page.Values)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<TPage> GetEnumerator()
    {
        TPage page = GetPage(FirstPageToken);
        SetRawResponse(page.GetRawResponse());
        yield return page;

        while (page.NextPageToken != null)
        {
            page = GetPage(page.NextPageToken);
            SetRawResponse(page.GetRawResponse());
            yield return page;
        }
    }
}
#pragma warning restore CS1591
