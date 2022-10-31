// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants operation options.
    /// </summary>
    public class AddParticipantsOptions
    {
        /// <summary>
        /// Creates a new AddParticipantsOptions object.
        /// </summary>
        /// <param name="participantsToAdd"></param>
        public AddParticipantsOptions(IEnumerable<CommunicationIdentifier> participantsToAdd)
        {
            ParticipantsToAdd = participantsToAdd;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The list of identity of participants to be added to the call.
        /// </summary>
        public IEnumerable<CommunicationIdentifier> ParticipantsToAdd { get; }

        /// <summary>
        /// The caller id of the source.
        /// </summary>
        public PhoneNumberIdentifier SourceCallerId { get; set; }

        /// <summary>
        /// The operationContext for this add participants call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Timeout before invitation times out.
        /// The minimum value is 1 second.
        /// The maximum value is 180 seconds.
        /// </summary>
        public int? InvitationTimeoutInSeconds { get; set; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }
    }
}
