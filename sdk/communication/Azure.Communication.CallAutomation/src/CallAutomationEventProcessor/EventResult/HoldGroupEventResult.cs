// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <see cref="HoldGroupEventResult"/> is returned from WaitForEvent of <see cref="HoldGroupCreatedEventResult"/>.
    /// </summary>
    public class HoldGroupEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="HoldGroupCreated"/> event will be returned once the hold group is created successfully.
        /// </summary>
        public HoldGroupCreated CreatedResult { get; }

        /// <summary>
        /// <see cref="HoldGroupAudioStarted"/> event will be returned once the hold group audio has started successfully.
        /// </summary>
        public HoldGroupAudioStarted AudioStartedResult { get; }

        /// <summary>
        /// <see cref="HoldGroupAudioFailed"/> event will be returned once the hold group audio failed.
        /// </summary>
        public HoldGroupAudioFailed AudioFailedResult { get; }

        /// <summary>
        /// <see cref="HoldGroupFailed"/> event will be returned once the hold group creation failed.
        /// </summary>
        public HoldGroupFailed FailedResult { get; }

        internal HoldGroupEventResult(bool isSuccess, HoldGroupCreated createdResult, HoldGroupAudioStarted audioStartedResult, HoldGroupAudioFailed audioFailedResult, HoldGroupFailed failedResult)
        {
            IsSuccess = isSuccess;
            CreatedResult = createdResult;
            AudioStartedResult = audioStartedResult;
            AudioFailedResult = audioFailedResult;
            FailedResult = failedResult;
        }
    }
}
