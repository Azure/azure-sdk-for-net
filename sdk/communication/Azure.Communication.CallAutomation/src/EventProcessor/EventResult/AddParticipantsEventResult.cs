// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="AddParticipantsEventResult"/> is returned from WaitForEvent of <see cref="AddParticipantResult"/>.</summary>
    public class AddParticipantsEventResult : EventResultBase
    {
        /// <summary>
        /// <see cref="AddParticipantSucceeded"/> event will be returned when the participant joined the call successfully.
        /// </summary>
        public AddParticipantSucceeded SuccessEvent { get; }

        /// <summary>
        /// <see cref="AddParticipantFailed"/> event will be returned when the participant did not join the call.
        /// </summary>
        public AddParticipantFailed FailureEvent { get; }

        internal AddParticipantsEventResult(bool isSuccessEvent, AddParticipantSucceeded successEvent, AddParticipantFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
