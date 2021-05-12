// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The participant in a call.
    /// </summary>
    public partial class CommunicationParticipant
    {
        /// <summary>
        /// The communication identity of the participant.
        /// </summary>
        public CommunicationIdentifier Identifier { get; set; }

        /// <summary>
        /// The participant id.
        /// </summary>
        public string ParticipantId { get; set; }

        /// <summary>
        /// Is participant muted.
        /// </summary>
        public bool IsMuted { get; set; }

        /// <summary> Initializes a new instance of <see cref="CommunicationParticipant"/>. </summary>
        /// <param name="communicationIdentifier">Communication Identifier.</param>
        /// <param name="participantId"> Participant Id. </param>
        /// <param name="isMuted"> Is participant muted. </param>
        internal CommunicationParticipant(CommunicationIdentifier communicationIdentifier, string participantId, bool isMuted)
        {
            Identifier = communicationIdentifier;
            ParticipantId = participantId;
            IsMuted = isMuted;
        }
    }
}
