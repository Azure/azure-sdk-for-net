// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientModel.Tests.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Scenario tests for sync and async streamed collections.
/// These tests use a reference implementation of a client that calls streaming
/// service endpoints.
/// </summary>
public class StreamedCollectionTests
{
    // Tests:
    //  1. Protocol/Sync
    //    a. Can enumerate pages (only one response for now)
    //  2. Protocol/Async
    //    a. Can enumerate pages
    //  3. Convenience/Sync
    //    a. Can get values from response stream
    //    b. Response stream is disposed
    //  4. Convenience/Async
    //    a. Can get values from response stream
    //    b. Response stream is disposed

    [Test]
    public void CanEnumerateRawPages()
    {
        StreamedCollectionClient client = new();
        CollectionResult collection = client.GetValues();
        IEnumerable<ClientResult> pages = collection.GetRawPages();

        int pageCount = 0;
        foreach (ClientResult page in pages)
        {
            PipelineResponse response = page.GetRawResponse();

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(response.Content.ToString().StartsWith("event"));

            pageCount++;
        }

        Assert.AreEqual(1, pageCount);
    }

    [Test]
    public async Task CanEnumerateRawPagesAsync()
    {
        StreamedCollectionClient client = new();
        AsyncCollectionResult collection = client.GetValuesAsync();
        IAsyncEnumerable<ClientResult> pages = collection.GetRawPagesAsync();

        int pageCount = 0;
        await foreach (ClientResult page in pages)
        {
            PipelineResponse response = page.GetRawResponse();

            Assert.AreEqual(200, response.Status);
            Assert.IsTrue(response.Content.ToString().StartsWith("event"));

            pageCount++;
        }

        Assert.AreEqual(1, pageCount);
    }

    [Test]
    public void CanEnumerateValues()
    {
        StreamedCollectionClient client = new();
        CollectionResult<StreamedValue> values = client.GetValues();

        int count = 0;
        foreach (StreamedValue value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, count);
    }

    [Test]
    public void ResponseStreamIsDisposed()
    {
        StreamedCollectionClient client = new();
        StreamedValueCollectionResult? values = client.GetValues() as StreamedValueCollectionResult;

        Assert.IsNotNull(values);

        ClientResult page = values!.GetRawPages().First();
        MockStreamedResponse? response = page.GetRawResponse() as MockStreamedResponse;

        Assert.IsNotNull(response);
        Assert.IsFalse(response?.IsDisposed);

        int count = 0;
        foreach (StreamedValue value in values!.GetPageValues(page))
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.IsTrue(response?.IsDisposed);
    }

    [Test]
    public async Task CanEnumerateValuesAsync()
    {
        StreamedCollectionClient client = new();
        AsyncCollectionResult<StreamedValue> values = client.GetValuesAsync();

        int count = 0;
        await foreach (StreamedValue value in values)
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, count);
    }

    [Test]
    public async Task ResponseStreamIsDisposedAsync()
    {
        StreamedCollectionClient client = new();
        AsyncStreamedValueCollectionResult? values = client.GetValuesAsync() as AsyncStreamedValueCollectionResult;

        Assert.IsNotNull(values);

        ClientResult page = await values!.GetRawPagesAsync().FirstAsync();
        MockStreamedResponse? response = page.GetRawResponse() as MockStreamedResponse;

        Assert.IsNotNull(response);
        Assert.IsFalse(response?.IsDisposed);

        int count = 0;
        await foreach (StreamedValue value in values!.GetPageValuesAsync(page))
        {
            Assert.AreEqual(count, value.Id);
            count++;
        }

        Assert.IsTrue(response?.IsDisposed);
    }
}
