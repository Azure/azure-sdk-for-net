// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

// TODO: rename test file
public class AsyncServerSentEventJsonDataEnumeratorTests
{
    [Test]
    public async Task EnumeratesSingleEvents()
    {
        MockPipelineResponse response = new();
        response.SetContent(_mockContent);

        async Task<ClientResult> getResultAsync()
        {
            // TODO: simulate async correctly
            await Task.Delay(0);
            return ClientResult.FromResponse(response);
        }

        AsyncSseValueResultCollection<MockJsonModel> models = new(getResultAsync);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
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
