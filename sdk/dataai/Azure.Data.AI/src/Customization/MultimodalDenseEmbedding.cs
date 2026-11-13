// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    [CodeGenSerialization(nameof(Embedding), SerializationValueHook = nameof(WriteEmbeddingValue))]
    public partial class MultimodalDenseEmbedding
    {
        /// <summary>
        /// `true` when the item was over the model's token limit and only its start was embedded; `warnings` then has an
        /// `EMBEDDING_INPUT_TRUNCATED` entry for it. Omitted otherwise.
        /// </summary>
        [CodeGenMember("Truncated")]
        public bool? IsTruncated { get; }

        private void WriteEmbeddingValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Embedding == null)
            {
                writer.WriteNullValue();
                return;
            }
#if NET6_0_OR_GREATER
            writer.WriteRawValue(Embedding);
#else
            using (JsonDocument document = JsonDocument.Parse(Embedding))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
        }
    }
}
