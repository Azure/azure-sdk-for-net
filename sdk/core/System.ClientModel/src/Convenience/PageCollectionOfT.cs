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
    // Note page collections delay making a first request until either
    // GetPage is called or the collection is enumerated, so the constructor
    // calls the base class constructor that does not take a response.
    protected PageCollection(RequestOptions? options/* = default*/) : base()
    {
        RequestOptions = options;
    }

    // Note that this is abstract rather than providing the field in the base
    // type because it means the implementation can hold the field as a subtype
    // instance in the implementation and not have to cast it.
    public abstract ClientToken FirstPageToken { get; }

    protected RequestOptions? RequestOptions { get; }

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
        PageResult<T> page = GetPage(FirstPageToken, RequestOptions);
        yield return page;

        while (page.NextPageToken != null)
        {
            page = GetPage(page.NextPageToken);
            yield return page;
        }
    }
}

#pragma warning restore CS1591
