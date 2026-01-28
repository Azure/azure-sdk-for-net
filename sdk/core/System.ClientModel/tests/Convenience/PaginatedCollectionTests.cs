// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Scenario tests for sync and async paginated collections.
/// These tests use a reference implementation of a client that calls paginated
/// service endpoints.
/// </summary>
public class PaginatedCollectionTests
{
    // Tests:
    //  1. Protocol/Sync
    //    a. Can enumerate pages
    //    b. Can rehydrate from token
    //  2. Protocol/Async
    //    a. Can enumerate pages
    //    b. Can rehydrate from token
    //  3. Convenience/Sync
    //    a. Can enumerate Ts
    //    b. Can cancel with single cancellation token
    //    c. Can evolve from protocol
    //  4. Convenience/Async
    //    a. Can enumerate Ts
    //    b. Can cancel with either of two cancellation tokens
    //    c. Can evolve from protocol

    [Test]
    public void CanEnumerateRawPages()
    {
        ProtocolPaginatedCollectionClient client = new();

        CollectionResult valueCollection = client.GetValues();
        IEnumerable<ClientResult> pages = valueCollection.GetRawPages();

        int expectedValueId = 0;
        int pageCount = 0;
        foreach (ClientResult page in pages)
        {
            PipelineResponse response = page.GetRawResponse();
            ValueItemPage conveniencePage = ValueItemPage.FromJson(response.Content);

            Assert.That(conveniencePage.Values.Count, Is.EqualTo(MockPageResponseData.DefaultPageSize));
            Assert.That(conveniencePage.Values[0].Id, Is.EqualTo(expectedValueId));

            pageCount++;
            expectedValueId += MockPageResponseData.DefaultPageSize;
        }

        Assert.That(pageCount, Is.EqualTo(MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize));
    }

    [Test]
    public void CanRehydrateCollection()
    {
        ProtocolPaginatedCollectionClient client = new();

        CollectionResult valueCollection = client.GetValues();
        List<ClientResult> pages = valueCollection.GetRawPages().ToList();
        ClientResult firstPage = pages[0];

        ContinuationToken? nextPageToken = valueCollection.GetContinuationToken(firstPage);
        CollectionResult rehydratedCollection = client.GetValues(nextPageToken!);

        List<ClientResult> rehydratedPages = rehydratedCollection.GetRawPages().ToList();

        int totalPageCount = MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize;
        int rehydratedPageCount = 0;
        for (int i = 1; i < totalPageCount; i++)
        {
            ClientResult originalPageResult = pages[i];
            ClientResult rehydratedPageResult = rehydratedPages[i - 1];

            ValueItemPage originalPage = ValueItemPage.FromJson(originalPageResult.GetRawResponse().Content);
            ValueItemPage rehydratedPage = ValueItemPage.FromJson(rehydratedPageResult.GetRawResponse().Content);

            Assert.That(rehydratedPage.Values.Count, Is.EqualTo(originalPage.Values.Count));
            Assert.That(rehydratedPage.Values[0].Id, Is.EqualTo(originalPage.Values[0].Id));

            rehydratedPageCount++;
        }

        Assert.That(rehydratedPageCount, Is.EqualTo(totalPageCount - 1));
    }

    [Test]
    public async Task CanEnumerateRawPagesAsync()
    {
        ProtocolPaginatedCollectionClient client = new();

        AsyncCollectionResult valueCollection = client.GetValuesAsync();
        IAsyncEnumerable<ClientResult> pages = valueCollection.GetRawPagesAsync();

        int expectedValueId = 0;
        int pageCount = 0;
        await foreach (ClientResult page in pages)
        {
            PipelineResponse response = page.GetRawResponse();
            ValueItemPage conveniencePage = ValueItemPage.FromJson(response.Content);

            Assert.That(conveniencePage.Values.Count, Is.EqualTo(MockPageResponseData.DefaultPageSize));
            Assert.That(conveniencePage.Values[0].Id, Is.EqualTo(expectedValueId));

            pageCount++;
            expectedValueId += MockPageResponseData.DefaultPageSize;
        }

        Assert.That(pageCount, Is.EqualTo(MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize));
    }

