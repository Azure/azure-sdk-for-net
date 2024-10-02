// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace ClientModel.ReferenceClients.SimplifiedClient;

public class OutputModel : IJsonModel<OutputModel>
{
    OutputModel IJsonModel<OutputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    OutputModel IPersistableModel<OutputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<OutputModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<OutputModel>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    internal static OutputModel DeserializeOutputModel(JsonElement element)
    {
        throw new NotImplementedException();
    }

    public static explicit operator OutputModel(ClientResult result)
    {
        using PipelineResponse response = result.GetRawResponse();
        using JsonDocument document = JsonDocument.Parse(response.Content);
        return DeserializeOutputModel(document.RootElement);
    }
}
