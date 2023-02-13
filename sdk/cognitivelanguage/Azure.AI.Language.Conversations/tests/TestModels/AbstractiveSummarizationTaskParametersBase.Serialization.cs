// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AbstractiveSummarizationTaskParametersBase : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
            writer.WriteEndObject();
        }

        internal static AbstractiveSummarizationTaskParametersBase DeserializeAbstractiveSummarizationTaskParametersBase(JsonElement element)
        {
            Optional<int> sentenceCount = default;
            Optional<StringIndexType> stringIndexType = default;
            Optional<IList<PhraseControl>> phraseControls = default;
            foreach (var property in element.EnumerateObject())
            {
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
            }
            return new AbstractiveSummarizationTaskParametersBase(Optional.ToNullable(sentenceCount), Optional.ToNullable(stringIndexType), Optional.ToList(phraseControls));
        }
    }
}
