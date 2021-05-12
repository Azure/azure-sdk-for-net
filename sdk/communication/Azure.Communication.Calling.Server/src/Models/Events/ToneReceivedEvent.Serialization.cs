// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class ToneReceivedEvent
    {
        /// <summary>
        /// Deserialize <see cref="ToneReceivedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ToneReceivedEvent"/> object.</returns>
        public static ToneReceivedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            Optional<ToneInfo> toneInfo = default;
            Optional<string> callLegId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("toneInfo") || property.NameEquals("ToneInfo"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    toneInfo = ToneInfo.DeserializeToneInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("callLegId") || property.NameEquals("CallLegId"))
                {
                    callLegId = property.Value.GetString();
                    continue;
                }
            }
            return new ToneReceivedEvent(toneInfo.Value, callLegId.Value);
        }
    }
}
