// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using ClientModel.Tests.Paging;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Scenario tests for sync and async page collections.
/// </summary>
public class PageScenarioCollectionTests
{
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
    public async Task CanRehydratePageCollectionAsync()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        AsyncPageCollection<ValueItem> pages = client.GetValuesAsync();
        PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

        ContinuationToken pageToken = page.PageToken;

        AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
        PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

        Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

        List<ValueItem> allValues = await pages.GetAllValuesAsync().ToListAsync();
        List<ValueItem> allRehydratedValues = await rehydratedPages.GetAllValuesAsync().ToListAsync();

        for (int i = 0; i < allValues.Count; i++)
        {
            Assert.AreEqual(allValues[i].Id, allRehydratedValues[i].Id);
        }
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
    public async Task CanReorderItemsAndRehydrateAsync()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        string order = "desc";
        Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

        PagingClient client = new PagingClient(options);
        AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(order: order);
        PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

        ContinuationToken pageToken = page.PageToken;

        AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
        PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

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
    public async Task CanChangePageSizeAndRehydrateAsync()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        int pageSize = 4;
        Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

        PagingClient client = new PagingClient(options);
        AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(pageSize: pageSize);
        PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

        ContinuationToken pageToken = page.PageToken;

        AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
        PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

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
    public async Task CanSkipItemsAndRehydrateAsync()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        int offset = 4;
        Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

        PagingClient client = new PagingClient(options);
        AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(offset: offset);
        PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

        ContinuationToken pageToken = page.PageToken;

        AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
        PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

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

        // Both page collections and first pages are the same on each dimension

        // Collections have same non-default number of pages.
        Assert.AreEqual(3, pages.Count());
        Assert.AreEqual(3, rehydratedPages.Count());

        // Last one first and same items skipped
        Assert.AreEqual(11, page.Values[0].Id);
        Assert.AreEqual(11, rehydratedPage.Values[0].Id);

        // Equal page size
        Assert.AreEqual(pageSize, page.Values.Count);
        Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    }

    [Test]
    public async Task CanChangeAllCollectionParametersAndRehydrateAsync()
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
        AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(order, pageSize, offset);
        PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

        ContinuationToken pageToken = page.PageToken;

        AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
        PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

        // Both page collections and first pages are the same on each dimension

        // Collections have same non-default number of pages.
        Assert.AreEqual(3, await pages.CountAsync());
        Assert.AreEqual(3, await rehydratedPages.CountAsync());

        // Last one first and same items skipped
        Assert.AreEqual(11, page.Values[0].Id);
        Assert.AreEqual(11, rehydratedPage.Values[0].Id);

        // Equal page size
        Assert.AreEqual(pageSize, page.Values.Count);
        Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
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
    public async Task CanCastToConvenienceFromProtocolAsync()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);

        // Call the protocol method on the convenience client.
        IAsyncEnumerable<ClientResult> pageResults = client.GetValuesAsync(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        // Cast to convience type from protocol return value.
        AsyncPageCollection<ValueItem> pages = (AsyncPageCollection<ValueItem>)pageResults;

        IAsyncEnumerable<ValueItem> values = pages.GetAllValuesAsync();

        int count = 0;
        await foreach (ValueItem value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanEvolveFromProtocol()
    {
        // This scenario tests validates that user code doesn't break when
        // convenience methods are added.  We show this by illustrating that
        // exactly the same code works the same way when using a client that
        // has only protocol methods and a client that has the same protocol
        // methods and also convenience methods.

        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        static void Validate(IEnumerable<ClientResult> results)
        {
            int pageCount = 0;
            foreach (ClientResult result in results)
            {
                Assert.AreEqual(200, result.GetRawResponse().Status);
                pageCount++;
            }

            Assert.AreEqual(MockPagingData.Count / MockPagingData.DefaultPageSize, pageCount);
        }

        // Protocol code
        PagingProtocolClient protocolClient = new PagingProtocolClient(options);
        IEnumerable<ClientResult> pageResults = protocolClient.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        Validate(pageResults);

        // Convenience code
        PagingClient convenienceClient = new PagingClient(options);
        IEnumerable<ClientResult> pages = convenienceClient.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        Validate(pages);
    }

    [Test]
    public async Task CanEvolveFromProtocolAsync()
    {
        // This scenario tests validates that user code doesn't break when
        // convenience methods are added.  We show this by illustrating that
        // exactly the same code works the same way when using a client that
        // has only protocol methods and a client that has the same protocol
        // methods and also convenience methods.

        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        static async Task ValidateAsync(IAsyncEnumerable<ClientResult> results)
        {
            int pageCount = 0;
            await foreach (ClientResult result in results)
            {
                Assert.AreEqual(200, result.GetRawResponse().Status);
                pageCount++;
            }

            Assert.AreEqual(MockPagingData.Count / MockPagingData.DefaultPageSize, pageCount);
        }

        // Protocol code
        PagingProtocolClient protocolClient = new PagingProtocolClient(options);
        IAsyncEnumerable<ClientResult> pageResults = protocolClient.GetValuesAsync(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        await ValidateAsync(pageResults);

        // Convenience code
        PagingClient convenienceClient = new PagingClient(options);
        IAsyncEnumerable<ClientResult> pages = convenienceClient.GetValuesAsync(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        await ValidateAsync(pages);
    }
}
