// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="AnswerCallEventResult"/> is returned from WaitForEvent of <see cref="AnswerCallResult"/>.</summary>
    public class AnswerCallEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="CallConnected"/> event will be returned once the call is established with AnswerCall.
        /// </summary>
        public CallConnected SuccessResult { get; }

        /// <summary>
        /// <see cref="AnswerFailed"/> evnet will be returned when the call was not answered.
        /// </summary>
        /// <value></value>
        public AnswerFailed FailureResult { get; }

        internal AnswerCallEventResult(bool isSuccess, CallConnected successResult, AnswerFailed failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
