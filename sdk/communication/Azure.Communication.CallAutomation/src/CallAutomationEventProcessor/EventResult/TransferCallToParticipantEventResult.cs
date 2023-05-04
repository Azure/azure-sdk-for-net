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
        /// <see cref="CallTransferAcceptedEventData"/> event will be returned once the call transfer is accepted successfully.
        /// </summary>
        public CallTransferAcceptedEventData SuccessResult { get; }

        /// <summary>
        /// <see cref="CallTransferFailedEventData"/> event will be returned once the call transfer is accepted unsuccessfully.
        /// </summary>
        public CallTransferFailedEventData FailureResult { get; }

        internal TransferCallToParticipantEventResult(bool isSuccess, CallTransferAcceptedEventData successResult, CallTransferFailedEventData failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
