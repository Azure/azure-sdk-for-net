// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer.Models
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
        public AddParticipantsOptions(PhoneNumberIdentifier alternateCallerId = default, string operationContext = default, int invitationTimeoutInSeconds = default, string replacementCallConnectionId = default)
        {
            AlternateCallerId = alternateCallerId;
            OperationContext = operationContext;
            InvitationTimeoutInSeconds = invitationTimeoutInSeconds;
            ReplacementCallConnectionId = replacementCallConnectionId;
        }
    }
}
