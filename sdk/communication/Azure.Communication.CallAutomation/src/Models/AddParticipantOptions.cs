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
        /// <value></value>
        public CallInvite ParticipantToAdd { get; }

        /// <summary>
        /// The caller ID number to appear on the participant.
        /// </summary>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; set; }

        /// <summary>
        /// (Optional) The display name of the source that is associated with this invite operation when
        /// adding a PSTN participant or teams user.  Note: Will not update the display name in the roster.
        /// </summary>
        public string SourceDisplayName { get; set; }

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
