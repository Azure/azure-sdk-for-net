// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Remove Participants Request.
    /// </summary>
    public class RemoveParticipantOptions
    {
        /// <summary>
        /// Creates a new RemoveParticipantsOptions object.
        /// </summary>
        public RemoveParticipantOptions(CommunicationIdentifier participantToRemove)
        {
            ParticipantToRemove = participantToRemove;
        }

        /// <summary>
        /// The list of identity of the participant to be removed from the call.
        /// </summary>
        public CommunicationIdentifier ParticipantToRemove { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI override for this transfer call request.
        /// </summary>
        public Uri CallbackUri { get; set; }
    }
}
