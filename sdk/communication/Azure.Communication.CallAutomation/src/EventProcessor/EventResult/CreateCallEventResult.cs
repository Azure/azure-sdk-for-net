// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> CreateCallEventResult is returned from WaitForEvent of CreateCallResult. </summary>
    /// </summary>
    public class CreateCallEventResult : EventResultBase
    {
        /// <summary>
        /// CallConnected event will be returned once the call is established with CreateCall.
        /// </summary>
        public CallConnected SuccessEvent { get; }

        internal CreateCallEventResult(bool isSuccessEvent, CallConnected successEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
        }
    }
}
