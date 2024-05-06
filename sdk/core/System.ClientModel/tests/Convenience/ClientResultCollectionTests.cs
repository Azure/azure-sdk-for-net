// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Results;

public class ClientResultCollectionTests : SyncAsyncTestBase
{
    public ClientResultCollectionTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanEnumerateBinaryDataValues()
    {
        MockPipelineResponse response = new();
        response.SetContent(_mockContent);
        AsyncResultCollection<BinaryData> results = AsyncResultCollection<BinaryData>.Create(response);

        int i = 0;
        await foreach (BinaryData result in results)
        {
            MockJsonModel model = result.ToObjectFromJson<MockJsonModel>();

            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public void BinaryDataCollectionThrowsIfCancelled()
    {
        MockPipelineResponse response = new();
        response.SetContent(_mockContent);

        var results = AsyncResultCollection<BinaryData>.Create(response);

        // Set it to `cancelled: true` to validate functionality.
        CancellationToken token = new(true);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (BinaryData result in results.WithCancellation(token))
            {
            }
        });
    }

    [Test]
    public async Task CanDelaySendingRequest()
    {
        MockClient client = new MockClient();
        AsyncResultCollection<MockJsonModel> models = client.GetModelsStreamingAsync(_mockContent);

        Assert.IsFalse(client.StreamingProtocolMethodCalled);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
        Assert.IsTrue(client.StreamingProtocolMethodCalled);
    }

    [Test]
    public async Task CreatesAsyncResultCollection()
    {
        MockClient client = new();
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
        MockClient client = new MockClient();
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
        MockClient client = new MockClient();
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
