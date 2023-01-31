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
        /// (Optional) The display name of the source that is associated with this invite operation when
        /// adding a PSTN participant or teams user.  Note: Will not update the display name in the roster.
        /// </summary>
        public string SourceDisplayName { get; set; }

        /// <summary>
        /// (Optional) The identifier of the source of the call for this invite operation. If SourceDisplayName
        /// is not set, the display name of the source will be used by default when adding a PSTN participant or teams user.
        /// </summary>
        public CommunicationIdentifier SourceIdentifier { get; set; }

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
