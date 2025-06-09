// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="MoveParticipantEventResult"/> is returned from WaitForEvent of <see cref="MoveParticipantsResult"/>.</summary>
    public class MoveParticipantEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="MoveParticipantSucceeded"/> event will be returned when all participants were moved to the call successfully.
        /// </summary>
        public MoveParticipantSucceeded SuccessResult { get; }

        /// <summary>
        /// <see cref="MoveParticipantFailed"/> event will be returned when participants could not be moved to the call.
        /// </summary>
        public MoveParticipantFailed FailureResult { get; }

        /// <summary>
        /// <see cref="IReadOnlyList{CommunicationIdentifier}"/> Participants that were affected by the move operation.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// The call connection ID from which the participant was moved.
        /// </summary>
        public string FromCall { get; }

        internal MoveParticipantEventResult(bool isSuccess, MoveParticipantSucceeded successResult, MoveParticipantFailed failureResult, CommunicationIdentifier targetParticipant, string fromCall)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
            TargetParticipant = targetParticipant;
            FromCall = fromCall;
        }
    }
}
