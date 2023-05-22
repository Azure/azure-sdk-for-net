// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="AddParticipantEventResult"/> is returned from WaitForEvent of <see cref="AddParticipantResult"/>.</summary>
    public class AddParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="AddParticipantSucceeded"/> event will be returned when the participant joined the call successfully.
        /// </summary>
        public AddParticipantSucceeded SuccessResult { get; }

        /// <summary>
        /// <see cref="AddParticipantFailed"/> event will be returned when the participant did not join the call.
        /// </summary>
        public AddParticipantFailed FailureResult { get; }

        /// <summary>
        /// <see cref="CommunicationIdentifier"/> Participant that was added or removed from the call.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        internal AddParticipantEventResult(bool isSuccess, AddParticipantSucceeded successResult, AddParticipantFailed failureResult, CommunicationIdentifier participant)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            Participant = participant;
        }
    }
}
