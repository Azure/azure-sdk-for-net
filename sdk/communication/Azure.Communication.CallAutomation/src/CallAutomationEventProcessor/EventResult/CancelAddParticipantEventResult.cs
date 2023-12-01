// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="CancelAddParticipantEventResult"/> is returned from WaitForEvent of <see cref="CancelAddParticipantOperationResult"/>.</summary>
    public class CancelAddParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CancelAddParticipantSucceeded"/> event will be returned when the invitation was cancelled successfully.
        /// </summary>
        public CancelAddParticipantSucceeded SuccessResult { get; }

        /// <summary>
        /// <see cref="CancelAddParticipantFailed"/> event will be returned when the invitation could not be cancelled.
        /// </summary>
        public CancelAddParticipantFailed FailureResult { get; }

        /// <summary>
        /// <see cref="CommunicationIdentifier"/> Participant whoose invitation was cancelled. Only applicable for
        /// <see cref="CancelAddParticipantSucceeded"/> event
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Invitation ID used to cancel the request.
        /// </summary>
        public string InvitationId { get; }

        internal CancelAddParticipantEventResult(
            bool isSuccess,
            CancelAddParticipantSucceeded successResult,
            CancelAddParticipantFailed failureResult,
            string invitationId,
            CommunicationIdentifier participant = null)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            Participant = participant;
            InvitationId = invitationId;
        }
    }
}
