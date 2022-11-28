// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationSummarizationTaskParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("summaryAspects");
            writer.WriteStartArray();
            foreach (var item in SummaryAspects)
            {
                writer.WriteStringValue(item.ToString());
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(SentenceCount))
            {
                writer.WritePropertyName("sentenceCount");
                writer.WriteNumberValue(SentenceCount.Value);
            }
            if (Optional.IsDefined(StringIndexType))
            {
                writer.WritePropertyName("stringIndexType");
                writer.WriteStringValue(StringIndexType.Value.ToString());
            }
            if (Optional.IsCollectionDefined(PhraseControls))
            {
                writer.WritePropertyName("phraseControls");
                writer.WriteStartArray();
                foreach (var item in PhraseControls)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

        internal static ConversationSummarizationTaskParameters DeserializeConversationSummarizationTaskParameters(JsonElement element)
        {
            IList<SummaryAspect> summaryAspects = default;
            Optional<int> sentenceCount = default;
            Optional<StringIndexType> stringIndexType = default;
            Optional<IList<PhraseControl>> phraseControls = default;
            Optional<string> modelVersion = default;
            Optional<bool> loggingOptOut = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("summaryAspects"))
                {
                    List<SummaryAspect> array = new List<SummaryAspect>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new SummaryAspect(item.GetString()));
                    }
                    summaryAspects = array;
                    continue;
                }
                if (property.NameEquals("sentenceCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sentenceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("stringIndexType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    stringIndexType = new StringIndexType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("phraseControls"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<PhraseControl> array = new List<PhraseControl>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PhraseControl.DeserializePhraseControl(item));
                    }
                    phraseControls = array;
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
            return new ConversationSummarizationTaskParameters(Optional.ToNullable(loggingOptOut), modelVersion.Value, summaryAspects, Optional.ToNullable(sentenceCount), Optional.ToNullable(stringIndexType), Optional.ToList(phraseControls));
        }
    }
}
