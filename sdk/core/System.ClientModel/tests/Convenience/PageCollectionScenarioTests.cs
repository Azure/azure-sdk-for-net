// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using ClientModel.Tests.Paging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Paging;

// Scenario tests for sync and async page collections
public class PageScenarioCollectionTests
{
    // TODO: Async
    // TODO: A few more tests - from commented-out tests

    [Test]
    public void CanGetAllValues()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues();
        IEnumerable<ValueItem> values = pages.GetAllValues();

        int count = 0;
        foreach (ValueItem value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanGetCurrentPage()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues();
        PageResult<ValueItem> page = pages.GetCurrentPage();

        Assert.AreEqual(MockPagingData.DefaultPageSize, page.Values.Count);
        Assert.AreEqual(0, page.Values[0].Id);
    }

    [Test]
    public void CanGetCurrentPageThenGetAllItems()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues();

        PageResult<ValueItem> page = pages.GetCurrentPage();

        Assert.AreEqual(MockPagingData.DefaultPageSize, page.Values.Count);
        Assert.AreEqual(0, page.Values[0].Id);

        IEnumerable<ValueItem> values = pages.GetAllValues();

        int count = 0;
        foreach (ValueItem value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanGetCurrentPageWhileEnumeratingItems()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues();

        IEnumerable<ValueItem> values = pages.GetAllValues();

        int count = 0;
        foreach (ValueItem value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;

            PageResult<ValueItem> page = pages.GetCurrentPage();

            // Validate that the current item is in range of the page values
            Assert.GreaterOrEqual(value.Id, page.Values[0].Id);
            Assert.LessOrEqual(value.Id, page.Values[page.Values.Count - 1].Id);
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanRehydratePageCollection()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues();
        PageResult<ValueItem> page = pages.GetCurrentPage();

        ContinuationToken pageToken = page.PageToken;

        PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
        PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

        Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

        List<ValueItem> allValues = pages.GetAllValues().ToList();
        List<ValueItem> allRehydratedValues = rehydratedPages.GetAllValues().ToList();

        for (int i = 0; i < allValues.Count; i++)
        {
            Assert.AreEqual(allValues[i].Id, allRehydratedValues[i].Id);
        }
    }

    [Test]
    public void CanCastToConvenienceFromProtocol()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);

        // Call the protocol method on the convenience client.
        IEnumerable<ClientResult> pageResults = client.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        // Cast to convience type from protocol return value.
        PageCollection<ValueItem> pages = (PageCollection<ValueItem>)pageResults;

        IEnumerable<ValueItem> values = pages.GetAllValues();

        int count = 0;
        foreach (ValueItem value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanReorderItemsAndRehydrate()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        string order = "desc";
        Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues(order: order);
        PageResult<ValueItem> page = pages.GetCurrentPage();

        ContinuationToken pageToken = page.PageToken;

        PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
        PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

        Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

        // We got the last one first from both pages
        Assert.AreEqual(MockPagingData.Count - 1, page.Values[0].Id);
        Assert.AreEqual(MockPagingData.Count - 1, rehydratedPage.Values[0].Id);
    }

    [Test]
    public void CanChangePageSizeAndRehydrate()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        int pageSize = 4;
        Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues(pageSize: pageSize);
        PageResult<ValueItem> page = pages.GetCurrentPage();

        ContinuationToken pageToken = page.PageToken;

        PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
        PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

