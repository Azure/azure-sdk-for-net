// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants operation options.
    /// </summary>
    public class AddParticipantOptions
    {
        /// <summary>
        /// Creates a new AddParticipantOptions object.
        /// </summary>
        /// <param name="participantToAdd"></param>
        public AddParticipantOptions(CallInvite participantToAdd)
        {
            ParticipantToAdd = participantToAdd;
        }

        /// <summary>
        /// Participant to add to the call.
        /// </summary>
        public CallInvite ParticipantToAdd { get; }

        /// <summary>
        /// The operationContext for this add participants call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Timeout before invitation times out.
        /// The minimum value is 1 second.
        /// The maximum value is 180 seconds.
        /// </summary>
        public int? InvitationTimeoutInSeconds { get; set; }
    }
}
