// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationPIITaskParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(PiiCategories))
            {
                writer.WritePropertyName("piiCategories");
                writer.WriteStartArray();
                foreach (var item in PiiCategories)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IncludeAudioRedaction))
            {
                writer.WritePropertyName("includeAudioRedaction");
                writer.WriteBooleanValue(IncludeAudioRedaction.Value);
            }
            if (Optional.IsDefined(RedactionSource))
            {
                writer.WritePropertyName("redactionSource");
                writer.WriteStringValue(RedactionSource.Value.ToString());
            }
            if (Optional.IsDefined(ModelVersion))
            {
                writer.WritePropertyName("modelVersion");
                writer.WriteStringValue(ModelVersion);
            }
            if (Optional.IsDefined(LoggingOptOut))
            {
                writer.WritePropertyName("loggingOptOut");
                writer.WriteBooleanValue(LoggingOptOut.Value);
            }
            writer.WriteEndObject();
        }

        internal static ConversationPIITaskParameters DeserializeConversationPIITaskParameters(JsonElement element)
        {
            Optional<IList<ConversationPIICategory>> piiCategories = default;
            Optional<bool> includeAudioRedaction = default;
            Optional<TranscriptContentType> redactionSource = default;
            Optional<string> modelVersion = default;
            Optional<bool> loggingOptOut = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("piiCategories"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ConversationPIICategory> array = new List<ConversationPIICategory>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new ConversationPIICategory(item.GetString()));
                    }
                    piiCategories = array;
                    continue;
                }
                if (property.NameEquals("includeAudioRedaction"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    includeAudioRedaction = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("redactionSource"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    redactionSource = new TranscriptContentType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("modelVersion"))
                {
                    modelVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("loggingOptOut"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    loggingOptOut = property.Value.GetBoolean();
                    continue;
                }
            }
            return new ConversationPIITaskParameters(Optional.ToNullable(loggingOptOut), modelVersion.Value, Optional.ToList(piiCategories), Optional.ToNullable(includeAudioRedaction), Optional.ToNullable(redactionSource));
        }
    }
}
