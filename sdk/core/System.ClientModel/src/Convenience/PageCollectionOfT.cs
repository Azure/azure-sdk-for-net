// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
    protected PageCollection() : base()
    {
    }

    // Note that this is abstract rather than providing the field in the base
    // type because it means the implementation can hold the field as a subtype
    // instance in the implementation and not have to cast it.

    // If we ever make this property public, we should keep the setter protected.
    protected abstract ContinuationToken CurrentPageToken { get; set; }

    public PageResult<T> GetCurrentPage() => GetPage(CurrentPageToken);

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

    // TODO: do we need this, and do we need it to be called Core?
    protected PageResult<T> GetPage(ContinuationToken pageToken)
    {
        Argument.AssertNotNull(pageToken, nameof(pageToken));

        return GetPageCore(pageToken);
    }

    // Doesn't take RequestOptions because RequestOptions cannot be rehydrated.
    protected abstract PageResult<T> GetPageCore(ContinuationToken pageToken);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<PageResult<T>>)this).GetEnumerator();

    IEnumerator<PageResult<T>> IEnumerable<PageResult<T>>.GetEnumerator()
    {
        PageResult<T> page = GetPage(CurrentPageToken);
        yield return page;

        while (page.NextPageToken != null)
        {
            page = GetPage(page.NextPageToken);
            CurrentPageToken = page.PageToken;

            yield return page;
        }
    }
}

#pragma warning restore CS1591
