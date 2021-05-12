// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class CallLegStateChangedEvent
    {
        /// <summary>
        /// Deserialize <see cref="CallLegStateChangedEvent"/> event.
        /// </summary>
        /// <param name="content"></param>
        /// <returns>The new <see cref="CallLegStateChangedEvent"/> object.</returns>
        public static CallLegStateChangedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            Optional<string> conversationId = default;
            Optional<string> callLegId = default;
            Optional<CallState> callState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("conversationId") || property.NameEquals("ConversationId"))
                {
                    conversationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("callLegId") || property.NameEquals("CallLegId"))
                {
                    callLegId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("callState") || property.NameEquals("CallState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    callState = property.Value.GetString().ToCallState();
                    continue;
                }
            }
            return new CallLegStateChangedEvent(conversationId.Value, callLegId.Value, callState);
        }
    }
}
