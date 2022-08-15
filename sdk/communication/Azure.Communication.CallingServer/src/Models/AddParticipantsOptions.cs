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
        /// <summary> The caller id of the source. </summary>
        public PhoneNumberIdentifier SourceCallerId { get; set; }

        /// <summary> The Operation Context. </summary>
        public string OperationContext { get; set; }

        /// <summary> Timeout before invitation timesout. </summary>
        public int? InvitationTimeoutInSeconds { get; set; }

        /// <summary>
        /// Add Participants Options.
        /// </summary>
        public AddParticipantsOptions()
        {
        }
    }
}
