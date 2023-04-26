// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="SendDtmfEventResult"/> is returned from WaitForEvent of <see cref="SendDtmfResult"/>.</summary>
    public class SendDtmfEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="SendDtmfCompletedEventData"/> event will be returned once the dtmf tones have been sent successfully.
        /// </summary>
        public SendDtmfCompletedEventData SuccessResult { get; }

        /// <summary>
        /// <see cref="SendDtmfFailedEventData"/> event will be returned if send dtmf tones completed unsuccessfully.
        /// </summary>
        public SendDtmfFailedEventData FailureResult { get; }

        internal SendDtmfEventResult(bool isSuccess, SendDtmfCompletedEventData successResult, SendDtmfFailedEventData failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
