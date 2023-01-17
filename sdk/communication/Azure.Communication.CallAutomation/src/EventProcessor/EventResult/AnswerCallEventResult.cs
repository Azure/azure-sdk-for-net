// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> AnswerCallEventResult is returned from WaitForEvent of AnswerCallResult. </summary>
    /// </summary>
    public class AnswerCallEventResult : EventResultBase
    {
        /// <summary>
        /// CallConnected event will be returned once the call is established with AnswerCall.
        /// </summary>
        public CallConnected SuccessEvent { get; }

        internal AnswerCallEventResult(bool isSuccessEvent, CallConnected successEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
        }
    }
}
