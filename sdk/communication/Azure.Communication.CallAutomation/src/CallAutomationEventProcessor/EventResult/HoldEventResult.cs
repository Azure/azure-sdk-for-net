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
        /// <see cref="HoldFailed"/> event will be returned once the hold failed.
        /// </summary>
        public HoldFailed FailureResult { get; }

        internal HoldEventResult(bool isSuccess, HoldFailed failureResult)
        {
            IsSuccess = isSuccess;
            FailureResult = failureResult;
        }
    }
}
