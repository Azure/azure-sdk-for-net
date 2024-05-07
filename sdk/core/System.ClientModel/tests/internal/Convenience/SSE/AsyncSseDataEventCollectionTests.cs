// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncSseDataEventCollectionTests
{
    [Test]
    public async Task BinaryDataCollectionEnumeratesData()
    {
        MockPipelineResponse response = new();
        response.SetContent(_mockContent);

        AsyncSseDataEventCollection results = new(response, "[DONE]");

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

        AsyncSseDataEventCollection results = new(response, "[DONE]");

        CancellationToken token = new(true);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
        {
            await foreach (BinaryData result in results.WithCancellation(token))
            {
            }
        });
    }

    // TODO: Add tests for dispose and handling cancellation token
    // TODO: later, add tests for varying the _doneToken value.
    // TODO: tests for infinite stream -- no terminal event; how to show it won't stop?

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
