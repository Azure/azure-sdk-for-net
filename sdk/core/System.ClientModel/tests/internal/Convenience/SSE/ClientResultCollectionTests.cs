// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Internal.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Convenience;

public class ClientResultCollectionTests : SyncAsyncTestBase
{
    public ClientResultCollectionTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task EnumeratesModelValues()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync();

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public async Task ModelCollectionDelaysSendingRequest()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync();

        Assert.IsFalse(client.ProtocolMethodCalled);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(3, i);
        Assert.IsTrue(client.ProtocolMethodCalled);
    }

    [Test]
    public void ModelCollectionThrowsIfCancelled()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync();

        // Set it to `cancelled: true` to validate functionality.
        CancellationToken token = new(true);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (MockJsonModel model in models.WithCancellation(token))
            {
            }
        });
    }

    [Test]
    public async Task ModelCollectionDisposesStream()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync();

        await foreach (MockJsonModel model in models)
        {
        }

        PipelineResponse response = models.GetRawResponse();
        Assert.Throws<ObjectDisposedException>(() => { var p = response.ContentStream!.Position; });
    }

    [Test]
    public void ModelCollectionGetRawResponseThrowsBeforeEnumerated()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync();
        Assert.Throws<InvalidOperationException>(() => { PipelineResponse response = models.GetRawResponse(); });
    }

    [Test]
    public async Task StopsOnStringBasedTerminalEvent()
    {
        MockSseClient client = new();
        AsyncCollectionResult<MockJsonModel> models = client.GetModelsStreamingAsync("[DONE]");

        bool empty = true;
        await foreach (MockJsonModel model in models)
        {
            empty = false;
        }

        Assert.IsNotNull(models);
        Assert.AreEqual("[DONE]", models.GetRawResponse().Content.ToString());
        Assert.IsTrue(empty);
    }

    [Test]
    public async Task EnumeratesDataValues()
    {
        MockSseClient client = new();
        ClientResult result = client.GetModelsStreamingAsync(MockSseClient.DefaultMockContent, new RequestOptions());

        int i = 0;
        await foreach (BinaryData data in result.GetRawResponse().EnumerateDataEvents())
        {
            MockJsonModel model = data.ToObjectFromJson<MockJsonModel>();

            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(3, i);
    }

    [Test]
    public void DataCollectionThrowsIfCancelled()
    {
        MockSseClient client = new();
        ClientResult result = client.GetModelsStreamingAsync(MockSseClient.DefaultMockContent, new RequestOptions());

        // Set it to `cancelled: true` to validate functionality.
        CancellationToken token = new(true);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (BinaryData data in result.GetRawResponse().EnumerateDataEvents().WithCancellation(token))
            {
            }
        });
    }

    [Test]
    public async Task DataCollectionDoesNotDisposeStream()
    {
        MockSseClient client = new();
        ClientResult result = client.GetModelsStreamingAsync(MockSseClient.DefaultMockContent, new RequestOptions());

        await foreach (BinaryData data in result.GetRawResponse().EnumerateDataEvents())
        {
        }

        Assert.DoesNotThrow(() => { var p = result.GetRawResponse().ContentStream!.Position; });
    }
}
