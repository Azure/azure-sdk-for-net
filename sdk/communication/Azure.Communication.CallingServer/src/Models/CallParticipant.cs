// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary> The participant in a call. </summary>
    public class CallParticipant
    {
        /// <summary> Initializes a new instance of CallParticipant. </summary>
        public CallParticipant()
        {
        }

        /// <summary> Initializes a new instance of CallParticipant. </summary>
        /// <param name="identifier"> The communication identifier. </param>
        /// <param name="participantId"> Participant Id. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        public CallParticipant(CommunicationIdentifier identifier, string participantId, bool? isMuted)
        {
            Identifier = identifier;
            ParticipantId = participantId;
            IsMuted = isMuted;
        }

        /// <summary> The communication identifier. </summary>
        public CommunicationIdentifier Identifier { get; set; }

        /// <summary> Participant Id. </summary>
        public string ParticipantId { get; set; }

        /// <summary> Is participant muted. </summary>
        public bool? IsMuted { get; set; }
    }
}
