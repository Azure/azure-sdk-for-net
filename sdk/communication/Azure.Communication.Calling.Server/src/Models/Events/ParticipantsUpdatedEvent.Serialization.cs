// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class ParticipantsUpdatedEvent
    {
        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdatedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdatedEvent"/> object.</returns>
        public static ParticipantsUpdatedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            Optional<string> callLegId = default;
            Optional<IEnumerable<CommunicationParticipant>> participants = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("callLegId") || property.NameEquals("CallLegId"))
                {
                    callLegId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("participants") || property.NameEquals("Participants"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<CommunicationParticipant> array = new List<CommunicationParticipant>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CommunicationParticipant.DeserializeCommunicationParticipant(item));
                    }
                    participants = array;
                    continue;
                }
            }

            return new ParticipantsUpdatedEvent(callLegId.Value, participants.Value);
        }
    }
}
