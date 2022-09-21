// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants operation options.
    /// </summary>
    public class AddParticipantsOptions: RepeatabilityHeaders
    {
        /// <summary>
        /// Creates a new AddParticipantsOptions object.
        /// </summary>
        /// <param name="participantsToAdd"></param>
        /// <param name="repeatabilityRequestId"></param>
        /// <param name="repeatablityFirstSent"></param>
        public AddParticipantsOptions(IEnumerable<CommunicationIdentifier> participantsToAdd, Guid? repeatabilityRequestId = null, string repeatablityFirstSent = default)
        {
            ParticipantsToAdd = participantsToAdd;
            RepeatabilityRequestId = repeatabilityRequestId;
            RepeatabilityFirstSent = repeatablityFirstSent;
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
        /// </summary>
        public int? InvitationTimeoutInSeconds { get; set; }
    }
}
