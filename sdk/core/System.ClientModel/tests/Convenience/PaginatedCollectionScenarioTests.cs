// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using ClientModel.Tests.Paging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Scenario tests for sync and async page collections.
/// </summary>
public class PaginatedCollectionScenarioTests
{
    [Test]
    public void CanGetValuesFromConvenienceMethod()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        CollectionResult<ValueItem> valueItems = client.GetValues();

        int count = 0;
        foreach (ValueItem item in valueItems)
        {
            Assert.AreEqual(count, item.Id);
            Assert.AreEqual(count.ToString(), item.Value);

            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanGetRawValuesFromProtocolMethod()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);
        CollectionResult collectionResult = client.GetValues(
                order: default,
                pageSize: default,
                offset: default,
                new RequestOptions());

        IEnumerable<ClientResult> rawPages = collectionResult.GetRawPages();

        int count = 0;

        // At the protocol layer, user must parse values from pages themselves.
        // The below uses conveniences in the test code to do that to simplify
        // the test implementation.

        foreach (ClientResult pageResult in rawPages)
        {
            ValueItemPage page = ValueItemPage.FromJson(pageResult.GetRawResponse().Content);
            foreach (ValueItem item in page.Values)
            {
                Assert.AreEqual(count, item.Id);
                Assert.AreEqual(count.ToString(), item.Value);

                count++;
            }
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    [Test]
    public void CanRehydratePaginatedCollection()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        // TODO: think about what this looks like if you enumerate
        // at both the convenience and protocol layer -- i.e. try to
        // use the convenience collection and then get the continuation token

        PagingClient client = new PagingClient(options);
        CollectionResult<ValueItem> values = client.GetValues();
        ClientResult rawPage = values.GetRawPages().First();
        ContinuationToken continuationToken = values.GetContinuationToken(rawPage)!;

        Assert.IsNotNull(continuationToken);

        CollectionResult<ValueItem> rehydratedValues = client.GetValues(continuationToken);

        List<ValueItem> remainingValues = values.ToList();
        List<ValueItem> remainingRehydratedValues = rehydratedValues.ToList();

        Assert.AreEqual(remainingValues.Count, remainingRehydratedValues.Count);

        for (int i = 0; i < remainingValues.Count; i++)
        {
            Assert.AreEqual(remainingValues[i].Id, remainingRehydratedValues[i].Id);
        }
    }

    //[Test]
    //public async Task CanRehydratePageCollectionAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    PagingClient client = new PagingClient(options);
    //    AsyncPageCollection<ValueItem> pages = client.GetValuesAsync();
    //    PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

    //    ContinuationToken pageToken = page.PageToken;

    //    AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
    //    PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

    //    Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

    //    List<ValueItem> allValues = await pages.GetAllValuesAsync().ToListAsync();
    //    List<ValueItem> allRehydratedValues = await rehydratedPages.GetAllValuesAsync().ToListAsync();

    //    for (int i = 0; i < allValues.Count; i++)
    //    {
    //        Assert.AreEqual(allValues[i].Id, allRehydratedValues[i].Id);
    //    }
    //}

    [Test]
    public void RehydrationPreservesOrdering()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        string order = "desc";
        Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

        // TODO: revisit per two enumerators

        PagingClient client = new PagingClient(options);
        CollectionResult<ValueItem> values = client.GetValues(order: order);
        ClientResult rawPage = values.GetRawPages().First();
        ContinuationToken continuationToken = values.GetContinuationToken(rawPage)!;

        Assert.IsNotNull(continuationToken);

        CollectionResult<ValueItem> rehydratedValues = client.GetValues(continuationToken);

        List<ValueItem> remainingValues = values.ToList();
        List<ValueItem> remainingRehydratedValues = rehydratedValues.ToList();

        Assert.AreEqual(remainingValues.Count, remainingRehydratedValues.Count);

