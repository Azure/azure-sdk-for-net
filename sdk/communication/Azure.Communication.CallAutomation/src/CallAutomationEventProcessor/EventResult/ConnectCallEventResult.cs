// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="ConnectCallEventResult"/> is returned from WaitForEvent of <see cref="ConnectCallResult"/>.</summary>
    public class ConnectCallEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CallConnected"/> event will be returned once the connect succeeded.
        /// </summary>
        public CallConnected SuccessResult { get; }

        /// <summary>
        /// <see cref="ConnectFailed"/> event will be returned once the connect failed.
        /// </summary>
        public ConnectFailed FailureResult { get; }

        internal ConnectCallEventResult(bool isSuccess, ConnectFailed failureResult, CallConnected successResult)
        {
            IsSuccess = isSuccess;
            FailureResult = failureResult;
            SuccessResult = successResult;
        }
    }
}
