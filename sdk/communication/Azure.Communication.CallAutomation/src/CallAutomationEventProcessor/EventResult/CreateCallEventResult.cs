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
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="CallConnected"/> event will be returned once the call is established with CreateCall.
        /// </summary>
        public CallConnected SuccessEvent { get; }

        internal CreateCallEventResult(bool isSuccessEvent, CallConnected successEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
        }
    }
}
