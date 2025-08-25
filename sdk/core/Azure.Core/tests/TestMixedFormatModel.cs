// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace Azure.Core.Tests
{
    /// <summary>
    /// Test model that supports both JSON and XML formats
    /// </summary>
    internal class TestMixedFormatModel : IPersistableModel<TestMixedFormatModel>
    {
        public string Name { get; set; } = "";
        public int Value { get; set; }

        BinaryData IPersistableModel<TestMixedFormatModel>.Write(ModelReaderWriterOptions options)
        {
            var format = ((IPersistableModel<TestMixedFormatModel>)this).GetFormatFromOptions(options);

            if (format == "X") // XML format
            {
                using var stream = new MemoryStream();
                using var writer = XmlWriter.Create(stream);
                writer.WriteStartElement("TestMixedFormatModel");
                writer.WriteElementString("name", Name);
                writer.WriteElementString("value", Value.ToString());
                writer.WriteEndElement();
                writer.Flush();
                return new BinaryData(stream.ToArray());
            }
            else // JSON format (default)
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
        }

        TestMixedFormatModel IPersistableModel<TestMixedFormatModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = ((IPersistableModel<TestMixedFormatModel>)this).GetFormatFromOptions(options);

            if (format == "X") // XML format
            {
                using var stream = new MemoryStream(data.ToArray());
                using var reader = XmlReader.Create(stream);

                var model = new TestMixedFormatModel();
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "name":
                                model.Name = reader.ReadElementContentAsString();
                                break;
                            case "value":
                                model.Value = reader.ReadElementContentAsInt();
                                break;
                        }
                    }
                }
                return model;
            }
            else // JSON format (default)
            {
                using var document = JsonDocument.Parse(data);
                return new TestMixedFormatModel
                {
                    Name = document.RootElement.GetProperty("name").GetString() ?? "",
                    Value = document.RootElement.GetProperty("value").GetInt32()
                };
            }
        }

        string IPersistableModel<TestMixedFormatModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            // Return "X" for XML format when specifically requested, otherwise default to JSON
            return options?.Format == "X" ? "X" : "J";
        }
    }
}