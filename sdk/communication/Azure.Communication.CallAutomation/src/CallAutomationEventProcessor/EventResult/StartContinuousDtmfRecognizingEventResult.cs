// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="StartContinuousDtmfRecognizingEventResult"/> is returned from WaitForEvent of <see cref="StartContinuousDtmfRecognizingResult"/>.</summary>
    public class StartContinuousDtmfRecognizingEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="ContinuousDtmfRecognitionToneReceived"/> event will be returned once the continuous dtmf recognition tone is received successfully.
        /// </summary>
        public ContinuousDtmfRecognitionToneReceived SuccessEvent { get; }

        /// <summary>
        /// <see cref="ContinuousDtmfRecognitionToneFailed"/> event will be returned once the continuous dtmf recognition tone is completed unsuccessfully.
        /// </summary>
        public ContinuousDtmfRecognitionToneFailed FailureEvent { get; }

        internal StartContinuousDtmfRecognizingEventResult(bool isSuccessEvent, ContinuousDtmfRecognitionToneReceived successEvent, ContinuousDtmfRecognitionToneFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
