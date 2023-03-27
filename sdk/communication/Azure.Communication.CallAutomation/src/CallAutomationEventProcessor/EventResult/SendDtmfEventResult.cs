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
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="SendDtmfCompleted"/> event will be returned once the dtmf tones have been sent successfully.
        /// </summary>
        public SendDtmfCompleted SuccessEvent { get; }

        /// <summary>
        /// <see cref="SendDtmfFailed"/> event will be returned if send dtmf tones completed unsuccessfully.
        /// </summary>
        public SendDtmfFailed FailureEvent { get; }

        internal SendDtmfEventResult(bool isSuccessEvent, SendDtmfCompleted successEvent, SendDtmfFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
