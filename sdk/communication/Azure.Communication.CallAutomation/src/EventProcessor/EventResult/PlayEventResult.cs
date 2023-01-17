// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> PlayEventResult is returned from WaitForEvent of PlayResult. </summary>
    /// </summary>
    public class PlayEventResult : EventResultBase
    {
        /// <summary>
        /// PlayCompleted event will be returned once the play is completed successfully.
        /// </summary>
        public PlayCompleted SuccessEvent { get; }

        /// <summary>
        /// PlayFailed event will be returned once the play failed.
        /// </summary>
        public PlayFailed FailureEvent { get; }

        internal PlayEventResult(bool isSuccessEvent, PlayCompleted successEvent, PlayFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
