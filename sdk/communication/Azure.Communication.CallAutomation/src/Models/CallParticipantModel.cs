// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> The participant in a call. </summary>
    public class CallParticipantModel
    {
        /// <summary> Initializes a new instance of CallParticipantModel. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        internal CallParticipantModel(CommunicationIdentifier identifier, bool isMuted)
        {
            Identifier = identifier;
            IsMuted = isMuted;
        }

        /// <summary> Initializes a new instance of CallParticipantModel. </summary>
        /// <param name="callParticipantModelInternal"> The internal call participant. </param>
        internal CallParticipantModel(AcsCallParticipantInternal callParticipantModelInternal)
        {
            Identifier = CommunicationIdentifierSerializer.Deserialize(callParticipantModelInternal.Identifier);
            IsMuted = (bool)callParticipantModelInternal.IsMuted;
        }

        /// <summary> The communication identifier. </summary>
        public CommunicationIdentifier Identifier { get; }

        /// <summary> Is participant muted. </summary>
        public bool IsMuted { get; }
    }
}
