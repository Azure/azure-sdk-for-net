// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The options for adding participant to a call. </summary>
    public class AddParticipantOptions
    {
        /// <summary> The alternate caller id of the source. </summary>
        public PhoneNumberIdentifier AlternateCallerId { get; set; }

        /// <summary> The Operation Context. </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Transfer Call Options.
        /// </summary>
        /// <param name="alternateCallerId">The alternate caller id of the source</param>
        /// <param name="operationContext">The operationContext.</param>
        public AddParticipantOptions(PhoneNumberIdentifier alternateCallerId, string operationContext)
        {
            AlternateCallerId = alternateCallerId;
            OperationContext = operationContext;
        }
    }
}
