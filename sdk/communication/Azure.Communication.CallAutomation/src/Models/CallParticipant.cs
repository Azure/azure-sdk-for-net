// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> The participant in a call. </summary>
    public class CallParticipant
    {
        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        /// <param name="isOnHold"> Is participant on hold. </param>
        internal CallParticipant(CommunicationIdentifier identifier, bool isMuted, bool isOnHold)
        {
            Identifier = identifier;
            IsMuted = isMuted;
            IsOnHold = isOnHold;
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="callParticipantInternal"> The internal call participant. </param>
        internal CallParticipant(CallParticipantInternal callParticipantInternal)
        {
            Identifier = CommunicationIdentifierSerializer_2025_06_30.Deserialize(callParticipantInternal.Identifier);
            IsMuted = (bool)callParticipantInternal.IsMuted;
            IsOnHold = callParticipantInternal.IsOnHold.GetValueOrDefault(false);
        }

        /// <summary> The communication identifier. </summary>
        public CommunicationIdentifier Identifier { get; }

        /// <summary> Is participant muted. </summary>
        public bool IsMuted { get; }

        /// <summary> Is participant on hold. </summary>
        public bool IsOnHold { get; }
    }
}
