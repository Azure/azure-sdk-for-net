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
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="RemoveParticipantSucceeded"/> event will be returned when the participant was removed from the call successfully.
        /// </summary>
        public RemoveParticipantSucceeded SuccessResult { get; }

        /// <summary>
        /// <see cref="RemoveParticipantFailed"/> event will be returned when the participant could not be removed from the call.
        /// </summary>
        public RemoveParticipantFailed FailureResult { get; }

        /// <summary>
        /// <see cref="CommunicationIdentifier"/> Participant that was removed from the call.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        internal RemoveParticipantEventResult(bool isSuccess, RemoveParticipantSucceeded successResult, RemoveParticipantFailed failureResult, CommunicationIdentifier participant)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            Participant = participant;
        }
    }
}