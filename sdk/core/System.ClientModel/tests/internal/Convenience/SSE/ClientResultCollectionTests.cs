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
    public async Task EnumeratesDataValues()
    {
        MockSseClient client = new();
        ClientResult result = client.GetModelsStreamingAsync(_mockContent, new RequestOptions());

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
        ClientResult result = client.GetModelsStreamingAsync(_mockContent, new RequestOptions());

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
        ClientResult result = client.GetModelsStreamingAsync(_mockContent, new RequestOptions());

        await foreach (BinaryData data in result.GetRawResponse().EnumerateDataEvents())
        {
        }

        Assert.DoesNotThrow(() => { var p = result.GetRawResponse().ContentStream!.Position; });
    }

    [Test]
    public async Task EnumeratesModelValues()
    {
        MockSseClient client = new();
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

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
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

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
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

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
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

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
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);
        Assert.Throws<InvalidOperationException>(() => { PipelineResponse response = models.GetRawResponse(); });
    }

    [Test]
    public async Task StopsOnStringBasedTerminalEvent()
    {
        MockSseClient client = new();
        AsyncClientResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync("[DONE]");

        bool empty = true;
        await foreach (MockJsonModel model in models)
        {
            empty = false;
        }

        Assert.IsNotNull(models);
        Assert.AreEqual("[DONE]", models.GetRawResponse().Content.ToString());
        Assert.IsTrue(empty);
    }

    #region Helpers

    private readonly string _mockContent = """
        event: event.0
        data: { "IntValue": 0, "StringValue": "0" }

        event: event.1
        data: { "IntValue": 1, "StringValue": "1" }

        event: event.2
        data: { "IntValue": 2, "StringValue": "2" }

        event: done
        data: [DONE]


        """;

    #endregion
}
