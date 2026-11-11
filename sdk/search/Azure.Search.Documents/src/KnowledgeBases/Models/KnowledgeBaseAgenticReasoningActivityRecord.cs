// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    [CodeGenSerialization(nameof(RetrievalReasoningEffort), "retrievalReasoningEffort")]
    [CodeGenSuppress(nameof(JsonModelWriteCore), typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class KnowledgeBaseAgenticReasoningActivityRecord
    {
        /// <summary> The retrieval reasoning effort configuration. </summary>
        public KnowledgeRetrievalReasoningEffort RetrievalReasoningEffort { get; }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<KnowledgeBaseAgenticReasoningActivityRecord>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(KnowledgeBaseAgenticReasoningActivityRecord)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(ReasoningTokens))
            {
                writer.WritePropertyName("reasoningTokens"u8);
                writer.WriteNumberValue(ReasoningTokens.Value);
            }
            if (Optional.IsDefined(RetrievalReasoningEffort))
            {
                writer.WritePropertyName("retrievalReasoningEffort"u8);
                writer.WriteObjectValue(RetrievalReasoningEffort, options);
            }
        }
    }
}
