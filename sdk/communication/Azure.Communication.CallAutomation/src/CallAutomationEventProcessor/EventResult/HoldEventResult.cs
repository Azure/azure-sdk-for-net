// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="HoldEventResult"/> is returned from WaitForEvent of <see cref="HoldResult"/>.</summary>
    public class HoldEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="HoldAudioCompleted"/> event will be returned once the hold audio is completed successfully.
        /// </summary>
        public HoldAudioCompleted SuccessResult { get; }

        /// <summary>
        /// <see cref="HoldAudioStarted"/> event will be returned once the hold audio has started successfully.
        /// </summary>
        public HoldAudioStarted StartResult { get; }

        /// <summary>
        /// <see cref="HoldAudioPaused"/> event will be returned once the hold audio is paused successfully.
        /// </summary>
        public HoldAudioPaused PauseResult { get; }

        /// <summary>
        /// <see cref="HoldAudioResumed"/> event will be returned once the hold audio is resumed successfully.
        /// </summary>
        public HoldAudioResumed ResumeResult { get; }

        /// <summary>
        /// <see cref="HoldFailed"/> event will be returned once the hold failed.
        /// </summary>
        public HoldFailed FailureResult { get; }

        internal HoldEventResult(bool isSuccess, HoldAudioCompleted successResult, HoldFailed failureResult, HoldAudioStarted startResult, HoldAudioPaused pauseResult, HoldAudioResumed resumeResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            StartResult = startResult;
            PauseResult = pauseResult;
            ResumeResult = resumeResult;
        }
    }
}
