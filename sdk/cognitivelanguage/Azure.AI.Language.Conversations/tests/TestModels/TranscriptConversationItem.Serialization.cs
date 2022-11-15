// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class TranscriptConversationItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("itn");
            writer.WriteStringValue(Itn);
            writer.WritePropertyName("maskedItn");
            writer.WriteStringValue(MaskedItn);
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            writer.WritePropertyName("lexical");
            writer.WriteStringValue(Lexical);
            if (Optional.IsCollectionDefined(WordLevelTimings))
            {
                writer.WritePropertyName("wordLevelTimings");
                writer.WriteStartArray();
                foreach (var item in WordLevelTimings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ConversationItemLevelTiming))
            {
                writer.WritePropertyName("conversationItemLevelTiming");
                writer.WriteObjectValue(ConversationItemLevelTiming);
            }
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("participantId");
            writer.WriteStringValue(ParticipantId);
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language");
                writer.WriteStringValue(Language);
            }
            if (Optional.IsDefined(Modality))
            {
                writer.WritePropertyName("modality");
                writer.WriteStringValue(Modality.Value.ToString());
            }
            if (Optional.IsDefined(Role))
            {
                writer.WritePropertyName("role");
                writer.WriteStringValue(Role.Value.ToString());
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