        // We got pages in the same order from both collections
        Assert.AreEqual(remainingRehydratedValues[0].Id, remainingValues[0].Id);
    }

    //[Test]
    //public async Task CanReorderItemsAndRehydrateAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    string order = "desc";
    //    Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

    //    PagingClient client = new PagingClient(options);
    //    AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(order: order);
    //    PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

    //    ContinuationToken pageToken = page.PageToken;

    //    AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
    //    PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

    //    Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

    //    // We got the last one first from both pages
    //    Assert.AreEqual(MockPagingData.Count - 1, page.Values[0].Id);
    //    Assert.AreEqual(MockPagingData.Count - 1, rehydratedPage.Values[0].Id);
    //}

    // TODO: come back to this one
    //[Test]
    //public void RehydrationPreservesPagesSize()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    int pageSize = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

    //    PagingClient client = new PagingClient(options);
    //    CollectionResult values = client.GetValues(pageSize: pageSize);
    //    List<ClientResult> rawPages = values.GetRawPages().ToList();
    //    ClientResult firstPage = rawPages[0];
    //    ContinuationToken continuationToken = values.GetContinuationToken(firstPage)!;

    //    Assert.IsNotNull(continuationToken);

    //    CollectionResult rehydratedValues = client.GetValues(continuationToken);

    //    // The first page of the rehydrated collection is the second page of the
    //    // original collection.
    //    ClientResult rehydratedFirstPage = rehydratedValues.GetRawPages().First();

    //    ValueItemPage valuesPage = ValueItemPage.FromJson(rawPages[1].GetRawResponse().Content);
    //    ValueItemPage rehydratedValuesPage = ValueItemPage.FromJson(rehydratedFirstPage.GetRawResponse().Content);

    //    // Both pages have same non-default page size
    //    Assert.AreEqual(pageSize, valuesPage.Values.Count);
    //    Assert.AreEqual(pageSize, rehydratedValuesPage.Values.Count);
    //}

    //[Test]
    //public async Task CanChangePageSizeAndRehydrateAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    int pageSize = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

    //    PagingClient client = new PagingClient(options);
    //    AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(pageSize: pageSize);
    //    PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

    //    ContinuationToken pageToken = page.PageToken;

    //    AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
    //    PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

    //    // Both pages have same non-default page size
    //    Assert.AreEqual(pageSize, page.Values.Count);
    //    Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    //}

    //[Test]
    //public void CanSkipItemsAndRehydrate()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    int offset = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

    //    PagingClient client = new PagingClient(options);
    //    PageCollection<ValueItem> pages = client.GetValues(offset: offset);
    //    PageResult<ValueItem> page = pages.GetCurrentPage();

    //    ContinuationToken pageToken = page.PageToken;

    //    PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
    //    PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

    //    Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

    //    // Both pages have the same non-default offset value
    //    Assert.AreEqual(offset, page.Values[0].Id);
    //    Assert.AreEqual(offset, rehydratedPage.Values[0].Id);
    //}

    //[Test]
    //public async Task CanSkipItemsAndRehydrateAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    int offset = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

    //    PagingClient client = new PagingClient(options);
    //    AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(offset: offset);
    //    PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

    //    ContinuationToken pageToken = page.PageToken;

    //    AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
    //    PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

    //    Assert.AreEqual(page.Values.Count, rehydratedPage.Values.Count);

    //    // Both pages have the same non-default offset value
    //    Assert.AreEqual(offset, page.Values[0].Id);
    //    Assert.AreEqual(offset, rehydratedPage.Values[0].Id);
    //}

    //[Test]
    //public void CanChangeAllCollectionParametersAndRehydrate()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    string order = "desc";
    //    Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

    //    int pageSize = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

    //    int offset = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

    //    PagingClient client = new PagingClient(options);
    //    PageCollection<ValueItem> pages = client.GetValues(order, pageSize, offset);
    //    PageResult<ValueItem> page = pages.GetCurrentPage();

    //    ContinuationToken pageToken = page.PageToken;

    //    PageCollection<ValueItem> rehydratedPages = client.GetValues(pageToken);
    //    PageResult<ValueItem> rehydratedPage = rehydratedPages.GetCurrentPage();

    //    // Both page collections and first pages are the same on each dimension

    //    // Collections have same non-default number of pages.
    //    Assert.AreEqual(3, pages.Count());
    //    Assert.AreEqual(3, rehydratedPages.Count());

    //    // Last one first and same items skipped
    //    Assert.AreEqual(11, page.Values[0].Id);
    //    Assert.AreEqual(11, rehydratedPage.Values[0].Id);

    //    // Equal page size
    //    Assert.AreEqual(pageSize, page.Values.Count);
    //    Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    //}

    //[Test]
    //public async Task CanChangeAllCollectionParametersAndRehydrateAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    string order = "desc";
    //    Assert.AreNotEqual(MockPagingData.DefaultOrder, order);

    //    int pageSize = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultPageSize, pageSize);

    //    int offset = 4;
    //    Assert.AreNotEqual(MockPagingData.DefaultOffset, offset);

    //    PagingClient client = new PagingClient(options);
    //    AsyncPageCollection<ValueItem> pages = client.GetValuesAsync(order, pageSize, offset);
    //    PageResult<ValueItem> page = await pages.GetCurrentPageAsync();

    //    ContinuationToken pageToken = page.PageToken;

    //    AsyncPageCollection<ValueItem> rehydratedPages = client.GetValuesAsync(pageToken);
    //    PageResult<ValueItem> rehydratedPage = await rehydratedPages.GetCurrentPageAsync();

    //    // Both page collections and first pages are the same on each dimension

    //    // Collections have same non-default number of pages.
    //    Assert.AreEqual(3, await pages.CountAsync());
    //    Assert.AreEqual(3, await rehydratedPages.CountAsync());

    //    // Last one first and same items skipped
    //    Assert.AreEqual(11, page.Values[0].Id);
    //    Assert.AreEqual(11, rehydratedPage.Values[0].Id);

    //    // Equal page size
    //    Assert.AreEqual(pageSize, page.Values.Count);
    //    Assert.AreEqual(pageSize, rehydratedPage.Values.Count);
    //}

    [Test]
    public void CanCastToConvenienceFromProtocol()
    {
        PagingClientOptions options = new()
        {
            Transport = new MockPipelineTransport("Mock", i => 200)
        };

        PagingClient client = new PagingClient(options);

        // Call the protocol method on the convenience client.
        CollectionResult collectionResult = client.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        // Cast to convience type from protocol return value.
        CollectionResult<ValueItem> valueItems = (CollectionResult<ValueItem>)collectionResult;

        int count = 0;
        foreach (ValueItem value in valueItems)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockPagingData.Count, count);
    }

    //[Test]
    //public async Task CanCastToConvenienceFromProtocolAsync()
    //{
    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    PagingClient client = new PagingClient(options);

    //    // Call the protocol method on the convenience client.
    //    IAsyncEnumerable<ClientResult> pageResults = client.GetValuesAsync(
    //        order: default,
    //        pageSize: default,
    //        offset: default,
    //        new RequestOptions());

    //    // Cast to convience type from protocol return value.
    //    AsyncPageCollection<ValueItem> pages = (AsyncPageCollection<ValueItem>)pageResults;

    //    IAsyncEnumerable<ValueItem> values = pages.GetAllValuesAsync();

    //    int count = 0;
    //    await foreach (ValueItem value in values)
    //    {
    //        Assert.AreEqual(count, value.Id);
    //        count++;
    //    }

    //    Assert.AreEqual(MockPagingData.Count, count);
    //}

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

        static void Validate(CollectionResult collectionResult)
        {
            int pageCount = 0;
            foreach (ClientResult result in collectionResult.GetRawPages())
            {
                Assert.AreEqual(200, result.GetRawResponse().Status);
                pageCount++;
            }

            Assert.AreEqual(MockPagingData.Count / MockPagingData.DefaultPageSize, pageCount);
        }

        // Protocol code
        PagingProtocolClient protocolClient = new PagingProtocolClient(options);
        CollectionResult protoResult = protocolClient.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        Validate(protoResult);

        // Convenience layer added -- behavior calling protocol method is the same
        PagingClient convenienceClient = new PagingClient(options);
        CollectionResult convResult = convenienceClient.GetValues(
            order: default,
            pageSize: default,
            offset: default,
            new RequestOptions());

        Validate(convResult);
    }

    //[Test]
    //public async Task CanEvolveFromProtocolAsync()
    //{
    //    // This scenario tests validates that user code doesn't break when
    //    // convenience methods are added.  We show this by illustrating that
    //    // exactly the same code works the same way when using a client that
    //    // has only protocol methods and a client that has the same protocol
    //    // methods and also convenience methods.

    //    PagingClientOptions options = new()
    //    {
    //        Transport = new MockPipelineTransport("Mock", i => 200)
    //    };

    //    static async Task ValidateAsync(IAsyncEnumerable<ClientResult> results)
    //    {
    //        int pageCount = 0;
    //        await foreach (ClientResult result in results)
    //        {
    //            Assert.AreEqual(200, result.GetRawResponse().Status);
    //            pageCount++;
    //        }

    //        Assert.AreEqual(MockPagingData.Count / MockPagingData.DefaultPageSize, pageCount);
    //    }

    //    // Protocol code
    //    PagingProtocolClient protocolClient = new PagingProtocolClient(options);
    //    IAsyncEnumerable<ClientResult> pageResults = protocolClient.GetValuesAsync(
    //        order: default,
    //        pageSize: default,
    //        offset: default,
    //        new RequestOptions());

    //    await ValidateAsync(pageResults);

    //    // Convenience code
    //    PagingClient convenienceClient = new PagingClient(options);
    //    IAsyncEnumerable<ClientResult> pages = convenienceClient.GetValuesAsync(
    //        order: default,
    //        pageSize: default,
    //        offset: default,
    //        new RequestOptions());

    //    await ValidateAsync(pages);
    //}
}
