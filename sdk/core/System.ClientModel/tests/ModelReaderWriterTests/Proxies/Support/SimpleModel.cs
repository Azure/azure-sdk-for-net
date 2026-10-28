// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// Simple model without AssertOptions logic, used for chain tests.
    /// </summary>
    internal class SimpleModel : IJsonModel<SimpleModel>
    {
        SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return new SimpleModel();
        }

        SimpleModel IPersistableModel<SimpleModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new SimpleModel();

        string IPersistableModel<SimpleModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<SimpleModel>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options);
    }
}
