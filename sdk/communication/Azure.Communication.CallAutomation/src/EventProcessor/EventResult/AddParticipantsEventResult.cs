// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="AddParticipantsEventResult"/> is returned from WaitForEvent of <see cref="AddParticipantsResult"/>.</summary>
    public class AddParticipantsEventResult : EventResultBase
    {
        /// <summary>
        /// <see cref="AddParticipantsSucceeded"/> event will be returned when the participant joined the call successfully.
        /// </summary>
        public AddParticipantsSucceeded SuccessEvent { get; }

        /// <summary>
        /// <see cref="AddParticipantsFailed"/> event will be returned when the participant did not join the call.
        /// </summary>
        public AddParticipantsFailed FailureEvent { get; }

        internal AddParticipantsEventResult(bool isSuccessEvent, AddParticipantsSucceeded successEvent, AddParticipantsFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
