// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests
{
    internal class TestJsonModel : IJsonModel<TestJsonModel>
    {
        public string Name { get; set; } = "";
        public int Value { get; set; }

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("name", Name);
            writer.WriteNumber("value", Value);
            writer.WriteEndObject();
        }

        public TestJsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return new TestJsonModel
            {
                Name = document.RootElement.GetProperty("name").GetString() ?? "",
                Value = document.RootElement.GetProperty("value").GetInt32()
            };
        }

        BinaryData IPersistableModel<TestJsonModel>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            Write(writer, options);
            writer.Flush();
            return new BinaryData(stream.ToArray());
        }

        TestJsonModel IPersistableModel<TestJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return Create(ref reader, options);
        }

        string IPersistableModel<TestJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}