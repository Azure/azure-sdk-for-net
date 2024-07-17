// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// A collection of page results returned by a cloud service.  Cloud services
/// use pagination to return a collection of items over multiple responses.
/// Each response from the service returns a page of items in the collection,
/// as well as the information needed to obtain the next page of items, until
/// all the items in the requested collection have been returned.  To enumerate
/// the items in the collection, instead of the pages in the collection, call
/// <see cref="GetAllValues"/>.  To get the current collection page, call
/// <see cref="GetCurrentPage"/>.
/// </summary>
public abstract class PageCollection<T> : IEnumerable<PageResult<T>>
{
    /// <summary>
    /// Create a new instance of <see cref="PageCollection{T}"/>.
    /// </summary>
    protected PageCollection() : base()
    {
        // Note that page collections delay making a first request until either
        // GetCurrentPage is called or the collection returned by GetAllValues
        // is enumerated, so this constructor calls the base class constructor
        // that does not take a PipelineResponse.
    }

    /// <summary>
    /// Get the current page of the collection.
    /// </summary>
    /// <returns>The current page in the collection.</returns>
    public PageResult<T> GetCurrentPage()
        => GetCurrentPageCore();

    /// <summary>
    /// Get a collection of all the values in the collection requested from the
    /// cloud service, rather than the pages of values.
    /// </summary>
    /// <returns>The values requested from the cloud service.</returns>
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

    /// <summary>
    /// Get the current page of the collection.
    /// </summary>
    /// <returns>The current page in the collection.</returns>
    protected abstract PageResult<T> GetCurrentPageCore();

    /// <summary>
    /// Get an enumerator that can enumerate the pages of values returned by
    /// the cloud service.
    /// </summary>
    /// <returns>An enumerator of pages holding the items in the value
    /// collection.</returns>
    protected abstract IEnumerator<PageResult<T>> GetEnumeratorCore();

    IEnumerator<PageResult<T>> IEnumerable<PageResult<T>>.GetEnumerator()
        => GetEnumeratorCore();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<PageResult<T>>)this).GetEnumerator();
}
