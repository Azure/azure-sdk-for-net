// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="PlayEventResult"/> is returned from WaitForEvent of <see cref="PlayResult"/>.</summary>
    public class PlayEventResult : EventResultBase
    {
        /// <summary>
        /// <see cref="PlayCompleted"/> event will be returned once the play is completed successfully.
        /// </summary>
        public PlayCompleted SuccessEvent { get; }

        /// <summary>
        /// <see cref="PlayFailed"/> event will be returned once the play failed.
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
