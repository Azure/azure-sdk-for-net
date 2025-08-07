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

        internal CancelAddParticipantEventResult(
            bool isSuccess,
            CancelAddParticipantSucceeded successResult,
            CancelAddParticipantFailed failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
