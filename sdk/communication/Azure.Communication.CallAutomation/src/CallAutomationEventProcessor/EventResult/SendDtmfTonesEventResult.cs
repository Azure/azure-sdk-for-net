// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="SendDtmfTonesEventResult"/> is returned from WaitForEvent of <see cref="SendDtmfTonesResult"/>.</summary>
    public class SendDtmfTonesEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="SendDtmfTonesCompleted"/> event will be returned once the dtmf tones have been sent successfully.
        /// </summary>
        public SendDtmfTonesCompleted SuccessResult { get; }

        /// <summary>
        /// <see cref="SendDtmfTonesFailed"/> event will be returned if send dtmf tones completed unsuccessfully.
        /// </summary>
        public SendDtmfTonesFailed FailureResult { get; }

        internal SendDtmfTonesEventResult(bool isSuccess, SendDtmfTonesCompleted successResult, SendDtmfTonesFailed failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
