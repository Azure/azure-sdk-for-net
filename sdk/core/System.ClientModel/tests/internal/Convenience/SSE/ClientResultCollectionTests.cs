// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Internal.Mocks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Convenience;

public class ClientResultCollectionTests : SyncAsyncTestBase
{
    public ClientResultCollectionTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanEnumerateBinaryDataValues()
    {
        MockSseClient client = new();
        ClientResult result = client.GetModelsStreamingAsync(_mockContent, new RequestOptions());

        int i = 0;
        await foreach (BinaryData data in result.GetRawResponse().EnumerateDataEvents())
        {
            MockJsonModel model = data.ToObjectFromJson<MockJsonModel>();

            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public void BinaryDataCollectionThrowsIfCancelled()
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
    public async Task CanDelaySendingRequest()
    {
        MockSseClient client = new();
        AsyncResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

        Assert.IsFalse(client.ProtocolMethodCalled);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
        Assert.IsTrue(client.ProtocolMethodCalled);
    }

    [Test]
    public async Task CreatesAsyncResultCollection()
    {
        MockSseClient client = new();
        AsyncResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync("[DONE]");

        bool empty = true;
        await foreach (MockJsonModel model in models)
        {
            empty = false;
        }

        Assert.IsNotNull(models);
        Assert.AreEqual(models.GetRawResponse().Content.ToString(), "[DONE]");
        Assert.IsTrue(empty);
    }

    [Test]
    public async Task CanEnumerateModelValues()
    {
        MockSseClient client = new();
        AsyncResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public void ModelCollectionThrowsIfCancelled()
    {
        MockSseClient client = new();
        AsyncResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

        // Set it to `cancelled: true` to validate functionality.
        CancellationToken token = new(true);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (MockJsonModel model in models.WithCancellation(token))
            {
            }
        });
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
