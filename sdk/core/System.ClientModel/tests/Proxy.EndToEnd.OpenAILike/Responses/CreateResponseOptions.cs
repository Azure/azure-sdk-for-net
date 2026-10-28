// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAILike.Responses
{
    /// <summary>Mock request body for <see cref="ResponsesClient.CreateResponseAsync"/>.</summary>
    public class CreateResponseOptions : IJsonModel<CreateResponseOptions>
    {
        public CreateResponseOptions(string model, IEnumerable<ResponseItem> input)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Input = new List<ResponseItem>(input ?? throw new ArgumentNullException(nameof(input)));
        }

        public string Model { get; }

        public IList<ResponseItem> Input { get; }

        public IList<ResponseTool> Tools { get; } = new List<ResponseTool>();

        void IJsonModel<CreateResponseOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("model"u8, Model);
            writer.WritePropertyName("input"u8);
            writer.WriteStartArray();
            foreach (ResponseItem item in Input)
            {
                item.Write(writer);
            }
            writer.WriteEndArray();
            if (Tools.Count > 0)
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (ResponseTool tool in Tools)
                {
                    writer.WriteRawValue(ModelReaderWriter.Write(tool, options, ResponseToolsContext.Default));
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        CreateResponseOptions IJsonModel<CreateResponseOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("The request model is write-only.");

        BinaryData IPersistableModel<CreateResponseOptions>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, ResponseToolsContext.Default);

        CreateResponseOptions IPersistableModel<CreateResponseOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("The request model is write-only.");

        string IPersistableModel<CreateResponseOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
