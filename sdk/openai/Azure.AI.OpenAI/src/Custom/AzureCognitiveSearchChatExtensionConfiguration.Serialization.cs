// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class AzureCognitiveSearchChatExtensionConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());

            // Custom code note: everything *except* type goes into 'parameters'
            writer.WriteStartObject("parameters"u8);

            writer.WritePropertyName("endpoint"u8);
            writer.WriteStringValue(SearchEndpoint.AbsoluteUri);
            writer.WriteString("key"u8, SearchKey);
            writer.WritePropertyName("indexName"u8);
            writer.WriteStringValue(IndexName);
            if (Optional.IsDefined(FieldMappingOptions))
            {
                writer.WritePropertyName("fieldMappings"u8);
                writer.WriteObjectValue(FieldMappingOptions);
            }
            if (Optional.IsDefined(DocumentCount))
            {
                writer.WritePropertyName("topNDocuments"u8);
                writer.WriteNumberValue(DocumentCount.Value);
            }
            if (Optional.IsDefined(QueryType))
            {
                writer.WritePropertyName("queryType"u8);
                writer.WriteStringValue(QueryType.Value.ToString());
            }
            if (Optional.IsDefined(ShouldRestrictResultScope))
            {
                writer.WritePropertyName("inScope"u8);
                writer.WriteBooleanValue(ShouldRestrictResultScope.Value);
            }
            if (Optional.IsDefined(SemanticConfiguration))
            {
                writer.WritePropertyName("semanticConfiguration"u8);
                writer.WriteStringValue(SemanticConfiguration);
            }
            if (Optional.IsDefined(EmbeddingEndpoint))
            {
                writer.WritePropertyName("embeddingEndpoint"u8);
                writer.WriteStringValue(EmbeddingEndpoint.AbsoluteUri);
            }
            if (Optional.IsDefined(EmbeddingKey))
            {
                writer.WriteString("embeddingKey"u8, EmbeddingKey);
            }
            // CUSTOM CODE NOTE: end of induced 'parameters' first, then the parent object
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
