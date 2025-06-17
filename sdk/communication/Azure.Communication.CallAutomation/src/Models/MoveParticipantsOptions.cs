// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The move participants operation options.
    /// </summary>
    public class MoveParticipantsOptions
    {
        /// <summary>
        /// Creates a new MoveParticipantsOptions object.
        /// </summary>
        /// <param name="targetParticipants">Participants to move.</param>
        /// <param name="fromCall">The call connection ID from which to move the participants.</param>
        public MoveParticipantsOptions(IEnumerable<CommunicationIdentifier> targetParticipants, string fromCall)
        {
            TargetParticipants = targetParticipants ?? throw new ArgumentNullException(nameof(targetParticipants));
            FromCall = fromCall ?? throw new ArgumentNullException(nameof(fromCall));
        }

        /// <summary>
        /// Participants to move from one call to another.
        /// </summary>
        public IEnumerable<CommunicationIdentifier> TargetParticipants { get; }

        /// <summary>
        /// The call connection ID from which to move the participants.
        /// </summary>
        public string FromCall { get; }

        /// <summary>
        /// The operationContext for this move participants call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
