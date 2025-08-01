// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests
{
    /// <summary>
    /// Test model that implements only IPersistableModel, not IJsonModel
    /// </summary>
    internal class TestPersistableModel : IPersistableModel<TestPersistableModel>
    {
        public string Name { get; set; } = "";
        public int Value { get; set; }

        BinaryData IPersistableModel<TestPersistableModel>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();
            writer.WriteString("name", Name);
            writer.WriteNumber("value", Value);
            writer.WriteEndObject();
            writer.Flush();
            return new BinaryData(stream.ToArray());
        }

        TestPersistableModel IPersistableModel<TestPersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            return new TestPersistableModel
            {
                Name = document.RootElement.GetProperty("name").GetString() ?? "",
                Value = document.RootElement.GetProperty("value").GetInt32()
            };
        }

        string IPersistableModel<TestPersistableModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}