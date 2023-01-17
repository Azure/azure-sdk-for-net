// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> TransferCallToParticipantEventResult is returned from WaitForEvent of TransferCallToParticipantResult. </summary>
    /// </summary>
    public class TransferCallToParticipantEventResult : EventResultBase
    {
        /// <summary>
        /// CallTransferAccepted event will be returned once the call transfer is accepted successfully.
        /// </summary>
        public CallTransferAccepted SuccessEvent { get; }

        /// <summary>
        /// CallTransferFailed event will be returned once the call transfer is accepted unsuccessfully.
        /// </summary>
        public CallTransferFailed FailureEvent { get; }

        internal TransferCallToParticipantEventResult(bool isSuccessEvent, CallTransferAccepted successEvent, CallTransferFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
