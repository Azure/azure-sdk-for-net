// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The options for adding participant to a call. </summary>
    public class AddParticipantsOptions
    {
        /// <summary> The alternate caller id of the source. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }

        /// <summary> The Operation Context. </summary>
        public string OperationContext { get; set; }

        /// <summary> Timeout before invitation timesout. </summary>
        public int InvitationTimeoutInSeconds { get; set; }

        /// <summary> The replacement CallConnectionId. </summary>
        public string ReplacementCallConnectionId { get; set; }

        /// <summary>
        /// Add Participants Options.
        /// </summary>
        /// <param name="alternateCallerId">The alternate caller id of the source</param>
        /// <param name="operationContext">The operationContext.</param>
        /// <param name="invitationTimeoutInSeconds"> Timeout before invitation timesout.</param>
        /// <param name="replacementCallConnectionId">replacementCallConnectionId.</param>
        public AddParticipantsOptions(PhoneNumberIdentifier alternateCallerId, string operationContext, int invitationTimeoutInSeconds, string replacementCallConnectionId)
        {
            AlternateCallerId = alternateCallerId;
            OperationContext = operationContext;
            this.InvitationTimeoutInSeconds = invitationTimeoutInSeconds;
            this.ReplacementCallConnectionId = replacementCallConnectionId;
        }
    }
}
