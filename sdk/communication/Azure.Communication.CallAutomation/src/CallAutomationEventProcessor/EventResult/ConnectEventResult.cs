// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="ConnectEventResult"/> is returned from WaitForEvent of <see cref="ConnectResult"/>.</summary>
    public class ConnectEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="ConnectFailed"/> event will be returned once the connect failed.
        /// </summary>
        public ConnectFailed FailureResult { get; }

        internal ConnectEventResult(bool isSuccess, ConnectFailed failureResult)
        {
            IsSuccess = isSuccess;
            FailureResult = failureResult;
        }
    }
}