    [Test]
    public async Task CanRehydrateCollectionAsync()
    {
        ProtocolPaginatedCollectionClient client = new();

        AsyncCollectionResult valueCollection = client.GetValuesAsync();
        List<ClientResult> pages = await valueCollection.GetRawPagesAsync().ToListAsync();
        ClientResult firstPage = pages[0];

        ContinuationToken? nextPageToken = valueCollection.GetContinuationToken(firstPage);
        AsyncCollectionResult rehydratedCollection = client.GetValuesAsync(nextPageToken!);

        List<ClientResult> rehydratedPages = await rehydratedCollection.GetRawPagesAsync().ToListAsync();

        int totalPageCount = MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize;
        int rehydratedPageCount = 0;
        for (int i = 1; i < totalPageCount; i++)
        {
            ClientResult originalPageResult = pages[i];
            ClientResult rehydratedPageResult = rehydratedPages[i - 1];

            ValueItemPage originalPage = ValueItemPage.FromJson(originalPageResult.GetRawResponse().Content);
            ValueItemPage rehydratedPage = ValueItemPage.FromJson(rehydratedPageResult.GetRawResponse().Content);

            Assert.That(rehydratedPage.Values.Count, Is.EqualTo(originalPage.Values.Count));
            Assert.That(rehydratedPage.Values[0].Id, Is.EqualTo(originalPage.Values[0].Id));

            rehydratedPageCount++;
        }

        Assert.That(rehydratedPageCount, Is.EqualTo(totalPageCount - 1));
    }

    [Test]
    public void CanEnumerateValues()
    {
        PaginatedCollectionClient client = new();
        CollectionResult<ValueItem> values = client.GetValues();

        int count = 0;
        foreach (ValueItem value in values)
        {
            Assert.That(value.Id, Is.EqualTo(count));
            count++;
        }

        Assert.That(count, Is.EqualTo(MockPageResponseData.TotalItemCount));
    }

    [Test]
    public void CanCancelViaServiceMethodCancellationToken()
    {
        using CancellationTokenSource cts = new();
        cts.Cancel();

        PaginatedCollectionClient client = new();
        CollectionResult<ValueItem> values = client.GetValues(cancellationToken: cts.Token);

        Assert.Throws<OperationCanceledException>(() => values.First());
    }

    [Test]
    public void CanEvolveFromProtocolLayer()
    {
        // This tests validates that user code doesn't break when convenience
        // methods are added.  We show this by illustrating that code written
        // at the protocol layer continues to work the same way when using a
        // client that has only protocol methods and when using client that has
        // both convenience and protocol methods.

        static bool Validate(CollectionResult valueCollection)
        {
            IEnumerable<ClientResult> pages = valueCollection.GetRawPages();

            int expectedValueId = 0;
            int pageCount = 0;
            foreach (ClientResult page in pages)
            {
                PipelineResponse response = page.GetRawResponse();
                ValueItemPage conveniencePage = ValueItemPage.FromJson(response.Content);

                Assert.That(conveniencePage.Values.Count, Is.EqualTo(MockPageResponseData.DefaultPageSize));
                Assert.That(conveniencePage.Values[0].Id, Is.EqualTo(expectedValueId));

                pageCount++;
                expectedValueId += MockPageResponseData.DefaultPageSize;
            }

            Assert.That(pageCount, Is.EqualTo(MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize));
            return true;
        }

        // Protocol client (v1) code
        ProtocolPaginatedCollectionClient protocolClient = new();
        CollectionResult protocolCollection = protocolClient.GetValues();

        // Convenience client (v2) code
        PaginatedCollectionClient convenienceClient = new();
        CollectionResult convenienceCollection = convenienceClient.GetValues();

        Assert.That(Validate(protocolCollection), Is.True);
        Assert.That(Validate(convenienceCollection), Is.True);
    }

    [Test]
    public void CanCastFromProtocolToConvenienceReturnType()
    {
        PaginatedCollectionClient client = new();

        // Call protocol method
        CollectionResult protocolCollection = client.GetValues(pageSize: default, new RequestOptions());

        // Cast to convenience method
        CollectionResult<ValueItem> convenienceCollection = (CollectionResult<ValueItem>)protocolCollection;

        int count = 0;
        foreach (ValueItem value in convenienceCollection)
        {
            Assert.That(value.Id, Is.EqualTo(count));
            count++;
        }

        Assert.That(count, Is.EqualTo(MockPageResponseData.TotalItemCount));
    }

    [Test]
    public async Task CanEnumerateValuesAsync()
    {
        PaginatedCollectionClient client = new();
        AsyncCollectionResult<ValueItem> values = client.GetValuesAsync();

        int count = 0;
        await foreach (ValueItem value in values)
        {
            Assert.That(value.Id, Is.EqualTo(count));
            count++;
        }

        Assert.That(count, Is.EqualTo(MockPageResponseData.TotalItemCount));
    }

