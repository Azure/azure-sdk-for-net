// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Remove Participants Request.
    /// </summary>
    public class RemoveParticipantsOptions
    {
        /// <summary>
        /// Creates a new RemoveParticipantsOptions object.
        /// </summary>
        public RemoveParticipantsOptions(IEnumerable<CommunicationIdentifier> participantsToRemove)
        {
            ParticipantsToRemove = (IReadOnlyList<CommunicationIdentifier>)participantsToRemove;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The list of identity of participants to be removed from the call.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> ParticipantsToRemove { get; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }
    }
}
