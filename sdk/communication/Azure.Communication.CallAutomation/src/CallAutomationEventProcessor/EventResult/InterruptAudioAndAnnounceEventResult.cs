// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="InterruptAudioAndAnnounceEventResult"/> is returned from WaitForEvent of <see cref="InterruptAudioAndAnnounceResult"/>.</summary>
    public class InterruptAudioAndAnnounceEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="PlayStarted"/> event will be returned once the play has started successfully.
        /// </summary>
        public PlayStarted StartResult { get; }

        /// <summary>
        /// <see cref="PlayPaused"/> event will be returned once the play is paused successfully.
        /// </summary>
        public PlayPaused PauseResult { get; }

        /// <summary>
        /// <see cref="PlayResumed"/> event will be returned once the play is resumed successfully.
        /// </summary>
        public PlayResumed ResumeResult { get; }

        /// <summary>
        /// <see cref="PlayCompleted"/> event will be returned once the play is completed successfully.
        /// </summary>
        public PlayCompleted SuccessResult { get; }

        /// <summary>
        /// <see cref="PlayFailed"/> event will be returned once the play failed.
        /// </summary>
        public PlayFailed FailureResult { get; }

        internal InterruptAudioAndAnnounceEventResult(bool isSuccess, PlayCompleted successResult, PlayFailed failureResult, PlayStarted startResult, PlayPaused pauseResult, PlayResumed resumeResult)
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