    [Test]
    public void CanCancelViaServiceMethodCancellationTokenAsync()
    {
        using CancellationTokenSource cts = new();
        cts.Cancel();

        PaginatedCollectionClient client = new();
        AsyncCollectionResult<ValueItem> values = client.GetValuesAsync(cancellationToken: cts.Token);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await values.FirstAsync());
    }

    [Test]
    public async Task CanCancelViaAsyncEnumerableCancellationTokenAsync()
    {
        using CancellationTokenSource cts = new();
        cts.Cancel();

        PaginatedCollectionClient client = new();
        AsyncCollectionResult<ValueItem> values = client.GetValuesAsync();

        bool threwException = false;
        try
        {
            await foreach (ValueItem value in values.WithCancellation(cts.Token))
            {
            }
        }
        catch (OperationCanceledException)
        {
            threwException = true;
        }

        Assert.That(threwException, Is.True);
    }

    [Test]
    public async Task CanEvolveFromProtocolLayerAsync()
    {
        // This tests validates that user code doesn't break when convenience
        // methods are added.  We show this by illustrating that code written
        // at the protocol layer continues to work the same way when using a
        // client that has only protocol methods and when using client that has
        // both convenience and protocol methods.

        static async Task<bool> ValidateAsync(AsyncCollectionResult valueCollection)
        {
            IAsyncEnumerable<ClientResult> pages = valueCollection.GetRawPagesAsync();

            int expectedValueId = 0;
            int pageCount = 0;
            await foreach (ClientResult page in pages)
            {
                PipelineResponse response = page.GetRawResponse();
                ValueItemPage conveniencePage = ValueItemPage.FromJson(response.Content);

                Assert.That(conveniencePage.Values.Count, Is.EqualTo(MockPageResponseData.DefaultPageSize));
                Assert.That(conveniencePage.Values[0].Id, Is.EqualTo(expectedValueId));

                pageCount++;
                expectedValueId += MockPageResponseData.DefaultPageSize;
            }

            Assert.That(pageCount, Is.EqualTo(MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize));
            return true;
        }

        // Protocol client (v1) code
        ProtocolPaginatedCollectionClient protocolClient = new();
        AsyncCollectionResult protocolCollection = protocolClient.GetValuesAsync();

        // Convenience client (v2) code
        PaginatedCollectionClient convenienceClient = new();
        AsyncCollectionResult convenienceCollection = convenienceClient.GetValuesAsync();

        Assert.That(await ValidateAsync(protocolCollection), Is.True);
        Assert.That(await ValidateAsync(convenienceCollection), Is.True);
    }

    [Test]
    public async Task CanCastFromProtocolToConvenienceReturnTypeAsync()
    {
        PaginatedCollectionClient client = new();

        // Call protocol method
        AsyncCollectionResult protocolCollection = client.GetValuesAsync(pageSize: default, new RequestOptions());

        // Cast to convenience method
        AsyncCollectionResult<ValueItem> convenienceCollection = (AsyncCollectionResult<ValueItem>)protocolCollection;

        int count = 0;
        await foreach (ValueItem value in convenienceCollection)
        {
            Assert.That(value.Id, Is.EqualTo(count));
            count++;
        }

        Assert.That(count, Is.EqualTo(MockPageResponseData.TotalItemCount));
    }

    [Test]
    public async Task CanGetDataInPagesFromTestService()
    {
        List<ValueItemPage> pages = MockPageResponseData.GetPages().ToList();
        int pageIndex = 0;

        using TestServer testServer = new(
            async context =>
            {
                ValueItemPage page = pages[pageIndex++];
                byte[] content = page.ToJson().ToArray();

                context.Response.StatusCode = 200;
                await context.Response.Body.WriteAsync(content, 0, content.Length);
            });

        ClientPipeline pipeline = ClientPipeline.Create();

        int pageCount = 0;
        ValueItemPage valuePage = default!;
        do
        {
            using PipelineMessage message = pipeline.CreateMessage();
            message.Request.Uri = testServer.Address;

            await pipeline.SendAsync(message);

            PipelineResponse response = message.Response!;
            valuePage = ValueItemPage.FromJson(response.Content);

            Assert.That(valuePage.Values.Count, Is.EqualTo(MockPageResponseData.DefaultPageSize));

            pageCount++;
        }
        while (valuePage.HasMore);

        Assert.That(pageCount, Is.EqualTo(MockPageResponseData.TotalItemCount / MockPageResponseData.DefaultPageSize));
    }
}
