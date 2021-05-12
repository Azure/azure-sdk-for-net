// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class ToneInfo
    {
        internal static ToneInfo DeserializeToneInfo(JsonElement element)
        {
            Optional<uint> sequenceId = default;
            Optional<ToneValue> tone = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sequenceId") || property.NameEquals("SequenceId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sequenceId = new Optional<uint>((uint)property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("tone") || property.NameEquals("Tone"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    tone = property.Value.GetString().ToToneValue();
                    continue;
                }
            }

            return new ToneInfo(sequenceId, tone);
        }
    }
}
