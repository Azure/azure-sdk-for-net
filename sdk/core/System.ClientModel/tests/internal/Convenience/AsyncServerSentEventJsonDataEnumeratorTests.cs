// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncServerSentEventJsonDataEnumeratorTests
{
    [Test]
    public async Task EnumeratesSingleEvents()
    {
        Stream contentStream = BinaryData.FromString(_mockSingleEventContent).ToStream();
        using ServerSentEventReader reader = new(contentStream);
        using AsyncServerSentEventEnumerator eventEnumerator = new(reader);
        using AsyncServerSentEventJsonDataEnumerator<MockJsonModel> modelEnumerator = new(eventEnumerator);

        int i = 0;
        while (await modelEnumerator.MoveNextAsync())
        {
            MockJsonModel model = modelEnumerator.Current;

            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public async Task EnumeratesBatchEvents()
    {
        Stream contentStream = BinaryData.FromString(_mockBatchEventContent).ToStream();
        using ServerSentEventReader reader = new(contentStream);
        using AsyncServerSentEventEnumerator eventEnumerator = new(reader);
        using AsyncServerSentEventJsonDataEnumerator<MockJsonModel> modelEnumerator = new(eventEnumerator);

        int i = 0;
        while (await modelEnumerator.MoveNextAsync())
        {
            MockJsonModel model = modelEnumerator.Current;

            Assert.AreEqual(model.IntValue, i);
            Assert.AreEqual(model.StringValue, i.ToString());

            i++;
        }

        Assert.AreEqual(i, 6);
    }

    // TODO: Add tests for dispose and handling cancellation token
    // TODO: later, add tests for varying the _doneToken value.
    // TODO: tests for infinite stream -- no terminal event; how to show it won't stop?

    #region Helpers

    private string _mockSingleEventContent = """
        event: event.0
        data: { "IntValue": 0, "StringValue": "0" }

        event: event.1
        data: { "IntValue": 1, "StringValue": "1" }

        event: event.2
        data: { "IntValue": 2, "StringValue": "2" }

        event: done
        data: [DONE]

        """;

    private string _mockBatchEventContent = """
        event: event.0
        data: { { "IntValue": 0, "StringValue": "0" }, { "IntValue": 1, "StringValue": "1" } }

        event: event.1
        data: { "IntValue": 2, "StringValue": "2" }

        event: event.2
        data: { { "IntValue": 3, "StringValue": "3" }, { "IntValue": 4, "StringValue": "4" }, { "IntValue": 5, "StringValue": "5" } }

        event: done
        data: [DONE]

        """;

    private class MockJsonModelCollection : ReadOnlyCollection<MockJsonModel>, IJsonModel<MockJsonModelCollection>
    {
        public MockJsonModelCollection(IList<MockJsonModel> models) : base(models)
        {
        }

        MockJsonModelCollection IJsonModel<MockJsonModelCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        MockJsonModelCollection IPersistableModel<MockJsonModelCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<MockJsonModelCollection>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<MockJsonModelCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        BinaryData IPersistableModel<MockJsonModelCollection>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
