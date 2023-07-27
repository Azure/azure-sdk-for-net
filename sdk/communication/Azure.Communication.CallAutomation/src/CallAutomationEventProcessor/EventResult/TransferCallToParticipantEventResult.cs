// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="TransferCallToParticipantEventResult"/> is returned from WaitForEvent of <see cref="TransferCallToParticipantResult"/>.</summary>
    public class TransferCallToParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CallTransferAccepted"/> event will be returned once the call transfer is accepted successfully.
        /// </summary>
        public CallTransferAccepted SuccessResult { get; }

        /// <summary>
        /// <see cref="CallTransferFailed"/> event will be returned once the call transfer is accepted unsuccessfully.
        /// </summary>
        public CallTransferFailed FailureResult { get; }

        internal TransferCallToParticipantEventResult(bool isSuccess, CallTransferAccepted successResult, CallTransferFailed failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
