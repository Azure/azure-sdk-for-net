// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class CallRecordingStateChangeEvent
    {
        /// <summary>
        /// Deserialize <see cref="CallRecordingStateChangeEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallRecordingStateChangeEvent"/> object.</returns>
        internal static CallRecordingStateChangeEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            Optional<string> recordingId = default;
            Optional<CallRecordingStateModel> state = default;
            Optional<DateTimeOffset> startDateTime = default;
            Optional<string> conversationId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("recordingId") || property.NameEquals("RecordingId"))
                {
                    recordingId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("state") || property.NameEquals("State"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    state = new CallRecordingStateModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("startDateTime") || property.NameEquals("StartDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    startDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("conversationId") || property.NameEquals("ConversationId"))
                {
                    conversationId = property.Value.GetString();
                    continue;
                }
            }
            return new CallRecordingStateChangeEvent(recordingId.Value, state, startDateTime, conversationId.Value);
        }
    }
}
