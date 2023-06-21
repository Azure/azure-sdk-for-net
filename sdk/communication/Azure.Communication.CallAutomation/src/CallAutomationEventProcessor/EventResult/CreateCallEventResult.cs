// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="CreateCallEventResult"/> is returned from WaitForEvent of <see cref="CreateCallResult"/>.</summary>
    public class CreateCallEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CallConnected"/> event will be returned once the call is established with CreateCall.
        /// </summary>
        public CallConnected SuccessResult { get; }

        internal CreateCallEventResult(bool isSuccess, CallConnected successResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
        }
    }
}
