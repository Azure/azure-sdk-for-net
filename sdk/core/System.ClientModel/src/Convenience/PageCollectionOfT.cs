// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

    public PageResult<T> GetCurrentPage()
    {
        IEnumerator<PageResult<T>> enumerator = GetEnumeratorCore();
        PageResult<T> current = enumerator.Current;

        // Relies on generated enumerator contract
        if (current == null)
        {
            enumerator.MoveNext();
            current = enumerator.Current;
        }

        return current;
    }

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

    protected abstract IEnumerator<PageResult<T>> GetEnumeratorCore();

    IEnumerator<PageResult<T>> IEnumerable<PageResult<T>>.GetEnumerator()
        => GetEnumeratorCore();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<PageResult<T>>)this).GetEnumerator();
}

#pragma warning restore CS1591
