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
        public AddParticipantsOptions(IEnumerable<CallTarget> participantsToAdd)
        {
            ParticipantsToAdd = participantsToAdd;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The list of identity of participants to be added to the call.
        /// </summary>
        public IEnumerable<CallTarget> ParticipantsToAdd { get; }

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

        /// <summary> Used by customer to pass in context to targets. </summary>
        public CustomContext CustomContext { get; set; }
    }
}
