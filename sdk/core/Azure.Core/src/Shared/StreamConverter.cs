// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core
{
    internal class StreamConverter : JsonConverter<Stream>
    {
        /// <summary> Serialize stream to BinaryData string. </summary>
        /// <param name="writer"> The writer. </param>
        /// <param name="model"> The Stream model. </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override void Write(Utf8JsonWriter writer, Stream model, JsonSerializerOptions options)
        {
            if (model.Length == 0)
            {
                writer.WriteNullValue();
                return;
            }
            MemoryStream? memoryContent = model as MemoryStream;

            if (memoryContent == null)
            {
                throw new InvalidOperationException($"The response is not fully buffered.");
            }

            if (memoryContent.TryGetBuffer(out ArraySegment<byte> segment))
            {
                var data = new BinaryData(segment.AsMemory());
#if NET6_0_OR_GREATER
                writer.WriteRawValue(data);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
            }
            else
            {
                var data = new BinaryData(memoryContent.ToArray());
#if NET6_0_OR_GREATER
                writer.WriteRawValue(data);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
            }
        }

        /// <summary> Deserialize Stream from BinaryData string. </summary>
        /// <param name="reader"> The reader. </param>
        /// <param name="typeToConvert"> The type to convert </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override Stream Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                var value = property.Value.GetString();
                return BinaryData.FromString(value!).ToStream();
            }
            return new MemoryStream();
        }
    }
}
