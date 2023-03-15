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
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="CallConnected"/> event will be returned once the call is established with AnswerCall.
        /// </summary>
        public CallConnected SuccessEvent { get; }

        internal AnswerCallEventResult(bool isSuccessEvent, CallConnected successEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
        }
    }
}
