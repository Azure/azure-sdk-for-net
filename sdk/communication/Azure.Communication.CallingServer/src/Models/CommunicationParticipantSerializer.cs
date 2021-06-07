// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    internal class CommunicationParticipantSerializer
    {
        public static CommunicationParticipant Deserialize(CommunicationParticipantInternal communicationParticipantInternal)
        {
            return new CommunicationParticipant()
            {
                Identifier = CommunicationIdentifierSerializer.Deserialize(communicationParticipantInternal.Identifier),
                ParticipantId = communicationParticipantInternal.ParticipantId,
                IsMuted = communicationParticipantInternal.IsMuted,
            };
        }
    }
}
