// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="RemoveParticipantEventResult"/> is returned from WaitForEvent of <see cref="RemoveParticipantResult"/>.</summary>
    public class RemoveParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="RemoveParticipantSucceeded"/> event will be returned when the participant was removed from the call successfully.
        /// </summary>
        public RemoveParticipantSucceeded SuccessEvent { get; }

        /// <summary>
        /// <see cref="RemoveParticipantFailed"/> event will be returned when the participant could not be removed from the call.
        /// </summary>
        public RemoveParticipantFailed FailureEvent { get; }

        /// <summary>
        /// <see cref="CommunicationIdentifier"/> Participant that was removed from the call.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        internal RemoveParticipantEventResult(bool isSuccessEvent, RemoveParticipantSucceeded successEvent, RemoveParticipantFailed failureEvent, CommunicationIdentifier participant)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
            Participant = participant;
        }
    }
}