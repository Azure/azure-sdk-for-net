// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal class JsonModelProxy : IJsonModel<JsonModel>
    {
        JsonModel IJsonModel<JsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            PassThroughOptionsTracker.AssertOptions(this, options);
            using var doc = JsonDocument.ParseValue(ref reader);
            return new JsonModel();
        }

        JsonModel IPersistableModel<JsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            PassThroughOptionsTracker.AssertOptions(this, options);
            return new JsonModel();
        }

        string IPersistableModel<JsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return "J";
        }

        void IJsonModel<JsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            PassThroughOptionsTracker.AssertOptions(this, options);
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<JsonModel>.Write(ModelReaderWriterOptions options)
        {
            PassThroughOptionsTracker.AssertOptions(this, options);
            return BinaryData.FromString("{}");
        }
    }
}
