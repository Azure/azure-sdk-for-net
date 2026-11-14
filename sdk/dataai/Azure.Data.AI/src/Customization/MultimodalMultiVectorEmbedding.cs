// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    [CodeGenSerialization(nameof(MultiEmbedding), SerializationValueHook = nameof(WriteMultiEmbeddingValue))]
    public partial class MultimodalMultiVectorEmbedding
    {
        private void WriteMultiEmbeddingValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (MultiEmbedding == null)
            {
                writer.WriteNullValue();
                return;
            }
#if NET6_0_OR_GREATER
            writer.WriteRawValue(MultiEmbedding);
#else
            using (JsonDocument document = JsonDocument.Parse(MultiEmbedding))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
        }
    }
}
