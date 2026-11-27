// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    [CodeGenSerialization(nameof(Embedding), SerializationValueHook = nameof(WriteEmbeddingValue))]
    [CodeGenSerialization(nameof(MultiEmbedding), SerializationValueHook = nameof(WriteMultiEmbeddingValue))]
    public partial class MultimodalDenseAndMultiVectorEmbedding
    {
        private void WriteEmbeddingValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => WriteRawOrNull(writer, Embedding);

        private void WriteMultiEmbeddingValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => WriteRawOrNull(writer, MultiEmbedding);

        private static void WriteRawOrNull(Utf8JsonWriter writer, BinaryData value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
#if NET6_0_OR_GREATER
            writer.WriteRawValue(value);
#else
            using (JsonDocument document = JsonDocument.Parse(value))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
        }
    }
}