        // Both pages have same non-default page size
        Assert.AreEqual(pageSize, page.Values.Count);
        Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    }

    [Test]
    public void CanSkipItemsAndRehydrate()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        int offset = 4;
        Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues(offset: offset);
        PageResult<ValueItem> page = pages.GetCurrentPage();

        ContinuationToken pageToken = page.PageToken;

        PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
        PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

        Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

        // Both pages have the same non-default offset value
        Assert.AreEqual(offset, page.Values[0].Id);
        Assert.AreEqual(offset, rehydratedPage.Values[0].Id);
    }

    [Test]
    public void CanChangeAllCollectionParametersAndRehydrate()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        string order = "desc";
        Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

        int pageSize = 4;
        Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

        int offset = 4;
        Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

        PagingClient client = new PagingClient(options);
        PageCollection<ValueItem> pages = client.GetValues(order, pageSize, offset);
        PageResult<ValueItem> page = pages.GetCurrentPage();

        ContinuationToken pageToken = page.PageToken;

        PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
        PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

        // Both page collections and first page are the same on each dimension

        // Last one first and same items skipped
        Assert.AreEqual(11, page.Values[0].Id);
        Assert.AreEqual(11, rehydratedPage.Values[0].Id);

        // Equal page size
        Assert.AreEqual(pageSize, page.Values.Count);
        Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    }

    //[Test]
    //public void CanEnumeratePages()
    //{
    //    List<int> values = new() { 0, 1, 2, 3 };
    //    int pageSize = 2;

    //    List<ClientResult> mockResults = new() {
    //        new MockClientResult(new MockPipelineResponse(0)),
    //        new MockClientResult(new MockPipelineResponse(1))
    //    };

    //    PageCollection<int> pages = new MockPageCollection<int>(values, mockResults, pageSize);

    //    int i = 0;
    //    foreach (PageResult<int> page in pages)
    //    {
    //        Assert.AreEqual(i++, page.Values[0]);
    //        Assert.AreEqual(i++, page.Values[1]);
    //    }

    //    Assert.AreEqual(4, i);
    //}

    //[Test]
    //public void CanEnumerateClientResults()
    //{
    //    List<ClientResult> mockResults = new() {
    //        new MockClientResult(new MockPipelineResponse(0)),
    //        new MockClientResult(new MockPipelineResponse(1))
    //    };

    //    IEnumerable<ClientResult> results = new ProtocolMockPageCollection(mockResults);

    //    int i = 0;
    //    foreach (ClientResult result in results)
    //    {
    //        Assert.AreEqual(i++, result.GetRawResponse().Status);
    //    }

    //    Assert.AreEqual(2, i);
    //}

    //[Test]
    //public void CanEvolveFromProtocol()
    //{
    //    List<int> values = new() { 0, 1, 2, 3 };
    //    int pageSize = 2;

    //    List<ClientResult> mockResults = new() {
    //        new MockClientResult(new MockPipelineResponse(0)),
    //        new MockClientResult(new MockPipelineResponse(1))
    //    };

    //    // Showing that we can use the same code as protocol-only
    //    // with a convenience return type.
    //    IEnumerable<ClientResult> results = new MockPageCollection<int>(values, mockResults, pageSize);

    //    int i = 0;
    //    foreach (ClientResult result in results)
    //    {
    //        Assert.AreEqual(i++, result.GetRawResponse().Status);
    //    }

    //    Assert.AreEqual(2, i);
    //}

    //private static readonly string[] MockPageContents = { """
    //        [
    //            { "intValue" : 0, "stringValue" : "0" },
    //            { "intValue" : 1, "stringValue" : "1" },
    //            { "intValue" : 2, "stringValue" : "2" }
    //        ]
    //        ""","""
    //        [
    //            { "intValue" : 3, "stringValue" : "3" },
    //            { "intValue" : 4, "stringValue" : "4" },
    //            { "intValue" : 5, "stringValue" : "5" }
    //        ]
    //        ""","""
    //        [
    //            { "intValue" : 6, "stringValue" : "6" },
    //            { "intValue" : 7, "stringValue" : "7" },
    //            { "intValue" : 8, "stringValue" : "8" }
    //        ]
    //        """,
    //    };

    //private static readonly int PageCount = MockPageContents.Length;
    //private static readonly int ItemCount = 9;

    //[Test]
    //public void CanEnumerateValues()
    //{
    //    MockPageableClient client = new();
    //    PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

    //    int i = 0;
    //    foreach (MockJsonModel model in models)
    //    {
    //        Assert.AreEqual(i, model.IntValue);
    //        Assert.AreEqual(i.ToString(), model.StringValue);

    //        i++;
    //    }

    //    Assert.AreEqual(ItemCount, i);
    //}

    //[Test]
    //public void CanEnumeratePages()
    //{
    //    MockPageableClient client = new();
    //    PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

    //    int pageCount = 0;
    //    int itemCount = 0;
    //    foreach (ResultPage<MockJsonModel> page in models.AsPages())
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(itemCount, model.IntValue);
    //            Assert.AreEqual(itemCount.ToString(), model.StringValue);

    //            itemCount++;
    //        }

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, itemCount);
    //    Assert.AreEqual(PageCount, pageCount);
    //}

    //[Test]
    //public void CanStartPageEnumerationMidwayThrough()
    //{
    //    MockPageableClient client = new();
    //    PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

    //    int pageCount = 0;
    //    int i = 6;

    //    // Request just the last page by starting at the last seen value
    //    // on the prior page -- i.e. item 5.
    //    foreach (ResultPage<MockJsonModel> page in models.AsPages(continuationToken: "5"))
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(i, model.IntValue);
    //            Assert.AreEqual(i.ToString(), model.StringValue);

    //            i++;
    //        }

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, i);
    //    Assert.AreEqual(1, pageCount);
    //}

    //[Test]
    //public void CanSetPageSizeHint()
    //{
    //    MockPageableClient client = new();
    //    PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);
    //    var pages = models.AsPages(pageSizeHint: 10);
    //    foreach (var _ in pages)
    //    {
    //        // page size hint is ignored in this mock
    //    }

    //    Assert.AreEqual(10, client.RequestedPageSize);
    //}

    //[Test]
    //public void CanGetRawResponses()
    //{
    //    MockPageableClient client = new();
    //    PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

    //    int pageCount = 0;
    //    int itemCount = 0;
    //    foreach (ResultPage<MockJsonModel> page in models.AsPages())
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(itemCount, model.IntValue);
    //            Assert.AreEqual(itemCount.ToString(), model.StringValue);

    //            itemCount++;
    //        }

    //        PipelineResponse collectionResponse = models.GetRawResponse();
    //        PipelineResponse pageResponse = page.GetRawResponse();

    //        Assert.AreEqual(pageResponse, collectionResponse);
    //        Assert.AreEqual(MockPageContents[pageCount], pageResponse.Content.ToString());
    //        Assert.AreEqual(MockPageContents[pageCount], collectionResponse.Content.ToString());

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, itemCount);
    //    Assert.AreEqual(PageCount, pageCount);
    //}

    //[Test]
    //public async Task CanEnumerateValuesAsync()
    //{
    //    MockPageableClient client = new();
    //    AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

    //    int i = 0;
    //    await foreach (MockJsonModel model in models)
    //    {
    //        Assert.AreEqual(i, model.IntValue);
    //        Assert.AreEqual(i.ToString(), model.StringValue);

    //        i++;
    //    }

    //    Assert.AreEqual(ItemCount, i);
    //}

    //[Test]
    //public async Task CanEnumeratePagesAsync()
    //{
    //    MockPageableClient client = new();
    //    AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

    //    int pageCount = 0;
    //    int itemCount = 0;
    //    await foreach (ResultPage<MockJsonModel> page in models.AsPages())
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(itemCount, model.IntValue);
    //            Assert.AreEqual(itemCount.ToString(), model.StringValue);

    //            itemCount++;
    //        }

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, itemCount);
    //    Assert.AreEqual(PageCount, pageCount);
    //}

    //[Test]
    //public async Task CanStartPageEnumerationMidwayThroughAsync()
    //{
    //    MockPageableClient client = new();
    //    AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

    //    int pageCount = 0;
    //    int i = 6;

    //    // Request just the last page by starting at the last seen value
    //    // on the prior page -- i.e. item 5.
    //    await foreach (ResultPage<MockJsonModel> page in models.AsPages(continuationToken: "5"))
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(i, model.IntValue);
    //            Assert.AreEqual(i.ToString(), model.StringValue);

    //            i++;
    //        }

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, i);
    //    Assert.AreEqual(1, pageCount);
    //}

    //[Test]
    //public async Task CanSetPageSizeHintAsync()
    //{
    //    MockPageableClient client = new();
    //    AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);
    //    var pages = models.AsPages(pageSizeHint: 10);
    //    await foreach (var _ in pages)
    //    {
    //        // page size hint is ignored in this mock
    //    }

    //    Assert.AreEqual(10, client.RequestedPageSize);
    //}

    //[Test]
    //public async Task CanGetRawResponsesAsync()
    //{
    //    MockPageableClient client = new();
    //    AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

    //    int pageCount = 0;
    //    int itemCount = 0;
    //    await foreach (ResultPage<MockJsonModel> page in models.AsPages())
    //    {
    //        foreach (MockJsonModel model in page)
    //        {
    //            Assert.AreEqual(itemCount, model.IntValue);
    //            Assert.AreEqual(itemCount.ToString(), model.StringValue);

    //            itemCount++;
    //        }

    //        PipelineResponse collectionResponse = models.GetRawResponse();
    //        PipelineResponse pageResponse = page.GetRawResponse();

    //        Assert.AreEqual(pageResponse, collectionResponse);
    //        Assert.AreEqual(MockPageContents[pageCount], pageResponse.Content.ToString());
    //        Assert.AreEqual(MockPageContents[pageCount], collectionResponse.Content.ToString());

    //        pageCount++;
    //    }

    //    Assert.AreEqual(ItemCount, itemCount);
    //    Assert.AreEqual(PageCount, pageCount);
    //}

    #region Helpers

    internal class ProtocolMockPageCollection : IEnumerable<ClientResult>
    {
        private readonly List<ClientResult> _results;

        public ProtocolMockPageCollection(List<ClientResult> results)
        {
            _results = results;
        }

        public IEnumerator<ClientResult> GetEnumerator()
        {
            foreach (ClientResult result in _results)
            {
                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion
}
