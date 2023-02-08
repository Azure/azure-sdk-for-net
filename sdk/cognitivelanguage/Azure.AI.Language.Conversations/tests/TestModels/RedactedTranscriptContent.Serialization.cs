// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class RedactedTranscriptContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Itn))
            {
                writer.WritePropertyName("itn");
                writer.WriteStringValue(Itn);
            }
            if (Optional.IsDefined(MaskedItn))
            {
                writer.WritePropertyName("maskedItn");
                writer.WriteStringValue(MaskedItn);
            }
            if (Optional.IsDefined(Text))
            {
                writer.WritePropertyName("text");
                writer.WriteStringValue(Text);
            }
            if (Optional.IsDefined(Lexical))
            {
                writer.WritePropertyName("lexical");
                writer.WriteStringValue(Lexical);
            }
            if (Optional.IsCollectionDefined(AudioTimings))
            {
                writer.WritePropertyName("audioTimings");
                writer.WriteStartArray();
                foreach (var item in AudioTimings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static RedactedTranscriptContent DeserializeRedactedTranscriptContent(JsonElement element)
        {
            Optional<string> itn = default;
            Optional<string> maskedItn = default;
            Optional<string> text = default;
            Optional<string> lexical = default;
            Optional<IList<AudioTiming>> audioTimings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("itn"))
                {
                    itn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maskedItn"))
                {
                    maskedItn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lexical"))
                {
                    lexical = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("audioTimings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<AudioTiming> array = new List<AudioTiming>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AudioTiming.DeserializeAudioTiming(item));
                    }
                    audioTimings = array;
                    continue;
                }
            }
            return new RedactedTranscriptContent(itn.Value, maskedItn.Value, text.Value, lexical.Value, Optional.ToList(audioTimings));
        }
    }
}
