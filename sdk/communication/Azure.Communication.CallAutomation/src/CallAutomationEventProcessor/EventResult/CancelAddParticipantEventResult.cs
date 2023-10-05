// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="CancelAddParticipantEventResult"/> is returned from WaitForEvent of <see cref="AddParticipantResult"/>.</summary>
    public class CancelAddParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CancelAddParticipantSucceeded"/> event will be returned when the participant joined the call successfully.
        /// </summary>
        public CancelAddParticipantSucceeded SuccessResult { get; }

        /// <summary>
        /// <see cref="CancelAddParticipantFailed"/> event will be returned when the participant did not join the call.
        /// </summary>
        public CancelAddParticipantFailed FailureResult { get; }

        /// <summary> Invitation ID used to cancel the add participant action. </summary>
        public string InvitationId { get; }

        internal CancelAddParticipantEventResult(bool isSuccess, CancelAddParticipantSucceeded successResult, CancelAddParticipantFailed failureResult, string invitationId)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            InvitationId = invitationId;
        }
    }
}
