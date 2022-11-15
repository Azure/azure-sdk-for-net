// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AudioTiming : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Offset))
            {
                writer.WritePropertyName("offset");
                writer.WriteNumberValue(Offset.Value);
            }
            if (Optional.IsDefined(Duration))
            {
                writer.WritePropertyName("duration");
                writer.WriteNumberValue(Duration.Value);
            }
            writer.WriteEndObject();
        }

        internal static AudioTiming DeserializeAudioTiming(JsonElement element)
        {
            Optional<long> offset = default;
            Optional<long> duration = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("offset"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    offset = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("duration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    duration = property.Value.GetInt64();
                    continue;
                }
            }
            return new AudioTiming(Optional.ToNullable(offset), Optional.ToNullable(duration));
        }
    }
}
