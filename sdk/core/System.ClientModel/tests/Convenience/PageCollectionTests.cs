// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using ClientModel.Tests.Paging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Unit tests for sync and async page collections.
/// </summary>
public class PageCollectionTests
{
    private const int Count = 16;
    private const int DefaultPageSize = 8;
    private static readonly List<int> MockValues = GetMockValues(Count).ToList();

    private static IEnumerable<int> GetMockValues(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return i;
        }
    }

    //[Test]
    //public void CanGetAllValues()
    //{
    //    PageCollection<int> pages = new MockPageCollection<int>(MockValues, DefaultPageSize);
    //    IEnumerable<int> values = pages.GetAllValues();

    //    int count = 0;
    //    foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;
    //    }

    //    Assert.AreEqual(Count, count);
    //}

    //[Test]
    //public async Task CanGetAllValuesAsync()
    //{
    //    AsyncPageCollection<int> pages = new MockAsyncPageCollection<int>(MockValues, DefaultPageSize);
    //    IAsyncEnumerable<int> values = pages.GetAllValuesAsync();

    //    int count = 0;
    //    await foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;
    //    }

    //    Assert.AreEqual(Count, count);
    //}

    //[Test]
    //public void CanGetCurrentPage()
    //{
    //    PageCollection<int> pages = new MockPageCollection<int>(MockValues, DefaultPageSize);
    //    PageResult<int> page = pages.GetCurrentPage();

    //    Assert.AreEqual(MockPagingData.DefaultPageSize, page.Values.Count);
    //    Assert.AreEqual(0, page.Values[0]);
    //}

    //[Test]
    //public async Task CanGetCurrentPageAsync()
    //{
    //    AsyncPageCollection<int> pages = new MockAsyncPageCollection<int>(MockValues, DefaultPageSize);
    //    PageResult<int> page = await pages.GetCurrentPageAsync();

    //    Assert.AreEqual(MockPagingData.DefaultPageSize, page.Values.Count);
    //    Assert.AreEqual(0, page.Values[0]);
    //}

    //[Test]
    //public void CanGetCurrentPageThenGetAllItems()
    //{
    //    PageCollection<int> pages = new MockPageCollection<int>(MockValues, DefaultPageSize);
    //    PageResult<int> page = pages.GetCurrentPage();

    //    Assert.AreEqual(DefaultPageSize, page.Values.Count);
    //    Assert.AreEqual(0, page.Values[0]);

    //    IEnumerable<int> values = pages.GetAllValues();

    //    int count = 0;
    //    foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;
    //    }

    //    Assert.AreEqual(Count, count);
    //}

    //[Test]
    //public async Task CanGetCurrentPageThenGetAllItemsAsync()
    //{
    //    AsyncPageCollection<int> pages = new MockAsyncPageCollection<int>(MockValues, DefaultPageSize);
    //    PageResult<int> page = await pages.GetCurrentPageAsync();

    //    Assert.AreEqual(DefaultPageSize, page.Values.Count);
    //    Assert.AreEqual(0, page.Values[0]);

    //    IAsyncEnumerable<int> values = pages.GetAllValuesAsync();

    //    int count = 0;
    //    await foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;
    //    }

    //    Assert.AreEqual(Count, count);
    //}

    //[Test]
    //public void CanGetCurrentPageWhileEnumeratingItems()
    //{
    //    PageCollection<int> pages = new MockPageCollection<int>(MockValues, DefaultPageSize);
    //    IEnumerable<int> values = pages.GetAllValues();

    //    int count = 0;
    //    foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;

    //        PageResult<int> page = pages.GetCurrentPage();

    //        // Validate that the current item is in range of the page values
    //        Assert.GreaterOrEqual(value, page.Values[0]);
    //        Assert.LessOrEqual(value, page.Values[page.Values.Count - 1]);
    //    }

    //    Assert.AreEqual(MockPagingData.Count, count);
    //}

    //[Test]
    //public async Task CanGetCurrentPageWhileEnumeratingItemsAsync()
    //{
    //    AsyncPageCollection<int> pages = new MockAsyncPageCollection<int>(MockValues, DefaultPageSize);
    //    IAsyncEnumerable<int> values = pages.GetAllValuesAsync();

    //    int count = 0;
    //    await foreach (int value in values)
    //    {
    //        Assert.AreEqual(count, value);
    //        count++;

    //        PageResult<int> page = await pages.GetCurrentPageAsync();

    //        // Validate that the current item is in range of the page values
    //        Assert.GreaterOrEqual(value, page.Values[0]);
    //        Assert.LessOrEqual(value, page.Values[page.Values.Count - 1]);
    //    }

    //    Assert.AreEqual(MockPagingData.Count, count);
    //}

    //[Test]
    //public void CanEnumerateClientResults()
    //{
    //    PageCollection<int> pages = new MockPageCollection<int>(MockValues, DefaultPageSize);
    //    IEnumerable<ClientResult> pageResults = pages;

    //    int pageCount = 0;
    //    foreach (ClientResult result in pageResults)
    //    {
    //        Assert.AreEqual(200, result.GetRawResponse().Status);
    //        pageCount++;
    //    }

    //    Assert.AreEqual(2, pageCount);
    //}

    //[Test]
    //public async Task CanEnumerateClientResultsAsync()
    //{
    //    AsyncPageCollection<int> pages = new MockAsyncPageCollection<int>(MockValues, DefaultPageSize);
    //    IAsyncEnumerable<ClientResult> pageResults = pages;

    //    int pageCount = 0;
    //    await foreach (ClientResult result in pageResults)
    //    {
    //        Assert.AreEqual(200, result.GetRawResponse().Status);
    //        pageCount++;
    //    }

    //    Assert.AreEqual(2, pageCount);
    //}
}
