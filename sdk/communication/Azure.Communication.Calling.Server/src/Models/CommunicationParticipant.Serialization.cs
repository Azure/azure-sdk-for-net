// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    public partial class CommunicationParticipant
    {
        internal static CommunicationParticipant DeserializeCommunicationParticipant(JsonElement element)
        {
            Optional<string> participantId = default;
            Optional<bool> isMuted = default;
            Optional<CommunicationIdentifier> identifier = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("participantId") || property.NameEquals("ParticipantId"))
                {
                    participantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isMuted") || property.NameEquals("IsMuted"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isMuted = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("identifier") || property.NameEquals("Identifier"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var identifierModel = CommunicationIdentifierModel.DeserializeCommunicationIdentifierModel(property.Value);

                    identifier = CommunicationIdentifierSerializer.Deserialize(identifierModel);
                    continue;
                }
            }
            return new CommunicationParticipant(identifier, participantId.Value, isMuted);
        }
    }
}
