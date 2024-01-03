// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace ClientModel.Tests.Mocks;

public class MockJsonModel : IJsonModel<MockJsonModel>
{
    MockJsonModel IJsonModel<MockJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    MockJsonModel IPersistableModel<MockJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<MockJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<MockJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<MockJsonModel>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
