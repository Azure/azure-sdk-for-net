// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The options for transfering a call. </summary>
    public class TransferCallToParticipantOptions
    {
        /// <summary> The caller id of the source. </summary>
        public PhoneNumberIdentifier SourceCallerId { get; set; }

        /// <summary> The UserToUserInformation. </summary>
        public string UserToUserInformation { get; set; }

        /// <summary> The operationContext for this transfer call. </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Transfer Call Options.
        /// </summary>
        public TransferCallToParticipantOptions()
        {
        }
    }
}
